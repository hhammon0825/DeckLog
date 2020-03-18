Public Class DeckLogUpdate
    Public FName As String = "./DeckLog/"
    Public ReadError As Boolean = False
    Public FileLoading As Boolean = False
    Public InitialLoad As Boolean = False
    Public FileRead As Boolean = False
    Public SLOpenFName As String = ""
    Public tablename As String = "Table1"
    'Public DataSet1 As DataSet
    Public HdrStr As String() = {"Vessel", "Navigator", "LocFrom", "LocTo", "DateZoneTime", "Compass", "Var", "Dev", "CTrue", "Speed", "PositionLatLong", "Loc Type", "Weather", "Remarks"}
    Public NullStr As String() = {vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString,
        vbNullString, vbNullString, vbNullString, vbNullString}
    Public UpdtRow As Integer = 0
    Public Structure DLUpdate
        Public Vessel As String
        Public Navigator As String
        Public LocFrom As String
        Public LocTo As String
        Public DateZoneTime As String
        Public Compass As String
        Public CompassI As Integer
        Public Var As String
        Public VarEW As String
        Public VarI As Decimal
        Public Dev As String
        Public DevEW As String
        Public DevI As Decimal
        Public CTrue As String
        Public CTrueI As Integer
        Public Speed As String
        Public SpeedI As Decimal
        Public PositionLatLong As String
        Public LDegI As Integer
        Public LMinI As Decimal
        Public LNS As String
        Public LatDecimal As Decimal
        Public LoDegI As Integer
        Public LoMinI As Decimal
        Public LoEW As String
        Public LongDecimal As Decimal
        Public LocType As String
        Public Weather As String
        Public Remarks As String
        Public Distance As Decimal
        Public Elapsed As TimeSpan
        Public CMG As Integer
        Public SMG As Decimal
        Public SetDir As Integer
        Public Drift As Decimal
        Public DBRowNum As Integer
    End Structure
    Public UpdtRtn As DLUpdate
    Public CurrRow As DLUpdate
    Public PrevRow As DLUpdate

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DefFName As String = "DeckLog" & Now.ToString("yyyyMMddHHmmss") & ".csv"
        InitialLoad = True
        FName &= DefFName
        ResetScreenFields()
        btnDeleteSight.Visible = False
        btnUpdateExisting.Visible = False

        'DataSet1 = New DataSet()
        'DataSet1.Tables.Add(tablename)
        'DataSet1.DataSetName = tablename
        'DataGridView1.DataSource = DataSet1
        'For i As Integer = 0 To UBound(HdrStr)
        '    DataSet1.Tables(tablename).Columns.Add(HdrStr(i))
        'Next
        DataSet2.Tables(tablename).Rows.Add(NullStr)
        'DataGridView1.DataSource = DataSet1.Tables(0).DefaultView
        'DataGridView1.Refresh()
        Me.Show()
        Me.Refresh()
        InitialLoad = False
        Exit Sub
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveDataGrid()
        Me.Close()
    End Sub
    Private Sub SaveDataGrid()

        Dim saveFileDialog1 As New SaveFileDialog()

        'Dim dirstr As String = FileIO.FileSystem.CurrentDirectory
        saveFileDialog1.InitialDirectory = "./DeckLog/"
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv"
        saveFileDialog1.Title = "Open Deck Log File"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If saveFileDialog1.FileName = vbNullString Then
                Exit Sub
            End If
            FName = saveFileDialog1.FileName
        End If

        Dim textstr As New System.Text.StringBuilder()
        Dim FileHdrStr As String = vbNullString
        For i As Integer = 0 To UBound(HdrStr)
            If i > 0 Then
                textstr.Append(",")
            End If
            textstr.Append(HdrStr(i))
        Next
        textstr.AppendLine()
        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If IsNothing(DataGridView1.Rows(x).Cells(0).Value) = False Then
                For v As Integer = 0 To DataGridView1.Columns.Count - 1
                    'extracting cell value from 0 to 9 and add it on list
                    If v > 0 Then
                        textstr.Append(",")
                    End If
                    Dim tempstr As String = DataGridView1.Rows(x).Cells(v).Value.ToString()
                    tempstr = tempstr.Replace(",", "") ' remove any commas input into any field so csv file is not corrupted
                    textstr.Append(tempstr)
                Next
            End If
            'adding new line to text
            textstr.AppendLine()
        Next
        IO.File.WriteAllText(FName, textstr.ToString())
        SLOpenFName = FName
        lblOpenFN.Visible = True
        txtOpenFN.Visible = True
        txtOpenFN.Text = SLOpenFName
        Exit Sub
    End Sub

    Private Sub btnExitNoSave_Click(sender As Object, e As EventArgs) Handles btnExitNoSave.Click
        Me.Close()
        Exit Sub
    End Sub

    Private Sub btnOpenCSV_Click(sender As Object, e As EventArgs) Handles btnOpenCSV.Click
        Dim myStream As System.IO.StreamReader = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        FileLoading = True
        DataSet2.Tables(tablename).Clear()

        'Dim dirstr As String = FileIO.FileSystem.CurrentDirectory
        openFileDialog1.InitialDirectory = "./DeckLog/"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv"
        openFileDialog1.Title = "Open Deck Log File"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If openFileDialog1.FileName = vbNullString Then
                Exit Sub
            End If
            ReadError = False

            Dim ReadNum As Integer = 0
            Try
                myStream = New System.IO.StreamReader(openFileDialog1.FileName)
                If (myStream IsNot Nothing) Then
                    FName = openFileDialog1.FileName
                    SLOpenFName = openFileDialog1.FileName
                    lblOpenFN.Visible = True
                    txtOpenFN.Visible = True
                    txtOpenFN.Text = SLOpenFName
                    Dim allData As String = myStream.ReadToEnd()
                    Dim rows As String() = allData.Split(vbCrLf) '("\r".ToCharArray())
                    Dim incr1 As Integer = 0
                    For Each r As String In rows
                        r = r.Trim(vbLf).Trim
                        If ReadNum = 0 Then
                            r = r.Trim(vbLf).Trim
                            Dim items As String() = r.Split(",")
                            'For ctr As Integer = 0 To UBound(items)
                            'Set1.Tables(tablename).Columns.Add(items(ctr))
                            'Next
                        Else
                            r = r.Trim(vbLf).Trim
                            Dim items1 As String() = r.Split(",")
                            If items1(0) <> vbNullString And items1(0) <> Nothing Then
                                DataSet2.Tables(tablename).Rows.Add(items1)
                            End If

                        End If
                        ReadNum += 1
                        incr1 += 1
                    Next
                    myStream.Close()
                    btnSaveFile.Visible = True
                    btnExit.Visible = True
                End If

                myStream.Dispose()
                DataGridView1.DataSource = DataSet2.Tables(0).DefaultView
                SortDataGridonDate()
                DataGridView1.Refresh()
                FileLoading = False
                Me.Refresh()

            Catch Ex As Exception
                ErrorMsgBox("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        Else
            btnSaveFile.Visible = False
            btnExit.Visible = False

        End If

    End Sub
    Private Sub ErrorMsgBox(ByVal ErrMsg As String)
        System.Windows.Forms.MessageBox.Show(ErrMsg, "Error",
                                                System.Windows.Forms.MessageBoxButtons.OK,
                                                System.Windows.Forms.MessageBoxIcon.Error,
                                                System.Windows.Forms.MessageBoxDefaultButton.Button1,
                                                System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly)
        Exit Sub
    End Sub

    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        SaveDataGrid()
        Exit Sub
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnInfoForm_Click(sender As Object, e As EventArgs) Handles btnInfoForm.Click
        DeckLogHelp.Show()
        Exit Sub
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If FileLoading = True Then
            Exit Sub
        End If
        If InitialLoad = True Then
            Exit Sub
        End If

        Dim n As Integer = DataGridView1.CurrentRow.Index
        'If DataGridView1.Rows(n).Cells(0).Value = Nothing Then Exit Sub
        UpdtRow = DataGridView1.CurrentRow.Index
        btnDeleteSight.Visible = True
        btnUpdateExisting.Visible = True
        ' The order of these variable and the integer indexs contained in each MUST match the order of the fields in the data grid
        ' Cell 0 = Vessel name  Cell 1 = Navigator name  Cell 2 = From location name   Cell 3 = To location name 
        ' Cell 4 = Zone Date & time String MM/dd/yyyy HH:mm:ss Cell 5 = Compass course string  Cell 6 = Variation string Cell 7 = Deviation string
        ' Cell 8 = computed True Course string  Cell 9 = Speed string  Cell 10 = Latitude string Cell 11 = Longitude string   Cell 12 = L/Lo loc type 
        ' Cell 13 = Weather string   Cell 14 = Remarks string

        If DataGridView1.Rows(n).Cells(0).Value <> vbNullString Then
            UpdtRtn.Vessel = DataGridView1.Rows(n).Cells(0).Value
            txtVessel.Text = DataGridView1.Rows(n).Cells(0).Value
        Else
            UpdtRtn.Vessel = vbNullString
            txtVessel.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(1).Value <> vbNullString Then
            UpdtRtn.Navigator = DataGridView1.Rows(n).Cells(1).Value
            txtNavigator.Text = DataGridView1.Rows(n).Cells(1).Value
        Else
            UpdtRtn.Navigator = vbNullString
            txtNavigator.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(2).Value <> vbNullString Then
            UpdtRtn.LocFrom = DataGridView1.Rows(n).Cells(2).Value
            txtFrom.Text = DataGridView1.Rows(n).Cells(2).Value
        End If

        If DataGridView1.Rows(n).Cells(3).Value <> vbNullString Then
            UpdtRtn.LocTo = DataGridView1.Rows(n).Cells(3).Value
            txtTo.Text = DataGridView1.Rows(n).Cells(3).Value
        Else
            UpdtRtn.LocTo = vbNullString
            txtTo.Text = vbNull
        End If

        If DataGridView1.Rows(n).Cells(4).Value <> vbNullString Then
            UpdtRtn.DateZoneTime = DataGridView1.Rows(n).Cells(4).Value
            DTDateZoneTime.Value = Convert.ToDateTime(DataGridView1.Rows(n).Cells(4).Value)
        Else
            UpdtRtn.DateZoneTime = Now.ToString("MM/dd/yyyy HH:mm:ss")
            DTDateZoneTime.Value = Now
        End If

        If DataGridView1.Rows(n).Cells(5).Value <> vbNullString Then
            UpdtRtn.Compass = DataGridView1.Rows(n).Cells(5).Value
            txtCompass.Text = DataGridView1.Rows(n).Cells(5).Value
        Else
            UpdtRtn.Compass = vbNullString
            txtCompass.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(6).Value <> vbNullString Then
            UpdtRtn.Var = DataGridView1.Rows(n).Cells(6).Value
            UpdtRtn.VarEW = UpdtRtn.Var.Last
            UpdtRtn.Var = UpdtRtn.Var.Substring(0, UpdtRtn.Var.Length - 1)
            txtVar.Text = UpdtRtn.Var
            cboVar.Text = UpdtRtn.VarEW
        Else
            UpdtRtn.Var = vbNullString
            txtVar.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(7).Value <> vbNullString Then
            UpdtRtn.Dev = DataGridView1.Rows(n).Cells(7).Value
            UpdtRtn.DevEW = UpdtRtn.Dev.Last
            UpdtRtn.Dev = UpdtRtn.Dev.Substring(0, UpdtRtn.Dev.Length - 1)
            txtDev.Text = UpdtRtn.Dev
            cboDev.Text = UpdtRtn.DevEW
        Else
            UpdtRtn.Dev = vbNullString
            txtDev.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(8).Value <> vbNullString Then
            UpdtRtn.CTrue = DataGridView1.Rows(n).Cells(8).Value
            txtCTrue.Text = DataGridView1.Rows(n).Cells(8).Value
        Else
            UpdtRtn.CTrue = vbNullString
            txtCTrue.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(9).Value <> vbNullString Then
            UpdtRtn.Speed = DataGridView1.Rows(n).Cells(9).Value
            txtSpeed.Text = DataGridView1.Rows(n).Cells(9).Value
        Else
            UpdtRtn.Speed = vbNullString
            txtSpeed.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(10).Value <> vbNullString Then
            UpdtRtn.PositionLatLong = DataGridView1.Rows(n).Cells(10).Value
            Dim LLo As String = DataGridView1.Rows(n).Cells(10).Value
            Dim LPos As Integer = LLo.IndexOf("=")
            Dim LDegPos As Integer = LLo.IndexOf(Chr(176))
            Dim LMinPos As Integer = LLo.IndexOf("'")
            Dim LoPos As Integer = LLo.IndexOf("=", LPos + 1)
            Dim LoDegPos As Integer = LLo.IndexOf(Chr(176), LDegPos + 1)
            Dim LoMinPos As Integer = LLo.IndexOf("'", LMinPos + 1)
            txtLDeg.Text = LLo.Substring(LPos + 1, (LDegPos - 1) - (LPos + 1) + 1)
            txtLMin.Text = LLo.Substring(LDegPos + 1, (LMinPos - 1) - (LDegPos + 1) + 1)
            cboL.Text = LLo.Substring(LMinPos + 1, 1)
            txtLoDeg.Text = LLo.Substring(LoPos + 1, (LoDegPos - 1) - (LoPos + 1) + 1)
            txtLoMin.Text = LLo.Substring(LoDegPos + 1, (LoMinPos - 1) - (LoDegPos + 1) + 1)
            cboLo.Text = LLo.Substring(LoMinPos + 1, 1)
        Else
            UpdtRtn.PositionLatLong = vbNullString
            txtLDeg.Clear()
            txtLMin.Clear()
            cboL.SelectedIndex = 0
            txtLoDeg.Clear()
            txtLoMin.Clear()
            cboLo.SelectedIndex = 0
        End If

        If DataGridView1.Rows(n).Cells(11).Value <> vbNullString Then
            UpdtRtn.LocType = DataGridView1.Rows(n).Cells(11).Value
            cboLocType.Text = DataGridView1.Rows(n).Cells(11).Value
        Else
            UpdtRtn.LocType = vbNullString
            cboLocType.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(12).Value <> vbNullString Then
            UpdtRtn.Weather = DataGridView1.Rows(n).Cells(12).Value
            txtWeather.Text = DataGridView1.Rows(n).Cells(12).Value
        Else
            UpdtRtn.Weather = vbNullString
            txtWeather.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(13).Value <> vbNullString Then
            UpdtRtn.Remarks = DataGridView1.Rows(n).Cells(13).Value
            txtRemarks.Text = DataGridView1.Rows(n).Cells(13).Value
        Else
            UpdtRtn.Remarks = vbNullString
            txtRemarks.Text = vbNullString
        End If

        Me.Refresh()

        Exit Sub
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        Dim LLo As String = "L=" & txtLDeg.Text.ToString & Chr(176) & txtLMin.Text.ToString & "'" & cboL.Text.ToString &
            " Lo=" & txtLoDeg.Text.ToString & Chr(176) & txtLoMin.Text.ToString & "'" & cboLo.Text.ToString

        DataSet2.Tables(tablename).Rows.Add(txtVessel.Text.ToString, txtNavigator.Text.ToString, txtFrom.Text.ToString, txtTo.Text.ToString,
                               DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), txtCompass.Text.ToString, txtVar.Text.ToString & cboVar.Text, txtDev.Text.ToString & cboDev.Text,
                               txtCTrue.Text.ToString, txtSpeed.Text.ToString, LLo, cboLocType.Text.ToString, txtWeather.Text.ToString, txtRemarks.Text.ToString)
        SortDataGridonDate()
        DataGridView1.Refresh()
        Me.Refresh()

        Exit Sub
    End Sub

    Private Sub btnUpdateExisting_Click(sender As Object, e As EventArgs) Handles btnUpdateExisting.Click
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        Dim LLo As String = ""
        LLo = "L=" & UpdtRtn.LDegI.ToString("00") & Chr(176) & UpdtRtn.LMinI.ToString("00.0") &
            "'" & cboL.Text.ToString & " Lo=" & UpdtRtn.LoDegI.ToString("00") & Chr(176) & UpdtRtn.LoMinI.ToString("00.0") & "'" & cboLo.Text.ToString
        DataGridView1.Rows(UpdtRow).Cells(0).Value = txtVessel.Text
        DataGridView1.Rows(UpdtRow).Cells(1).Value = txtNavigator.Text
        DataGridView1.Rows(UpdtRow).Cells(2).Value = txtFrom.Text
        DataGridView1.Rows(UpdtRow).Cells(3).Value = txtTo.Text
        DataGridView1.Rows(UpdtRow).Cells(4).Value = DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss")
        DataGridView1.Rows(UpdtRow).Cells(5).Value = txtCompass.Text
        DataGridView1.Rows(UpdtRow).Cells(6).Value = txtVar.Text & cboVar.Text
        DataGridView1.Rows(UpdtRow).Cells(7).Value = txtDev.Text & cboDev.Text
        DataGridView1.Rows(UpdtRow).Cells(8).Value = txtCTrue.Text
        DataGridView1.Rows(UpdtRow).Cells(9).Value = txtSpeed.Text
        DataGridView1.Rows(UpdtRow).Cells(10).Value = LLo
        DataGridView1.Rows(UpdtRow).Cells(11).Value = cboLocType.Text
        DataGridView1.Rows(UpdtRow).Cells(12).Value = txtWeather.Text
        DataGridView1.Rows(UpdtRow).Cells(13).Value = txtRemarks.Text
        SortDataGridonDate()
        DataGridView1.Refresh()
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub btnDeleteSight_Click(sender As Object, e As EventArgs) Handles btnDeleteSight.Click
        DataSet2.Tables(tablename).Rows.RemoveAt(UpdtRow)
        SortDataGridonDate()
        DataGridView1.Refresh()
        Me.Refresh()
        Exit Sub
    End Sub
    Private Function EditUpdtFields() As Boolean
        If txtVessel.Text = vbNullString Or txtVessel.Text = "" Then
            ErrorMsgBox("Vessel Name must be entered")
            Return False
        End If
        If txtNavigator.Text = vbNullString Or txtNavigator.Text = "" Then
            ErrorMsgBox("Navigator Name must be entered")
            Return False
        End If
        If txtFrom.Text = vbNullString Or txtFrom.Text = "" Then
            ErrorMsgBox("From Location must be entered")
            Return False
        End If
        If txtTo.Text = vbNullString Or txtTo.Text = "" Then
            ErrorMsgBox("Destination Location must be entered")
            Return False
        End If

        If txtCompass.Text = vbNullString Or txtCompass.Text = "" Then
            ErrorMsgBox("Compass Course must be entered")
            Return False
        End If
        If IsNumeric(txtCompass.Text) = False Then
            ErrorMsgBox("Compass Course must be numeric between 0 and 360")
            Return False
        End If
        Try
            UpdtRtn.CompassI = Convert.ToInt32(txtCompass.Text)
            If UpdtRtn.CompassI < 0 Or UpdtRtn.CompassI > 359 Then
                ErrorMsgBox("Compass Course must be numeric between 0 and 360")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Compass Course must be numeric between 0 and 360")
            Return False
        End Try

        If txtVar.Text = vbNullString Or txtVar.Text = "" Then
            ErrorMsgBox("Variation must be entered")
            Return False
        End If
        If IsNumeric(txtVar.Text) = False Then
            ErrorMsgBox("Variation must be numeric between 0 and 20")
            Return False
        End If
        Try
            UpdtRtn.VarI = Convert.ToDecimal(txtVar.Text)
            If UpdtRtn.VarI < 0 Or UpdtRtn.VarI > 20 Then
                ErrorMsgBox("Var Course must be numeric between 0 and 20")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Var Course must be numeric between 0 and 20")
            Return False
        End Try

        If txtDev.Text = vbNullString Or txtDev.Text = "" Then
            ErrorMsgBox("Deviation must be entered")
            Return False
        End If
        If IsNumeric(txtDev.Text) = False Then
            ErrorMsgBox("Deviation must be numeric between 0 and 20")
            Return False
        End If
        Try
            UpdtRtn.DevI = Convert.ToDecimal(txtDev.Text)
            If UpdtRtn.DevI < 0 Or UpdtRtn.DevI > 20 Then
                ErrorMsgBox("Dev Course must be numeric between 0 and 20")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Dev Course must be numeric between 0 and 20")
            Return False
        End Try

        If cboVar.Text = "W" Then
            UpdtRtn.VarI = -UpdtRtn.VarI
        End If
        If cboDev.Text = "W" Then
            UpdtRtn.DevI = -UpdtRtn.DevI
        End If
        UpdtRtn.CTrueI = UpdtRtn.CompassI + UpdtRtn.VarI + UpdtRtn.DevI
        txtCTrue.Text = UpdtRtn.CTrueI.ToString("000")

        If txtSpeed.Text = vbNullString Or txtSpeed.Text = "" Then
            ErrorMsgBox("Speed must be entered")
            Return False
        End If
        If IsNumeric(txtSpeed.Text) = False Then
            ErrorMsgBox("Speed must be numeric between 0 and 99")
            Return False
        End If
        Try
            UpdtRtn.SpeedI = Convert.ToDecimal(txtSpeed.Text)
            If UpdtRtn.SpeedI < 0 Or UpdtRtn.SpeedI > 99 Then
                ErrorMsgBox("Speed must be numeric between 0 and 99")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Speed must be numeric between 0 and 99")
            Return False
        End Try

        If txtLDeg.Text = vbNullString Or txtLDeg.Text = "" Then
            ErrorMsgBox("Latitude Degrees must be entered")
            Return False
        End If
        If IsNumeric(txtLDeg.Text) = False Then
            ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89")
            Return False
        End If
        Try
            UpdtRtn.LDegI = Convert.ToInt32(txtLDeg.Text)
            If UpdtRtn.LDegI < 0 Or UpdtRtn.LDegI > 89 Then
                ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89")
            Return False
        End Try

        If txtLMin.Text = vbNullString Or txtLMin.Text = "" Then
            ErrorMsgBox("Latitude Minutes must be entered")
            Return False
        End If
        If IsNumeric(txtLMin.Text) = False Then
            ErrorMsgBox("Latitude Minutes be numeric between 0 and 59.9")
            Return False
        End If
        Try
            UpdtRtn.LMinI = Convert.ToDecimal(txtLMin.Text)
            UpdtRtn.LatDecimal = Convert.ToDecimal(UpdtRtn.LDegI) + UpdtRtn.LMinI / 60
            UpdtRtn.LNS = cboL.Text
            If UpdtRtn.LMinI < 0 Or UpdtRtn.LMinI > 59.9 Then
                ErrorMsgBox("LMin Course must be numeric between 0 and 59.9")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("LMin Course must be numeric between 0 and 59.9")
            Return False
        End Try


        If txtLoDeg.Text = vbNullString Or txtLDeg.Text = "" Then
            ErrorMsgBox("Longitude Degrees must be entered")
            Return False
        End If
        If IsNumeric(txtLoDeg.Text) = False Then
            ErrorMsgBox("Longitude Degrees must be numeric between 0 and 89")
            Return False
        End If
        Try
            UpdtRtn.LoDegI = Convert.ToInt32(txtLoDeg.Text)
            If UpdtRtn.LoDegI < 0 Or UpdtRtn.LoDegI > 180 Then
                ErrorMsgBox("Longitude Degrees must be numeric between 0 and 180")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Longitude Degrees must be numeric between 0 and 180")
            Return False
        End Try

        If txtLoMin.Text = vbNullString Or txtLoMin.Text = "" Then
            ErrorMsgBox("Longitude Minutes must be entered")
            Return False
        End If
        If IsNumeric(txtLoMin.Text) = False Then
            ErrorMsgBox("Longitude Minutes be numeric between 0 and 59.9")
            Return False
        End If
        Try
            UpdtRtn.LoMinI = Convert.ToDecimal(txtLoMin.Text)
            UpdtRtn.LongDecimal = Convert.ToDecimal(UpdtRtn.LoDegI) + UpdtRtn.LoMinI / 60
            UpdtRtn.LoEW = cboLo.Text
            If UpdtRtn.LoMinI < 0 Or UpdtRtn.LoMinI > 59.9 Then
                ErrorMsgBox("Longitude Minutes must be numeric between 0 and 59.9")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Longitude Minutes must be numeric between 0 and 59.9")
            Return False
        End Try

        Return True
        Exit Function
    End Function
    Private Sub ResetScreenFields()
        txtVessel.Clear()
        txtNavigator.Clear()
        txtFrom.Clear()
        txtTo.Clear()
        DTDateZoneTime.Value = Now
        txtCompass.Clear()
        txtVar.Clear()
        txtDev.Clear()
        txtCTrue.Clear()
        txtSpeed.Clear()
        txtLDeg.Clear()
        txtLMin.Clear()
        txtLoDeg.Clear()
        txtLoMin.Clear()
        txtWeather.Clear()
        txtRemarks.Clear()

        cboL.SelectedIndex = 0
        cboLo.SelectedIndex = 0
        cboVar.SelectedIndex = 0
        cboDev.SelectedIndex = 0
        cboLocType.SelectedIndex = 0

        Exit Sub
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ResetScreenFields()
        Exit Sub
    End Sub
    Private Sub SortDataGridonDate()
        DataGridView1.Sort(DataGridView1.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
        Exit Sub
    End Sub
    Private Function EditRelationsinDG() As Boolean

        Return True
    End Function
    Private Sub evaluateDB()
        Dim DGlimit As Integer = DataGridView1.Rows.Count
        If DGlimit = 1 Then
            ErrorMsgBox("Nothing to evaluate - the Data Grid only has one entry")
        End If

        For i As Integer = 1 To DGlimit - 1

        Next

        Exit Sub
    End Sub
    Private Function GetDistance(ByVal Lat1In As Double, ByVal Long1In As Double, ByVal Lat2In As Double, ByVal Long2In As Double) As Double
        Dim Coord1 As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(Lat1In, Long1In)
        Dim Coord2 As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(Lat2In, Long2In)
        Return Coord1.GetDistanceTo(Coord2)
    End Function
    Private Function GetHeading(ByVal lat1 As Double, ByVal long1 As Double, ByVal lat2 As Double, ByVal long2 As Double) As Double
        Dim a As Double = lat1 * Math.PI / 180
        Dim b As Double = long1 * Math.PI / 180
        Dim c As Double = lat2 * Math.PI / 180
        Dim d As Double = long2 * Math.PI / 180

        If (Math.Cos(c) * Math.Sin(d - b) = 0) Then
            If (c > a) Then
                Return 0
            Else
                Return 180
            End If
        Else
            Dim angle As Double = Math.Atan2(Math.Cos(c) * Math.Sin(d - b), Math.Sin(c) * Math.Cos(a) - Math.Sin(a) * Math.Cos(c) * Math.Cos(d - b))
            Return (angle * 180 / Math.PI + 360) Mod 360
        End If
        Return 0
    End Function
    Private Function FindDestLatLong(ByVal LatIn As Double, ByVal LonIn As Double, ByVal Dist As Double, ByVal Course As Double) As System.Device.Location.GeoCoordinate
        Dim lat1 As Double = LatIn * Math.PI / 180
        Dim Lon1 As Double = LonIn * Math.PI / 180
        Dim Theta As Double = Course * Math.PI / 180
        Dim R As Double = 3440.1  ' this is the radius of the earth in nautical miles
        Dim d As Double = Dist    ' this is the distance travelled in nautical miles
        Dim lat2 As Double = Math.Asin(Math.Sin(lat1) * Math.Cos(d / R) + Math.Cos(lat1) * Math.Sin(d / R) * Math.Cos(Theta))
        Dim lon2 As Double = Lon1 + Math.Atan2((Math.Sin(Theta) * Math.Sin(d / R) * Math.Cos(lat1)), (Math.Cos(d / R) - (Math.Sin(lat1) * Math.Sin(lat2))))
        Dim RtnGC As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(lat2 * 180 / Math.PI, lon2 * 180 / Math.PI)
        Return RtnGC
    End Function
    Private Function Calc60DSTDistance(ByVal DT1 As DateTime, ByVal DT2 As DateTime, ByVal Speed As Double) As Double
        Dim TS As TimeSpan = DT2 - DT1
        Return (Speed * TS.TotalHours)
    End Function
End Class
