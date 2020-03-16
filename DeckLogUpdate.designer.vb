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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblCompass = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblZoneDT = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.txtNavigator = New System.Windows.Forms.TextBox()
        Me.lblNavigator = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = " "
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(11, 225)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.Size = New System.Drawing.Size(1365, 613)
        Me.DataGridView1.TabIndex = 0
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
        Me.btnOpenCSV.Location = New System.Drawing.Point(12, 7)
        Me.btnOpenCSV.Name = "btnOpenCSV"
        Me.btnOpenCSV.Size = New System.Drawing.Size(118, 23)
        Me.btnOpenCSV.TabIndex = 3
        Me.btnOpenCSV.Text = "Open a Deck Log"
        Me.btnOpenCSV.UseVisualStyleBackColor = False
        '
        'lblOpenFN
        '
        Me.lblOpenFN.AutoSize = True
        Me.lblOpenFN.Location = New System.Drawing.Point(136, 13)
        Me.lblOpenFN.Name = "lblOpenFN"
        Me.lblOpenFN.Size = New System.Drawing.Size(58, 13)
        Me.lblOpenFN.TabIndex = 4
        Me.lblOpenFN.Text = "Open File: "
        Me.lblOpenFN.Visible = False
        '
        'txtOpenFN
        '
        Me.txtOpenFN.Location = New System.Drawing.Point(194, 10)
        Me.txtOpenFN.Name = "txtOpenFN"
        Me.txtOpenFN.ReadOnly = True
        Me.txtOpenFN.Size = New System.Drawing.Size(900, 20)
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
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.lblCompass)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(461, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 12
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(396, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(59, 20)
        Me.TextBox1.TabIndex = 11
        '
        'lblCompass
        '
        Me.lblCompass.AutoSize = True
        Me.lblCompass.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompass.Location = New System.Drawing.Point(292, 52)
        Me.lblCompass.Name = "lblCompass"
        Me.lblCompass.Size = New System.Drawing.Size(100, 15)
        Me.lblCompass.TabIndex = 10
        Me.lblCompass.Text = "Compass Course:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(128, 50)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(144, 20)
        Me.DateTimePicker1.TabIndex = 9
        '
        'lblZoneDT
        '
        Me.lblZoneDT.AutoSize = True
        Me.lblZoneDT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoneDT.Location = New System.Drawing.Point(21, 52)
        Me.lblZoneDT.Name = "lblZoneDT"
        Me.lblZoneDT.Size = New System.Drawing.Size(102, 15)
        Me.lblZoneDT.TabIndex = 8
        Me.lblZoneDT.Text = "Zone Date / Time:"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(696, 18)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(160, 20)
        Me.txtTo.TabIndex = 7
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(667, 20)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(24, 15)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "To:"
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(502, 18)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(160, 20)
        Me.txtFrom.TabIndex = 5
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(461, 20)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(37, 15)
        Me.lblFrom.TabIndex = 4
        Me.lblFrom.Text = "From:"
        '
        'txtNavigator
        '
        Me.txtNavigator.Location = New System.Drawing.Point(295, 18)
        Me.txtNavigator.Name = "txtNavigator"
        Me.txtNavigator.Size = New System.Drawing.Size(160, 20)
        Me.txtNavigator.TabIndex = 3
        '
        'lblNavigator
        '
        Me.lblNavigator.AutoSize = True
        Me.lblNavigator.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigator.Location = New System.Drawing.Point(229, 20)
        Me.lblNavigator.Name = "lblNavigator"
        Me.lblNavigator.Size = New System.Drawing.Size(63, 15)
        Me.lblNavigator.TabIndex = 2
        Me.lblNavigator.Text = "Navigator:"
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(62, 18)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(160, 20)
        Me.txtVessel.TabIndex = 1
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(11, 20)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(44, 15)
        Me.lblVessel.TabIndex = 0
        Me.lblVessel.Text = "Vessel:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(456, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(9, 17)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "°"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(575, 52)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(59, 20)
        Me.TextBox2.TabIndex = 174
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(471, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Compass Course:"
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
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblCompass As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents lblZoneDT As Label
    Friend WithEvents txtTo As TextBox
    Friend WithEvents lblTo As Label
    Friend WithEvents txtFrom As TextBox
    Friend WithEvents lblFrom As Label
    Friend WithEvents txtNavigator As TextBox
    Friend WithEvents lblNavigator As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Public WithEvents Label6 As Label
End Class
