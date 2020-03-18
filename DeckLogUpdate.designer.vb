<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeckLogUpdate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.VesselDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NavigatorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZoneDateTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VarDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DevDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpeedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocLatLongDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeatherDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataSet2 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn14 = New System.Data.DataColumn()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExitNoSave = New System.Windows.Forms.Button()
        Me.CommonNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommonNameDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebLocationDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOpenCSV = New System.Windows.Forms.Button()
        Me.lblOpenFN = New System.Windows.Forms.Label()
        Me.txtOpenFN = New System.Windows.Forms.TextBox()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.btnInfoForm = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboLocType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClearFields = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdateExisting = New System.Windows.Forms.Button()
        Me.btnDeleteSight = New System.Windows.Forms.Button()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCTrue = New System.Windows.Forms.TextBox()
        Me.lblCTrue = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtWeather = New System.Windows.Forms.TextBox()
        Me.lblWeather = New System.Windows.Forms.Label()
        Me.cboLo = New System.Windows.Forms.ComboBox()
        Me.cboL = New System.Windows.Forms.ComboBox()
        Me.txtLDeg = New System.Windows.Forms.TextBox()
        Me.txtLoMin = New System.Windows.Forms.TextBox()
        Me.txtLoDeg = New System.Windows.Forms.TextBox()
        Me.txtLMin = New System.Windows.Forms.TextBox()
        Me.lblLoMin = New System.Windows.Forms.Label()
        Me.lblLoDeg = New System.Windows.Forms.Label()
        Me.lblDRLo = New System.Windows.Forms.Label()
        Me.lblLMin = New System.Windows.Forms.Label()
        Me.lblLDeg = New System.Windows.Forms.Label()
        Me.lblDRL = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDev = New System.Windows.Forms.ComboBox()
        Me.txtDev = New System.Windows.Forms.TextBox()
        Me.lblDev = New System.Windows.Forms.Label()
        Me.cboVar = New System.Windows.Forms.ComboBox()
        Me.txtVar = New System.Windows.Forms.TextBox()
        Me.lblVariation = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompass = New System.Windows.Forms.TextBox()
        Me.lblCompass = New System.Windows.Forms.Label()
        Me.DTDateZoneTime = New System.Windows.Forms.DateTimePicker()
        Me.lblZoneDT = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.txtNavigator = New System.Windows.Forms.TextBox()
        Me.lblNavigator = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Gold
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VesselDataGridViewTextBoxColumn, Me.NavigatorDataGridViewTextBoxColumn, Me.FromDataGridViewTextBoxColumn, Me.ToDataGridViewTextBoxColumn, Me.ZoneDateTimeDataGridViewTextBoxColumn, Me.CompassDataGridViewTextBoxColumn, Me.VarDataGridViewTextBoxColumn, Me.DevDataGridViewTextBoxColumn, Me.TrueDataGridViewTextBoxColumn, Me.SpeedDataGridViewTextBoxColumn, Me.LocLatLongDataGridViewTextBoxColumn, Me.LocTypeDataGridViewTextBoxColumn, Me.WeatherDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn})
        Me.DataGridView1.DataMember = "Table1"
        Me.DataGridView1.DataSource = Me.DataSet2
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.NullValue = " "
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Location = New System.Drawing.Point(8, 215)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1365, 613)
        Me.DataGridView1.TabIndex = 0
        '
        'VesselDataGridViewTextBoxColumn
        '
        Me.VesselDataGridViewTextBoxColumn.DataPropertyName = "Vessel"
        Me.VesselDataGridViewTextBoxColumn.HeaderText = "Vessel"
        Me.VesselDataGridViewTextBoxColumn.Name = "VesselDataGridViewTextBoxColumn"
        Me.VesselDataGridViewTextBoxColumn.ReadOnly = True
        Me.VesselDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VesselDataGridViewTextBoxColumn.Width = 49
        '
        'NavigatorDataGridViewTextBoxColumn
        '
        Me.NavigatorDataGridViewTextBoxColumn.DataPropertyName = "Navigator"
        Me.NavigatorDataGridViewTextBoxColumn.HeaderText = "Navigator"
        Me.NavigatorDataGridViewTextBoxColumn.Name = "NavigatorDataGridViewTextBoxColumn"
        Me.NavigatorDataGridViewTextBoxColumn.ReadOnly = True
        Me.NavigatorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NavigatorDataGridViewTextBoxColumn.Width = 66
        '
        'FromDataGridViewTextBoxColumn
        '
        Me.FromDataGridViewTextBoxColumn.DataPropertyName = "From"
        Me.FromDataGridViewTextBoxColumn.HeaderText = "From"
        Me.FromDataGridViewTextBoxColumn.Name = "FromDataGridViewTextBoxColumn"
        Me.FromDataGridViewTextBoxColumn.ReadOnly = True
        Me.FromDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FromDataGridViewTextBoxColumn.Width = 42
        '
        'ToDataGridViewTextBoxColumn
        '
        Me.ToDataGridViewTextBoxColumn.DataPropertyName = "To"
        Me.ToDataGridViewTextBoxColumn.HeaderText = "To"
        Me.ToDataGridViewTextBoxColumn.Name = "ToDataGridViewTextBoxColumn"
        Me.ToDataGridViewTextBoxColumn.ReadOnly = True
        Me.ToDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ToDataGridViewTextBoxColumn.Width = 26
        '
        'ZoneDateTimeDataGridViewTextBoxColumn
        '
        Me.ZoneDateTimeDataGridViewTextBoxColumn.DataPropertyName = "ZoneDateTime"
        Me.ZoneDateTimeDataGridViewTextBoxColumn.HeaderText = "ZoneDateTime"
        Me.ZoneDateTimeDataGridViewTextBoxColumn.Name = "ZoneDateTimeDataGridViewTextBoxColumn"
        Me.ZoneDateTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ZoneDateTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ZoneDateTimeDataGridViewTextBoxColumn.Width = 93
        '
        'CompassDataGridViewTextBoxColumn
        '
        Me.CompassDataGridViewTextBoxColumn.DataPropertyName = "Compass"
        Me.CompassDataGridViewTextBoxColumn.HeaderText = "Compass"
        Me.CompassDataGridViewTextBoxColumn.Name = "CompassDataGridViewTextBoxColumn"
        Me.CompassDataGridViewTextBoxColumn.ReadOnly = True
        Me.CompassDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CompassDataGridViewTextBoxColumn.Width = 62
        '
        'VarDataGridViewTextBoxColumn
        '
        Me.VarDataGridViewTextBoxColumn.DataPropertyName = "Var"
        Me.VarDataGridViewTextBoxColumn.HeaderText = "Var"
        Me.VarDataGridViewTextBoxColumn.Name = "VarDataGridViewTextBoxColumn"
        Me.VarDataGridViewTextBoxColumn.ReadOnly = True
        Me.VarDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VarDataGridViewTextBoxColumn.Width = 33
        '
        'DevDataGridViewTextBoxColumn
        '
        Me.DevDataGridViewTextBoxColumn.DataPropertyName = "Dev"
        Me.DevDataGridViewTextBoxColumn.HeaderText = "Dev"
        Me.DevDataGridViewTextBoxColumn.Name = "DevDataGridViewTextBoxColumn"
        Me.DevDataGridViewTextBoxColumn.ReadOnly = True
        Me.DevDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DevDataGridViewTextBoxColumn.Width = 33
        '
        'TrueDataGridViewTextBoxColumn
        '
        Me.TrueDataGridViewTextBoxColumn.DataPropertyName = "True"
        Me.TrueDataGridViewTextBoxColumn.HeaderText = "True"
        Me.TrueDataGridViewTextBoxColumn.Name = "TrueDataGridViewTextBoxColumn"
        Me.TrueDataGridViewTextBoxColumn.ReadOnly = True
        Me.TrueDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TrueDataGridViewTextBoxColumn.Width = 39
        '
        'SpeedDataGridViewTextBoxColumn
        '
        Me.SpeedDataGridViewTextBoxColumn.DataPropertyName = "Speed"
        Me.SpeedDataGridViewTextBoxColumn.HeaderText = "Speed"
        Me.SpeedDataGridViewTextBoxColumn.Name = "SpeedDataGridViewTextBoxColumn"
        Me.SpeedDataGridViewTextBoxColumn.ReadOnly = True
        Me.SpeedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpeedDataGridViewTextBoxColumn.Width = 45
        '
        'LocLatLongDataGridViewTextBoxColumn
        '
        Me.LocLatLongDataGridViewTextBoxColumn.DataPropertyName = "Loc Lat Long"
        Me.LocLatLongDataGridViewTextBoxColumn.HeaderText = "Loc Lat Long"
        Me.LocLatLongDataGridViewTextBoxColumn.Name = "LocLatLongDataGridViewTextBoxColumn"
        Me.LocLatLongDataGridViewTextBoxColumn.ReadOnly = True
        Me.LocLatLongDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LocLatLongDataGridViewTextBoxColumn.Width = 85
        '
        'LocTypeDataGridViewTextBoxColumn
        '
        Me.LocTypeDataGridViewTextBoxColumn.DataPropertyName = "LocType"
        Me.LocTypeDataGridViewTextBoxColumn.HeaderText = "LocType"
        Me.LocTypeDataGridViewTextBoxColumn.Name = "LocTypeDataGridViewTextBoxColumn"
        Me.LocTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.LocTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LocTypeDataGridViewTextBoxColumn.Width = 58
        '
        'WeatherDataGridViewTextBoxColumn
        '
        Me.WeatherDataGridViewTextBoxColumn.DataPropertyName = "Weather"
        Me.WeatherDataGridViewTextBoxColumn.HeaderText = "Weather"
        Me.WeatherDataGridViewTextBoxColumn.Name = "WeatherDataGridViewTextBoxColumn"
        Me.WeatherDataGridViewTextBoxColumn.ReadOnly = True
        Me.WeatherDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WeatherDataGridViewTextBoxColumn.Width = 60
        '
        'RemarksDataGridViewTextBoxColumn
        '
        Me.RemarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.HeaderText = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.Name = "RemarksDataGridViewTextBoxColumn"
        Me.RemarksDataGridViewTextBoxColumn.ReadOnly = True
        Me.RemarksDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RemarksDataGridViewTextBoxColumn.Width = 64
        '
        'DataSet2
        '
        Me.DataSet2.DataSetName = "DeckLogDataSet"
        Me.DataSet2.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14})
        Me.DataTable1.TableName = "Table1"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Vessel"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Navigator"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "From"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "To"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "ZoneDateTime"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "Compass"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Var"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "Dev"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "True"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Speed"
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "Loc Lat Long"
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "LocType"
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "Weather"
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "Remarks"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(1255, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(118, 23)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit and Save Input"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExitNoSave
        '
        Me.btnExitNoSave.BackColor = System.Drawing.Color.Red
        Me.btnExitNoSave.ForeColor = System.Drawing.Color.White
        Me.btnExitNoSave.Location = New System.Drawing.Point(1255, 33)
        Me.btnExitNoSave.Name = "btnExitNoSave"
        Me.btnExitNoSave.Size = New System.Drawing.Size(118, 23)
        Me.btnExitNoSave.TabIndex = 2
        Me.btnExitNoSave.Text = "Exit with No Save"
        Me.btnExitNoSave.UseVisualStyleBackColor = False
        '
        'CommonNameDataGridViewTextBoxColumn1
        '
        Me.CommonNameDataGridViewTextBoxColumn1.DataPropertyName = "Common Name"
        Me.CommonNameDataGridViewTextBoxColumn1.HeaderText = "Common Name"
        Me.CommonNameDataGridViewTextBoxColumn1.Name = "CommonNameDataGridViewTextBoxColumn1"
        Me.CommonNameDataGridViewTextBoxColumn1.Width = 140
        '
        'CommonNameDataGridViewTextBoxColumn2
        '
        Me.CommonNameDataGridViewTextBoxColumn2.DataPropertyName = "Common Name"
        Me.CommonNameDataGridViewTextBoxColumn2.HeaderText = "Common Name"
        Me.CommonNameDataGridViewTextBoxColumn2.Name = "CommonNameDataGridViewTextBoxColumn2"
        Me.CommonNameDataGridViewTextBoxColumn2.Width = 140
        '
        'WebLocationDataGridViewTextBoxColumn1
        '
        Me.WebLocationDataGridViewTextBoxColumn1.DataPropertyName = "Web Location"
        Me.WebLocationDataGridViewTextBoxColumn1.HeaderText = "Web Location"
        Me.WebLocationDataGridViewTextBoxColumn1.Name = "WebLocationDataGridViewTextBoxColumn1"
        Me.WebLocationDataGridViewTextBoxColumn1.Width = 130
        '
        'btnOpenCSV
        '
        Me.btnOpenCSV.BackColor = System.Drawing.Color.Yellow
        Me.btnOpenCSV.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCSV.Location = New System.Drawing.Point(13, 32)
        Me.btnOpenCSV.Name = "btnOpenCSV"
        Me.btnOpenCSV.Size = New System.Drawing.Size(118, 23)
        Me.btnOpenCSV.TabIndex = 3
        Me.btnOpenCSV.Text = "Open a Deck Log"
        Me.btnOpenCSV.UseVisualStyleBackColor = False
        '
        'lblOpenFN
        '
        Me.lblOpenFN.AutoSize = True
        Me.lblOpenFN.Location = New System.Drawing.Point(258, 42)
        Me.lblOpenFN.Name = "lblOpenFN"
        Me.lblOpenFN.Size = New System.Drawing.Size(58, 13)
        Me.lblOpenFN.TabIndex = 4
        Me.lblOpenFN.Text = "Open File: "
        Me.lblOpenFN.Visible = False
        '
        'txtOpenFN
        '
        Me.txtOpenFN.Location = New System.Drawing.Point(316, 39)
        Me.txtOpenFN.Name = "txtOpenFN"
        Me.txtOpenFN.ReadOnly = True
        Me.txtOpenFN.Size = New System.Drawing.Size(700, 20)
        Me.txtOpenFN.TabIndex = 5
        Me.txtOpenFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtOpenFN.Visible = False
        '
        'btnSaveFile
        '
        Me.btnSaveFile.BackColor = System.Drawing.Color.Blue
        Me.btnSaveFile.ForeColor = System.Drawing.Color.White
        Me.btnSaveFile.Location = New System.Drawing.Point(1133, 8)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(118, 23)
        Me.btnSaveFile.TabIndex = 6
        Me.btnSaveFile.Text = "Save Current File"
        Me.btnSaveFile.UseVisualStyleBackColor = False
        '
        'btnInfoForm
        '
        Me.btnInfoForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnInfoForm.ForeColor = System.Drawing.Color.Black
        Me.btnInfoForm.Location = New System.Drawing.Point(1133, 32)
        Me.btnInfoForm.Name = "btnInfoForm"
        Me.btnInfoForm.Size = New System.Drawing.Size(118, 23)
        Me.btnInfoForm.TabIndex = 7
        Me.btnInfoForm.Text = "Display Help Info"
        Me.btnInfoForm.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Silver
        Me.GroupBox1.Controls.Add(Me.cboLocType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnClearFields)
        Me.GroupBox1.Controls.Add(Me.btnAddNew)
        Me.GroupBox1.Controls.Add(Me.btnUpdateExisting)
        Me.GroupBox1.Controls.Add(Me.btnDeleteSight)
        Me.GroupBox1.Controls.Add(Me.txtSpeed)
        Me.GroupBox1.Controls.Add(Me.lblSpeed)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCTrue)
        Me.GroupBox1.Controls.Add(Me.lblCTrue)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.lblRemarks)
        Me.GroupBox1.Controls.Add(Me.txtWeather)
        Me.GroupBox1.Controls.Add(Me.lblWeather)
        Me.GroupBox1.Controls.Add(Me.cboLo)
        Me.GroupBox1.Controls.Add(Me.cboL)
        Me.GroupBox1.Controls.Add(Me.txtLDeg)
        Me.GroupBox1.Controls.Add(Me.txtLoMin)
        Me.GroupBox1.Controls.Add(Me.txtLoDeg)
        Me.GroupBox1.Controls.Add(Me.txtLMin)
        Me.GroupBox1.Controls.Add(Me.lblLoMin)
        Me.GroupBox1.Controls.Add(Me.lblLoDeg)
        Me.GroupBox1.Controls.Add(Me.lblDRLo)
        Me.GroupBox1.Controls.Add(Me.lblLMin)
        Me.GroupBox1.Controls.Add(Me.lblLDeg)
        Me.GroupBox1.Controls.Add(Me.lblDRL)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDev)
        Me.GroupBox1.Controls.Add(Me.txtDev)
        Me.GroupBox1.Controls.Add(Me.lblDev)
        Me.GroupBox1.Controls.Add(Me.cboVar)
        Me.GroupBox1.Controls.Add(Me.txtVar)
        Me.GroupBox1.Controls.Add(Me.lblVariation)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCompass)
        Me.GroupBox1.Controls.Add(Me.lblCompass)
        Me.GroupBox1.Controls.Add(Me.DTDateZoneTime)
        Me.GroupBox1.Controls.Add(Me.lblZoneDT)
        Me.GroupBox1.Controls.Add(Me.txtTo)
        Me.GroupBox1.Controls.Add(Me.lblTo)
        Me.GroupBox1.Controls.Add(Me.txtFrom)
        Me.GroupBox1.Controls.Add(Me.lblFrom)
        Me.GroupBox1.Controls.Add(Me.txtNavigator)
        Me.GroupBox1.Controls.Add(Me.lblNavigator)
        Me.GroupBox1.Controls.Add(Me.txtVessel)
        Me.GroupBox1.Controls.Add(Me.lblVessel)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1360, 157)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Fields"
        '
        'cboLocType
        '
        Me.cboLocType.FormattingEnabled = True
        Me.cboLocType.Items.AddRange(New Object() {"DR", "GPS", "Fix"})
        Me.cboLocType.Location = New System.Drawing.Point(1201, 55)
        Me.cboLocType.Name = "cboLocType"
        Me.cboLocType.Size = New System.Drawing.Size(59, 21)
        Me.cboLocType.TabIndex = 221
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(1137, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(66, 18)
        Me.Label5.TabIndex = 220
        Me.Label5.Text = "Loc Type:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClearFields
        '
        Me.btnClearFields.BackColor = System.Drawing.Color.Yellow
        Me.btnClearFields.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFields.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnClearFields.Location = New System.Drawing.Point(1235, 19)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(110, 23)
        Me.btnClearFields.TabIndex = 219
        Me.btnClearFields.Text = "Clear Fields"
        Me.btnClearFields.UseVisualStyleBackColor = False
        '
        'btnAddNew
        '
        Me.btnAddNew.BackColor = System.Drawing.Color.Yellow
        Me.btnAddNew.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddNew.Location = New System.Drawing.Point(890, 19)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(110, 23)
        Me.btnAddNew.TabIndex = 216
        Me.btnAddNew.Text = "Add New Log Entry"
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'btnUpdateExisting
        '
        Me.btnUpdateExisting.BackColor = System.Drawing.Color.Yellow
        Me.btnUpdateExisting.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateExisting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUpdateExisting.Location = New System.Drawing.Point(1006, 19)
        Me.btnUpdateExisting.Name = "btnUpdateExisting"
        Me.btnUpdateExisting.Size = New System.Drawing.Size(110, 23)
        Me.btnUpdateExisting.TabIndex = 217
        Me.btnUpdateExisting.Text = "Update Log Entry"
        Me.btnUpdateExisting.UseVisualStyleBackColor = False
        '
        'btnDeleteSight
        '
        Me.btnDeleteSight.BackColor = System.Drawing.Color.Red
        Me.btnDeleteSight.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteSight.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnDeleteSight.Location = New System.Drawing.Point(1119, 19)
        Me.btnDeleteSight.Name = "btnDeleteSight"
        Me.btnDeleteSight.Size = New System.Drawing.Size(110, 23)
        Me.btnDeleteSight.TabIndex = 218
        Me.btnDeleteSight.Text = "Delete Log Entry"
        Me.btnDeleteSight.UseVisualStyleBackColor = False
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(726, 54)
        Me.txtSpeed.MaxLength = 4
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(35, 20)
        Me.txtSpeed.TabIndex = 215
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpeed.Location = New System.Drawing.Point(681, 56)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(43, 15)
        Me.lblSpeed.TabIndex = 214
        Me.lblSpeed.Text = "Speed:"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(663, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(9, 17)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "°"
        '
        'txtCTrue
        '
        Me.txtCTrue.Enabled = False
        Me.txtCTrue.Location = New System.Drawing.Point(631, 53)
        Me.txtCTrue.MaxLength = 3
        Me.txtCTrue.Name = "txtCTrue"
        Me.txtCTrue.ReadOnly = True
        Me.txtCTrue.Size = New System.Drawing.Size(30, 20)
        Me.txtCTrue.TabIndex = 212
        '
        'lblCTrue
        '
        Me.lblCTrue.AutoSize = True
        Me.lblCTrue.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTrue.Location = New System.Drawing.Point(594, 55)
        Me.lblCTrue.Name = "lblCTrue"
        Me.lblCTrue.Size = New System.Drawing.Size(35, 15)
        Me.lblCTrue.TabIndex = 211
        Me.lblCTrue.Text = "True:"
        Me.lblCTrue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(83, 104)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRemarks.Size = New System.Drawing.Size(570, 41)
        Me.txtRemarks.TabIndex = 210
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.Location = New System.Drawing.Point(23, 106)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 15)
        Me.lblRemarks.TabIndex = 209
        Me.lblRemarks.Text = "Remarks:"
        '
        'txtWeather
        '
        Me.txtWeather.Location = New System.Drawing.Point(83, 78)
        Me.txtWeather.Name = "txtWeather"
        Me.txtWeather.Size = New System.Drawing.Size(570, 20)
        Me.txtWeather.TabIndex = 208
        '
        'lblWeather
        '
        Me.lblWeather.AutoSize = True
        Me.lblWeather.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeather.Location = New System.Drawing.Point(21, 80)
        Me.lblWeather.Name = "lblWeather"
        Me.lblWeather.Size = New System.Drawing.Size(55, 15)
        Me.lblWeather.TabIndex = 207
        Me.lblWeather.Text = "Weather:"
        '
        'cboLo
        '
        Me.cboLo.BackColor = System.Drawing.SystemColors.Window
        Me.cboLo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLo.Items.AddRange(New Object() {"W", "E"})
        Me.cboLo.Location = New System.Drawing.Point(1092, 53)
        Me.cboLo.Name = "cboLo"
        Me.cboLo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLo.Size = New System.Drawing.Size(41, 24)
        Me.cboLo.TabIndex = 200
        '
        'cboL
        '
        Me.cboL.BackColor = System.Drawing.SystemColors.Window
        Me.cboL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboL.Items.AddRange(New Object() {"N", "S"})
        Me.cboL.Location = New System.Drawing.Point(894, 53)
        Me.cboL.Name = "cboL"
        Me.cboL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboL.Size = New System.Drawing.Size(41, 24)
        Me.cboL.TabIndex = 197
        '
        'txtLDeg
        '
        Me.txtLDeg.AcceptsReturn = True
        Me.txtLDeg.BackColor = System.Drawing.SystemColors.Window
        Me.txtLDeg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLDeg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLDeg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLDeg.HideSelection = False
        Me.txtLDeg.Location = New System.Drawing.Point(822, 53)
        Me.txtLDeg.MaxLength = 2
        Me.txtLDeg.Name = "txtLDeg"
        Me.txtLDeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLDeg.Size = New System.Drawing.Size(25, 22)
        Me.txtLDeg.TabIndex = 195
        '
        'txtLoMin
        '
        Me.txtLoMin.AcceptsReturn = True
        Me.txtLoMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLoMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLoMin.HideSelection = False
        Me.txtLoMin.Location = New System.Drawing.Point(1048, 54)
        Me.txtLoMin.MaxLength = 4
        Me.txtLoMin.Name = "txtLoMin"
        Me.txtLoMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLoMin.Size = New System.Drawing.Size(33, 22)
        Me.txtLoMin.TabIndex = 199
        '
        'txtLoDeg
        '
        Me.txtLoDeg.AcceptsReturn = True
        Me.txtLoDeg.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoDeg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLoDeg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoDeg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLoDeg.HideSelection = False
        Me.txtLoDeg.Location = New System.Drawing.Point(1006, 54)
        Me.txtLoDeg.MaxLength = 3
        Me.txtLoDeg.Name = "txtLoDeg"
        Me.txtLoDeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLoDeg.Size = New System.Drawing.Size(33, 22)
        Me.txtLoDeg.TabIndex = 198
        '
        'txtLMin
        '
        Me.txtLMin.AcceptsReturn = True
        Me.txtLMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtLMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLMin.HideSelection = False
        Me.txtLMin.Location = New System.Drawing.Point(854, 53)
        Me.txtLMin.MaxLength = 4
        Me.txtLMin.Name = "txtLMin"
        Me.txtLMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLMin.Size = New System.Drawing.Size(33, 22)
        Me.txtLMin.TabIndex = 196
        '
        'lblLoMin
        '
        Me.lblLoMin.BackColor = System.Drawing.SystemColors.Window
        Me.lblLoMin.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoMin.Location = New System.Drawing.Point(1081, 55)
        Me.lblLoMin.Name = "lblLoMin"
        Me.lblLoMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLoMin.Size = New System.Drawing.Size(9, 17)
        Me.lblLoMin.TabIndex = 206
        Me.lblLoMin.Text = "'"
        '
        'lblLoDeg
        '
        Me.lblLoDeg.BackColor = System.Drawing.SystemColors.Window
        Me.lblLoDeg.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoDeg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoDeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoDeg.Location = New System.Drawing.Point(1040, 55)
        Me.lblLoDeg.Name = "lblLoDeg"
        Me.lblLoDeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLoDeg.Size = New System.Drawing.Size(9, 17)
        Me.lblLoDeg.TabIndex = 205
        Me.lblLoDeg.Text = "°"
        '
        'lblDRLo
        '
        Me.lblDRLo.BackColor = System.Drawing.Color.Silver
        Me.lblDRLo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDRLo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDRLo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDRLo.Location = New System.Drawing.Point(939, 56)
        Me.lblDRLo.Name = "lblDRLo"
        Me.lblDRLo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDRLo.Size = New System.Drawing.Size(66, 18)
        Me.lblDRLo.TabIndex = 204
        Me.lblDRLo.Text = "Longitude:"
        Me.lblDRLo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLMin
        '
        Me.lblLMin.BackColor = System.Drawing.SystemColors.Window
        Me.lblLMin.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLMin.Location = New System.Drawing.Point(887, 55)
        Me.lblLMin.Name = "lblLMin"
        Me.lblLMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLMin.Size = New System.Drawing.Size(9, 17)
        Me.lblLMin.TabIndex = 203
        Me.lblLMin.Text = "'"
        '
        'lblLDeg
        '
        Me.lblLDeg.BackColor = System.Drawing.SystemColors.Window
        Me.lblLDeg.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLDeg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLDeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLDeg.Location = New System.Drawing.Point(847, 55)
        Me.lblLDeg.Name = "lblLDeg"
        Me.lblLDeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLDeg.Size = New System.Drawing.Size(9, 17)
        Me.lblLDeg.TabIndex = 202
        Me.lblLDeg.Text = "°"
        '
        'lblDRL
        '
        Me.lblDRL.BackColor = System.Drawing.Color.Silver
        Me.lblDRL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDRL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDRL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDRL.Location = New System.Drawing.Point(768, 54)
        Me.lblDRL.Name = "lblDRL"
        Me.lblDRL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDRL.Size = New System.Drawing.Size(56, 20)
        Me.lblDRL.TabIndex = 201
        Me.lblDRL.Text = "Latitude:"
        Me.lblDRL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(546, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(9, 17)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "°"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(439, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(9, 17)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "°"
        '
        'cboDev
        '
        Me.cboDev.FormattingEnabled = True
        Me.cboDev.Items.AddRange(New Object() {"W", "E"})
        Me.cboDev.Location = New System.Drawing.Point(557, 52)
        Me.cboDev.Name = "cboDev"
        Me.cboDev.Size = New System.Drawing.Size(35, 21)
        Me.cboDev.TabIndex = 178
        '
        'txtDev
        '
        Me.txtDev.Location = New System.Drawing.Point(519, 53)
        Me.txtDev.MaxLength = 2
        Me.txtDev.Name = "txtDev"
        Me.txtDev.Size = New System.Drawing.Size(25, 20)
        Me.txtDev.TabIndex = 177
        '
        'lblDev
        '
        Me.lblDev.AutoSize = True
        Me.lblDev.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDev.Location = New System.Drawing.Point(489, 55)
        Me.lblDev.Name = "lblDev"
        Me.lblDev.Size = New System.Drawing.Size(32, 15)
        Me.lblDev.TabIndex = 176
        Me.lblDev.Text = "Dev:"
        Me.lblDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboVar
        '
        Me.cboVar.FormattingEnabled = True
        Me.cboVar.Items.AddRange(New Object() {"W", "E"})
        Me.cboVar.Location = New System.Drawing.Point(448, 52)
        Me.cboVar.Name = "cboVar"
        Me.cboVar.Size = New System.Drawing.Size(35, 21)
        Me.cboVar.TabIndex = 175
        '
        'txtVar
        '
        Me.txtVar.Location = New System.Drawing.Point(413, 53)
        Me.txtVar.MaxLength = 2
        Me.txtVar.Name = "txtVar"
        Me.txtVar.Size = New System.Drawing.Size(25, 20)
        Me.txtVar.TabIndex = 174
        '
        'lblVariation
        '
        Me.lblVariation.AutoSize = True
        Me.lblVariation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariation.Location = New System.Drawing.Point(385, 55)
        Me.lblVariation.Name = "lblVariation"
        Me.lblVariation.Size = New System.Drawing.Size(27, 15)
        Me.lblVariation.TabIndex = 173
        Me.lblVariation.Text = "Var:"
        Me.lblVariation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(370, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(9, 17)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "°"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(403, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 12
        '
        'txtCompass
        '
        Me.txtCompass.Location = New System.Drawing.Point(338, 52)
        Me.txtCompass.MaxLength = 3
        Me.txtCompass.Name = "txtCompass"
        Me.txtCompass.Size = New System.Drawing.Size(30, 20)
        Me.txtCompass.TabIndex = 11
        '
        'lblCompass
        '
        Me.lblCompass.AutoSize = True
        Me.lblCompass.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompass.Location = New System.Drawing.Point(278, 54)
        Me.lblCompass.Name = "lblCompass"
        Me.lblCompass.Size = New System.Drawing.Size(59, 15)
        Me.lblCompass.TabIndex = 10
        Me.lblCompass.Text = "Compass:"
        Me.lblCompass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTDateZoneTime
        '
        Me.DTDateZoneTime.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.DTDateZoneTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDateZoneTime.Location = New System.Drawing.Point(128, 50)
        Me.DTDateZoneTime.Name = "DTDateZoneTime"
        Me.DTDateZoneTime.ShowUpDown = True
        Me.DTDateZoneTime.Size = New System.Drawing.Size(144, 20)
        Me.DTDateZoneTime.TabIndex = 9
        '
        'lblZoneDT
        '
        Me.lblZoneDT.AutoSize = True
        Me.lblZoneDT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoneDT.Location = New System.Drawing.Point(23, 52)
        Me.lblZoneDT.Name = "lblZoneDT"
        Me.lblZoneDT.Size = New System.Drawing.Size(102, 15)
        Me.lblZoneDT.TabIndex = 8
        Me.lblZoneDT.Text = "Zone Date / Time:"
        Me.lblZoneDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(712, 20)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(160, 20)
        Me.txtTo.TabIndex = 7
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(683, 22)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(24, 15)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "To:"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(518, 20)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(160, 20)
        Me.txtFrom.TabIndex = 5
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(477, 22)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(37, 15)
        Me.lblFrom.TabIndex = 4
        Me.lblFrom.Text = "From:"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNavigator
        '
        Me.txtNavigator.Location = New System.Drawing.Point(311, 20)
        Me.txtNavigator.Name = "txtNavigator"
        Me.txtNavigator.Size = New System.Drawing.Size(160, 20)
        Me.txtNavigator.TabIndex = 3
        '
        'lblNavigator
        '
        Me.lblNavigator.AutoSize = True
        Me.lblNavigator.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigator.Location = New System.Drawing.Point(245, 22)
        Me.lblNavigator.Name = "lblNavigator"
        Me.lblNavigator.Size = New System.Drawing.Size(63, 15)
        Me.lblNavigator.TabIndex = 2
        Me.lblNavigator.Text = "Navigator:"
        Me.lblNavigator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(72, 20)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(160, 20)
        Me.txtVessel.TabIndex = 1
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(24, 23)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(44, 15)
        Me.lblVessel.TabIndex = 0
        Me.lblVessel.Text = "Vessel:"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DeckLogUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1379, 850)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnInfoForm)
        Me.Controls.Add(Me.btnSaveFile)
        Me.Controls.Add(Me.txtOpenFN)
        Me.Controls.Add(Me.lblOpenFN)
        Me.Controls.Add(Me.btnOpenCSV)
        Me.Controls.Add(Me.btnExitNoSave)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DeckLogUpdate"
        Me.Text = "Deck Log Updater"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExit As Button
    Friend WithEvents btnExitNoSave As Button
    Friend WithEvents CommonNameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents CommonNameDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents WebLocationDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents btnOpenCSV As Button
    Friend WithEvents lblOpenFN As Label
    Friend WithEvents txtOpenFN As TextBox
    Friend WithEvents btnSaveFile As Button
    Friend WithEvents btnInfoForm As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCompass As TextBox
    Friend WithEvents lblCompass As Label
    Friend WithEvents DTDateZoneTime As DateTimePicker
    Friend WithEvents lblZoneDT As Label
    Friend WithEvents txtTo As TextBox
    Friend WithEvents lblTo As Label
    Friend WithEvents txtFrom As TextBox
    Friend WithEvents lblFrom As Label
    Friend WithEvents txtNavigator As TextBox
    Friend WithEvents lblNavigator As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents txtVar As TextBox
    Friend WithEvents lblVariation As Label
    Public WithEvents Label6 As Label
    Friend WithEvents cboDev As ComboBox
    Friend WithEvents txtDev As TextBox
    Friend WithEvents lblDev As Label
    Friend WithEvents cboVar As ComboBox
    Public WithEvents Label3 As Label
    Public WithEvents Label2 As Label
    Friend WithEvents txtSpeed As TextBox
    Friend WithEvents lblSpeed As Label
    Public WithEvents Label4 As Label
    Friend WithEvents txtCTrue As TextBox
    Friend WithEvents lblCTrue As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtWeather As TextBox
    Friend WithEvents lblWeather As Label
    Public WithEvents cboLo As ComboBox
    Public WithEvents cboL As ComboBox
    Public WithEvents txtLDeg As TextBox
    Public WithEvents txtLoMin As TextBox
    Public WithEvents txtLoDeg As TextBox
    Public WithEvents txtLMin As TextBox
    Public WithEvents lblLoMin As Label
    Public WithEvents lblLoDeg As Label
    Public WithEvents lblDRLo As Label
    Public WithEvents lblLMin As Label
    Public WithEvents lblLDeg As Label
    Public WithEvents lblDRL As Label
    Friend WithEvents btnClearFields As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdateExisting As Button
    Friend WithEvents btnDeleteSight As Button
    Friend WithEvents cboLocType As ComboBox
    Public WithEvents Label5 As Label
    Friend WithEvents DataSet2 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
    Friend WithEvents DataColumn6 As DataColumn
    Friend WithEvents DataColumn7 As DataColumn
    Friend WithEvents DataColumn8 As DataColumn
    Friend WithEvents DataColumn9 As DataColumn
    Friend WithEvents DataColumn10 As DataColumn
    Friend WithEvents DataColumn11 As DataColumn
    Friend WithEvents DataColumn12 As DataColumn
    Friend WithEvents DataColumn13 As DataColumn
    Friend WithEvents DataColumn14 As DataColumn
    Friend WithEvents VesselDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NavigatorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FromDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ToDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ZoneDateTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CompassDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VarDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DevDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TrueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SpeedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocLatLongDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WeatherDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
