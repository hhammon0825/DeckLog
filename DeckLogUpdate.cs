using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DeckLog
{
    public partial class DeckLogUpdate
    {
        public DeckLogUpdate()
        {
            InitializeComponent();
        }

        public string FName = "./DeckLog/";
        public bool ReadError = false;
        public bool FileLoading = false;
        public bool InitialLoad = false;
        public bool FileRead = false;
        public bool SortingDG = false;
        public bool IsUpdated = false;
        public string SLOpenFName = "";
        public string tablename = "Table1";
        public DataSet DataSet1;
        public string[] HdrStr = new[] { "Vessel", "Navigator", "From", "To", "Log Type", "Log DateTime", "Course Psc", "Var", "Dev", "Course True", "Speed", "Position L/Lo", "Weather Notes", "Log Entry Notes", "ElapsedTime", "Distance", "Calc Dest", "Calc True", "Calc Speed", "Set", "Drift", "Eval Basis" };
        public string[] NullStr = new[] { Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString, Constants.vbNullString };
        public int UpdtRow = 0;

        public struct DLUpdate
        {
            public string Vessel;
            public string Navigator;
            public string LocFrom;
            public string LocTo;
            public string DateZoneTime;
            public string Compass;
            public int CompassI;
            public string Var;
            public string VarEW;
            public decimal VarI;
            public string Dev;
            public string DevEW;
            public decimal DevI;
            public string CTrue;
            public int CTrueI;
            public string Speed;
            public decimal SpeedI;
            public string PositionLatLong;
            public int LDegI;
            public decimal LMinI;
            public string LNS;
            public decimal LatDecimal;
            public int LoDegI;
            public decimal LoMinI;
            public string LoEW;
            public decimal LongDecimal;
            public string LogType;
            public string Weather;
            public string Remarks;
            public decimal Distance;
            public TimeSpan Elapsed;
            public int CMG;
            public decimal SMG;
            public int SetDir;
            public decimal Drift;
            public int DBRowNum;
            public string DestLatLongStr;
            public int DestLDegI;
            public decimal DestLMinI;
            public string DestLNS;
            public decimal DestLatDecimal;
            public int DestLoDegI;
            public decimal DestLoMinI;
            public string DestLoEW;
            public decimal DestLongDecimal;
            public int DestTrueI;
            public decimal DestDistance;
            public decimal DestSpeed;
            public string DestEstArrival;
            public string DestEstElapsed;
        }

        public DLUpdate UpdtRtn;
        public DLUpdate CurrRow;
        public DLUpdate PrevRow;

        private void Form1_Load(object sender, EventArgs e)
        {
            string DefFName = "DeckLog" + DateAndTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            InitialLoad = true;
            FName += DefFName;
            DataSet1 = new DataSet();
            DataSet1.Tables.Add(tablename);
            DataSet1.DataSetName = tablename;
            this.DataGridView1.DataSource = DataSet1;
            for (int i = 0, loopTo = Information.UBound(HdrStr); i <= loopTo; i++)
            {
                DataSet1.Tables[tablename].Columns.Add(HdrStr[i]);
                DataSet1.Tables[tablename].Columns[i].AllowDBNull = false;
                DataSet1.Tables[tablename].Columns[i].DefaultValue = "";
            }

            DataSet1.Tables[tablename].Rows.Add(NullStr);
            // DataSet1.Tables(tablename).Rows.RemoveAt(0)
            this.DataGridView1.DataSource = DataSet1.Tables[0].DefaultView;
            for (int i = 0, loopTo1 = this.DataGridView1.Columns.Count - 1; i <= loopTo1; i++)
            {
                this.DataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            this.DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.DataGridView1.Columns[12].MinimumWidth = 250;
            this.DataGridView1.Columns[13].MinimumWidth = 250;
            this.txtVar.Text = Conversions.ToString(0);
            this.txtDev.Text = Conversions.ToString(0);
            SortDataGridonDate();
            this.DataGridView1.Refresh();
            ResetScreenFields();
            this.btnDeleteSight.Visible = false;
            this.btnUpdateExisting.Visible = false;
            this.Show();
            this.Refresh();
            InitialLoad = false;
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveDataGrid();
            IsUpdated = false;
            this.Close();
        }

        private void SaveDataGrid()
        {
            var saveFileDialog1 = new SaveFileDialog();

            // Dim dirstr As String = FileIO.FileSystem.CurrentDirectory
            saveFileDialog1.InitialDirectory = "./DeckLog/";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            saveFileDialog1.Title = "Open Deck Log File";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    return;
                }

                FName = saveFileDialog1.FileName;
            }

            var textstr = new System.Text.StringBuilder();
            string FileHdrStr = Constants.vbNullString;
            for (int i = 0, loopTo = Information.UBound(HdrStr); i <= loopTo; i++)
            {
                if (i > 0)
                {
                    textstr.Append(",");
                }

                textstr.Append(HdrStr[i]);
            }

            textstr.AppendLine();
            for (int x = 0, loopTo1 = this.DataGridView1.Rows.Count - 1; x <= loopTo1; x++)
            {
                if (Information.IsNothing(this.DataGridView1.Rows[x].Cells[0].Value) == false)
                {
                    for (int v = 0, loopTo2 = this.DataGridView1.Columns.Count - 1; v <= loopTo2; v++)
                    {
                        // extracting cell value from 0 to 9 and add it on list
                        if (v > 0)
                        {
                            textstr.Append(",");
                        }

                        string tempstr = this.DataGridView1.Rows[x].Cells[v].Value.ToString();
                        tempstr = tempstr.Replace(",", ""); // remove any commas input into any field so csv file is not corrupted
                        textstr.Append(tempstr);
                    }
                }
                // adding new line to text
                textstr.AppendLine();
            }

            System.IO.File.WriteAllText(FName, textstr.ToString());
            SLOpenFName = FName;
            this.lblOpenFN.Visible = true;
            this.txtOpenFN.Visible = true;
            this.txtOpenFN.Text = SLOpenFName;
            return;
        }

        private void btnExitNoSave_Click(object sender, EventArgs e)
        {
            if (IsUpdated == true)
            {
                var MsgBack = Interaction.MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data");
                if (MsgBack == MsgBoxResult.Yes)
                {
                    SaveDataGrid();
                }

                IsUpdated = false;
            }

            this.Close();
            return;
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader myStream = null;
            var openFileDialog1 = new OpenFileDialog();
            if (IsUpdated == true)
            {
                var MsgBack = Interaction.MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data");
                if (MsgBack == MsgBoxResult.Yes)
                {
                    SaveDataGrid();
                }

                IsUpdated = false;
            }

            FileLoading = true;
            DataSet1.Tables[tablename].Clear();

            // Dim dirstr As String = FileIO.FileSystem.CurrentDirectory
            openFileDialog1.InitialDirectory = "./DeckLog/";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            openFileDialog1.Title = "Open Deck Log File";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    return;
                }

                ReadError = false;
                int ReadNum = 0;
                try
                {
                    myStream = new System.IO.StreamReader(openFileDialog1.FileName);
                    if (myStream is object)
                    {
                        FName = openFileDialog1.FileName;
                        SLOpenFName = openFileDialog1.FileName;
                        this.lblOpenFN.Visible = true;
                        this.txtOpenFN.Visible = true;
                        this.txtOpenFN.Text = SLOpenFName;
                        string allData = myStream.ReadToEnd();
                        var rows = allData.Split(Conversions.ToChar(Constants.vbCrLf)); // ("\r".ToCharArray())
                        int incr1 = 0;
                        foreach (string r in rows)
                        {
                            r = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                            if (ReadNum == 0)
                            {
                                r = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                                var items = r.Split(',');
                            }
                            // For ctr As Integer = 0 To UBound(items)
                            // Set1.Tables(tablename).Columns.Add(items(ctr))
                            // Next
                            else
                            {
                                r = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                                var items1 = r.Split(',');
                                if (!string.IsNullOrEmpty(items1[0]) & items1[0] != default)
                                {
                                    DataSet1.Tables[tablename].Rows.Add(items1);
                                }
                            }

                            ReadNum += 1;
                            incr1 += 1;
                        }

                        myStream.Close();
                        this.btnSaveFile.Visible = true;
                        this.btnExit.Visible = true;
                    }

                    myStream.Dispose();
                    this.DataGridView1.DataSource = DataSet1.Tables[0].DefaultView;
                    SortDataGridonDate();
                    evaluateDG();
                    this.DataGridView1.Refresh();
                    FileLoading = false;
                    this.Refresh();
                }
                catch (Exception Ex)
                {
                    ErrorMsgBox("Cannot read file from disk. Original error: " + Ex.Message);
                }
                finally
                {
                    // Check this again, since we need to make sure we didn't throw an exception on open.
                    if (myStream is object)
                    {
                        myStream.Close();
                    }
                }
            }
            else
            {
                this.btnSaveFile.Visible = false;
                this.btnExit.Visible = false;
            }
        }

        private void ErrorMsgBox(string ErrMsg)
        {
            MessageBox.Show(ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            return;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveDataGrid();
            IsUpdated = false;
            return;
        }

        private void btnInfoForm_Click(object sender, EventArgs e)
        {
            DeckLog.My.MyProject.Forms.DeckLogHelp.Show();
            return;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (FileLoading == true)
            {
                return;
            }

            if (InitialLoad == true)
            {
                return;
            }

            if (SortingDG == true)
            {
                return;
            }

            int n;
            if (Information.IsNothing(this.DataGridView1.CurrentRow.Index)) // Or DataGridView1.CurrentRow.Index = vbNull Then
            {
                return;
            }
            else
            {
                n = this.DataGridView1.CurrentRow.Index;
            }

            if (Information.IsNothing(this.DataGridView1.Rows[n].Cells[0].Value))
            {
                return;
            }

            UpdtRow = this.DataGridView1.CurrentRow.Index;

            // The order of these variable and the integer indexs contained in each MUST match the order of the fields in the data grid
            // Cell 0 = Vessel name  
            // Cell 1 = Navigator name  
            // Cell 2 = From location name   
            // Cell 3 = To location name 
            // Cell 4 = L/Lo loc type 
            // Cell 5 = Zone Date & time String MM/dd/yyyy HH:mm:ss 
            // Cell 6 = Compass course string 
            // Cell 7 = Variation string 
            // Cell 8 = Deviation string
            // Cell 9 = Computed True Course string  
            // Cell 10 = DR Speed string  
            // Cell 11 = Latitude / Longitude string 
            // Cell 12 = Weather string   
            // Cell 13 = Remarks string
            // Cell 14 = Elapsed Time from Lat/Long to Dest Lat/Long
            // Cell 15 = Distance in nm from Lat/Long to Dest Lat/Long
            // Cell 16 = Calculated Destination Lat/Long
            // Cell 17 = Calculated True Course to destination
            // Cell 18 = Calculated Speed to make destination
            // Cell 19 = Calculated Set between two GPS/Fix locations
            // Cell 20 = Calculated Drift between two GPS/Fix locations
            // Cell 21 = Eval Based On string (filled in in EvaluatedDG subroutine)

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[0].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Vessel = Conversions.ToString(this.DataGridView1.Rows[n].Cells[0].Value);
                this.txtVessel.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[0].Value);
            }
            else
            {
                UpdtRtn.Vessel = Constants.vbNullString;
                this.txtVessel.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[1].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Navigator = Conversions.ToString(this.DataGridView1.Rows[n].Cells[1].Value);
                this.txtNavigator.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[1].Value);
            }
            else
            {
                UpdtRtn.Navigator = Constants.vbNullString;
                this.txtNavigator.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[2].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.LocFrom = Conversions.ToString(this.DataGridView1.Rows[n].Cells[2].Value);
                this.txtFrom.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[2].Value);
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[3].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.LocTo = Conversions.ToString(this.DataGridView1.Rows[n].Cells[3].Value);
                this.txtTo.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[3].Value);
            }
            else
            {
                UpdtRtn.LocTo = Constants.vbNullString;
                this.txtTo.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[4].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.LogType = Conversions.ToString(this.DataGridView1.Rows[n].Cells[4].Value);
                this.cboLocType.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[4].Value);
            }
            else
            {
                UpdtRtn.LogType = Constants.vbNullString;
                this.cboLocType.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[5].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.DateZoneTime = Conversions.ToString(this.DataGridView1.Rows[n].Cells[5].Value);
                this.DTDateZoneTime.Value = Convert.ToDateTime(this.DataGridView1.Rows[n].Cells[5].Value);
            }
            else
            {
                UpdtRtn.DateZoneTime = DateAndTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                this.DTDateZoneTime.Value = DateAndTime.Now;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[6].Value, Constants.vbNullString, false)))
            {
                int tlen = this.DataGridView1.Rows[n].Cells[6].Value.ToString().Length;
                UpdtRtn.Compass = this.DataGridView1.Rows[n].Cells[6].Value.ToString().Substring(0, tlen - 1);
                this.txtCompass.Text = this.DataGridView1.Rows[n].Cells[6].Value.ToString().Substring(0, tlen - 1);
            }
            else
            {
                UpdtRtn.Compass = Constants.vbNullString;
                this.txtCompass.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[7].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Var = Conversions.ToString(this.DataGridView1.Rows[n].Cells[7].Value);
                UpdtRtn.VarEW = Conversions.ToString(UpdtRtn.Var.Last());
                UpdtRtn.Var = UpdtRtn.Var.Substring(0, UpdtRtn.Var.Length - 1);
                this.txtVar.Text = UpdtRtn.Var;
                this.cboVar.Text = UpdtRtn.VarEW;
            }
            else
            {
                UpdtRtn.Var = Conversions.ToString(0);
                this.txtVar.Text = Conversions.ToString(0);
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[8].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Dev = Conversions.ToString(this.DataGridView1.Rows[n].Cells[8].Value);
                UpdtRtn.DevEW = Conversions.ToString(UpdtRtn.Dev.Last());
                UpdtRtn.Dev = UpdtRtn.Dev.Substring(0, UpdtRtn.Dev.Length - 1);
                this.txtDev.Text = UpdtRtn.Dev;
                this.cboDev.Text = UpdtRtn.DevEW;
            }
            else
            {
                UpdtRtn.Dev = Conversions.ToString(0);
                this.txtDev.Text = Conversions.ToString(0);
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[9].Value, Constants.vbNullString, false)))
            {
                int tlen = this.DataGridView1.Rows[n].Cells[9].Value.ToString().Length;
                UpdtRtn.CTrue = this.DataGridView1.Rows[n].Cells[9].Value.ToString().Substring(0, tlen - 1);
                this.txtCTrue.Text = this.DataGridView1.Rows[n].Cells[9].Value.ToString().Substring(0, tlen - 1);
            }
            else
            {
                UpdtRtn.CTrue = Constants.vbNullString;
                this.txtCTrue.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[10].Value, Constants.vbNullString, false)))
            {
                int tlen = this.DataGridView1.Rows[n].Cells[10].Value.ToString().Length;
                UpdtRtn.Speed = this.DataGridView1.Rows[n].Cells[10].Value.ToString().Substring(0, tlen - 2);
                this.txtSpeed.Text = this.DataGridView1.Rows[n].Cells[10].Value.ToString().Substring(0, tlen - 2);
            }
            else
            {
                UpdtRtn.Speed = Constants.vbNullString;
                this.txtSpeed.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[11].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.PositionLatLong = Conversions.ToString(this.DataGridView1.Rows[n].Cells[11].Value);
                string LLo = Conversions.ToString(this.DataGridView1.Rows[n].Cells[11].Value);
                int LPos = LLo.IndexOf("=");
                int LDegPos = LLo.IndexOf((char)176);
                int LMinPos = LLo.IndexOf("'");
                int LoPos = LLo.IndexOf("=", LPos + 1);
                int LoDegPos = LLo.IndexOf((char)176, LDegPos + 1);
                int LoMinPos = LLo.IndexOf("'", LMinPos + 1);
                this.txtLDeg.Text = LLo.Substring(LPos + 1, LDegPos - 1 - (LPos + 1) + 1);
                this.txtLMin.Text = LLo.Substring(LDegPos + 1, LMinPos - 1 - (LDegPos + 1) + 1);
                this.cboL.Text = LLo.Substring(LMinPos + 1, 1);
                this.txtLoDeg.Text = LLo.Substring(LoPos + 1, LoDegPos - 1 - (LoPos + 1) + 1);
                this.txtLoMin.Text = LLo.Substring(LoDegPos + 1, LoMinPos - 1 - (LoDegPos + 1) + 1);
                this.cboLo.Text = LLo.Substring(LoMinPos + 1, 1);
            }
            else
            {
                UpdtRtn.PositionLatLong = Constants.vbNullString;
                this.txtLDeg.Clear();
                this.txtLMin.Clear();
                this.cboL.SelectedIndex = 0;
                this.txtLoDeg.Clear();
                this.txtLoMin.Clear();
                this.cboLo.SelectedIndex = 0;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[12].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Weather = Conversions.ToString(this.DataGridView1.Rows[n].Cells[12].Value);
                this.txtWeather.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[12].Value);
            }
            else
            {
                UpdtRtn.Weather = Constants.vbNullString;
                this.txtWeather.Text = Constants.vbNullString;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[n].Cells[13].Value, Constants.vbNullString, false)))
            {
                UpdtRtn.Remarks = Conversions.ToString(this.DataGridView1.Rows[n].Cells[13].Value);
                this.txtRemarks.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[13].Value);
            }
            else
            {
                UpdtRtn.Remarks = Constants.vbNullString;
                this.txtRemarks.Text = Constants.vbNullString;
            }

            if ((UpdtRtn.LogType ?? "") == "Plan")
            {
                this.txtDestElapsed.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[14].Value);
                UpdtRtn.DestEstElapsed = Conversions.ToString(this.DataGridView1.Rows[n].Cells[14].Value);
                this.txtDestDist.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[15].Value);
                UpdtRtn.DestDistance = Convert.ToDecimal(this.DataGridView1.Rows[n].Cells[15].Value.ToString().Substring(0, this.txtDestDist.Text.ToString().Length - 2));
                UpdtRtn.DestLatLongStr = Conversions.ToString(this.DataGridView1.Rows[n].Cells[16].Value);
                string DestLLo = Conversions.ToString(this.DataGridView1.Rows[n].Cells[16].Value);
                int LPos = DestLLo.IndexOf("=");
                int LDegPos = DestLLo.IndexOf((char)176);
                int LMinPos = DestLLo.IndexOf("'");
                int LoPos = DestLLo.IndexOf("=", LPos + 1);
                int LoDegPos = DestLLo.IndexOf((char)176, LDegPos + 1);
                int LoMinPos = DestLLo.IndexOf("'", LMinPos + 1);
                this.txtDestLDeg.Text = DestLLo.Substring(LPos + 1, LDegPos - 1 - (LPos + 1) + 1);
                this.txtDestLMin.Text = DestLLo.Substring(LDegPos + 1, LMinPos - 1 - (LDegPos + 1) + 1);
                this.cboDestL.Text = DestLLo.Substring(LMinPos + 1, 1);
                this.txtDestLoDeg.Text = DestLLo.Substring(LoPos + 1, LoDegPos - 1 - (LoPos + 1) + 1);
                this.txtDestLoMin.Text = DestLLo.Substring(LoDegPos + 1, LoMinPos - 1 - (LoDegPos + 1) + 1);
                this.cboDestLo.Text = DestLLo.Substring(LoMinPos + 1, 1);
                this.txtDestTrue.Text = Conversions.ToString(this.DataGridView1.Rows[n].Cells[17].Value);
                UpdtRtn.DestTrueI = Convert.ToInt32(this.DataGridView1.Rows[n].Cells[17].Value.ToString().Substring(0, this.txtDestTrue.Text.ToString().Length - 1));
                int Pos1 = this.txtRemarks.Text.IndexOf(":");
                int Len1 = this.txtRemarks.Text.Length - (Pos1 + 1);
                this.txtEstArrival.Text = this.txtRemarks.Text.Substring(Pos1 + 1, Len1);
            }

            this.btnUpdateExisting.Visible = true;
            this.btnDeleteSight.Visible = true;
            this.Refresh();
            return;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.btnDeleteSight.Visible = true;
            this.btnUpdateExisting.Visible = true;
            if (EditUpdtFields() == false)
            {
                this.Refresh();
                return;
            }

            if ((this.cboLocType.Text ?? "") == "Plan")
            {
                if (EditPlanFields() == false)
                {
                    this.Refresh();
                    return;
                }
            }

            string LLo = "L=" + this.txtLDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtLMin.Text.ToString() + "'" + this.cboL.Text.ToString() + " Lo=" + this.txtLoDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtLoMin.Text.ToString() + "'" + this.cboLo.Text.ToString();
            if ((this.cboLocType.Text ?? "") == "Plan")
            {
                string DestLLo = "L=" + this.txtDestLDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtDestLMin.Text.ToString() + "'" + this.cboDestL.Text.ToString() + " Lo=" + this.txtDestLoDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtDestLoMin.Text.ToString() + "'" + this.cboDestLo.Text.ToString();
                DataSet1.Tables[tablename].Rows.Add(this.txtVessel.Text.ToString(), this.txtNavigator.Text.ToString(), this.txtFrom.Text.ToString(), this.txtTo.Text.ToString(), this.cboLocType.Text.ToString(), this.DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), this.txtCompass.Text.ToString() + Conversions.ToString((char)176), this.txtVar.Text.ToString() + this.cboVar.Text, this.txtDev.Text.ToString() + this.cboDev.Text, this.txtCTrue.Text.ToString() + Conversions.ToString((char)176), this.txtSpeed.Text.ToString() + "kn", LLo, this.txtWeather.Text.ToString(), this.txtRemarks.Text.ToString(), this.txtDestElapsed.Text, this.txtDestDist.Text, DestLLo, this.txtDestTrue.Text, "", "", "", "Plan Entry");
            }
            else
            {
                DataSet1.Tables[tablename].Rows.Add(this.txtVessel.Text.ToString(), this.txtNavigator.Text.ToString(), this.txtFrom.Text.ToString(), this.txtTo.Text.ToString(), this.cboLocType.Text.ToString(), this.DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss"), this.txtCompass.Text.ToString() + Conversions.ToString((char)176), this.txtVar.Text.ToString() + this.cboVar.Text, this.txtDev.Text.ToString() + this.cboDev.Text, this.txtCTrue.Text.ToString() + Conversions.ToString((char)176), this.txtSpeed.Text.ToString() + "kn", LLo, this.txtWeather.Text.ToString(), this.txtRemarks.Text.ToString());
            }

            SortDataGridonDate();
            evaluateDG();
            this.DataGridView1.Refresh();
            this.Refresh();
            IsUpdated = true;
            return;
        }

        private void btnUpdateExisting_Click(object sender, EventArgs e)
        {
            if (EditUpdtFields() == false)
            {
                this.Refresh();
                return;
            }

            if ((this.cboLocType.Text ?? "") == "Plan")
            {
                if (EditPlanFields() == false)
                {
                    this.Refresh();
                    return;
                }
            }

            string LLo = "";
            LLo = "L=" + UpdtRtn.LDegI.ToString("00") + Conversions.ToString((char)176) + UpdtRtn.LMinI.ToString("00.0") + "'" + this.cboL.Text.ToString() + " Lo=" + UpdtRtn.LoDegI.ToString("00") + Conversions.ToString((char)176) + UpdtRtn.LoMinI.ToString("00.0") + "'" + this.cboLo.Text.ToString();
            this.DataGridView1.Rows[UpdtRow].Cells[0].Value = this.txtVessel.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[1].Value = this.txtNavigator.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[2].Value = this.txtFrom.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[3].Value = this.txtTo.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[4].Value = this.cboLocType.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[5].Value = this.DTDateZoneTime.Value.ToString("MM/dd/yyyy HH:mm:ss");
            this.DataGridView1.Rows[UpdtRow].Cells[6].Value = this.txtCompass.Text + Conversions.ToString((char)176);
            this.DataGridView1.Rows[UpdtRow].Cells[7].Value = this.txtVar.Text + this.cboVar.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[8].Value = this.txtDev.Text + this.cboDev.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[9].Value = this.txtCTrue.Text + Conversions.ToString((char)176);
            this.DataGridView1.Rows[UpdtRow].Cells[10].Value = this.txtSpeed.Text + "kn";
            this.DataGridView1.Rows[UpdtRow].Cells[11].Value = LLo;
            this.DataGridView1.Rows[UpdtRow].Cells[12].Value = this.txtWeather.Text;
            this.DataGridView1.Rows[UpdtRow].Cells[13].Value = this.txtRemarks.Text;
            if ((this.cboLocType.Text ?? "") == "Plan")
            {
                string DestLLo = "L=" + this.txtDestLDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtDestLMin.Text.ToString() + "'" + this.cboDestL.Text.ToString() + " Lo=" + this.txtDestLoDeg.Text.ToString() + Conversions.ToString((char)176) + this.txtDestLoMin.Text.ToString() + "'" + this.cboDestLo.Text.ToString();
                this.DataGridView1.Rows[UpdtRow].Cells[14].Value = this.txtDestElapsed.Text;
                this.DataGridView1.Rows[UpdtRow].Cells[15].Value = this.txtDestDist.Text;
                this.DataGridView1.Rows[UpdtRow].Cells[16].Value = DestLLo;
                this.DataGridView1.Rows[UpdtRow].Cells[17].Value = this.txtDestTrue.Text;
            }

            SortDataGridonDate();
            evaluateDG();
            this.DataGridView1.Refresh();
            this.Refresh();
            IsUpdated = true;
            return;
        }

        private void btnDeleteSight_Click(object sender, EventArgs e)
        {
            DataSet1.Tables[tablename].Rows.RemoveAt(UpdtRow);
            SortDataGridonDate();
            evaluateDG();
            this.DataGridView1.Refresh();
            this.Refresh();
            IsUpdated = true;
            return;
        }

        private bool EditUpdtFields()
        {
            if (string.IsNullOrEmpty(this.txtVessel.Text) | string.IsNullOrEmpty(this.txtVessel.Text))
            {
                ErrorMsgBox("Vessel Name must be entered");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNavigator.Text) | string.IsNullOrEmpty(this.txtNavigator.Text))
            {
                ErrorMsgBox("Navigator Name must be entered");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtFrom.Text) | string.IsNullOrEmpty(this.txtFrom.Text))
            {
                ErrorMsgBox("From Location must be entered");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtTo.Text) | string.IsNullOrEmpty(this.txtTo.Text))
            {
                ErrorMsgBox("Destination Location must be entered");
                return false;
            }
            // if the Log Entry type is Plan then do not edit compass, dev, var fields
            if ((this.cboLocType.Text ?? "") != "Plan")
            {
                if (string.IsNullOrEmpty(this.txtCompass.Text) | string.IsNullOrEmpty(this.txtCompass.Text))
                {
                    ErrorMsgBox("Compass Course must be entered");
                    return false;
                }

                if (Information.IsNumeric(this.txtCompass.Text) == false)
                {
                    ErrorMsgBox("Compass Course must be numeric between 0 and 360");
                    return false;
                }

                try
                {
                    UpdtRtn.CompassI = Convert.ToInt32(this.txtCompass.Text);
                    if (UpdtRtn.CompassI < 0 | UpdtRtn.CompassI > 359)
                    {
                        ErrorMsgBox("Compass Course must be numeric between 0 and 360");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ErrorMsgBox("Compass Course must be numeric between 0 and 360");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(this.txtVar.Text) | string.IsNullOrEmpty(this.txtVar.Text))
            {
                this.txtVar.Text = Conversions.ToString(0);
                // ErrorMsgBox("Variation must be entered")
                // Return False
            }

            if (Information.IsNumeric(this.txtVar.Text) == false)
            {
                ErrorMsgBox("Variation must be numeric between 0 and 20");
                return false;
            }

            try
            {
                UpdtRtn.VarI = Convert.ToDecimal(this.txtVar.Text);
                if (UpdtRtn.VarI < 0 | UpdtRtn.VarI > 20)
                {
                    ErrorMsgBox("Var Course must be numeric between 0 and 20");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Var Course must be numeric between 0 and 20");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDev.Text) | string.IsNullOrEmpty(this.txtDev.Text))
            {
                this.txtDev.Text = Conversions.ToString(0);
                // ErrorMsgBox("Deviation must be entered")
                // Return False
            }

            if (Information.IsNumeric(this.txtDev.Text) == false)
            {
                ErrorMsgBox("Deviation must be numeric between 0 and 20");
                return false;
            }

            try
            {
                UpdtRtn.DevI = Convert.ToDecimal(this.txtDev.Text);
                if (UpdtRtn.DevI < 0 | UpdtRtn.DevI > 20)
                {
                    ErrorMsgBox("Dev Course must be numeric between 0 and 20");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Dev Course must be numeric between 0 and 20");
                return false;
            }

            if ((this.cboVar.Text ?? "") == "W")
            {
                UpdtRtn.VarI = -UpdtRtn.VarI;
            }

            if ((this.cboDev.Text ?? "") == "W")
            {
                UpdtRtn.DevI = -UpdtRtn.DevI;
            }

            if ((this.cboLocType.Text ?? "") != "Plan")
            {
                UpdtRtn.CTrueI = (int)(UpdtRtn.CompassI + UpdtRtn.VarI + UpdtRtn.DevI);
                this.txtCTrue.Text = UpdtRtn.CTrueI.ToString("000");
            }

            if (string.IsNullOrEmpty(this.txtSpeed.Text) | string.IsNullOrEmpty(this.txtSpeed.Text))
            {
                ErrorMsgBox("Speed must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtSpeed.Text) == false)
            {
                ErrorMsgBox("Speed must be numeric between 0 and 99");
                return false;
            }

            try
            {
                UpdtRtn.SpeedI = Convert.ToDecimal(this.txtSpeed.Text);
                if (UpdtRtn.SpeedI < 0 | UpdtRtn.SpeedI > 99)
                {
                    ErrorMsgBox("Speed must be numeric between 0 and 99");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Speed must be numeric between 0 and 99");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtLDeg.Text) | string.IsNullOrEmpty(this.txtLDeg.Text))
            {
                ErrorMsgBox("Latitude Degrees must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtLDeg.Text) == false)
            {
                ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89");
                return false;
            }

            try
            {
                UpdtRtn.LDegI = Convert.ToInt32(this.txtLDeg.Text);
                if (UpdtRtn.LDegI < 0 | UpdtRtn.LDegI > 89)
                {
                    ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Latitude Degrees must be numeric between 0 and 89");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtLMin.Text) | string.IsNullOrEmpty(this.txtLMin.Text))
            {
                ErrorMsgBox("Latitude Minutes must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtLMin.Text) == false)
            {
                ErrorMsgBox("Latitude Minutes be numeric between 0 and 59.9");
                return false;
            }

            try
            {
                UpdtRtn.LMinI = Convert.ToDecimal(this.txtLMin.Text);
                UpdtRtn.LNS = this.cboL.Text;
                if ((this.cboL.Text ?? "") == "N")
                {
                    UpdtRtn.LatDecimal = Convert.ToDecimal(UpdtRtn.LDegI) + UpdtRtn.LMinI / 60;
                }
                else
                {
                    UpdtRtn.LatDecimal = -1 * (Convert.ToDecimal(UpdtRtn.LDegI) + UpdtRtn.LMinI / 60);
                }

                if (UpdtRtn.LMinI < 0 | Conversions.ToDouble(UpdtRtn.LMinI) > 59.9)
                {
                    ErrorMsgBox("Latitude Minutes must be numeric between 0 and 59.9");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Latitude Minutes must be numeric between 0 and 59.9");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtLoDeg.Text) | string.IsNullOrEmpty(this.txtLDeg.Text))
            {
                ErrorMsgBox("Longitude Degrees must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtLoDeg.Text) == false)
            {
                ErrorMsgBox("Longitude Degrees must be numeric between 0 and 89");
                return false;
            }

            try
            {
                UpdtRtn.LoDegI = Convert.ToInt32(this.txtLoDeg.Text);
                if (UpdtRtn.LoDegI < 0 | UpdtRtn.LoDegI > 180)
                {
                    ErrorMsgBox("Longitude Degrees must be numeric between 0 and 180");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Longitude Degrees must be numeric between 0 and 180");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtLoMin.Text) | string.IsNullOrEmpty(this.txtLoMin.Text))
            {
                ErrorMsgBox("Longitude Minutes must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtLoMin.Text) == false)
            {
                ErrorMsgBox("Longitude Minutes be numeric between 0 and 59.9");
                return false;
            }

            try
            {
                UpdtRtn.LoMinI = Convert.ToDecimal(this.txtLoMin.Text);
                UpdtRtn.LoEW = this.cboLo.Text;
                if ((this.cboLo.Text ?? "") == "W")
                {
                    UpdtRtn.LongDecimal = Convert.ToDecimal(UpdtRtn.LoDegI) + UpdtRtn.LoMinI / 60;
                }
                else
                {
                    UpdtRtn.LongDecimal = -1 * (Convert.ToDecimal(UpdtRtn.LoDegI) + UpdtRtn.LoMinI / 60);
                }

                if (UpdtRtn.LoMinI < 0 | Conversions.ToDouble(UpdtRtn.LoMinI) > 59.9)
                {
                    ErrorMsgBox("Longitude Minutes must be numeric between 0 and 59.9");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("Longitude Minutes must be numeric between 0 and 59.9");
                return false;
            }

            return true;
            return default;
        }

        private bool EditPlanFields()
        {
            if (string.IsNullOrEmpty(this.txtCTrue.Text) | string.IsNullOrEmpty(this.txtCTrue.Text))
            {
                ErrorMsgBox("For Plan Entry,True Course must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtCTrue.Text) == false)
            {
                ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360");
                return false;
            }

            try
            {
                UpdtRtn.CTrueI = Convert.ToInt32(this.txtCTrue.Text);
                if (UpdtRtn.CTrueI < 0 | UpdtRtn.CTrueI > 359)
                {
                    ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("For Plan Entry,True Course must be numeric between 0 and 360");
                return false;
            }

            UpdtRtn.CompassI = (int)(UpdtRtn.CTrueI + UpdtRtn.VarI + UpdtRtn.DevI);
            this.txtCompass.Text = UpdtRtn.CompassI.ToString("000");
            if (string.IsNullOrEmpty(this.txtDestLDeg.Text) | string.IsNullOrEmpty(this.txtDestLDeg.Text))
            {
                ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtDestLDeg.Text) == false)
            {
                ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be numeric between 0 and 89");
                return false;
            }

            try
            {
                UpdtRtn.DestLDegI = Convert.ToInt32(this.txtDestLDeg.Text);
                if (UpdtRtn.DestLDegI < 0 | UpdtRtn.DestLDegI > 89)
                {
                    ErrorMsgBox("For Plan Entry, Destination Latitude Degrees must be numeric between 0 and 89");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("For Plan Entry, DestinationLatitude Degrees must be numeric between 0 and 89");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDestLMin.Text) | string.IsNullOrEmpty(this.txtDestLMin.Text))
            {
                ErrorMsgBox("For Plan Entry, Latitude Minutes must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtDestLMin.Text) == false)
            {
                ErrorMsgBox("For Plan Entry, Latitude Minutes be numeric between 0 and 59.9");
                return false;
            }

            try
            {
                UpdtRtn.DestLMinI = Convert.ToDecimal(this.txtDestLMin.Text);
                UpdtRtn.DestLNS = this.cboDestL.Text;
                if ((UpdtRtn.DestLNS ?? "") == "N")
                {
                    UpdtRtn.DestLatDecimal = Convert.ToDecimal(UpdtRtn.DestLDegI) + UpdtRtn.DestLMinI / 60;
                }
                else
                {
                    UpdtRtn.DestLatDecimal = -1 * (Convert.ToDecimal(UpdtRtn.DestLDegI) + UpdtRtn.DestLMinI / 60);
                }

                if (UpdtRtn.DestLMinI < 0 | Conversions.ToDouble(UpdtRtn.DestLMinI) > 59.9)
                {
                    ErrorMsgBox("For Plan Entry, Latitude Minutes must be numeric between 0 and 59.9");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("For Plan Entry, Latitude Minutes must be numeric between 0 and 59.9");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDestLoDeg.Text) | string.IsNullOrEmpty(this.txtDestLDeg.Text))
            {
                ErrorMsgBox("For Plan Entry, Longitude Degrees must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtDestLoDeg.Text) == false)
            {
                ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 89");
                return false;
            }

            try
            {
                UpdtRtn.DestLoDegI = Convert.ToInt32(this.txtDestLoDeg.Text);
                if (UpdtRtn.DestLoDegI < 0 | UpdtRtn.DestLoDegI > 180)
                {
                    ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 180");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("For Plan Entry, Longitude Degrees must be numeric between 0 and 180");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDestLoMin.Text) | string.IsNullOrEmpty(this.txtDestLoMin.Text))
            {
                ErrorMsgBox("For Plan Entry, Longitude Minutes must be entered");
                return false;
            }

            if (Information.IsNumeric(this.txtDestLoMin.Text) == false)
            {
                ErrorMsgBox("For Plan Entry, Longitude Minutes be numeric between 0 and 59.9");
                return false;
            }

            try
            {
                UpdtRtn.DestLoMinI = Convert.ToDecimal(this.txtDestLoMin.Text);
                UpdtRtn.DestLoEW = this.cboDestLo.Text;
                if ((UpdtRtn.DestLoEW ?? "") == "W")
                {
                    UpdtRtn.DestLongDecimal = Convert.ToDecimal(UpdtRtn.DestLoDegI) + UpdtRtn.DestLoMinI / 60;
                }
                else
                {
                    UpdtRtn.DestLongDecimal = -1 * (Convert.ToDecimal(UpdtRtn.DestLoDegI) + UpdtRtn.DestLoMinI / 60);
                }

                if (UpdtRtn.DestLoMinI < 0 | Conversions.ToDouble(UpdtRtn.DestLoMinI) > 59.9)
                {
                    ErrorMsgBox("For Plan Entry, Longitude Minutes must be numeric between 0 and 59.9");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsgBox("For Plan Entry, Longitude Minutes must be numeric between 0 and 59.9");
                return false;
            }

            var Loc1 = new System.Device.Location.GeoCoordinate(Conversions.ToDouble(UpdtRtn.LatDecimal), Conversions.ToDouble(UpdtRtn.LongDecimal));
            var Loc2 = new System.Device.Location.GeoCoordinate(Conversions.ToDouble(UpdtRtn.DestLatDecimal), Conversions.ToDouble(UpdtRtn.DestLongDecimal));
            double DestDist = GetDistance(Conversions.ToDouble(UpdtRtn.LatDecimal), Conversions.ToDouble(UpdtRtn.LongDecimal), Conversions.ToDouble(UpdtRtn.DestLatDecimal), Conversions.ToDouble(UpdtRtn.DestLongDecimal));
            this.txtDestDist.Text = DestDist.ToString("##0.0") + "nm";
            this.txtDestTrue.Text = GetHeading(Conversions.ToDouble(UpdtRtn.LatDecimal), Conversions.ToDouble(UpdtRtn.LongDecimal), Conversions.ToDouble(UpdtRtn.DestLatDecimal), Conversions.ToDouble(UpdtRtn.DestLongDecimal)).ToString("##0") + Conversions.ToString((char)176);
            var DestElapsed = this.Calc60DSTElapsed(this.DTDateZoneTime.Value, Convert.ToDouble(this.txtSpeed.Text), DestDist);
            if (DestElapsed.Days == 0)
            {
                this.txtDestElapsed.Text = DestElapsed.ToString(@"hh\:mm\:ss");
            }
            else
            {
                this.txtDestElapsed.Text = DestElapsed.ToString(@"d\d\y\ hh\:mm\:ss");
            }
            // txtDestElapsed.Text = DestElapsed.ToString("d\d\y\ hh\:mm\:ss")
            var DestEstArrival = this.DTDateZoneTime.Value + DestElapsed;
            this.txtRemarks.Text = "Estimated Arrival Time for Plan Log Entry:" + DestEstArrival.ToString("MM/dd/yyyy HH:mm:ss");
            this.txtEstArrival.Text = DestEstArrival.ToString("MM/dd/yyyy HH:mm:ss");
            return true;
        }

        private void ResetScreenFields()
        {
            this.txtVessel.Clear();
            this.txtNavigator.Clear();
            this.txtFrom.Clear();
            this.txtTo.Clear();
            this.DTDateZoneTime.Value = DateAndTime.Now;
            this.txtCompass.Clear();
            this.txtVar.Clear();
            this.txtDev.Clear();
            this.txtCTrue.Clear();
            this.txtSpeed.Clear();
            this.txtLDeg.Clear();
            this.txtLMin.Clear();
            this.txtLoDeg.Clear();
            this.txtLoMin.Clear();
            this.txtWeather.Clear();
            this.txtRemarks.Clear();
            this.cboLocType.SelectedIndex = 0;
            this.cboL.SelectedIndex = 0;
            this.cboLo.SelectedIndex = 0;
            this.cboVar.SelectedIndex = 0;
            this.cboDev.SelectedIndex = 0;
            this.cboLocType.SelectedIndex = 0;
            this.txtVar.Text = Conversions.ToString(0);
            this.txtDev.Text = Conversions.ToString(0);
            return;
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            this.btnDeleteSight.Visible = false;
            this.btnUpdateExisting.Visible = false;
            ResetScreenFields();
            return;
        }

        private void SortDataGridonDate()
        {
            SortingDG = true;
            this.DataGridView1.Sort(this.DataGridView1.Columns[5], System.ComponentModel.ListSortDirection.Ascending);
            for (int i = 0, loopTo = this.DataGridView1.Columns.Count - 1; i <= loopTo; i++)
                this.DataGridView1.AutoResizeColumn(i);
            // select last row in data grid
            int LastRow = this.DataGridView1.Rows.Count - 1;
            this.DataGridView1.CurrentCell = this.DataGridView1.Rows[LastRow].Cells[4];
            this.DataGridView1.Rows[LastRow].Selected = true;
            SortingDG = false;
            return;
        }

        private bool EditRelationsinDG()
        {
            return true;
        }

        private void evaluateDG()
        {
            if (InitialLoad == true)
                return;
            if (FileLoading == true)
                return;
            int DGlimit = this.DataGridView1.Rows.Count;
            bool PrevGPSFIXExists = false;
            int PrevGPSFix = 0;
            bool PrevDRExists = false;
            int PrevDR = 0;
            if (DGlimit == 1)
            {
                ErrorMsgBox("Nothing to evaluate - the Data Grid only has one entry");
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[0].Cells[4].Value, "GPS", false) | Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[0].Cells[4].Value, "Fix", false)))
            {
                PrevGPSFIXExists = true;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[0].Cells[4].Value, "DR", false)))
            {
                PrevDRExists = true;
                PrevDR = 0;
            }
            // for the first data grid row clear out the last 6 cells to make sure nothing displays
            // For i As Integer = 14 To 20
            // DataGridView1.Rows(0).Cells(i).Value = ""
            // Next
            // now pass thru the data grid from the second record to the end evaluate each pair of records and calculating the final route results
            for (int i = 1, loopTo = DGlimit - 1; i <= loopTo; i++)
            {
                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "Plan", false)))
                {
                    this.DataGridView1.Rows[i].Cells[14].Value = ""; // Elapsed Time
                    this.DataGridView1.Rows[i].Cells[15].Value = ""; // Distance
                    this.DataGridView1.Rows[i].Cells[16].Value = ""; // Calc Loc L/Lo
                    this.DataGridView1.Rows[i].Cells[17].Value = ""; // CMG
                    this.DataGridView1.Rows[i].Cells[18].Value = ""; // SMG
                    this.DataGridView1.Rows[i].Cells[19].Value = ""; // Set 
                    this.DataGridView1.Rows[i].Cells[20].Value = ""; // Drift
                    this.DataGridView1.Rows[i].Cells[21].Value = ""; // Eval Based On
                }
                else
                {
                    this.DataGridView1.Rows[i].Cells[19].Value = ""; // Set 
                    this.DataGridView1.Rows[i].Cells[20].Value = ""; // Drift
                    this.DataGridView1.Rows[i].Cells[21].Value = "";
                } // Eval Based On

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "GPS", false) | Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "Fix", false)))
                {
                    if (PrevGPSFIXExists == true)
                    {
                        EvaluateDBPairs(i, PrevGPSFix, true);
                        this.DataGridView1.Rows[i].Cells[21].Value = "Prev GPS/Fix Entry";
                        PrevGPSFix = i;
                    }
                    else
                    {
                        PrevGPSFIXExists = true;
                        PrevGPSFix = i;
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "Plan", false)))
                        {
                            if (PrevDRExists == true)
                            {
                                EvaluateDBPairs(i, PrevDR, false);
                                this.DataGridView1.Rows[i].Cells[21].Value = "Prev Log Entry";
                                PrevDR = i;
                            }
                            else
                            {
                                PrevDRExists = true;
                                PrevDR = i;
                            }
                        }
                    }
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "Plan", false)))
                {
                    int x = 0; // do nothing statement just to do something
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i].Cells[4].Value, "DR", false) & !Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[i - 1].Cells[4].Value, "Plan", false)))
                {
                    if (PrevDRExists == true)
                    {
                        EvaluateDBPairs(i, PrevDR, false);
                        this.DataGridView1.Rows[i].Cells[21].Value = "Prev Log Entry";
                        PrevDR = i;
                    }
                    else
                    {
                        PrevDRExists = true;
                        PrevDR = i;
                    }
                    // ElseIf DataGridView1.Rows(i).Cells(4).Value = "DR" And DataGridView1.Rows(i - 1).Cells(4).Value = "Plan" Then
                    // PrevDRExists = True
                    // PrevDR = i
                }
            }

            return;
        }

        private void EvaluateDBPairs(int CurrRec, int PrevRec, bool GPSFixEntry)
        {
            // evaluate Elapsed time from last entry
            var DT1 = Convert.ToDateTime(this.DataGridView1.Rows[PrevRec].Cells[5].Value);
            var DT2 = Convert.ToDateTime(this.DataGridView1.Rows[CurrRec].Cells[5].Value);
            var TS = DT2 - DT1;
            if (TS.Days == 0)
            {
                this.DataGridView1.Rows[CurrRec].Cells[14].Value = TS.ToString(@"hh\:mm\:ss");
            }
            else
            {
                this.DataGridView1.Rows[CurrRec].Cells[14].Value = TS.ToString(@"d\d\y\ hh\:mm\:ss");
            }

            // evaluate Calculate destination location - start with location of previous entry 
            var GeoLLo1 = ParseLatLong(Conversions.ToString(this.DataGridView1.Rows[PrevRec].Cells[11].Value));
            string TempcboL1 = "N";
            double TempL1 = GeoLLo1.Latitude;
            double TempL1Disp = GeoLLo1.Latitude;
            if (GeoLLo1.Latitude < 0)
            {
                TempcboL1 = "S";
                TempL1 = -1 * TempL1Disp;
            }
            else
            {
                TempcboL1 = "N";
                TempL1 = TempL1Disp;
            }

            string TempcboLo1 = "";
            double TempLo1Disp = GeoLLo1.Longitude;
            double TempLo1 = GeoLLo1.Longitude;
            if (GeoLLo1.Longitude < 0)
            {
                TempcboLo1 = "E";
                TempLo1 = -1 * TempLo1Disp;
            }
            else
            {
                TempcboLo1 = "W";
                TempLo1 = TempLo1Disp;
            }

            // now calculate the location for the current entry
            var GeoLLo = ParseLatLong(Conversions.ToString(this.DataGridView1.Rows[CurrRec].Cells[11].Value));
            string TempcboL = "N";
            double TempL = GeoLLo.Latitude;
            double TempLDisp = GeoLLo.Latitude;
            if (GeoLLo.Longitude < 0)
            {
                TempcboL = "S";
                TempL = -1 * TempLDisp;
            }
            else
            {
                TempcboL = "N";
                TempL = TempL1Disp;
            }

            string TempcboLo = "";
            double TempLoDisp = GeoLLo.Longitude;
            double TempLo = GeoLLo.Longitude;
            if (GeoLLo.Longitude < 0)
            {
                TempcboLo = "E";
                TempLo = -1 * TempLoDisp;
            }
            else
            {
                TempcboLo = "W";
                TempLo = TempLoDisp;
            }

            int tlen = this.DataGridView1.Rows[PrevRec].Cells[9].Value.ToString().Length;
            decimal TempTrue = Convert.ToDecimal(this.DataGridView1.Rows[PrevRec].Cells[9].Value.ToString().Substring(0, tlen - 1));
            tlen = this.DataGridView1.Rows[PrevRec].Cells[10].Value.ToString().Length;
            decimal TempSpeed = Convert.ToDecimal(this.DataGridView1.Rows[PrevRec].Cells[10].Value.ToString().Substring(0, tlen - 2));

            // get the distance from the previous location to the current entry location
            double Dist = GetDistance(TempL1Disp, TempLo1Disp, TempLDisp, TempLoDisp);
            this.DataGridView1.Rows[CurrRec].Cells[15].Value = Dist.ToString("#0.0") + " nm";

            // now calculate the destination location using the previous loc, the distance using prev speed and elapsed time, and true course of prev entry
            var TempLoc = FindDestLatLong(TempL1Disp, TempLo1Disp, Dist, Conversions.ToDouble(TempTrue));
            double TempL3 = TempLoc.Latitude;
            string TempL3NS = TempcboL;
            double TempL3Disp = 0;
            if (TempL3 < 0)
            {
                TempL3NS = "S";
                TempL3Disp = -1 * TempL3;
            }
            else
            {
                TempL3NS = "N";
                TempL3Disp = TempL3;
            }

            int TempL3Deg = Conversions.ToInteger(Conversion.Int(TempL3));
            decimal TempL3Min = (decimal)((TempL3 - TempL3Deg) * 60);
            double TempLo3 = TempLoc.Longitude;
            string TempLo3EW = TempcboLo;
            double TempLo3Disp = 0;
            if (TempLo3 < 0)
            {
                TempLo3EW = "W";
                TempLo3Disp = -1 * TempLo3;
            }
            else
            {
                TempLo3EW = "E";
                TempLo3Disp = TempLo3;
            }

            int TempLo3Deg = Conversions.ToInteger(Conversion.Int(TempLo3Disp));
            decimal TempLo3Min = (decimal)((TempLo3Disp - TempLo3Deg) * 60);
            this.DataGridView1.Rows[CurrRec].Cells[16].Value = "L=" + TempL3Deg.ToString("##0") + Conversions.ToString((char)176) + TempL3Min.ToString("#0.0") + "'" + TempL3NS + " " + "Lo=" + TempLo3Deg.ToString("##0") + Conversions.ToString((char)176) + TempLo3Min.ToString("#0.0") + "'" + TempLo3EW;

            // Calculate the actual course between the previous loc and the current loc 
            double CMG = GetHeading(TempL1, TempLo1, TempL, TempLo);
            this.DataGridView1.Rows[CurrRec].Cells[17].Value = CMG.ToString("##0.0") + Conversions.ToString((char)176);
            // Calculate the actual speed using the calculate distance between previous loc and current loc and the elapsed time
            double SMG = Calc60DSTSpeed(DT1, DT2, Dist);
            this.DataGridView1.Rows[CurrRec].Cells[18].Value = SMG.ToString("##0.0") + "kn ";
            if (GPSFixEntry == true)
            {

                // calculate the Direction of Set from current loc to actual computed loc 
                double SetCalc = GetHeading(TempL, TempLo, TempL3, TempLo3);
                this.DataGridView1.Rows[CurrRec].Cells[19].Value = SetCalc.ToString("##0.0") + Conversions.ToString((char)176);
                // Calculate Drift distance and speed from current loc to actual computed loc
                double DistDrift = GetDistance(TempL, TempLo, TempL3, TempLo3);
                double DriftSpeed = Calc60DSTSpeed(DT1, DT2, DistDrift);
                this.DataGridView1.Rows[CurrRec].Cells[20].Value = DriftSpeed.ToString("##0.0") + "kn ";
            }

            return;
        }

        private double GetDistance(double Lat1In, double Long1In, double Lat2In, double Long2In)
        {
            var Coord1 = new System.Device.Location.GeoCoordinate(Lat1In, Long1In);
            var Coord2 = new System.Device.Location.GeoCoordinate(Lat2In, Long2In);
            return Coord1.GetDistanceTo(Coord2) / 1852;  // GetDistanceTo returns distance between geo coords in meters - there are 1852 meters in a nuatical mile
        }

        private double GetHeading(double lat1, double long1, double lat2, double long2)
        {
            double x = Math.Cos(DegreesToRadians(lat1)) * Math.Sin(DegreesToRadians(lat2)) - Math.Sin(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) * Math.Cos(DegreesToRadians(long2) - DegreesToRadians(long1));
            double y = Math.Sin(DegreesToRadians(long2) - DegreesToRadians(long1)) * Math.Cos(DegreesToRadians(lat2));
            double DegX = RadiansToDegrees(x);
            double DegY = RadiansToDegrees(y);
            double Angle = RadiansToDegrees(Math.Atan2(DegY, DegX));
            if (Angle < 180)
            {
                if (lat2 > 0)
                {
                    Angle = 360 - Angle;
                }
                else
                {
                    Angle = 180 + Angle;
                }
            }
            else if (lat2 > 0)
            {
                Angle = Angle;
            }
            else
            {
                Angle = 180 - Angle;
            }

            return Angle % 360;
        }

        private double DegreesToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }

        private double RadiansToDegrees(double angle)
        {
            return angle * 180 / Math.PI;
        }

        private System.Device.Location.GeoCoordinate FindDestLatLong(double LatIn, double LonIn, double Dist, double Course)
        {
            double lat1 = LatIn * Math.PI / 180;
            double Lon1 = LonIn * Math.PI / 180;
            double Theta = Course * Math.PI / 180;
            double R = 3443.92;  // this is the radius of the earth in nautical miles
            double d = Dist;    // this is the distance travelled in nautical miles
            double DDivR = d / R * Math.PI / 180;
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(DDivR) + Math.Cos(lat1) * Math.Sin(DDivR) * Math.Cos(Theta));
            double lon2 = Lon1 + Math.Atan2(Math.Sin(Theta) * Math.Sin(DDivR) * Math.Cos(lat1), Math.Cos(DDivR) - Math.Sin(lat1) * Math.Sin(lat2));
            var RtnGC = new System.Device.Location.GeoCoordinate(lat2 * 180 / Math.PI, lon2 * 180 / Math.PI);
            return RtnGC;
        }

        private double Calc60DSTDistance(DateTime DT1, DateTime DT2, double Speed)
        {
            var TS = DT2 - DT1;
            return Speed * TS.TotalHours;
        }

        private double Calc60DSTSpeed(DateTime DT1, DateTime DT2, double Dist)
        {
            var TS = DT2 - DT1;
            return Dist / TS.TotalHours;
        }

        private TimeSpan Calc60DSTElapsed(DateTime DT1, double Speed, double Distance)
        {
            double ElapsedMin = 60 * Distance / Speed;
            var newDT = DT1;
            newDT = newDT.AddMinutes(ElapsedMin);
            var TS = newDT - DT1;
            return TS;
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            evaluateDG();
            return;
        }

        private System.Device.Location.GeoCoordinate ParseLatLong(string StrIn)
        {
            // evaluate Calculate destination location - start with location of previous entry 
            string LLo1 = StrIn;  // DataGridView1.Rows(i - 1).Cells(11).Value
            int LPos1 = LLo1.IndexOf("=");
            int LDegPos1 = LLo1.IndexOf((char)176);
            int LMinPos1 = LLo1.IndexOf("'");
            int LoPos1 = LLo1.IndexOf("=", LPos1 + 1);
            int LoDegPos1 = LLo1.IndexOf((char)176, LDegPos1 + 1);
            int LoMinPos1 = LLo1.IndexOf("'", LMinPos1 + 1);
            double TempL1 = Convert.ToDouble(LLo1.Substring(LPos1 + 1, LDegPos1 - 1 - (LPos1 + 1) + 1)) + Convert.ToDouble(Conversions.ToDouble(LLo1.Substring(LDegPos1 + 1, LMinPos1 - 1 - (LDegPos1 + 1) + 1)) / 60);
            string TempcboL1 = LLo1.Substring(LMinPos1 + 1, 1);
            double TempL1Disp = 0;
            if ((TempcboL1 ?? "") == "S")
            {
                TempL1Disp = -1 * TempL1;
            }
            else
            {
                TempL1Disp = TempL1;
            }

            double TempLo1 = Convert.ToDouble(LLo1.Substring(LoPos1 + 1, LoDegPos1 - 1 - (LoPos1 + 1) + 1)) + Convert.ToDouble(Conversions.ToDouble(LLo1.Substring(LoDegPos1 + 1, LoMinPos1 - 1 - (LoDegPos1 + 1) + 1)) / 60);
            string TempcboLo1 = LLo1.Substring(LoMinPos1 + 1, 1);
            double TempLo1Disp = 0;
            if ((TempcboLo1 ?? "") == "W")
            {
                TempLo1Disp = -1 * TempLo1;
            }
            else
            {
                TempLo1Disp = TempLo1;
            }

            var RtnLLo = new System.Device.Location.GeoCoordinate(TempL1Disp, TempLo1Disp);
            return RtnLLo;
        }

        private void cboLocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InitialLoad == true)
                return;
            if (FileLoading == true)
                return;
            if ((this.cboLocType.Text ?? "") == "Plan")
            {
                // make visible plan dest fields and enable 
                this.grpbxPlan.Visible = true;
                this.txtCompass.Enabled = false;
                this.txtCTrue.Enabled = true;
                this.txtCTrue.Text = Conversions.ToString(0);
                this.txtDev.Enabled = true;
                this.txtDev.Text = Conversions.ToString(0);
                this.cboDev.Enabled = true;
                this.cboDev.SelectedIndex = 0;
                this.txtVar.Enabled = true;
                this.cboVar.Enabled = true;
                this.cboVar.SelectedIndex = 0;
                this.txtVar.Text = Conversions.ToString(0);
            }
            else
            {
                // make invisible plan dest fields and disable 
                this.grpbxPlan.Visible = false;
                this.txtCompass.Enabled = true;
                this.txtCTrue.Enabled = false;
                this.txtCTrue.Text = Conversions.ToString(0);
                this.txtDev.Enabled = true;
                this.txtDev.Text = Conversions.ToString(0);
                this.cboDev.Enabled = true;
                this.cboDev.SelectedIndex = 0;
                this.txtVar.Enabled = true;
                this.cboVar.Enabled = true;
                this.cboVar.SelectedIndex = 0;
                this.txtVar.Text = Conversions.ToString(0);
            }

            ClearPlanFields();
            this.Refresh();
            return;
        }

        private void ClearPlanFields()
        {
            this.txtDestLDeg.Clear();
            this.txtDestLMin.Clear();
            this.txtDestLoDeg.Clear();
            this.txtDestLoMin.Clear();
            this.cboDestL.SelectedIndex = 0;
            this.cboDestLo.SelectedIndex = 0;
            this.txtDestTrue.Clear();
            this.txtDestDist.Clear();
            this.txtDestElapsed.Clear();
            this.txtEstArrival.Clear();
            this.txtWeather.Clear();
            this.txtRemarks.Clear();
            return;
        }

        private void chkHideFirst4Col_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHideFirst4Col.Checked == true)
            {
                this.DataGridView1.Columns[0].Visible = false;
                this.DataGridView1.Columns[1].Visible = false;
                this.DataGridView1.Columns[2].Visible = false;
                this.DataGridView1.Columns[3].Visible = false;
                this.DataGridView1.Columns[12].Visible = false;
                SortDataGridonDate();
                this.DataGridView1.Refresh();
                this.Refresh();
            }
            else
            {
                this.DataGridView1.Columns[0].Visible = true;
                this.DataGridView1.Columns[1].Visible = true;
                this.DataGridView1.Columns[2].Visible = true;
                this.DataGridView1.Columns[3].Visible = true;
                this.DataGridView1.Columns[12].Visible = true;
                SortDataGridonDate();
                this.DataGridView1.Refresh();
                this.Refresh();
            }
        }

        private void btnStartFresh_Click(object sender, EventArgs e)
        {
            if (IsUpdated == true)
            {
                var MsgBack = Interaction.MsgBox("Data has been updated - Save to File - Yes or No", MsgBoxStyle.YesNo, "Save Updated Data");
                if (MsgBack == MsgBoxResult.Yes)
                {
                    SaveDataGrid();
                }

                IsUpdated = false;
            }

            FileLoading = true;
            DataSet1.Tables[tablename].Clear();
            ClearPlanFields();
            ResetScreenFields();
            this.Refresh();
            FileLoading = false;
            return;
        }
    }
}