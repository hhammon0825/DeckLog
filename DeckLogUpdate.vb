Public Class DeckLogUpdate
    Public FName As String = "./DeckLog/"
    Public ReadError As Boolean = False
    Public FileLoading As Boolean = False
    Public InitialLoad As Boolean = False
    Public SLOpenFName As String = ""
    Public tablename As String = "Export"
    Public DataSet1 As DataSet
    Public HdrStr As String() = {"Vessel", "Navigator", "LocFrom", "LocTo", "DateZoneTime", "Compass", "Var", "Dev", "CTrue", "Speed", "PositionLatLong", "Loc Type", "Weather", "Remarks"}
    Public NullStr As String() = {vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString, vbNullString}
    Public UpdtRow As Integer = 0
    Public Structure DLUpdate
        Public Vessel As String
        Public Navigator As String
        Public LocFrom As String
        Public LocTo As String
        Public DateZoneTime As String
        Public Compass As String
        Public Var As String
        Public Dev As String
        Public CTrue As String
        Public Speed As String
        Public PositionLatLong As String
        Public LocType As String
        Public Weather As String
        Public Remarks As String
        Public UpdtFlag As String  ' "" or vbnullstring or "C" = cancel / ignore "A" = Add data to decklog "U" = Update data back into decklog  "D" = Delete info from decklog
    End Structure
    Public UpdtRtn As DLUpdate

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DefFName As String = "DeckLog" & Now.ToString("yyyyMMddHHmmss") & ".csv"
        InitialLoad = True
        FName &= DefFName
        cboL.SelectedIndex = 0
        cboLo.SelectedIndex = 0
        cboVar.SelectedIndex = 0
        cboDev.SelectedIndex = 0
        cboLocType.SelectedIndex = 0

        DataSet1 = New DataSet()
        DataSet1.Tables.Add(tablename)
        DataSet1.DataSetName = tablename
        DataGridView1.DataSource = DataSet1
        For i As Integer = 0 To UBound(HdrStr)
            DataSet1.Tables(tablename).Columns.Add(HdrStr(i))
        Next

        DataGridView1.DataSource = DataSet1.Tables(0).DefaultView
        DataGridView1.Refresh()
        Me.Show()
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveDataGrid()
        Me.Close()
    End Sub
    Private Sub SaveDataGrid()
        Dim textstr As New System.Text.StringBuilder()
        Dim FileHdrStr As String = vbNullString
        For i As Integer = 0 To UBound(HdrStr) - 1
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

        Exit Sub
    End Sub

    Private Sub btnExitNoSave_Click(sender As Object, e As EventArgs) Handles btnExitNoSave.Click
        Me.Close()
        Exit Sub
    End Sub

    Private Sub btnOpenCSV_Click(sender As Object, e As EventArgs) Handles btnOpenCSV.Click
        Dim myStream As System.IO.StreamReader = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        If DataSet1.DataSetName = tablename Then
            DataSet1.Dispose()
            DataSet1 = New DataSet()
            DataGridView1.DataSource = vbNull
        End If
        DataSet1.Tables.Add(tablename)
        DataSet1.DataSetName = tablename
        DataGridView1.DataSource = DataSet1
        Dim dirstr As String = FileIO.FileSystem.CurrentDirectory
        openFileDialog1.InitialDirectory = dirstr & "/DeckLog/"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv"
        openFileDialog1.Title = "Open Deck Log File"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If openFileDialog1.FileName = vbNullString Then
                Exit Sub
            End If
            ReadError = False
            FileLoading = True
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
                            For ctr As Integer = 0 To UBound(items)
                                DataSet1.Tables(tablename).Columns.Add(items(ctr))
                            Next
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
        UpdtRow = DataGridView1.CurrentRow.Index
        ' The order of these variable and the integer indexs contained in each MUST match the order of the fields in the data grid
        UpdtRtn.Vessel = DataGridView1.Rows(n).Cells(0).Value
        txtVessel.Text = DataGridView1.Rows(n).Cells(0).Value

        UpdtRtn.Navigator = DataGridView1.Rows(n).Cells(1).Value
        txtNavigator.Text = DataGridView1.Rows(n).Cells(1).Value

        UpdtRtn.LocFrom = DataGridView1.Rows(n).Cells(2).Value
        txtFrom.Text = DataGridView1.Rows(n).Cells(2).Value

        UpdtRtn.LocTo = DataGridView1.Rows(n).Cells(3).Value
        txtTo.Text = DataGridView1.Rows(n).Cells(3).Value

        UpdtRtn.DateZoneTime = DataGridView1.Rows(n).Cells(4).Value
        DTDateZoneTime.Value = Convert.ToDateTime(DataGridView1.Rows(n).Cells(4).Value)

        UpdtRtn.Compass = DataGridView1.Rows(n).Cells(5).Value
        txtCompass.Text = DataGridView1.Rows(n).Cells(5).Value

        UpdtRtn.Var = DataGridView1.Rows(n).Cells(6).Value
        txtVar.Text = DataGridView1.Rows(n).Cells(6).Value

        UpdtRtn.Dev = DataGridView1.Rows(n).Cells(7).Value
        txtDev.Text = DataGridView1.Rows(n).Cells(7).Value

        UpdtRtn.CTrue = DataGridView1.Rows(n).Cells(8).Value
        txtCTrue.Text = DataGridView1.Rows(n).Cells(8).Value

        UpdtRtn.Speed = DataGridView1.Rows(n).Cells(9).Value
        txtSpeed.Text = DataGridView1.Rows(n).Cells(9).Value

        UpdtRtn.PositionLatLong = DataGridView1.Rows(n).Cells(10).Value
        Dim LLo As String = DataGridView1.Rows(n).Cells(10).Value
        Dim LPos As Integer = LLo.IndexOf("=")
        Dim LDegPos As Integer = LLo.IndexOf(Chr(176))
        Dim LMinPos As Integer = LLo.IndexOf("'")
        Dim LoPos As Integer = LLo.LastIndexOf("=")
        Dim LoDegPos As Integer = LLo.LastIndexOf(Chr(176))
        Dim LoMinPos As Integer = LLo.LastIndexOf("'")
        txtLDeg.Text = LLo.Substring(LPos + 1, (LDegPos - 1) - (LPos + 1))
        txtLMin.Text = LLo.Substring(LDegPos + 1, (LMinPos - 1) + (LDegPos + 1))
        cboL.Text = LLo.Substring(LMinPos + 1, 1)
        txtLoDeg.Text = LLo.Substring(LoPos + 1, (LoDegPos - 1) - (LoPos + 1))
        txtLoMin.Text = LLo.Substring(LoDegPos + 1, (LoMinPos - 1) + (LoDegPos + 1))
        cboLo.Text = LLo.Substring(LoMinPos + 1, 1)

        UpdtRtn.LocType = DataGridView1.Rows(n).Cells(11).Value
        cboLocType.Text = DataGridView1.Rows(n).Cells(11).Value

        UpdtRtn.Weather = DataGridView1.Rows(n).Cells(12).Value
        txtWeather.Text = DataGridView1.Rows(n).Cells(12).Value

        UpdtRtn.Remarks = DataGridView1.Rows(n).Cells(13).Value
        txtRemarks.Text = DataGridView1.Rows(n).Cells(13).Value

        Me.Refresh()

        Exit Sub
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        Dim LLo As String = "L=" & txtLDeg.Text.ToString & Chr(176) & txtLMin.Text.ToString & "'" & cboL.Text.ToString & " Lo=" & txtLoDeg.Text.ToString & Chr(176) & txtLoMin.Text.ToString & cboLo.Text.ToString

        DataSet1.Tables(tablename).Rows.Add(txtVessel.Text.ToString, txtNavigator.Text.ToString, txtFrom.Text.ToString, txtTo.Text.ToString,
                               DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), txtCompass.Text.ToString, txtVar.Text.ToString, txtDev.Text.ToString,
                               txtCTrue.Text.ToString, txtSpeed.Text.ToString, LLo, cboLocType.Text.ToString, txtWeather.Text.ToString, txtRemarks.Text.ToString)
        DataGridView1.Refresh()
        Me.Refresh()

        Exit Sub
    End Sub

    Private Sub btnUpdateExisting_Click(sender As Object, e As EventArgs) Handles btnUpdateExisting.Click
        If EditUpdtFields() = False Then
            Me.Refresh()
            Exit Sub
        End If
        Dim LLo As String = "L=" & txtLDeg.Text.ToString & Chr(176) & txtLMin.Text.ToString & "'" & cboL.Text.ToString & " Lo=" & txtLoDeg.Text.ToString & Chr(176) & txtLoMin.Text.ToString & cboLo.Text.ToString
        DataGridView1.Rows(UpdtRow).Cells(0).Value = txtVessel.Text
        DataGridView1.Rows(UpdtRow).Cells(1).Value = txtNavigator.Text
        DataGridView1.Rows(UpdtRow).Cells(2).Value = txtFrom.Text
        DataGridView1.Rows(UpdtRow).Cells(3).Value = txtTo.Text
        DataGridView1.Rows(UpdtRow).Cells(4).Value = DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss")
        DataGridView1.Rows(UpdtRow).Cells(5).Value = txtCompass.Text
        DataGridView1.Rows(UpdtRow).Cells(6).Value = txtVar.Text
        DataGridView1.Rows(UpdtRow).Cells(7).Value = txtDev.Text
        DataGridView1.Rows(UpdtRow).Cells(8).Value = txtCTrue.Text
        DataGridView1.Rows(UpdtRow).Cells(9).Value = txtSpeed.Text
        DataGridView1.Rows(UpdtRow).Cells(10).Value = LLo
        DataGridView1.Rows(UpdtRow).Cells(11).Value = cboLocType.Text
        DataGridView1.Rows(UpdtRow).Cells(12).Value = txtWeather.Text
        DataGridView1.Rows(UpdtRow).Cells(13).Value = txtRemarks.Text

        DataGridView1.Refresh()
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub btnDeleteSight_Click(sender As Object, e As EventArgs) Handles btnDeleteSight.Click
        DataSet1.Tables(tablename).Rows.RemoveAt(UpdtRow)
        DataGridView1.Refresh()
        Me.Refresh()
        Exit Sub
    End Sub
    Private Function EditUpdtFields() As Boolean
        Return True
        Exit Function
    End Function
End Class
