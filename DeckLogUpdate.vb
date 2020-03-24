Public Class DeckLogUpdate
    Public FName As String = "./DeckLog/"
    Public ReadError As Boolean = False
    Public FileLoading As Boolean = False
    Public InitialLoad As Boolean = False
    Public FileRead As Boolean = False
    Public SortingDG As Boolean = False
    Public IsUpdated As Boolean = False
    Public SLOpenFName As String = ""
    Public tablename As String = "Table1"
    Public DataSet1 As DataSet
    Public HdrStr As String() = {"Vessel", "Navigator", "From", "To", "Log Type",
        "Log DateTime", "Course Psc", "Var", "Dev", "Course True", "Speed", "Position L/Lo", "Weather Notes", "Log Entry Notes",
        "ElapsedTime", "Distance", "Calc Dest", "Calc True", "Calc Speed", "Set", "Drift", "Eval Basis"}
    Public NullStr As String() = {vbNullString, vbNullString, vbNullString, vbNullString, vbNullString,
        vbNullString, vbNullString, vbNullString, vbNullString, vbNullString,
        vbNullString, vbNullString, vbNullString, vbNullString, vbNullString,
        vbNullString, vbNullString, vbNullString, vbNullString, vbNullString}

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
        Public LogType As String
        Public Weather As String
        Public Remarks As String
        Public Distance As Decimal
        Public Elapsed As TimeSpan
        Public CMG As Integer
        Public SMG As Decimal
        Public SetDir As Integer
        Public Drift As Decimal
        Public DBRowNum As Integer
        Public DestLatLongStr As String
        Public DestLDegI As Integer
        Public DestLMinI As Decimal
        Public DestLNS As String
        Public DestLatDecimal As Decimal
        Public DestLoDegI As Integer
        Public DestLoMinI As Decimal
        Public DestLoEW As String
        Public DestLongDecimal As Decimal
        Public DestTrueI As Integer
        Public DestDistance As Decimal
        Public DestSpeed As Decimal
        Public DestEstArrival As String
        Public DestEstElapsed As String
    End Structure
    Public UpdtRtn As DLUpdate
    Public CurrRow As DLUpdate
    Public PrevRow As DLUpdate

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DefFName As String = "DeckLog" & Now.ToString("yyyyMMddHHmmss") & ".csv"
        InitialLoad = True
        FName &= DefFName

        DataSet1 = New DataSet()
        DataSet1.Tables.Add(tablename)
        DataSet1.DataSetName = tablename
        DataGridView1.DataSource = DataSet1
        For i As Integer = 0 To UBound(HdrStr)
            DataSet1.Tables(tablename).Columns.Add(HdrStr(i))
            DataSet1.Tables(tablename).Columns(i).AllowDBNull = False
            DataSet1.Tables(tablename).Columns(i).DefaultValue = ""
        Next
        DataSet1.Tables(tablename).Rows.Add(NullStr)
        'DataSet1.Tables(tablename).Rows.RemoveAt(0)
        DataGridView1.DataSource = DataSet1.Tables(0).DefaultView
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView1.Columns(12).MinimumWidth = 250
        DataGridView1.Columns(13).MinimumWidth = 250

        txtVar.Text = 0
        txtDev.Text = 0

        SortDataGridonDate()
        DataGridView1.Refresh()

        ResetScreenFields()
        btnDeleteSight.Visible = False
        btnUpdateExisting.Visible = False

        Me.Show()
        Me.Refresh()
        InitialLoad = False
        Exit Sub
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveDataGrid()
        IsUpdated = False
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
        If IsUpdated = True Then
            Dim MsgBack As MsgBoxResult = MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data")
            If MsgBack = MsgBoxResult.Yes Then
                SaveDataGrid()
            End If
            IsUpdated = False
        End If
        Me.Close()
        Exit Sub
    End Sub

    Private Sub btnOpenCSV_Click(sender As Object, e As EventArgs) Handles btnOpenCSV.Click
        Dim myStream As System.IO.StreamReader = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        If IsUpdated = True Then
            Dim MsgBack As MsgBoxResult = MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data")
            If MsgBack = MsgBoxResult.Yes Then
                SaveDataGrid()
            End If
            IsUpdated = False
        End If
        FileLoading = True
        DataSet1.Tables(tablename).Clear()

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
                                DataSet1.Tables(tablename).Rows.Add(items1)
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
                DataGridView1.DataSource = DataSet1.Tables(0).DefaultView
                SortDataGridonDate()
                evaluateDG()
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
        IsUpdated = False
        Exit Sub
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
        If SortingDG = True Then
            Exit Sub
        End If

        Dim n As Integer
        If IsNothing(DataGridView1.CurrentRow.Index) Then 'Or DataGridView1.CurrentRow.Index = vbNull Then
            Exit Sub
        Else
            n = DataGridView1.CurrentRow.Index
        End If
        If IsNothing(DataGridView1.Rows(n).Cells(0).Value) Then
            Exit Sub
        End If
        UpdtRow = DataGridView1.CurrentRow.Index

        ' The order of these variable and the integer indexs contained in each MUST match the order of the fields in the data grid
        ' Cell 0 = Vessel name  
        ' Cell 1 = Navigator name  
        ' Cell 2 = From location name   
        ' Cell 3 = To location name 
        ' Cell 4 = L/Lo loc type 
        ' Cell 5 = Zone Date & time String MM/dd/yyyy HH:mm:ss 
        ' Cell 6 = Compass course string 
        ' Cell 7 = Variation string 
        ' Cell 8 = Deviation string
        ' Cell 9 = Computed True Course string  
        ' Cell 10 = DR Speed string  
        ' Cell 11 = Latitude / Longitude string 
        ' Cell 12 = Weather string   
        ' Cell 13 = Remarks string
        ' Cell 14 = Elapsed Time from Lat/Long to Dest Lat/Long
        ' Cell 15 = Distance in nm from Lat/Long to Dest Lat/Long
        ' Cell 16 = Calculated Destination Lat/Long
        ' Cell 17 = Calculated True Course to destination
        ' Cell 18 = Calculated Speed to make destination
        ' Cell 19 = Calculated Set between two GPS/Fix locations
        ' Cell 20 = Calculated Drift between two GPS/Fix locations
        ' Cell 21 = Eval Based On string (filled in in EvaluatedDG subroutine)

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
            txtTo.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(4).Value <> vbNullString Then
            UpdtRtn.LogType = DataGridView1.Rows(n).Cells(4).Value
            cboLocType.Text = DataGridView1.Rows(n).Cells(4).Value
        Else
            UpdtRtn.LogType = vbNullString
            cboLocType.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(5).Value <> vbNullString Then
            UpdtRtn.DateZoneTime = DataGridView1.Rows(n).Cells(5).Value
            DTDateZoneTime.Value = Convert.ToDateTime(DataGridView1.Rows(n).Cells(5).Value)
        Else
            UpdtRtn.DateZoneTime = Now.ToString("MM/dd/yyyy HH:mm:ss")
            DTDateZoneTime.Value = Now
        End If

        If DataGridView1.Rows(n).Cells(6).Value <> vbNullString Then
            Dim tlen As Integer = DataGridView1.Rows(n).Cells(6).Value.ToString.Length
            UpdtRtn.Compass = DataGridView1.Rows(n).Cells(6).Value.ToString.Substring(0, tlen - 1)
            txtCompass.Text = DataGridView1.Rows(n).Cells(6).Value.ToString.Substring(0, tlen - 1)
        Else
            UpdtRtn.Compass = vbNullString
            txtCompass.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(7).Value <> vbNullString Then
            UpdtRtn.Var = DataGridView1.Rows(n).Cells(7).Value
            UpdtRtn.VarEW = UpdtRtn.Var.Last
            UpdtRtn.Var = UpdtRtn.Var.Substring(0, UpdtRtn.Var.Length - 1)
            txtVar.Text = UpdtRtn.Var
            cboVar.Text = UpdtRtn.VarEW
        Else
            UpdtRtn.Var = 0
            txtVar.Text = 0
        End If

        If DataGridView1.Rows(n).Cells(8).Value <> vbNullString Then
            UpdtRtn.Dev = DataGridView1.Rows(n).Cells(8).Value
            UpdtRtn.DevEW = UpdtRtn.Dev.Last
            UpdtRtn.Dev = UpdtRtn.Dev.Substring(0, UpdtRtn.Dev.Length - 1)
            txtDev.Text = UpdtRtn.Dev
            cboDev.Text = UpdtRtn.DevEW
        Else
            UpdtRtn.Dev = 0
            txtDev.Text = 0
        End If

        If DataGridView1.Rows(n).Cells(9).Value <> vbNullString Then
            Dim tlen As Integer = DataGridView1.Rows(n).Cells(9).Value.ToString.Length
            UpdtRtn.CTrue = DataGridView1.Rows(n).Cells(9).Value.ToString.Substring(0, tlen - 1)
            txtCTrue.Text = DataGridView1.Rows(n).Cells(9).Value.ToString.Substring(0, tlen - 1)
        Else
            UpdtRtn.CTrue = vbNullString
            txtCTrue.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(10).Value <> vbNullString Then
            Dim tlen As Integer = DataGridView1.Rows(n).Cells(10).Value.ToString.Length
            UpdtRtn.Speed = DataGridView1.Rows(n).Cells(10).Value.ToString.Substring(0, tlen - 2)
            txtSpeed.Text = DataGridView1.Rows(n).Cells(10).Value.ToString.Substring(0, tlen - 2)
        Else
            UpdtRtn.Speed = vbNullString
            txtSpeed.Text = vbNullString
        End If

        If DataGridView1.Rows(n).Cells(11).Value <> vbNullString Then
            UpdtRtn.PositionLatLong = DataGridView1.Rows(n).Cells(11).Value
            Dim LLo As String = DataGridView1.Rows(n).Cells(11).Value
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

        If UpdtRtn.LogType = "Plan" Then
            txtDestElapsed.Text = DataGridView1.Rows(n).Cells(14).Value
            UpdtRtn.DestEstElapsed = DataGridView1.Rows(n).Cells(14).Value
            txtDestDist.Text = DataGridView1.Rows(n).Cells(15).Value
            UpdtRtn.DestDistance = Convert.ToDecimal(DataGridView1.Rows(n).Cells(15).Value.ToString.Substring(0, txtDestDist.Text.ToString.Length - 2))
            UpdtRtn.DestLatLongStr = DataGridView1.Rows(n).Cells(16).Value
            Dim DestLLo As String = DataGridView1.Rows(n).Cells(16).Value
            Dim LPos As Integer = DestLLo.IndexOf("=")
            Dim LDegPos As Integer = DestLLo.IndexOf(Chr(176))
            Dim LMinPos As Integer = DestLLo.IndexOf("'")
            Dim LoPos As Integer = DestLLo.IndexOf("=", LPos + 1)
            Dim LoDegPos As Integer = DestLLo.IndexOf(Chr(176), LDegPos + 1)
            Dim LoMinPos As Integer = DestLLo.IndexOf("'", LMinPos + 1)
            txtDestLDeg.Text = DestLLo.Substring(LPos + 1, (LDegPos - 1) - (LPos + 1) + 1)
            txtDestLMin.Text = DestLLo.Substring(LDegPos + 1, (LMinPos - 1) - (LDegPos + 1) + 1)
            cboDestL.Text = DestLLo.Substring(LMinPos + 1, 1)
            txtDestLoDeg.Text = DestLLo.Substring(LoPos + 1, (LoDegPos - 1) - (LoPos + 1) + 1)
            txtDestLoMin.Text = DestLLo.Substring(LoDegPos + 1, (LoMinPos - 1) - (LoDegPos + 1) + 1)
            cboDestLo.Text = DestLLo.Substring(LoMinPos + 1, 1)
            txtDestTrue.Text = DataGridView1.Rows(n).Cells(17).Value
            UpdtRtn.DestTrueI = Convert.ToInt32(DataGridView1.Rows(n).Cells(17).Value.ToString.Substring(0, txtDestTrue.Text.ToString.Length - 1))
            Dim Pos1 As Integer = txtRemarks.Text.IndexOf(":")
            Dim Len1 As Integer = txtRemarks.Text.Length - (Pos1 + 1)
            txtEstArrival.Text = txtRemarks.Text.Substring(Pos1 + 1, Len1)
        End If
        btnUpdateExisting.Visible = True
        btnDeleteSight.Visible = True
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnDeleteSight.Visible = True
        btnUpdateExisting.Visible = True
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        If cboLocType.Text = "Plan" Then
            If EditPlanFields() = False Then
                Me.Refresh()
                Exit Sub
            End If
        End If
        Dim LLo As String = "L=" & txtLDeg.Text.ToString & Chr(176) & txtLMin.Text.ToString & "'" & cboL.Text.ToString &
            " Lo=" & txtLoDeg.Text.ToString & Chr(176) & txtLoMin.Text.ToString & "'" & cboLo.Text.ToString

        If cboLocType.Text = "Plan" Then
            Dim DestLLo As String = "L=" & txtDestLDeg.Text.ToString & Chr(176) & txtDestLMin.Text.ToString & "'" & cboDestL.Text.ToString &
                                " Lo=" & txtDestLoDeg.Text.ToString & Chr(176) & txtDestLoMin.Text.ToString & "'" & cboDestLo.Text.ToString
            DataSet1.Tables(tablename).Rows.Add(txtVessel.Text.ToString, txtNavigator.Text.ToString, txtFrom.Text.ToString, txtTo.Text.ToString,
                               cboLocType.Text.ToString, DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), txtCompass.Text.ToString & Chr(176),
                               txtVar.Text.ToString & cboVar.Text, txtDev.Text.ToString & cboDev.Text,
                               txtCTrue.Text.ToString & Chr(176), txtSpeed.Text.ToString & "kn", LLo, txtWeather.Text.ToString, txtRemarks.Text.ToString,
                               txtDestElapsed.Text, txtDestDist.Text, DestLLo, txtDestTrue.Text, "", "", "", "Plan Entry")
        Else
            DataSet1.Tables(tablename).Rows.Add(txtVessel.Text.ToString, txtNavigator.Text.ToString, txtFrom.Text.ToString, txtTo.Text.ToString,
                               cboLocType.Text.ToString, DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), txtCompass.Text.ToString & Chr(176),
                               txtVar.Text.ToString & cboVar.Text, txtDev.Text.ToString & cboDev.Text,
                               txtCTrue.Text.ToString & Chr(176), txtSpeed.Text.ToString & "kn", LLo, txtWeather.Text.ToString, txtRemarks.Text.ToString)
        End If

        SortDataGridonDate()
        evaluateDG()
        DataGridView1.Refresh()
        Me.Refresh()
        IsUpdated = True
        Exit Sub
    End Sub

    Private Sub btnUpdateExisting_Click(sender As Object, e As EventArgs) Handles btnUpdateExisting.Click
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        If cboLocType.Text = "Plan" Then
            If EditPlanFields() = False Then
                Me.Refresh()
                Exit Sub
            End If
        End If
        Dim LLo As String = ""
        LLo = "L=" & UpdtRtn.LDegI.ToString("00") & Chr(176) & UpdtRtn.LMinI.ToString("00.0") &
            "'" & cboL.Text.ToString & " Lo=" & UpdtRtn.LoDegI.ToString("00") & Chr(176) & UpdtRtn.LoMinI.ToString("00.0") & "'" & cboLo.Text.ToString
        DataGridView1.Rows(UpdtRow).Cells(0).Value = txtVessel.Text
        DataGridView1.Rows(UpdtRow).Cells(1).Value = txtNavigator.Text
        DataGridView1.Rows(UpdtRow).Cells(2).Value = txtFrom.Text
        DataGridView1.Rows(UpdtRow).Cells(3).Value = txtTo.Text
        DataGridView1.Rows(UpdtRow).Cells(4).Value = cboLocType.Text
        DataGridView1.Rows(UpdtRow).Cells(5).Value = DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss")
        DataGridView1.Rows(UpdtRow).Cells(6).Value = txtCompass.Text & Chr(176)
        DataGridView1.Rows(UpdtRow).Cells(7).Value = txtVar.Text & cboVar.Text
        DataGridView1.Rows(UpdtRow).Cells(8).Value = txtDev.Text & cboDev.Text
        DataGridView1.Rows(UpdtRow).Cells(9).Value = txtCTrue.Text & Chr(176)
        DataGridView1.Rows(UpdtRow).Cells(10).Value = txtSpeed.Text & "kn"
        DataGridView1.Rows(UpdtRow).Cells(11).Value = LLo
        DataGridView1.Rows(UpdtRow).Cells(12).Value = txtWeather.Text
        DataGridView1.Rows(UpdtRow).Cells(13).Value = txtRemarks.Text
        If cboLocType.Text = "Plan" Then
            Dim DestLLo As String = "L=" & txtDestLDeg.Text.ToString & Chr(176) & txtDestLMin.Text.ToString & "'" & cboDestL.Text.ToString &
            " Lo=" & txtDestLoDeg.Text.ToString & Chr(176) & txtDestLoMin.Text.ToString & "'" & cboDestLo.Text.ToString
            DataGridView1.Rows(UpdtRow).Cells(14).Value = txtDestElapsed.Text
            DataGridView1.Rows(UpdtRow).Cells(15).Value = txtDestDist.Text
            DataGridView1.Rows(UpdtRow).Cells(16).Value = DestLLo
            DataGridView1.Rows(UpdtRow).Cells(17).Value = txtDestTrue.Text
        End If


        SortDataGridonDate()
        evaluateDG()
        DataGridView1.Refresh()
        Me.Refresh()
        IsUpdated = True
        Exit Sub
    End Sub

    Private Sub btnDeleteSight_Click(sender As Object, e As EventArgs) Handles btnDeleteSight.Click
        DataSet1.Tables(tablename).Rows.RemoveAt(UpdtRow)
        SortDataGridonDate()
        evaluateDG()
        DataGridView1.Refresh()
        Me.Refresh()
        IsUpdated = True
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
        ' if the Log Entry type is Plan then do not edit compass, dev, var fields
        If cboLocType.Text <> "Plan" Then
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
        End If

        If txtVar.Text = vbNullString Or txtVar.Text = "" Then
                txtVar.Text = 0
                'ErrorMsgBox("Variation must be entered")
                'Return False
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
                txtDev.Text = 0
                'ErrorMsgBox("Deviation must be entered")
                'Return False
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
        If cboLocType.Text <> "Plan" Then
            UpdtRtn.CTrueI = UpdtRtn.CompassI + UpdtRtn.VarI + UpdtRtn.DevI
            txtCTrue.Text = UpdtRtn.CTrueI.ToString("000")
        End If

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
            UpdtRtn.LNS = cboL.Text
            If cboL.Text = "N" Then
                UpdtRtn.LatDecimal = Convert.ToDecimal(UpdtRtn.LDegI) + UpdtRtn.LMinI / 60
            Else
                UpdtRtn.LatDecimal = -1 * (Convert.ToDecimal(UpdtRtn.LDegI) + UpdtRtn.LMinI / 60)
            End If
            If UpdtRtn.LMinI < 0 Or UpdtRtn.LMinI > 59.9 Then
                ErrorMsgBox("Latitude Minutes must be numeric between 0 and 59.9")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("Latitude Minutes must be numeric between 0 and 59.9")
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
            UpdtRtn.LoEW = cboLo.Text
            If cboLo.Text = "W" Then
                UpdtRtn.LongDecimal = Convert.ToDecimal(UpdtRtn.LoDegI) + UpdtRtn.LoMinI / 60
            Else
                UpdtRtn.LongDecimal = -1 * (Convert.ToDecimal(UpdtRtn.LoDegI) + UpdtRtn.LoMinI / 60)
            End If
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
    Private Function EditPlanFields() As Boolean

        If txtCTrue.Text = vbNullString Or txtCTrue.Text = "" Then
            ErrorMsgBox("For Plan Entry,True Course must be entered")
            Return False
        End If
        If IsNumeric(txtCTrue.Text) = False Then
            ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360")
            Return False
        End If
        Try
            UpdtRtn.CTrueI = Convert.ToInt32(txtCTrue.Text)
            If UpdtRtn.CTrueI < 0 Or UpdtRtn.CTrueI > 359 Then
                ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360")
            Return False
        End Try

        UpdtRtn.CompassI = UpdtRtn.CTrueI + UpdtRtn.VarI + UpdtRtn.DevI
        txtCompass.Text = UpdtRtn.CompassI.ToString("000")

        If txtDestLDeg.Text = vbNullString Or txtDestLDeg.Text = "" Then
            ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be entered")
            Return False
        End If
        If IsNumeric(txtDestLDeg.Text) = False Then
            ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be numeric between 0 and 89")
            Return False
        End If
        Try
            UpdtRtn.DestLDegI = Convert.ToInt32(txtDestLDeg.Text)
            If UpdtRtn.DestLDegI < 0 Or UpdtRtn.DestLDegI > 89 Then
                ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be numeric between 0 and 89")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("For Plan Entry, DestinationLatitude Degrees must be numeric between 0 and 89")
            Return False
        End Try

        If txtDestLMin.Text = vbNullString Or txtDestLMin.Text = "" Then
            ErrorMsgBox("For Plan Entry, Latitude Minutes must be entered")
            Return False
        End If
        If IsNumeric(txtDestLMin.Text) = False Then
            ErrorMsgBox("For Plan Entry, Latitude Minutes be numeric between 0 and 59.9")
            Return False
        End If
        Try
            UpdtRtn.DestLMinI = Convert.ToDecimal(txtDestLMin.Text)
            UpdtRtn.DestLNS = cboDestL.Text
            If UpdtRtn.DestLNS = "N" Then
                UpdtRtn.DestLatDecimal = Convert.ToDecimal(UpdtRtn.DestLDegI) + UpdtRtn.DestLMinI / 60
            Else
                UpdtRtn.DestLatDecimal = -1 * (Convert.ToDecimal(UpdtRtn.DestLDegI) + UpdtRtn.DestLMinI / 60)
            End If
            If UpdtRtn.DestLMinI < 0 Or UpdtRtn.DestLMinI > 59.9 Then
                ErrorMsgBox("For Plan Entry, Latitude Minutes must be numeric between 0 and 59.9")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("For Plan Entry, Latitude Minutes must be numeric between 0 and 59.9")
            Return False
        End Try

        If txtDestLoDeg.Text = vbNullString Or txtDestLDeg.Text = "" Then
            ErrorMsgBox("For Plan Entry, Longitude Degrees must be entered")
            Return False
        End If
        If IsNumeric(txtDestLoDeg.Text) = False Then
            ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 89")
            Return False
        End If
        Try
            UpdtRtn.DestLoDegI = Convert.ToInt32(txtDestLoDeg.Text)
            If UpdtRtn.DestLoDegI < 0 Or UpdtRtn.DestLoDegI > 180 Then
                ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 180")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 180")
            Return False
        End Try

        If txtDestLoMin.Text = vbNullString Or txtDestLoMin.Text = "" Then
            ErrorMsgBox("For Plan Entry, Longitude Minutes must be entered")
            Return False
        End If
        If IsNumeric(txtDestLoMin.Text) = False Then
            ErrorMsgBox("For Plan Entry, Longitude Minutes be numeric between 0 and 59.9")
            Return False
        End If
        Try
            UpdtRtn.DestLoMinI = Convert.ToDecimal(txtDestLoMin.Text)
            UpdtRtn.DestLoEW = cboDestLo.Text
            If UpdtRtn.DestLoEW = "W" Then
                UpdtRtn.DestLongDecimal = Convert.ToDecimal(UpdtRtn.DestLoDegI) + UpdtRtn.DestLoMinI / 60
            Else
                UpdtRtn.DestLongDecimal = -1 * (Convert.ToDecimal(UpdtRtn.DestLoDegI) + UpdtRtn.DestLoMinI / 60)
            End If
            If UpdtRtn.DestLoMinI < 0 Or UpdtRtn.DestLoMinI > 59.9 Then
                ErrorMsgBox("For Plan Entry, Longitude Minutes must be numeric between 0 and 59.9")
                Return False
            End If
        Catch ex As Exception
            ErrorMsgBox("For Plan Entry, Longitude Minutes must be numeric between 0 and 59.9")
            Return False
        End Try
        Dim Loc1 As System.Device.Location.GeoCoordinate = New Device.Location.GeoCoordinate(UpdtRtn.LatDecimal, UpdtRtn.LongDecimal)
        Dim Loc2 As System.Device.Location.GeoCoordinate = New Device.Location.GeoCoordinate(UpdtRtn.DestLatDecimal, UpdtRtn.DestLongDecimal)
        Dim DestDist As Double = GetDistance(UpdtRtn.LatDecimal, UpdtRtn.LongDecimal, UpdtRtn.DestLatDecimal, UpdtRtn.DestLongDecimal)
        txtDestDist.Text = DestDist.ToString("##0.0") & "nm"
        txtDestTrue.Text = GetHeading(UpdtRtn.LatDecimal, UpdtRtn.LongDecimal, UpdtRtn.DestLatDecimal, UpdtRtn.DestLongDecimal).ToString("##0") & Chr(176)
        Dim DestElapsed As TimeSpan = Calc60DSTElapsed(DTDateZoneTime.Value, Convert.ToDouble(txtSpeed.Text), DestDist)
        If DestElapsed.Days = 0 Then
            txtDestElapsed.Text = DestElapsed.ToString("hh\:mm\:ss")
        Else
            txtDestElapsed.Text = DestElapsed.ToString("d\d\y\ hh\:mm\:ss")
        End If
        'txtDestElapsed.Text = DestElapsed.ToString("d\d\y\ hh\:mm\:ss")
        Dim DestEstArrival As DateTime = DTDateZoneTime.Value + DestElapsed
        txtRemarks.Text = "Estimated Arrival Time for Plan Log Entry:" & DestEstArrival.ToString("MM/dd/yyyy HH:mm:ss")
        txtEstArrival.Text = DestEstArrival.ToString("MM/dd/yyyy HH:mm:ss")
        Return True
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
        cboLocType.SelectedIndex = 0
        cboL.SelectedIndex = 0
        cboLo.SelectedIndex = 0
        cboVar.SelectedIndex = 0
        cboDev.SelectedIndex = 0
        cboLocType.SelectedIndex = 0
        txtVar.Text = 0
        txtDev.Text = 0
        Exit Sub
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        btnDeleteSight.Visible = False
        btnUpdateExisting.Visible = False
        ResetScreenFields()
        Exit Sub
    End Sub
    Private Sub SortDataGridonDate()
        SortingDG = True
        DataGridView1.Sort(DataGridView1.Columns(5), System.ComponentModel.ListSortDirection.Ascending)
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.AutoResizeColumn(i)
        Next
        ' select last row in data grid
        Dim LastRow As Integer = DataGridView1.Rows.Count - 1
        DataGridView1.CurrentCell = DataGridView1.Rows(LastRow).Cells(4)
        DataGridView1.Rows(LastRow).Selected = True
        SortingDG = False
        Exit Sub
    End Sub
    Private Function EditRelationsinDG() As Boolean

        Return True
    End Function
    Private Sub evaluateDG()
        If InitialLoad = True Then Exit Sub
        If FileLoading = True Then Exit Sub
        Dim DGlimit As Integer = DataGridView1.Rows.Count
        Dim PrevGPSFIXExists As Boolean = False
        Dim PrevGPSFix As Integer = 0
        Dim PrevDRExists As Boolean = False
        Dim PrevDR As Integer = 0
        If DGlimit = 1 Then
            ErrorMsgBox("Nothing to evaluate - the Data Grid only has one entry")
        End If
        If DataGridView1.Rows(0).Cells(4).Value = "GPS" Or DataGridView1.Rows(0).Cells(4).Value = "Fix" Then
            PrevGPSFIXExists = True
        End If
        If DataGridView1.Rows(0).Cells(4).Value = "DR" Then
            PrevDRExists = True
            PrevDR = 0
        End If
        ' for the first data grid row clear out the last 6 cells to make sure nothing displays
        'For i As Integer = 14 To 20
        '    DataGridView1.Rows(0).Cells(i).Value = ""
        'Next
        ' now pass thru the data grid from the second record to the end evaluate each pair of records and calculating the final route results
        For i As Integer = 1 To DGlimit - 1
            If DataGridView1.Rows(i).Cells(4).Value <> "Plan" Then
                DataGridView1.Rows(i).Cells(14).Value = "" ' Elapsed Time
                DataGridView1.Rows(i).Cells(15).Value = "" ' Distance
                DataGridView1.Rows(i).Cells(16).Value = "" ' Calc Loc L/Lo
                DataGridView1.Rows(i).Cells(17).Value = "" ' CMG
                DataGridView1.Rows(i).Cells(18).Value = "" ' SMG
                DataGridView1.Rows(i).Cells(19).Value = "" ' Set 
                DataGridView1.Rows(i).Cells(20).Value = "" ' Drift
                DataGridView1.Rows(i).Cells(21).Value = "" ' Eval Based On
            Else
                DataGridView1.Rows(i).Cells(19).Value = "" ' Set 
                DataGridView1.Rows(i).Cells(20).Value = "" ' Drift
                DataGridView1.Rows(i).Cells(21).Value = "" ' Eval Based On
            End If


            If DataGridView1.Rows(i).Cells(4).Value = "GPS" Or DataGridView1.Rows(i).Cells(4).Value = "Fix" Then
                If PrevGPSFIXExists = True Then
                    EvaluateDBPairs(i, PrevGPSFix, True)
                    DataGridView1.Rows(i).Cells(21).Value = "Prev GPS/Fix Entry"
                    PrevGPSFix = i
                Else
                    PrevGPSFIXExists = True
                    PrevGPSFix = i
                    If DataGridView1.Rows(i).Cells(4).Value <> "Plan" Then
                        If PrevDRExists = True Then
                            EvaluateDBPairs(i, PrevDR, False)
                            DataGridView1.Rows(i).Cells(21).Value = "Prev Log Entry"
                            PrevDR = i
                        Else
                            PrevDRExists = True
                            PrevDR = i
                        End If
                    End If
                End If
            ElseIf DataGridView1.Rows(i).Cells(4).Value = "Plan" Then
                Dim x As Integer = 0 ' do nothing statement just to do something
            ElseIf DataGridView1.Rows(i).Cells(4).Value = "DR" And DataGridView1.Rows(i - 1).Cells(4).Value <> "Plan" Then
                If PrevDRExists = True Then
                    EvaluateDBPairs(i, PrevDR, False)
                    DataGridView1.Rows(i).Cells(21).Value = "Prev Log Entry"
                    PrevDR = i
                Else
                    PrevDRExists = True
                    PrevDR = i
                End If
                'ElseIf DataGridView1.Rows(i).Cells(4).Value = "DR" And DataGridView1.Rows(i - 1).Cells(4).Value = "Plan" Then
                '    PrevDRExists = True
                '    PrevDR = i
            End If
        Next
        Exit Sub
    End Sub
    Private Sub EvaluateDBPairs(ByVal CurrRec As Integer, ByVal PrevRec As Integer, ByVal GPSFixEntry As Boolean)
        ' evaluate Elapsed time from last entry
        Dim DT1 As DateTime = Convert.ToDateTime(DataGridView1.Rows(PrevRec).Cells(5).Value)
        Dim DT2 As DateTime = Convert.ToDateTime(DataGridView1.Rows(CurrRec).Cells(5).Value)
        Dim TS As TimeSpan = DT2 - DT1
        If TS.Days = 0 Then
            DataGridView1.Rows(CurrRec).Cells(14).Value = TS.ToString("hh\:mm\:ss")
        Else
            DataGridView1.Rows(CurrRec).Cells(14).Value = TS.ToString("d\d\y\ hh\:mm\:ss")
        End If

        ' evaluate Calculate destination location - start with location of previous entry 
        Dim GeoLLo1 As Device.Location.GeoCoordinate = ParseLatLong(DataGridView1.Rows(PrevRec).Cells(11).Value)
        Dim TempcboL1 As String = "N"
        Dim TempL1 As Double = GeoLLo1.Latitude
        Dim TempL1Disp As Double = GeoLLo1.Latitude
        If GeoLLo1.Latitude < 0 Then
            TempcboL1 = "S"
            TempL1 = -1 * TempL1Disp
        Else
            TempcboL1 = "N"
            TempL1 = TempL1Disp
        End If
        Dim TempcboLo1 As String = ""
        Dim TempLo1Disp As Double = GeoLLo1.Longitude
        Dim TempLo1 As Double = GeoLLo1.Longitude
        If GeoLLo1.Longitude < 0 Then
            TempcboLo1 = "E"
            TempLo1 = -1 * TempLo1Disp
        Else
            TempcboLo1 = "W"
            TempLo1 = TempLo1Disp
        End If

        ' now calculate the location for the current entry
        Dim GeoLLo As Device.Location.GeoCoordinate = ParseLatLong(DataGridView1.Rows(CurrRec).Cells(11).Value)
        Dim TempcboL As String = "N"
        Dim TempL As Double = GeoLLo.Latitude
        Dim TempLDisp As Double = GeoLLo.Latitude
        If GeoLLo.Longitude < 0 Then
            TempcboL = "S"
            TempL = -1 * TempLDisp
        Else
            TempcboL = "N"
            TempL = TempL1Disp
        End If
        Dim TempcboLo As String = ""
        Dim TempLoDisp As Double = GeoLLo.Longitude
        Dim TempLo As Double = GeoLLo.Longitude
        If GeoLLo.Longitude < 0 Then
            TempcboLo = "E"
            TempLo = -1 * TempLoDisp
        Else
            TempcboLo = "W"
            TempLo = TempLoDisp
        End If

        Dim tlen As Integer = DataGridView1.Rows(PrevRec).Cells(9).Value.ToString.Length
        Dim TempTrue As Decimal = Convert.ToDecimal(DataGridView1.Rows(PrevRec).Cells(9).Value.ToString.Substring(0, tlen - 1))
        tlen = DataGridView1.Rows(PrevRec).Cells(10).Value.ToString.Length
        Dim TempSpeed As Decimal = Convert.ToDecimal(DataGridView1.Rows(PrevRec).Cells(10).Value.ToString.Substring(0, tlen - 2))

        ' get the distance from the previous location to the current entry location
        Dim Dist As Double = GetDistance(TempL1Disp, TempLo1Disp, TempLDisp, TempLoDisp)
        DataGridView1.Rows(CurrRec).Cells(15).Value = Dist.ToString("#0.0") & " nm"

        ' now calculate the destination location using the previous loc, the distance using prev speed and elapsed time, and true course of prev entry
        Dim TempLoc As System.Device.Location.GeoCoordinate = FindDestLatLong(TempL1Disp, TempLo1Disp, Dist, TempTrue)
        Dim TempL3 As Double = TempLoc.Latitude
        Dim TempL3NS As String = TempcboL
        Dim TempL3Disp As Double = 0
        If TempL3 < 0 Then
            TempL3NS = "S"
            TempL3Disp = -1 * TempL3
        Else
            TempL3NS = "N"
            TempL3Disp = TempL3
        End If
        Dim TempL3Deg As Integer = Int(TempL3)
        Dim TempL3Min As Decimal = (TempL3 - TempL3Deg) * 60

        Dim TempLo3 As Double = TempLoc.Longitude
        Dim TempLo3EW As String = TempcboLo
        Dim TempLo3Disp As Double = 0
        If TempLo3 < 0 Then
            TempLo3EW = "W"
            TempLo3Disp = -1 * TempLo3
        Else
            TempLo3EW = "E"
            TempLo3Disp = TempLo3
        End If
        Dim TempLo3Deg As Integer = Int(TempLo3Disp)
        Dim TempLo3Min As Decimal = (TempLo3Disp - TempLo3Deg) * 60

        DataGridView1.Rows(CurrRec).Cells(16).Value = "L=" & TempL3Deg.ToString("##0") & Chr(176) & TempL3Min.ToString("#0.0") & "'" & TempL3NS & " " &
                                                    "Lo=" & TempLo3Deg.ToString("##0") & Chr(176) & TempLo3Min.ToString("#0.0") & "'" & TempLo3EW

        ' Calculate the actual course between the previous loc and the current loc 
        Dim CMG As Double = GetHeading(TempL1, TempLo1, TempL, TempLo)
        DataGridView1.Rows(CurrRec).Cells(17).Value = CMG.ToString("##0.0") & Chr(176)
        ' Calculate the actual speed using the calculate distance between previous loc and current loc and the elapsed time
        Dim SMG As Double = Calc60DSTSpeed(DT1, DT2, Dist)
        DataGridView1.Rows(CurrRec).Cells(18).Value = SMG.ToString("##0.0") & "kn "

        If GPSFixEntry = True Then

            ' calculate the Direction of Set from current loc to actual computed loc 
            Dim SetCalc As Double = GetHeading(TempL, TempLo, TempL3, TempLo3)
            DataGridView1.Rows(CurrRec).Cells(19).Value = SetCalc.ToString("##0.0") & Chr(176)
            ' Calculate Drift distance and speed from current loc to actual computed loc
            Dim DistDrift As Double = GetDistance(TempL, TempLo, TempL3, TempLo3)
            Dim DriftSpeed As Double = Calc60DSTSpeed(DT1, DT2, DistDrift)
            DataGridView1.Rows(CurrRec).Cells(20).Value = DriftSpeed.ToString("##0.0") & "kn "
        End If

        Exit Sub
    End Sub
    Private Function GetDistance(ByVal Lat1In As Double, ByVal Long1In As Double, ByVal Lat2In As Double, ByVal Long2In As Double) As Double
        Dim Coord1 As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(Lat1In, Long1In)
        Dim Coord2 As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(Lat2In, Long2In)
        Return (Coord1.GetDistanceTo(Coord2)) / 1852  ' GetDistanceTo returns distance between geo coords in meters - there are 1852 meters in a nuatical mile
    End Function
    Private Function GetHeading(ByVal lat1 As Double, ByVal long1 As Double, ByVal lat2 As Double, ByVal long2 As Double) As Double

        Dim x As Double = Math.Cos(DegreesToRadians(lat1)) * Math.Sin(DegreesToRadians(lat2)) - Math.Sin(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) * Math.Cos(DegreesToRadians(long2) - DegreesToRadians(long1))
        Dim y As Double = Math.Sin(DegreesToRadians(long2) - DegreesToRadians(long1)) * Math.Cos(DegreesToRadians(lat2))
        Dim DegX As Double = RadiansToDegrees(x)
        Dim DegY As Double = RadiansToDegrees(y)
        Dim Angle As Double = RadiansToDegrees(Math.Atan2(DegY, DegX))
        If Angle < 180 Then
            If lat2 > 0 Then
                Angle = 360 - Angle
            Else
                Angle = 180 + Angle
            End If
        Else
            If lat2 > 0 Then
                Angle = Angle
            Else
                Angle = 180 - Angle
            End If
        End If
        Return Angle Mod 360
    End Function
    Private Function DegreesToRadians(ByVal angle As Double) As Double
        Return angle * Math.PI / 180
    End Function
    Private Function RadiansToDegrees(ByVal angle As Double) As Double
        Return angle * 180 / Math.PI
    End Function
    Private Function FindDestLatLong(ByVal LatIn As Double, ByVal LonIn As Double, ByVal Dist As Double, ByVal Course As Double) As System.Device.Location.GeoCoordinate
        Dim lat1 As Double = LatIn * Math.PI / 180
        Dim Lon1 As Double = LonIn * Math.PI / 180
        Dim Theta As Double = Course * Math.PI / 180
        Dim R As Double = 3443.92  ' this is the radius of the earth in nautical miles
        Dim d As Double = Dist    ' this is the distance travelled in nautical miles
        Dim DDivR As Double = (d / R) * Math.PI / 180

        Dim lat2 As Double = Math.Asin(Math.Sin(lat1) * Math.Cos(DDivR) + Math.Cos(lat1) * Math.Sin(DDivR) * Math.Cos(Theta))
        Dim lon2 As Double = Lon1 + Math.Atan2((Math.Sin(Theta) * Math.Sin(DDivR) * Math.Cos(lat1)), (Math.Cos(DDivR) - (Math.Sin(lat1) * Math.Sin(lat2))))
        Dim RtnGC As System.Device.Location.GeoCoordinate = New System.Device.Location.GeoCoordinate(lat2 * 180 / Math.PI, lon2 * 180 / Math.PI)
        Return RtnGC
    End Function
    Private Function Calc60DSTDistance(ByVal DT1 As DateTime, ByVal DT2 As DateTime, ByVal Speed As Double) As Double
        Dim TS As TimeSpan = DT2 - DT1
        Return (Speed * TS.TotalHours)
    End Function
    Private Function Calc60DSTSpeed(ByVal DT1 As DateTime, ByVal DT2 As DateTime, ByVal Dist As Double) As Double
        Dim TS As TimeSpan = DT2 - DT1
        Return (Dist / TS.TotalHours)
    End Function
    Private Function Calc60DSTElapsed(ByVal DT1 As DateTime, ByVal Speed As Double, ByVal Distance As Double) As TimeSpan
        Dim ElapsedMin As Double = (60 * Distance) / Speed
        Dim newDT As DateTime = DT1
        newDT = newDT.AddMinutes(ElapsedMin)
        Dim TS As TimeSpan = newDT - DT1
        Return TS
    End Function
    Private Sub btnEval_Click(sender As Object, e As EventArgs)
        evaluateDG()
        Exit Sub
    End Sub
    Private Function ParseLatLong(ByVal StrIn As String) As System.Device.Location.GeoCoordinate
        ' evaluate Calculate destination location - start with location of previous entry 
        Dim LLo1 As String = StrIn  'DataGridView1.Rows(i - 1).Cells(11).Value
        Dim LPos1 As Integer = LLo1.IndexOf("=")
        Dim LDegPos1 As Integer = LLo1.IndexOf(Chr(176))
        Dim LMinPos1 As Integer = LLo1.IndexOf("'")
        Dim LoPos1 As Integer = LLo1.IndexOf("=", LPos1 + 1)
        Dim LoDegPos1 As Integer = LLo1.IndexOf(Chr(176), LDegPos1 + 1)
        Dim LoMinPos1 As Integer = LLo1.IndexOf("'", LMinPos1 + 1)
        Dim TempL1 As Double = Convert.ToDouble(LLo1.Substring(LPos1 + 1, (LDegPos1 - 1) - (LPos1 + 1) + 1)) +
            Convert.ToDouble(LLo1.Substring(LDegPos1 + 1, (LMinPos1 - 1) - (LDegPos1 + 1) + 1) / 60)
        Dim TempcboL1 As String = LLo1.Substring(LMinPos1 + 1, 1)
        Dim TempL1Disp As Double = 0
        If TempcboL1 = "S" Then
            TempL1Disp = -1 * TempL1
        Else
            TempL1Disp = TempL1
        End If
        Dim TempLo1 As Double = Convert.ToDouble(LLo1.Substring(LoPos1 + 1, (LoDegPos1 - 1) - (LoPos1 + 1) + 1)) +
            Convert.ToDouble(LLo1.Substring(LoDegPos1 + 1, (LoMinPos1 - 1) - (LoDegPos1 + 1) + 1) / 60)
        Dim TempcboLo1 As String = LLo1.Substring(LoMinPos1 + 1, 1)
        Dim TempLo1Disp As Double = 0
        If TempcboLo1 = "W" Then
            TempLo1Disp = -1 * TempLo1
        Else
            TempLo1Disp = TempLo1
        End If

        Dim RtnLLo As Device.Location.GeoCoordinate = New Device.Location.GeoCoordinate(TempL1Disp, TempLo1Disp)
        Return RtnLLo
    End Function

    Private Sub cboLocType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocType.SelectedIndexChanged
        If InitialLoad = True Then Exit Sub
        If FileLoading = True Then Exit Sub
        If cboLocType.Text = "Plan" Then
            ' make visible plan dest fields and enable 
            grpbxPlan.Visible = True
            txtCompass.Enabled = False
            txtCTrue.Enabled = True
            txtCTrue.Text = 0
            txtDev.Enabled = True
            txtDev.Text = 0
            cboDev.Enabled = True
            cboDev.SelectedIndex = 0
            txtVar.Enabled = True
            cboVar.Enabled = True
            cboVar.SelectedIndex = 0
            txtVar.Text = 0
        Else
            ' make invisible plan dest fields and disable 
            grpbxPlan.Visible = False
            txtCompass.Enabled = True
            txtCTrue.Enabled = False
            txtCTrue.Text = 0
            txtDev.Enabled = True
            txtDev.Text = 0
            cboDev.Enabled = True
            cboDev.SelectedIndex = 0
            txtVar.Enabled = True
            cboVar.Enabled = True
            cboVar.SelectedIndex = 0
            txtVar.Text = 0
        End If
        ClearPlanFields()
        Me.Refresh()
        Exit Sub
    End Sub
    Private Sub ClearPlanFields()
        txtDestLDeg.Clear()
        txtDestLMin.Clear()
        txtDestLoDeg.Clear()
        txtDestLoMin.Clear()
        cboDestL.SelectedIndex = 0
        cboDestLo.SelectedIndex = 0
        txtDestTrue.Clear()
        txtDestDist.Clear()
        txtDestElapsed.Clear()
        txtEstArrival.Clear()
        txtWeather.Clear()
        txtRemarks.Clear()
        Exit Sub
    End Sub

    Private Sub chkHideFirst4Col_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideFirst4Col.CheckedChanged
        If chkHideFirst4Col.Checked = True Then
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(12).Visible = False
            SortDataGridonDate()
            DataGridView1.Refresh()
            Me.Refresh()
        Else
            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(2).Visible = True
            DataGridView1.Columns(3).Visible = True
            DataGridView1.Columns(12).Visible = True
            SortDataGridonDate()
            DataGridView1.Refresh()
            Me.Refresh()
        End If
    End Sub

    Private Sub btnStartFresh_Click(sender As Object, e As EventArgs) Handles btnStartFresh.Click
        If IsUpdated = True Then
            Dim MsgBack As MsgBoxResult = MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data")
            If MsgBack = MsgBoxResult.Yes Then
                SaveDataGrid()
            End If
            IsUpdated = False
        End If
        FileLoading = True
        DataSet1.Tables(tablename).Clear()
        ClearPlanFields()
        ResetScreenFields()
        Me.Refresh()
        FileLoading = False
        Exit Sub
    End Sub
End Class
