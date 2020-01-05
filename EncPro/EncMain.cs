using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using EncModel.Meditrac;
using EncModel.Subcache;
using EncModel.Log;
using EncModel.EdiManagement;
using EncModel.SubHistory;
using System.Xml.Linq;
using EncModel.DHCS;
using System.Data.SqlClient;
using EncModel._835;
using EncModel._999;
using EncModel._277CA;
using EncModel.MAO2;
using EncModel.Premium820;

namespace EncPro
{
    public partial class EncMain : Form
    {
        public EncMain()
        {
            InitializeComponent();
        }
        private void EncPro_Load(object sender, EventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["MeditracConnectionString"].ToString();
            string server = cn.Split('=')[1];
            int endpos = Regex.Match(server, ";").Index;
            lbConnectedDatabase.Text = "Connected to " + server.Substring(0, endpos);

            GlobalVariables.DestinationFolder = ConfigurationManager.AppSettings["DestinationFolder"];
            GlobalVariables.DMEProcCodes = EdiManagementUtility.GetDMEProcedureCodes();

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            LoadSchedulesToDataGridView();

            DateTime lastEndDate = LogUtility.GetLastEndDate();
            dateTimePicker1.Value = lastEndDate.AddDays(1);
            dateTimePicker2.Value = lastEndDate.AddDays(7);

            treeView1.SelectedNode = treeView1.Nodes[0];

            this.btLoadData.Click += new System.EventHandler(async (s1, e1) => await this.btLoadData_ClickAsync());
            this.btExport.Click += new System.EventHandler(async (s1, e1) => await this.btExport_ClickAsync());
            this.btLoadTP837s.Click += new System.EventHandler(async (s1, e1) => await this.btLoadTP837s_ClickAsync());
        }
        private async Task btLoadData_ClickAsync()
        {
            lbRunningStatus.Text = "Loading data get counts...";
            btLoadData.Enabled = false;
            Application.DoEvents();
            //load data to staging
            string startDate = dateTimePicker1.Value.ToString("yyyyMMdd");
            string endDate = dateTimePicker2.Value.ToString("yyyyMMdd");
            int totalCCII = await MeditracUtility.GetMeditracCounts("'810','812'", "UB", startDate, endDate, "'TBP','ENC','CLD'");
            int totalCCIP = await MeditracUtility.GetMeditracCounts("'810','812'", "HCF", startDate, endDate, "'TBP','ENC','CLD'");
            int totalCMCI = await MeditracUtility.GetMeditracCounts("'H53'", "UB", startDate, endDate, "'TBP','ENC','CLD'");
            int totalCMCP = await MeditracUtility.GetMeditracCounts("'H53'", "HCF", startDate, endDate, "'TBP','ENC','CLD'");
            int totalDHCSI = await MeditracUtility.GetMeditracCounts("'305','306'", "UB", startDate, endDate, "'TBP','ENC'");
            int totalDHCSP = await MeditracUtility.GetMeditracCounts("'305','306'", "HCF", startDate, endDate, "'TBP','ENC'");
            if (totalCCII + totalCCIP + totalCMCI + totalCMCP + totalDHCSI + totalDHCSP == 0)
            {
                MessageBox.Show("No Records to load");
                return;
            }
            int pagesCCII = (int)Math.Ceiling((decimal)totalCCII / 10000);
            int pagesCCIP = (int)Math.Ceiling((decimal)totalCCIP / 10000);
            int pagesCMCI = (int)Math.Ceiling((decimal)totalCMCI / 10000);
            int pagesCMCP = (int)Math.Ceiling((decimal)totalCMCP / 10000);
            int pagesDHCSI = (int)Math.Ceiling((decimal)totalDHCSI / 10000);
            int pagesDHCSP = (int)Math.Ceiling((decimal)totalDHCSP / 10000);
            toolStripProgressBar1.Maximum = pagesCCII + pagesCCIP + pagesCMCI + pagesCMCP + pagesDHCSI + pagesDHCSP;
            toolStripProgressBar1.Value = 0;
            GlobalVariables.TotalCCII = totalCCII;
            GlobalVariables.TotalCCIP = totalCCIP;
            GlobalVariables.TotalCMCI = totalCMCI;
            GlobalVariables.TotalCMCP = totalCMCP;
            GlobalVariables.TotalDHCSI = totalDHCSI;
            GlobalVariables.TotalDHCSP = totalDHCSP;
            //await SubcacheUtility.TruncateStagingTables();
            lbRunningStatus.Text = "Loading data for CCI institutional";
            for (int page = 0; page < pagesCCII; page++)
            {
                await LoadData.LoadMeditrac.LoadCCII(startDate, endDate, page);
                toolStripProgressBar1.Value += 1;
                Application.DoEvents();
            }
            //lbRunningStatus.Text = "Loading data for CCI professional";
            //for (int page = 0; page < pagesCCIP; page++)
            //{
            //    await LoadData.LoadMeditrac.LoadCCIP(startDate, endDate, page);
            //    toolStripProgressBar1.Value += 1;
            //    Application.DoEvents();
            //}
            //lbRunningStatus.Text = "Loading data for CMC institutional";
            //for (int page = 0; page < pagesCMCI; page++)
            //{
            //    await LoadData.LoadMeditrac.LoadCMCI(startDate, endDate, page);
            //    toolStripProgressBar1.Value += 1;
            //    Application.DoEvents();
            //}
            //lbRunningStatus.Text = "Loading data for CMC professional";
            //for (int page = 0; page < pagesCMCP; page++)
            //{
            //    await LoadData.LoadMeditrac.LoadCMCP(startDate, endDate, page);
            //    toolStripProgressBar1.Value += 1;
            //    Application.DoEvents();
            //}
            //lbRunningStatus.Text = "Loading data for DHCS institutional";
            //for (int page = 0; page < pagesDHCSI; page++)
            //{
            //    await LoadData.LoadMeditrac.LoadDHCSI(startDate, endDate, page);
            //    toolStripProgressBar1.Value += 1;
            //    Application.DoEvents();
            //}
            //lbRunningStatus.Text = "Loading data for DHCS professional";
            //for (int page = 0; page < pagesDHCSP; page++)
            //{
            //    await LoadData.LoadMeditrac.LoadDHCSP(startDate, endDate, page);
            //    toolStripProgressBar1.Value += 1;
            //    Application.DoEvents();
            //}
            LoadLog log = new LoadLog
            {
                StartDate = dateTimePicker1.Value,
                EndDate = dateTimePicker2.Value,
                RunDate = DateTime.Now,
                CCI_Institutional = GlobalVariables.TotalCCII,
                CCI_Professional = GlobalVariables.TotalCCIP,
                CMC_Institutional = GlobalVariables.TotalCMCI,
                CMC_Professional = GlobalVariables.TotalCMCP,
                DHCS_Institutional = GlobalVariables.TotalDHCSI,
                DHCS_Professional = GlobalVariables.TotalDHCSP,
                LoadedBy = Environment.UserName
            };
            //await LogUtility.SaveLog(log);
            lbRunningStatus.Text = "Loading data for" + startDate + " to " + endDate + " done!";
            btLoadData.Enabled = true;
        }
        private async Task btExport_ClickAsync()
        {
            if (string.IsNullOrEmpty(GlobalVariables.DestinationFolder))
            {
                MessageBox.Show("Must select file directory for exported 837 files");
                return;
            }
            if (!System.IO.Directory.Exists(GlobalVariables.DestinationFolder))
            {
                System.IO.Directory.CreateDirectory(GlobalVariables.DestinationFolder);
            }
            lbRunningStatus.Text = "Generating 837 files, ";
            btExport.Enabled = false;
            Application.DoEvents();
            string flag = "P";
            if (comboBox2.Text == "Test") flag = "T";
            switch (comboBox1.Text)
            {
                case "CCIE810":
                    lbRunningStatus.Text = "Exporting CCI DME 810";
                    await Export837.ExportCCIE("810", flag);
                    break;
                case "CCIE812":
                    lbRunningStatus.Text = "Exporting CCI DME 812";
                    await Export837.ExportCCIE("812", flag);
                    break;
                case "CCII810":
                    lbRunningStatus.Text = "Exporting CCI Institutional 810";
                    await Export837.ExportCCII("810", flag);
                    break;
                case "CCII812":
                    lbRunningStatus.Text = "Exporting CCI Institutional 812";
                    await Export837.ExportCCII("812", flag);
                    break;
                case "CCIP810":
                    lbRunningStatus.Text = "Exporting CCI Professional 810";
                    await Export837.ExportCCIP("810", flag);
                    break;
                case "CCIP812":
                    lbRunningStatus.Text = "Exporting CCI Professional 812";
                    await Export837.ExportCCIP("812", flag);
                    break;
                case "CCI_ALL":
                    lbRunningStatus.Text = "Exporting CCI ALL";
                    await Export837.ExportCCIE("810", flag);
                    await Export837.ExportCCIE("812", flag);
                    await Export837.ExportCCII("810", flag);
                    await Export837.ExportCCII("812", flag);
                    await Export837.ExportCCIP("810", flag);
                    await Export837.ExportCCIP("812", flag);
                    break;
                case "CMCE":
                    lbRunningStatus.Text = "Exporting CMC DME";
                    await Export837.ExportCMCE("H53", flag);
                    break;
                case "CMCI":
                    lbRunningStatus.Text = "Exporting CMC Institutional";
                    await Export837.ExportCMCI("H53", flag);
                    break;
                case "CMCP":
                    lbRunningStatus.Text = "Exporting CMC Professional";
                    await Export837.ExportCMCP("H53", flag);
                    break;
                case "CMC_ALL":
                    lbRunningStatus.Text = "Exporting CMC ALL";
                    await Export837.ExportCMCE("H53", flag);
                    await Export837.ExportCMCI("H53", flag);
                    await Export837.ExportCMCP("H53", flag);
                    break;
                case "DHCSI305":
                    lbRunningStatus.Text = "Exporting DHCS Institutional 305";
                    await ExportToDHCS.Export837IAsync("305", flag);
                    break;
                case "DHCSI306":
                    lbRunningStatus.Text = "Exporting DHCS Institutional 306";
                    await ExportToDHCS.Export837IAsync("306", flag);
                    break;
                case "DHCSP305":
                    lbRunningStatus.Text = "Exporting DHCS Professional 305";
                    await ExportToDHCS.Export837PAsync("305", flag);
                    break;
                case "DHCSP306":
                    lbRunningStatus.Text = "Exporting DHCS Professional 306";
                    await ExportToDHCS.Export837PAsync("306", flag);
                    break;
                case "DHCS_ALL":
                    lbRunningStatus.Text = "Exporting DHCS ALL";
                    await ExportToDHCS.Export837IAsync("305", flag);
                    await ExportToDHCS.Export837IAsync("306", flag);
                    await ExportToDHCS.Export837PAsync("305", flag);
                    await ExportToDHCS.Export837PAsync("306", flag);
                    break;
            }
            lbRunningStatus.Text = "Generating 837 files, Done";
            btExport.Enabled = true;
        }

        public void LoadSchedulesToDataGridView()
        {
            List<LoadLog> scheduleViews = LogUtility.GetLogs();
            if (scheduleViews.Count == 0) return;
            GlobalVariables.SchedulePages = new List<List<LoadLog>>();
            for (int i = 0; i < Math.Ceiling((decimal)scheduleViews.Count() / 20); i++)
            {
                GlobalVariables.SchedulePages.Add(scheduleViews.Skip(i * 20).Take(20).ToList());
            }
            bindingSource1.DataSource = GlobalVariables.SchedulePages;

            dataGridView1.DataSource = GlobalVariables.SchedulePages[0];
        }
        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (GlobalVariables.SchedulePages.Count == 0) return;
            dataGridView1.DataSource = GlobalVariables.SchedulePages[bindingSource1.Position];
        }
        private void btParseSubmission_Click(object sender, EventArgs e)
        {
            string sourceFolder = tbSubmissionSourceFolder.Text;
            string archiveFolder = tbSubmissionArchiveFolder.Text;
            if (string.IsNullOrEmpty(sourceFolder)) return;
            string logFolder = ConfigurationManager.AppSettings["LogFolder"];
            if (!Directory.Exists(archiveFolder)) Directory.CreateDirectory(archiveFolder);
            if (!Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);
            System.Text.StringBuilder sbLog = new StringBuilder();
            sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
            try
            {
                DirectoryInfo di = new DirectoryInfo(sourceFolder);
                FileInfo[] fis = di.GetFiles();
                Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                    using (var context = new SubHistoryContext())
                    {
                        SubmissionLog submittedfile = context.SubmissionLogs.Where(x => x.FileName == fi.Name).FirstOrDefault();
                        if (submittedfile != null)
                        {
                            listBox2.Items.Add("File " + fi.Name + " already processed before");
                            sbLog.AppendLine("File " + fi.Name + " already processed before");
                            return;
                        }
                        string s837 = File.ReadAllText(fi.FullName);
                        s837 = s837.Replace("\r", "").Replace("\n", "");
                        string[] s837Lines = s837.Split('~');
                        s837 = null;
                        int encounterCount = s837Lines.Count(x => x.StartsWith("CLM*"));
                        if (encounterCount == 0)
                        {
                            listBox2.Items.Add("File " + fi.Name + " not valid");
                            sbLog.AppendLine("File " + fi.Name + " not valid");
                            return;
                        }
                        listBox2.Items.Add("Processing file " + fi.Name + " total records: " + encounterCount.ToString());
                        sbLog.AppendLine("Processing file " + fi.Name + " total records: " + encounterCount.ToString());

                        submittedfile = new SubmissionLog();
                        submittedfile.FileName = fi.Name;
                        submittedfile.FilePath = sourceFolder;
                        submittedfile.EncounterCount = encounterCount;
                        submittedfile.CreatedDate = DateTime.Now;
                        //isa
                        string[] temp1 = s837Lines[0].Split('*');
                        submittedfile.SubmitterID = temp1[6];
                        submittedfile.ReceiverID = temp1[8];
                        submittedfile.InterchangeControlNumber = temp1[13];
                        submittedfile.ProductionFlag = temp1[15];
                        char elementDelimiter = Char.Parse(temp1[16]);
                        //gs
                        temp1 = s837Lines[1].Split('*');
                        submittedfile.InterchangeDate = temp1[4];
                        submittedfile.InterchangeTime = temp1[5];
                        submittedfile.FileType = temp1[8];
                        //bht
                        temp1 = s837Lines[3].Split('*');
                        submittedfile.BatchControlNumber = temp1[3];
                        submittedfile.ReportType = temp1[6];
                        //nm1*41
                        temp1 = s837Lines[4].Split('*');
                        submittedfile.SubmitterLastName = temp1[3];
                        submittedfile.SubmitterFirstName = temp1[4];
                        submittedfile.SubmitterMiddle = temp1[5];
                        //nm1*40
                        string tempstring = s837Lines.Where(x => x.StartsWith("NM1*40")).FirstOrDefault();
                        temp1 = tempstring.Split('*');
                        submittedfile.ReceiverLastName = temp1[3];
                        //clm
                        tempstring = s837Lines.Where(x => x.StartsWith("CLM*")).FirstOrDefault();
                        string ClaimID = tempstring.Split('*')[1];

                        context.SubmissionLogs.Add(submittedfile);
                        context.SaveChanges();

                        string LoopName = "";

                        Claim claim = new Claim();
                        claim.Header.FileID = submittedfile.FileID;
                        claim.Header.ClaimID = ClaimID;
                        List<Claim> claims = new List<Claim>();
                        bool saveFlag = false;

                        foreach (string s837Line in s837Lines)
                        {
                            ParseData.Process837.Process837Line(s837Line, ref submittedfile, ref LoopName, ref saveFlag, ref claim, ref claims, ref elementDelimiter);
                            if (claims.Count >= 1000)
                            {
                                SubHistoryUtility.SaveClaims(ref claims);
                                claims.Clear();
                            }
                        }
                        ParseData.Process837.InitilizeClaim("Claim", ref claim, ref claims, ref submittedfile);
                        SubHistoryUtility.SaveClaims(ref claims);
                        claims.Clear();
                        claim = null;
                        context.SaveChanges();
                    }
                    if (File.Exists(Path.Combine(archiveFolder, fi.Name))) File.Delete(Path.Combine(archiveFolder, fi.Name));
                    fi.MoveTo(Path.Combine(archiveFolder, fi.Name));
                });
            }
            catch (Exception ex)
            {
                sbLog.AppendLine(ex.Message);
            }
            finally
            {
                sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                File.AppendAllText(Path.Combine(logFolder, "SHRLog.txt"), sbLog.ToString());
            }
            MessageBox.Show("Parse submitted 837 files to database completed");
        }

        private void btLoadResponse_Click(object sender, EventArgs e)
        {
            switch (cbResponseFile.Text)
            {
                case "CMS 999":
                    ParseCms999();
                    break;
                case "CMS 277CA":
                    ParseCms277CA();
                    break;
                case "CMS MAO002":
                    ParseCmsMao2();
                    break;
                case "CMS MAO004":
                    ParseCmsMao4();
                    break;
                case "DHCS EVR":
                    ParseDhcsEvr();
                    break;
                case "835":
                    Parse835();
                    break;
                case "820":
                    Parse820();
                    break;

            }
        }
        private void ParseCms999()
        {
            string _999SourceFolder = tbResponseSourceFolder.Text;
            string _999ArchiveFolder = tbResponseArchiveFolder.Text;
            string _999LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            //processing 999 files
            if (_999SourceFolder != null && Directory.GetFiles(_999SourceFolder, "*", SearchOption.AllDirectories).Length > 0)
            {
                System.Text.StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(_999SourceFolder);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        using (var context = new Cms999Context())
                        {
                            List<_999Transaction> transactions = new List<_999Transaction>();
                            List<_999Error> errors = new List<_999Error>();
                            List<_999Element> elements = new List<_999Element>();
                            _999File processingFile = context.Table999File.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }
                            string s999 = File.ReadAllText(fi.FullName);
                            string[] s999Lines = s999.Split('~');
                            s999 = null;

                            processingFile = new _999File();
                            processingFile.FileName = fi.Name;

                            string tempSeg = s999Lines[1];
                            string[] tempArray = tempSeg.Split('*');
                            processingFile.ReceiverId = tempArray[2];
                            processingFile.SenderId = tempArray[3];
                            processingFile.TransactionDate = tempArray[4];
                            processingFile.TransactionTime = tempArray[5];
                            tempSeg = s999Lines[0];
                            tempArray = tempSeg.Split('*');
                            processingFile.ICN = tempArray[13];
                            processingFile.ProductionFlag = tempArray[15];
                            processingFile.CreateUser = Environment.UserName;
                            processingFile.CreateDate = DateTime.Today;
                            context.Table999File.Add(processingFile);
                            context.SaveChanges();
                            string loopName = "";
                            foreach (string s999Line in s999Lines)
                            {
                                ParseData.Parser.Parser999Line(s999Line, ref processingFile, ref transactions, ref errors, ref elements, ref loopName);
                            }

                            context.Table999Transaction.AddRange(transactions);
                            context.Table999Error.AddRange(errors); context.Table999Element.AddRange(elements);
                            context.SaveChanges();
                        }
                        if (File.Exists(Path.Combine(_999ArchiveFolder, fi.Name))) File.Delete(Path.Combine(_999ArchiveFolder, fi.Name));
                        fi.MoveTo(Path.Combine(_999ArchiveFolder, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(_999LogFolder, "999Log.txt"), sbLog.ToString());
                }
            }
        }
        private void ParseCms277CA()
        {
            string _277CaSourceFolder = tbResponseSourceFolder.Text;
            string _277CaArchiveFolder = tbResponseArchiveFolder.Text;
            string _277CaLogFolder = ConfigurationManager.AppSettings["LogFolder"];
            //processing 277CA files
            if (_277CaSourceFolder != null && Directory.GetFiles(_277CaSourceFolder, "*", SearchOption.AllDirectories).Length > 0)
            {
                System.Text.StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(_277CaSourceFolder);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        using (var context = new Cms277CAContext())
                        {
                            List<_277CABillProv> billProvs = new List<_277CABillProv>();
                            List<_277CAPatient> patients = new List<_277CAPatient>();
                            List<_277CALine> lines = new List<_277CALine>();
                            List<_277CAStc> stcs = new List<_277CAStc>();
                            _277CAFile processingFile = context.Table277CAFile.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }
                            string s277CA = File.ReadAllText(fi.FullName).Replace("\n", "");
                            string[] s277CALines = s277CA.Split('~');
                            s277CA = null;
                            int encounterCount = s277CALines.Count(x => x.StartsWith("TRN*2*")) - 1;
                            if (encounterCount <= 0)
                            {
                                Console.WriteLine("File " + fi.Name + " not valid");
                                sbLog.AppendLine("File " + fi.Name + " not valid");
                                return;
                            }
                            Console.WriteLine("Processing file " + fi.Name + " total records: " + encounterCount.ToString());
                            sbLog.AppendLine("Processing file " + fi.Name + " total records: " + encounterCount.ToString());

                            processingFile = new _277CAFile();
                            processingFile.FileName = fi.Name;

                            string tempSeg = s277CALines[1];
                            string[] tempArray = tempSeg.Split('*');
                            processingFile.ReceiverId = tempArray[2];
                            processingFile.SenderId = tempArray[3];
                            processingFile.TransactionDate = tempArray[4];
                            processingFile.TransactionTime = tempArray[5];
                            tempSeg = s277CALines[5];
                            tempArray = tempSeg.Split('*');
                            processingFile.ReceiverName = tempArray[3];
                            tempSeg = s277CALines[10];
                            tempArray = tempSeg.Split('*');
                            processingFile.SenderName = tempArray[3];
                            tempSeg = s277CALines[11];
                            tempArray = tempSeg.Split('*');
                            processingFile.BatchId = tempArray[2];
                            tempSeg = s277CALines[0];
                            tempArray = tempSeg.Split('*');
                            processingFile.ICN = tempArray[13];
                            char elementDelimiter = (char)tempArray[16].ToCharArray()[0];
                            processingFile.CreateUser = Environment.UserName;
                            processingFile.CreateDate = DateTime.Today;
                            context.Table277CAFile.Add(processingFile);
                            context.SaveChanges();

                            string LoopName = "";
                            foreach (string s277CALine in s277CALines)
                            {
                                ParseData.Parser.Parser277CALine(s277CALine, ref processingFile, ref billProvs, ref patients,
                                    ref lines, ref stcs, ref LoopName, ref elementDelimiter);
                            }

                            context.Table277CABillProv.AddRange(billProvs);
                            context.Table277CAPatient.AddRange(patients);
                            context.Table277CALine.AddRange(lines);
                            context.Table277CAStc.AddRange(stcs);
                            context.SaveChanges();
                        }
                        if (File.Exists(Path.Combine(_277CaArchiveFolder, fi.Name))) File.Delete(Path.Combine(_277CaArchiveFolder, fi.Name));
                        fi.MoveTo(Path.Combine(_277CaArchiveFolder, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(_277CaLogFolder, "277CALog.txt"), sbLog.ToString());
                }

            }
        }
        private void ParseCmsMao2()
        {
            string MAO2SourceFolder = tbResponseSourceFolder.Text;
            string MAO2ArchiveFolder = tbResponseArchiveFolder.Text;
            string MAO2LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            //processing mao002 files
            if (MAO2SourceFolder != null && Directory.GetFiles(MAO2SourceFolder, "*", SearchOption.AllDirectories).Length > 0)
            {
                System.Text.StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(MAO2SourceFolder);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        using (var context = new CmsMao2Context())
                        {
                            List<MAO2Detail> details = new List<MAO2Detail>();
                            MAO2File processingFile = context.TableMao2File.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }

                            processingFile = new MAO2File
                            {
                                FileName = fi.Name,
                                CreateUser = Environment.UserName,
                                CreateDate = DateTime.Today
                            };
                            context.TableMao2File.Add(processingFile);
                            context.SaveChanges();
                            using (StreamReader sr = fi.OpenText())
                            {
                                string line = "";
                                while ((line = sr.ReadLine()) != null)
                                {
                                    ParseData.Parser.ParserMao2Line(line, ref processingFile, ref details);
                                }
                            }

                            context.TableMao2Detail.AddRange(details);
                            context.SaveChanges();
                        }
                        if (File.Exists(Path.Combine(MAO2ArchiveFolder, fi.Name))) File.Delete(Path.Combine(MAO2ArchiveFolder, fi.Name));
                        fi.MoveTo(Path.Combine(MAO2ArchiveFolder, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(MAO2LogFolder, "Mao2Log.txt"), sbLog.ToString());
                }
            }
        }
        private void ParseCmsMao4()
        {
            string ConnectionString = ConfigurationManager.AppSettings["CmsMao4ConnectionString"];
            string sourceFolder = tbResponseSourceFolder.Text;
            string archiveFolder = tbResponseArchiveFolder.Text;
            if (string.IsNullOrEmpty(sourceFolder)) return;
            string logFolder = ConfigurationManager.AppSettings["LogFolder"];
            if (!Directory.Exists(archiveFolder)) Directory.CreateDirectory(archiveFolder);
            if (!Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);
            DirectoryInfo di = new DirectoryInfo(sourceFolder);
            FileInfo[] fis = di.GetFiles();
            foreach (FileInfo fi in fis)
            {
                string FileName = fi.FullName;
                string s = File.ReadAllText(FileName);
                s.Replace("\r", "");
                string[] MAO4Lines = s.Split('\n');
                s = null;
                string[] MAO4Header = MAO4Lines[0].Split('*');
                string[] MAO4Trailer = MAO4Lines[MAO4Lines.Length - 1].Split('*');
                SqlConnection cn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into MAO_004_Header (TransmissionId,ReportId,ContractId,ReportDate,ReportDescription,SubmissionFileType,RecordCount,Phase,Version,CreateUser) values(@TransmissionId,@ReportId,@ContractId,@ReportDate,@ReportDescription,@SubmissionFileType,@RecordCount,@Phase,@Version,@CreateUser);select Scope_identity();";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@TransmissionId", null);
                cmd.Parameters.AddWithValue("@ReportId", MAO4Header[1]);
                cmd.Parameters.AddWithValue("@ContractId", MAO4Header[2]);
                cmd.Parameters.AddWithValue("@ReportDate", MAO4Header[3]);
                cmd.Parameters.AddWithValue("@ReportDescription", MAO4Header[4]);
                cmd.Parameters.AddWithValue("@SubmissionFileType", MAO4Header[6]);
                cmd.Parameters.AddWithValue("@RecordCount", MAO4Trailer[3]);
                cmd.Parameters.AddWithValue("@Phase", "3");
                cmd.Parameters.AddWithValue("@Version", "1");
                cmd.Parameters.AddWithValue("@CreateUser", Environment.UserName);
                cn.Open();
                object result = cmd.ExecuteScalar();
                cn.Close();
                int HeaderId = int.Parse(result.ToString());
                string[] MAO4detail;
                string EncounterICN = "";
                int DetailId = 0;
                Dictionary<string, string> DiagDic = null;
                string ICD = null;
                for (int i = 1; i < MAO4Lines.Length - 1; i++)
                {
                    MAO4detail = MAO4Lines[i].Split('*');
                    if (EncounterICN != MAO4detail[4])
                    {
                        cmd = new SqlCommand();
                        cmd.CommandText = "insert into MAO_004_Detail (HeaderId,ReportId,MedicareContractId,BeneficiaryHICN,EncounterICN,EncounterTypeSwitch,OriginalEncounterICN,OriginalEncounterStatus,AllowDisallowFlag,AllowDisallowReasnCode,SubmissionDate,ServiceStartDate,ServiceEndDate,ClaimType,CreateUser) values(@HeaderId,@ReportId,@MedicareContractId,@BeneficiaryHICN,@EncounterICN,@EncounterTypeSwitch,@OriginalEncounterICN,@OriginalEncounterStatus,@AllowDisallowFlag,@AllowDisallowReasonCode,@SubmissionDate,@ServiceStartDate,@ServiceEndDate,@ClaimType,@CreateUser);select scope_identity();";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@HeaderId", HeaderId);
                        cmd.Parameters.AddWithValue("@ReportId", MAO4detail[1]);
                        cmd.Parameters.AddWithValue("@MedicareContractId", MAO4detail[2]);
                        cmd.Parameters.AddWithValue("@BeneficiaryHICN", MAO4detail[3]);
                        cmd.Parameters.AddWithValue("@EncounterICN", MAO4detail[4]);
                        cmd.Parameters.AddWithValue("@EncounterTypeSwitch", MAO4detail[5]);
                        cmd.Parameters.AddWithValue("@OriginalEncounterICN", MAO4detail[6]);
                        cmd.Parameters.AddWithValue("@OriginalEncounterStatus", MAO4detail[7]);
                        cmd.Parameters.AddWithValue("@AllowDisallowFlag", MAO4detail[12]);
                        cmd.Parameters.AddWithValue("@AllowDisallowReasonCode", MAO4detail[13]);
                        cmd.Parameters.AddWithValue("@SubmissionDate", MAO4detail[8]);
                        cmd.Parameters.AddWithValue("@ServiceStartDate", MAO4detail[9]);
                        cmd.Parameters.AddWithValue("@ServiceEndDate", MAO4detail[10]);
                        cmd.Parameters.AddWithValue("@ClaimType", MAO4detail[11]);
                        cmd.Parameters.AddWithValue("@CreateUser", Environment.UserName);
                        cn.Open();
                        result = cmd.ExecuteScalar();
                        cn.Close();
                        DetailId = int.Parse(result.ToString());
                        ICD = MAO4detail[14];
                        DiagDic = new Dictionary<string, string>();
                        for (int j = 0; j < 38; j++)
                        {
                            if (!string.IsNullOrEmpty(MAO4detail[2 * j + 15].Trim()))
                            {
                                DiagDic.Add(MAO4detail[2 * j + 15].Trim(), MAO4detail[2 * j + 16]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        foreach (KeyValuePair<string, string> kvp in DiagDic)
                        {
                            cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cmd.CommandText = "insert into MAO_004_DiagnosisCode (DetailId,Code,ICD,Flag,CreateUser) values(@DetailId,@Code,@ICD,@Flag,@CreateUser)";
                            cmd.Parameters.AddWithValue("@DetailId", DetailId);
                            cmd.Parameters.AddWithValue("@Code", kvp.Key);
                            cmd.Parameters.AddWithValue("@ICD", ICD);
                            cmd.Parameters.AddWithValue("@Flag", kvp.Value);
                            cmd.Parameters.AddWithValue("@CreateUser", Environment.UserName);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                    else
                    {
                        DiagDic = new Dictionary<string, string>();
                        for (int j = 0; j < 38; j++)
                        {
                            if (!string.IsNullOrEmpty(MAO4detail[2 * j + 15].Trim()))
                            {
                                DiagDic.Add(MAO4detail[2 * j + 15].Trim(), MAO4detail[2 * j + 16]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        foreach (KeyValuePair<string, string> kvp in DiagDic)
                        {
                            cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cmd.CommandText = "insert into MAO_004_DiagnosisCode (DetailId,Code,ICD,Flag,CreateUser) values(@DetailId,@Code,@ICD,@Flag,@CreateUser)";
                            cmd.Parameters.AddWithValue("@DetailId", DetailId);
                            cmd.Parameters.AddWithValue("@Code", kvp.Key);
                            cmd.Parameters.AddWithValue("@ICD", ICD);
                            cmd.Parameters.AddWithValue("@Flag", kvp.Value);
                            cmd.Parameters.AddWithValue("@CreateUser", Environment.UserName);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }

                    }

                    EncounterICN = MAO4detail[4];
                }
                cmd.Dispose();
            }
        }
        private void ParseDhcsEvr()
        {
            string DHCSSourceFolder = tbResponseSourceFolder.Text;
            string DHCSArchiveFolder = tbResponseArchiveFolder.Text;
            string DHCSLogFolder = ConfigurationManager.AppSettings["LogFolder"];
            if (!Directory.Exists(DHCSArchiveFolder)) Directory.CreateDirectory(DHCSArchiveFolder);
            if (!Directory.Exists(DHCSLogFolder)) Directory.CreateDirectory(DHCSLogFolder);
            //processing dhcs response files
            if (DHCSSourceFolder != null && Directory.GetFiles(DHCSSourceFolder, "*", SearchOption.AllDirectories).Length > 0)
            {
                System.Text.StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(DHCSSourceFolder);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        using (var context = new DHCSContext())
                        {
                            List<DHCSTransaction> transactions = new List<DHCSTransaction>();
                            List<DHCSEncounter> encounters = new List<DHCSEncounter>();
                            List<DHCSEncounterResponse> responses = new List<DHCSEncounterResponse>();
                            List<DHCSServiceLine> lines = new List<DHCSServiceLine>();
                            DHCSFile processingFile = context.TableDHCSFile.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }
                            Console.WriteLine("File " + fi.Name + " is processing now...");
                            sbLog.AppendLine("File " + fi.Name + " is processing now...");

                            XDocument xDoc = XDocument.Load(fi.FullName);
                            XNamespace ns = "http://www.dhcs.ca.gov/EDS/DHCSResponse";
                            processingFile = new DHCSFile
                            {
                                FileName = fi.Name,
                                EncounterFileName = xDoc.Descendants(ns + "EncounterFileName").FirstOrDefault()?.Value,
                                SubmitterName =
                                xDoc.Descendants(ns + "EncounterSubmitterName").FirstOrDefault()?.Value,
                                SubmissionDate =
                                xDoc.Descendants(ns + "EncounterSubmissionDate").FirstOrDefault()?.Value,
                                ValidationStatus = xDoc.Descendants(ns + "ValidationStatus").FirstOrDefault()?.Value,
                                CreateUser = Environment.UserName,
                                CreateDate = DateTime.Today
                            };
                            context.TableDHCSFile.Add(processingFile);
                            context.SaveChanges();
                            foreach (XElement eleTransaction in xDoc.Descendants(ns + "Transaction"))
                            {
                                DHCSTransaction transaction = new DHCSTransaction();
                                transaction.FileId = processingFile.FileId;
                                transaction.TransactionStatus = eleTransaction.Attributes("Status").FirstOrDefault()?.Value;
                                transaction.TransactionNumber =
                                    eleTransaction.Descendants(ns + "TransactionNumber").FirstOrDefault()?.Value;
                                foreach (XElement ele in eleTransaction.Descendants(ns + "Identifiers").Descendants(ns + "Envelope"))
                                {
                                    switch (ele.Attributes("IdentifierName").FirstOrDefault()?.Value)
                                    {
                                        case "ISAControlNumber":
                                            transaction.ISAControlNumber =
                                                ele.Attributes("IdentifierValue").FirstOrDefault()?.Value;
                                            break;
                                        case "GroupControlNumber":
                                            transaction.GroupControlNumber =
                                                ele.Attributes("IdentifierValue").FirstOrDefault()?.Value;
                                            break;
                                        case "OriginatorTransactionId":
                                            transaction.OriginatorTransactionId =
                                                ele.Attributes("IdentifierValue").FirstOrDefault()?.Value;
                                            break;
                                    }
                                }
                                transactions.Add(transaction);
                                foreach (XElement eleEncounter in eleTransaction.Descendants(ns + "Encounter"))
                                {
                                    DHCSEncounter encounter = new DHCSEncounter
                                    {
                                        FileId = processingFile.FileId,
                                        TransactionNumber = transactions.Last().TransactionNumber,
                                        EncounterStatus = eleEncounter.Attributes("Status").FirstOrDefault()?.Value,
                                        EncounterReferenceNumber =
                                        eleEncounter.Descendants(ns + "EncounterReferenceNumber").FirstOrDefault()?.Value,
                                        DHCSEncounterId = eleEncounter.Descendants(ns + "EncounterId").FirstOrDefault()?.Value
                                    };
                                    encounters.Add(encounter);
                                    foreach (XElement eleResponse in eleEncounter.Descendants(ns + "Response"))
                                    {
                                        DHCSEncounterResponse response = new DHCSEncounterResponse
                                        {
                                            FileId = processingFile.FileId,
                                            TransactionNumber = transactions.Last().TransactionNumber,
                                            EncounterReferenceNumber = encounters.Last().EncounterReferenceNumber,
                                            Severity = eleResponse.Attributes("Severity").FirstOrDefault()?.Value,
                                            IssueId = eleResponse.Descendants(ns + "Id").FirstOrDefault()?.Value,
                                            IsSNIP = eleResponse.Descendants(ns + "IsSNIP").FirstOrDefault()?.Value,
                                            IssueDescription =
                                            eleResponse.Descendants(ns + "Description").FirstOrDefault()?.Value
                                        };
                                        responses.Add(response);
                                    }

                                    foreach (XElement eleService in eleEncounter.Descendants(ns + "Service"))
                                    {
                                        DHCSServiceLine line = new DHCSServiceLine
                                        {
                                            FileId = processingFile.FileId,
                                            TransactionNumber = transactions.Last().TransactionNumber,
                                            EncounterReferenceNumber = encounters.Last().EncounterReferenceNumber,
                                            Line = eleService.Attributes().FirstOrDefault()?.Value,
                                            Severity = eleService.Descendants(ns + "Response").FirstOrDefault()?.Attributes().FirstOrDefault()?.Value,
                                            Id = eleService.Descendants(ns + "Id").FirstOrDefault()?.Value,
                                            Description = eleService.Descendants(ns + "Description").FirstOrDefault()?.Value
                                        };
                                        lines.Add(line);
                                    }
                                }
                            }

                            context.TableDHCSTransaction.AddRange(transactions);
                            context.TableDHCSEncounter.AddRange(encounters);
                            context.TableDHCSEncounterResponse.AddRange(responses);
                            context.TableDHCSServiceLine.AddRange(lines);
                            context.SaveChanges();
                        }
                        if (File.Exists(Path.Combine(DHCSArchiveFolder, fi.Name))) File.Delete(Path.Combine(DHCSArchiveFolder, fi.Name));
                        fi.MoveTo(Path.Combine(DHCSArchiveFolder, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(DHCSLogFolder, "DHCSLog.txt"), sbLog.ToString());
                }
            }
        }
        private void Parse835()
        {
            string SourceFolder835 = tbResponseSourceFolder.Text;
            string ArchiveFolder835 = tbResponseArchiveFolder.Text;
            string LogFolder835 = ConfigurationManager.AppSettings["LogFolder"];
            if (!Directory.Exists(ArchiveFolder835)) Directory.CreateDirectory(ArchiveFolder835);
            if (!Directory.Exists(LogFolder835)) Directory.CreateDirectory(LogFolder835);
            //processing 835 files
            if (SourceFolder835 != null && Directory.GetFiles(SourceFolder835, "*", SearchOption.AllDirectories).Length > 0)
            {
                StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(SourceFolder835);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        using (var context = new Context835())
                        {
                            List<Claim835> claims = new List<Claim835>();
                            File835 processingFile = context.File835s.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }
                            string s835 = File.ReadAllText(fi.FullName).Replace("\n", "").Replace("\r", "");
                            string[] s835Lines = s835.Split('~');
                            s835 = null;
                            int encounterCount = s835Lines.Count(x => x.StartsWith("CLP*"));
                            if (encounterCount < 1)
                            {
                                Console.WriteLine("File " + fi.Name + " not valid");
                                sbLog.AppendLine("File " + fi.Name + " not valid");
                                return;
                            }
                            Console.WriteLine("Processing file " + fi.Name + " total records: " + encounterCount.ToString());
                            sbLog.AppendLine("Processing file " + fi.Name + " total records: " + encounterCount.ToString());

                            processingFile = new File835();
                            processingFile.FileName = fi.Name;

                            string tempSeg = s835Lines[0];
                            string[] tempArray = tempSeg.Split('*');
                            processingFile.SenderIdQualifier = tempArray[5];
                            processingFile.SenderId = tempArray[6].Trim();
                            processingFile.ReceiverIdQualifier = tempArray[7];
                            processingFile.ReceiverId = tempArray[8].Trim();
                            processingFile.InterchangeControlNumber = tempArray[13];
                            processingFile.ProductionFlag = tempArray[15];
                            char elementDelimiter = (char)tempArray[16].ToCharArray()[0];
                            processingFile.CreateUser = Environment.UserName;
                            processingFile.CreateDate = DateTime.Now;
                            tempSeg = s835Lines[1];
                            tempArray = tempSeg.Split('*');
                            processingFile.TransactionDate = tempArray[4];
                            processingFile.TransactionTime = tempArray[5];
                            tempSeg = s835Lines[3];
                            tempArray = tempSeg.Split('*');
                            processingFile.MoneytaryAmount = tempArray[2];
                            processingFile.CreditFlag = tempArray[3];
                            processingFile.PaymentMethodCode = tempArray[4];
                            processingFile.PaymentFormatCode = tempArray[5];
                            processingFile.Sender_Dfi_Id_Qualifier = tempArray[6];
                            processingFile.Sender_Dfi_Id = tempArray[7];
                            processingFile.SenderAccountQualifier = tempArray[8];
                            processingFile.SenderAccountNumber = tempArray[9];
                            processingFile.OriginatingCompanyId = tempArray[10];
                            processingFile.OriginatingCompanySupplementalCode = tempArray[11];
                            processingFile.Receiver_Dfi_Id_Qualifier = tempArray[12];
                            processingFile.ReceiverBankId = tempArray[13];
                            processingFile.ReceiverAccountQualifier = tempArray[14];
                            processingFile.ReceiverAccountNumber = tempArray[15];
                            processingFile.CheckIssueDate = tempArray[16];
                            tempSeg = s835Lines[4];
                            tempArray = tempSeg.Split('*');
                            processingFile.TraceTypeCode = tempArray[1];
                            processingFile.ReferenceId = tempArray[2];
                            if (tempArray.Length > 4) processingFile.OriginatingComapnySupplementalCode = tempArray[4];

                            context.File835s.Add(processingFile);
                            context.SaveChanges();
                            string LoopNumber = "0000";
                            foreach (string s835Line in s835Lines)
                            {
                                ParseData.Process835.Process835Line(s835Line, elementDelimiter, ref processingFile, ref claims, ref LoopNumber);
                            }

                            context.Claim835s.AddRange(claims);
                            context.SaveChanges();
                        }
                        if (File.Exists(Path.Combine(ArchiveFolder835, fi.Name))) File.Delete(Path.Combine(ArchiveFolder835, fi.Name));
                        fi.MoveTo(Path.Combine(ArchiveFolder835, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(LogFolder835, "Log835.txt"), sbLog.ToString());
                }

            }
        }
        private void Parse820()
        {
            string Premium820SourceFolder = tbResponseSourceFolder.Text; ;
            string Premium820ArchiveFolder = tbResponseArchiveFolder.Text;
            string Premium820LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            if (!Directory.Exists(Premium820ArchiveFolder)) Directory.CreateDirectory(Premium820ArchiveFolder);
            if (!Directory.Exists(Premium820LogFolder)) Directory.CreateDirectory(Premium820LogFolder);
            //processing dhcs response files
            if (Premium820SourceFolder != null && Directory.GetFiles(Premium820SourceFolder, "*", SearchOption.AllDirectories).Length > 0)
            {
                System.Text.StringBuilder sbLog = new StringBuilder();
                sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
                try
                {
                    DirectoryInfo di = new DirectoryInfo(Premium820SourceFolder);
                    FileInfo[] fis = di.GetFiles();
                    Parallel.ForEach(fis, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (fi) => {
                        List<Member820> premiums = new List<Member820>();
                        using (var context = new Premium820Context())
                        {
                            File820 processingFile = context.Premium820File.FirstOrDefault(x => x.FileName == fi.Name);
                            if (processingFile != null)
                            {
                                Console.WriteLine("File " + fi.Name + " already processed before");
                                sbLog.AppendLine("File " + fi.Name + " already processed before");
                                return;
                            }
                            Console.WriteLine("Processing file " + fi.Name + " now...");
                            sbLog.AppendLine("Processing file " + fi.Name + " now...");
                            string s820 = File.ReadAllText(fi.FullName).Replace("\r", "").Replace("\n", "");
                            string[] s820Lines = s820.Split('~');
                            s820 = null;
                            processingFile = new File820();
                            processingFile.FileName = fi.Name;
                            string[] tempSegs = s820Lines[0].Split('*');
                            processingFile.SenderId = tempSegs[6];
                            processingFile.ReceiverId = tempSegs[8];
                            processingFile.InterchangeControlNumber = tempSegs[13];
                            tempSegs = s820Lines[1].Split('*');
                            processingFile.TransactionDate = tempSegs[4];
                            processingFile.TransactionTime = tempSegs[5];
                            tempSegs = s820Lines[3].Split('*');
                            processingFile.TotalPremiumAmount = tempSegs[2];
                            processingFile.PaymentMethodQualifier = tempSegs[3];
                            processingFile.PaymentMethod = tempSegs[4];
                            processingFile.TransactionNumber = tempSegs[10];
                            processingFile.CheckIssueDate = tempSegs[16];
                            tempSegs = s820Lines[4].Split('*');
                            processingFile.TraceTypeCode = tempSegs[1];
                            processingFile.TraceNumber = tempSegs[2];
                            context.Premium820File.Add(processingFile);
                            context.SaveChanges();
                            string loopName = "";
                            bool firstRMR = true;
                            foreach (string line in s820Lines)
                            {
                                ParseData.Parser820.Parse820Line(line, ref loopName, ref processingFile, ref premiums, ref firstRMR);
                            }
                            context.Premium820Member.AddRange(premiums);
                            context.SaveChanges();
                        }

                        if (File.Exists(Path.Combine(Premium820ArchiveFolder, fi.Name))) File.Delete(Path.Combine(Premium820ArchiveFolder, fi.Name));
                        fi.MoveTo(Path.Combine(Premium820ArchiveFolder, fi.Name));
                    });
                }
                catch (Exception ex)
                {
                    sbLog.AppendLine(ex.Message);
                }
                finally
                {
                    sbLog.AppendLine("End time:" + DateTime.Now.ToString());
                    File.AppendAllText(Path.Combine(Premium820LogFolder, "Premium820Log.txt"), sbLog.ToString());
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Meditrac" && tabControl1.SelectedTab == tabPage5) { tabControl1.SelectedTab = tabPage1; }
            if (treeView1.SelectedNode.Text == "Trading Partner" && tabControl1.SelectedTab == tabPage1) { tabControl1.SelectedTab = tabPage5; }
        }
        private async Task btLoadTP837s_ClickAsync()
        {
            string SourceFolder = tbTP837sSourceFolder.Text;
            string ArchiveFolder = tbTP837sArchiveFolder.Text;
            string LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            string EVRFolder = tbEVRReportFolder.Text;
            if (!Directory.Exists(ArchiveFolder)) Directory.CreateDirectory(ArchiveFolder);
            if (!Directory.Exists(LogFolder)) Directory.CreateDirectory(LogFolder);
            if (!Directory.Exists(EVRFolder)) Directory.CreateDirectory(EVRFolder);
            DirectoryInfo di = new DirectoryInfo(SourceFolder);
            FileInfo[] fis = di.GetFiles();
            System.Text.StringBuilder sbLog = new StringBuilder();
            sbLog.AppendLine("Start time:" + DateTime.Now.ToString());
            foreach (FileInfo fi in fis)
            {
                sbLog.AppendLine(await LoadData.LoadTradingPartner.LoadTradingPartner837(fi, SourceFolder, ArchiveFolder, EVRFolder));
            }

            sbLog.AppendLine("End time:" + DateTime.Now.ToString());
            File.AppendAllText(Path.Combine(LogFolder, "LoadTP837sLog.txt"), sbLog.ToString());
            MessageBox.Show("Load Trading Partner 837s completed");
        }
    }
}
