namespace RegexTester
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using RegexTester.My;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;

    [DesignerGenerated]
    public class MainForm : Form
    {
        private IContainer components;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("MenuStrip1")]
        private MenuStrip _MenuStrip1;
        [AccessedThroughProperty("mnuFile")]
        private ToolStripMenuItem _mnuFile;
        [AccessedThroughProperty("mnuOptions")]
        private ToolStripMenuItem _mnuOptions;
        [AccessedThroughProperty("mnuOptionsIgnoreCase")]
        private ToolStripMenuItem _mnuOptionsIgnoreCase;
        [AccessedThroughProperty("mnuOptionsMultiline")]
        private ToolStripMenuItem _mnuOptionsMultiline;
        [AccessedThroughProperty("mnuOptionsIgnoreWhitespace")]
        private ToolStripMenuItem _mnuOptionsIgnoreWhitespace;
        [AccessedThroughProperty("mnuOptionsCompiled")]
        private ToolStripMenuItem _mnuOptionsCompiled;
        [AccessedThroughProperty("mnuOptionsExplicitCapture")]
        private ToolStripMenuItem _mnuOptionsExplicitCapture;
        [AccessedThroughProperty("mnuOptionsRightToLeft")]
        private ToolStripMenuItem _mnuOptionsRightToLeft;
        [AccessedThroughProperty("mnuOptionsCultureInvariant")]
        private ToolStripMenuItem _mnuOptionsCultureInvariant;
        [AccessedThroughProperty("mnuOptionsEcmaScript")]
        private ToolStripMenuItem _mnuOptionsEcmaScript;
        [AccessedThroughProperty("mnuFileOpen")]
        private ToolStripMenuItem _mnuFileOpen;
        [AccessedThroughProperty("dlgOpenDoc")]
        private OpenFileDialog _dlgOpenDoc;
        [AccessedThroughProperty("rtbSource")]
        private RichTextBox _rtbSource;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("mnuFileNew")]
        private ToolStripMenuItem _mnuFileNew;
        [AccessedThroughProperty("mnuResults")]
        private ToolStripMenuItem _mnuResults;
        [AccessedThroughProperty("mnuCommands")]
        private ToolStripMenuItem _mnuCommands;
        [AccessedThroughProperty("mnuCommandsFind")]
        private ToolStripMenuItem _mnuCommandsFind;
        [AccessedThroughProperty("mnuCommandsReplace")]
        private ToolStripMenuItem _mnuCommandsReplace;
        [AccessedThroughProperty("mnuCommandsSplit")]
        private ToolStripMenuItem _mnuCommandsSplit;
        [AccessedThroughProperty("ToolStripSeparator1")]
        private ToolStripSeparator _ToolStripSeparator1;
        [AccessedThroughProperty("mnuCommandsEscape")]
        private ToolStripMenuItem _mnuCommandsEscape;
        [AccessedThroughProperty("lblReplace")]
        private Label _lblReplace;
        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip _StatusStrip1;
        [AccessedThroughProperty("staExecutionTime")]
        private ToolStripStatusLabel _staExecutionTime;
        [AccessedThroughProperty("staMatches")]
        private ToolStripStatusLabel _staMatches;
        [AccessedThroughProperty("tvwResults")]
        private TreeView _tvwResults;
        [AccessedThroughProperty("mnuResultsGroups")]
        private ToolStripMenuItem _mnuResultsGroups;
        [AccessedThroughProperty("mnuResultsCaptures")]
        private ToolStripMenuItem _mnuResultsCaptures;
        [AccessedThroughProperty("mnuResultsNoDetails")]
        private ToolStripMenuItem _mnuResultsNoDetails;
        [AccessedThroughProperty("ToolStripSeparator2")]
        private ToolStripSeparator _ToolStripSeparator2;
        [AccessedThroughProperty("mnuResultsDontSort")]
        private ToolStripMenuItem _mnuResultsDontSort;
        [AccessedThroughProperty("mnuResultsSortAlphabetically")]
        private ToolStripMenuItem _mnuResultsSortAlphabetically;
        [AccessedThroughProperty("mnuResultsShortest")]
        private ToolStripMenuItem _mnuResultsShortest;
        [AccessedThroughProperty("mnuResultsLargest")]
        private ToolStripMenuItem _mnuResultsLargest;
        [AccessedThroughProperty("ToolStripTextBox1")]
        private ToolStripMenuItem _ToolStripTextBox1;
        [AccessedThroughProperty("txtViewMaxMatches")]
        private ToolStripTextBox _txtViewMaxMatches;
        [AccessedThroughProperty("rtbResults")]
        private RichTextBox _rtbResults;
        [AccessedThroughProperty("ToolStripMenuItem1")]
        private ToolStripSeparator _ToolStripMenuItem1;
        [AccessedThroughProperty("ctxPattern")]
        private ContextMenuStrip _ctxPattern;
        [AccessedThroughProperty("ctxReplace")]
        private ContextMenuStrip _ctxReplace;
        [AccessedThroughProperty("rtbRegex")]
        private RichTextBox _rtbRegex;
        [AccessedThroughProperty("rtbReplace")]
        private RichTextBox _rtbReplace;
        [AccessedThroughProperty("mnuCommandsRun")]
        private ToolStripMenuItem _mnuCommandsRun;
        [AccessedThroughProperty("ToolStripSeparator3")]
        private ToolStripSeparator _ToolStripSeparator3;
        [AccessedThroughProperty("mnuFileSave")]
        private ToolStripMenuItem _mnuFileSave;
        [AccessedThroughProperty("mnuFileSaveAs")]
        private ToolStripMenuItem _mnuFileSaveAs;
        [AccessedThroughProperty("ToolStripSeparator4")]
        private ToolStripSeparator _ToolStripSeparator4;
        [AccessedThroughProperty("mnuFileProperties")]
        private ToolStripMenuItem _mnuFileProperties;
        [AccessedThroughProperty("ToolStripSeparator5")]
        private ToolStripSeparator _ToolStripSeparator5;
        [AccessedThroughProperty("mnuFileLoad")]
        private ToolStripMenuItem _mnuFileLoad;
        [AccessedThroughProperty("ToolStripSeparator6")]
        private ToolStripSeparator _ToolStripSeparator6;
        [AccessedThroughProperty("mnuFileExit")]
        private ToolStripMenuItem _mnuFileExit;
        [AccessedThroughProperty("staItemInfo")]
        private ToolStripStatusLabel _staItemInfo;
        [AccessedThroughProperty("mnuResultsTreeView")]
        private ToolStripMenuItem _mnuResultsTreeView;
        [AccessedThroughProperty("mnuResultsReport")]
        private ToolStripMenuItem _mnuResultsReport;
        [AccessedThroughProperty("ToolStripSeparator7")]
        private ToolStripSeparator _ToolStripSeparator7;
        [AccessedThroughProperty("lblMatches")]
        private Label _lblMatches;
        [AccessedThroughProperty("mnuResultsAuto")]
        private ToolStripMenuItem _mnuResultsAuto;
        [AccessedThroughProperty("mnuEdit")]
        private ToolStripMenuItem _mnuEdit;
        [AccessedThroughProperty("mnuEditWordWrap")]
        private ToolStripMenuItem _mnuEditWordWrap;
        [AccessedThroughProperty("dlgOpenRegex")]
        private OpenFileDialog _dlgOpenRegex;
        [AccessedThroughProperty("dlgSaveRegex")]
        private SaveFileDialog _dlgSaveRegex;
        [AccessedThroughProperty("mnuCommandsGenerateCode")]
        private ToolStripMenuItem _mnuCommandsGenerateCode;
        [AccessedThroughProperty("mnuCommandsShowGroups")]
        private ToolStripMenuItem _mnuCommandsShowGroups;
        [AccessedThroughProperty("mnuResultsIncludeEmptyGroups")]
        private ToolStripMenuItem _mnuResultsIncludeEmptyGroups;
        [AccessedThroughProperty("mnuCommandsCompile")]
        private ToolStripMenuItem _mnuCommandsCompile;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("HelpProvider1")]
        private HelpProvider _HelpProvider1;
        [AccessedThroughProperty("mnuHelp")]
        private ToolStripMenuItem _mnuHelp;
        [AccessedThroughProperty("mnuHelpAbout")]
        private ToolStripMenuItem _mnuHelpAbout;
        [AccessedThroughProperty("mnuOptionsSingleline")]
        private ToolStripMenuItem _mnuOptionsSingleline;
        internal ProjectOptions Options;
        internal Regex re;
        internal RegexTester.CompileForm CompileForm;

        public MainForm()
        {
            base.Load += new EventHandler(this.MainForm_Load);
            this.Options = new ProjectOptions();
            this.InitializeComponent();
        }

        public void BuildRegexMenu()
        {
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("RegexTester.Regexes.xml"));
            string xml = reader.ReadToEnd();
            reader.Close();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            this.BuildRegexMenu_Sub(xmlDoc, this.ctxPattern, 1);
            this.BuildRegexMenu_Sub(xmlDoc, this.ctxReplace, 2);
        }

        public void BuildRegexMenu_Sub(XmlDocument xmlDoc, ContextMenuStrip rootMenu, int bitMask)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = xmlDoc.SelectNodes("//group").GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XmlElement current = (XmlElement) enumerator.Current;
                    if ((Conversions.ToInteger(current.GetAttribute("includeBits")) & bitMask) != 0)
                    {
                        string text = current.GetAttribute("text").Replace("?", "&");
                        if (text == "-")
                        {
                            rootMenu.Items.Add(new ToolStripSeparator());
                        }
                        else
                        {
                            IEnumerator enumerator2;
                            string str2 = current.GetAttribute("toolTip").Replace("?", "\r\n");
                            ToolStripMenuItem item = new ToolStripMenuItem(text);
                            item.ToolTipText = str2;
                            rootMenu.Items.Add(item);
                            try
                            {
                                enumerator2 = current.SelectNodes("item").GetEnumerator();
                                while (enumerator2.MoveNext())
                                {
                                    XmlElement element2 = (XmlElement) enumerator2.Current;
                                    string str3 = element2.GetAttribute("text").Replace("?", "&");
                                    if (str3 == "-")
                                    {
                                        item.DropDownItems.Add(new ToolStripSeparator());
                                    }
                                    else
                                    {
                                        string str4 = element2.GetAttribute("toolTip").Replace("?", "\r\n");
                                        string attribute = element2.GetAttribute("regex");
                                        ToolStripMenuItem item2 = new ToolStripMenuItem(str3);
                                        item2.ToolTipText = str4;
                                        item2.Tag = attribute;
                                        item.DropDownItems.Add(item2);
                                        item2.Click += new EventHandler(this.RegexMenu_Click);
                                    }
                                }
                                continue;
                            }
                            finally
                            { 
                            }
                        }
                    }
                }
            }
            finally
            { 
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void ExecuteCommand()
        {
            MatchCollection matchs;
            StringBuilder builder2;
            IEnumerator enumerator;
            Stopwatch stopwatch = new Stopwatch();
            string str = "";
            string[] strArray = null;
            try
            {
                this.re = new Regex(this.rtbRegex.Text, this.Options.RegexOptions);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.staMatches.Text = "Parsing Error";
                MessageBox.Show(exception.Message, "Parsing error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
            }
            try
            {
                stopwatch.Start();
                matchs = this.re.Matches(this.rtbSource.Text);
                int count = matchs.Count;
                stopwatch.Stop();
                if (this.Options.Command == RegexTester.Command.Replace)
                {
                    stopwatch.Start();
                    str = this.re.Replace(this.rtbSource.Text, this.rtbReplace.Text);
                    stopwatch.Stop();
                }
                else if (this.Options.Command == RegexTester.Command.Split)
                {
                    strArray = this.re.Split(this.rtbSource.Text);
                    stopwatch.Start();
                    stopwatch.Stop();
                }
                this.staExecutionTime.Text = string.Format("Execution: {0} msecs.   ", stopwatch.ElapsedMilliseconds);
                this.staMatches.Text = string.Format("Found {0} matches   ", count);
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                this.staMatches.Text = "Execution error";
                MessageBox.Show(exception2.Message, "Execution error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
            }
            List<Match> list = new List<Match>();
            try
            {
                enumerator = matchs.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Match current = (Match) enumerator.Current;
                    list.Add(current);
                }
            }
            finally
            {
               
            }
            this.Refresh();
            int num = 0;
            switch (this.Options.Sort)
            {
                case SortOption.Alphabetic:
                    list.Sort(new AlphaComparer());
                    break;

                case SortOption.ShortestFirst:
                    list.Sort(new ShortestComparer());
                    break;

                case SortOption.LargestFirst:
                    list.Sort(new LargestComparer());
                    break;
            }
            this.tvwResults.Nodes.Clear();
            int num7 = list.Count - 1;
            for (int i = 0; i <= num7; i++)
            {
                Match item = list[i];
                TreeNode node = this.tvwResults.Nodes.Add(item.Value);
                node.Tag = new NodeInfo(item, i.ToString());
                if ((this.Options.Detail != DetailOption.NoDetails) && (item.Groups.Count > 0))
                {
                    node.Nodes.Add("*");
                }
                num++;
                if (num == this.Options.MaxMatches)
                {
                    break;
                }
            }
            if (matchs.Count > this.Options.MaxMatches)
            {
                this.staItemInfo.Text = string.Format("(Only the first {0} are displayed)", this.Options.MaxMatches);
            }
            num = 0;
            if (this.Options.Command != RegexTester.Command.Find)
            {
                if (this.Options.Command != RegexTester.Command.Split)
                {
                    goto Label_0525;
                }
                builder2 = new StringBuilder();
                string[] strArray2 = strArray;
                for (int j = 0; j < strArray2.Length; j++)
                {
                    object obj2 = strArray2[j];
                    builder2.AppendFormat("[{0,3}]: {1}", num, RuntimeHelpers.GetObjectValue(obj2));
                    builder2.AppendLine();
                    num++;
                    if (num == this.Options.MaxMatches)
                    {
                        break;
                    }
                }
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                int num8 = list.Count - 1;
                for (int j = 0; j <= num8; j++)
                {
                    Match match3 = list[j];
                    builder.AppendFormat("MATCH[{0}]: '{1}'   [index={2}]", j, match3.Value, match3.Index);
                    builder.AppendLine();
                    if (this.Options.Detail != DetailOption.NoDetails)
                    {
                        int num9 = match3.Groups.Count - 1;
                        for (int k = 1; k <= num9; k++)
                        {
                            Group group = match3.Groups[k];
                            if ((group.Length != 0) || this.Options.IncludeEmptyGroups)
                            {
                                builder.AppendFormat("   GROUP[{0}]: '{1}'   [index={2}]", this.re.GroupNameFromNumber(k), group.Value, group.Index);
                                builder.AppendLine();
                                if (this.Options.Detail != DetailOption.Groups)
                                {
                                    int num10 = group.Captures.Count - 1;
                                    for (int m = 0; m <= num10; m++)
                                    {
                                        Capture capture = group.Captures[m];
                                        builder.AppendFormat("      CAPTURE[{0}]: '{1}'   [index={2}]", m, capture.Value, capture.Index);
                                        builder.AppendLine();
                                    }
                                }
                            }
                        }
                        num++;
                        if (num == this.Options.MaxMatches)
                        {
                            break;
                        }
                    }
                }
                str = builder.ToString();
                goto Label_0525;
            }
            str = builder2.ToString();
        Label_0525:
            this.rtbResults.Text = str;
            this.rtbResults.Select(0, 0);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctxPattern = new ContextMenuStrip(this.components);
            this.Label1 = new Label();
            this.MenuStrip1 = new MenuStrip();
            this.mnuFile = new ToolStripMenuItem();
            this.mnuFileNew = new ToolStripMenuItem();
            this.mnuFileOpen = new ToolStripMenuItem();
            this.mnuFileSave = new ToolStripMenuItem();
            this.mnuFileSaveAs = new ToolStripMenuItem();
            this.ToolStripSeparator4 = new ToolStripSeparator();
            this.mnuFileProperties = new ToolStripMenuItem();
            this.ToolStripSeparator5 = new ToolStripSeparator();
            this.mnuFileLoad = new ToolStripMenuItem();
            this.ToolStripSeparator6 = new ToolStripSeparator();
            this.mnuFileExit = new ToolStripMenuItem();
            this.mnuEdit = new ToolStripMenuItem();
            this.mnuEditWordWrap = new ToolStripMenuItem();
            this.mnuCommands = new ToolStripMenuItem();
            this.mnuCommandsRun = new ToolStripMenuItem();
            this.ToolStripSeparator3 = new ToolStripSeparator();
            this.mnuCommandsFind = new ToolStripMenuItem();
            this.mnuCommandsReplace = new ToolStripMenuItem();
            this.mnuCommandsSplit = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.mnuCommandsShowGroups = new ToolStripMenuItem();
            this.mnuCommandsEscape = new ToolStripMenuItem();
            this.mnuCommandsGenerateCode = new ToolStripMenuItem();
            this.mnuCommandsCompile = new ToolStripMenuItem();
            this.mnuOptions = new ToolStripMenuItem();
            this.mnuOptionsIgnoreCase = new ToolStripMenuItem();
            this.mnuOptionsIgnoreWhitespace = new ToolStripMenuItem();
            this.mnuOptionsMultiline = new ToolStripMenuItem();
            this.mnuOptionsCompiled = new ToolStripMenuItem();
            this.mnuOptionsExplicitCapture = new ToolStripMenuItem();
            this.mnuOptionsRightToLeft = new ToolStripMenuItem();
            this.mnuOptionsCultureInvariant = new ToolStripMenuItem();
            this.mnuOptionsEcmaScript = new ToolStripMenuItem();
            this.mnuResults = new ToolStripMenuItem();
            this.mnuResultsTreeView = new ToolStripMenuItem();
            this.mnuResultsReport = new ToolStripMenuItem();
            this.mnuResultsAuto = new ToolStripMenuItem();
            this.ToolStripSeparator7 = new ToolStripSeparator();
            this.mnuResultsNoDetails = new ToolStripMenuItem();
            this.mnuResultsGroups = new ToolStripMenuItem();
            this.mnuResultsCaptures = new ToolStripMenuItem();
            this.ToolStripSeparator2 = new ToolStripSeparator();
            this.ToolStripTextBox1 = new ToolStripMenuItem();
            this.txtViewMaxMatches = new ToolStripTextBox();
            this.mnuResultsIncludeEmptyGroups = new ToolStripMenuItem();
            this.ToolStripMenuItem1 = new ToolStripSeparator();
            this.mnuResultsDontSort = new ToolStripMenuItem();
            this.mnuResultsSortAlphabetically = new ToolStripMenuItem();
            this.mnuResultsShortest = new ToolStripMenuItem();
            this.mnuResultsLargest = new ToolStripMenuItem();
            this.mnuHelp = new ToolStripMenuItem();
            this.mnuHelpAbout = new ToolStripMenuItem();
            this.dlgOpenDoc = new OpenFileDialog();
            this.rtbSource = new RichTextBox();
            this.Label2 = new Label();
            this.lblReplace = new Label();
            this.StatusStrip1 = new StatusStrip();
            this.staMatches = new ToolStripStatusLabel();
            this.staExecutionTime = new ToolStripStatusLabel();
            this.staItemInfo = new ToolStripStatusLabel();
            this.ctxReplace = new ContextMenuStrip(this.components);
            this.tvwResults = new TreeView();
            this.rtbResults = new RichTextBox();
            this.rtbRegex = new RichTextBox();
            this.rtbReplace = new RichTextBox();
            this.lblMatches = new Label();
            this.dlgOpenRegex = new OpenFileDialog();
            this.dlgSaveRegex = new SaveFileDialog();
            this.ToolTip1 = new ToolTip(this.components);
            this.HelpProvider1 = new HelpProvider();
            this.mnuOptionsSingleline = new ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            this.ctxPattern.Name = "ctxPattern";
            Size size = new Size(0x3d, 4);
            this.ctxPattern.Size = size;
            this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(12, 0x21);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x3f, 0x26);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Regex";
            this.MenuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuFile, this.mnuEdit, this.mnuCommands, this.mnuOptions, this.mnuResults, this.mnuHelp });
            point = new Point(0, 0);
            this.MenuStrip1.Location = point;
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            size = new Size(0x2f1, 0x18);
            this.MenuStrip1.Size = size;
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            this.mnuFile.DropDownItems.AddRange(new ToolStripItem[] { this.mnuFileNew, this.mnuFileOpen, this.mnuFileSave, this.mnuFileSaveAs, this.ToolStripSeparator4, this.mnuFileProperties, this.ToolStripSeparator5, this.mnuFileLoad, this.ToolStripSeparator6, this.mnuFileExit });
            this.mnuFile.Name = "mnuFile";
            size = new Size(0x29, 20);
            this.mnuFile.Size = size;
            this.mnuFile.Text = "&File";
            this.mnuFileNew.Name = "mnuFileNew";
            size = new Size(0xb1, 0x16);
            this.mnuFileNew.Size = size;
            this.mnuFileNew.Text = "&New";
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            size = new Size(0xb1, 0x16);
            this.mnuFileOpen.Size = size;
            this.mnuFileOpen.Text = "&Open ...";
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
            size = new Size(0xb1, 0x16);
            this.mnuFileSave.Size = size;
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            size = new Size(0xb1, 0x16);
            this.mnuFileSaveAs.Size = size;
            this.mnuFileSaveAs.Text = "Save &as ...";
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            size = new Size(0xae, 6);
            this.ToolStripSeparator4.Size = size;
            this.mnuFileProperties.Name = "mnuFileProperties";
            this.mnuFileProperties.ShortcutKeys = Keys.F4;
            size = new Size(0xb1, 0x16);
            this.mnuFileProperties.Size = size;
            this.mnuFileProperties.Text = "&Properties";
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            size = new Size(0xae, 6);
            this.ToolStripSeparator5.Size = size;
            this.mnuFileLoad.Name = "mnuFileLoad";
            this.mnuFileLoad.ShortcutKeys = Keys.Control | Keys.L;
            size = new Size(0xb1, 0x16);
            this.mnuFileLoad.Size = size;
            this.mnuFileLoad.Text = "&Load source";
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            size = new Size(0xae, 6);
            this.ToolStripSeparator6.Size = size;
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = Keys.Alt | Keys.X;
            size = new Size(0xb1, 0x16);
            this.mnuFileExit.Size = size;
            this.mnuFileExit.Text = "E&xit";
            this.mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { this.mnuEditWordWrap });
            this.mnuEdit.Name = "mnuEdit";
            size = new Size(0x29, 20);
            this.mnuEdit.Size = size;
            this.mnuEdit.Text = "&Edit";
            this.mnuEditWordWrap.Name = "mnuEditWordWrap";
            size = new Size(0x7c, 0x16);
            this.mnuEditWordWrap.Size = size;
            this.mnuEditWordWrap.Text = "&Word wrap";
            this.mnuCommands.DropDownItems.AddRange(new ToolStripItem[] { this.mnuCommandsRun, this.ToolStripSeparator3, this.mnuCommandsFind, this.mnuCommandsReplace, this.mnuCommandsSplit, this.ToolStripSeparator1, this.mnuCommandsShowGroups, this.mnuCommandsEscape, this.mnuCommandsGenerateCode, this.mnuCommandsCompile });
            this.mnuCommands.Name = "mnuCommands";
            size = new Size(0x41, 20);
            this.mnuCommands.Size = size;
            this.mnuCommands.Text = "&Commands";
            this.mnuCommandsRun.Name = "mnuCommandsRun";
            this.mnuCommandsRun.ShortcutKeys = Keys.F5;
            size = new Size(0xb8, 0x16);
            this.mnuCommandsRun.Size = size;
            this.mnuCommandsRun.Text = "&Run";
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            size = new Size(0xb5, 6);
            this.ToolStripSeparator3.Size = size;
            this.mnuCommandsFind.Name = "mnuCommandsFind";
            this.mnuCommandsFind.ShortcutKeys = Keys.Control | Keys.F;
            size = new Size(0xb8, 0x16);
            this.mnuCommandsFind.Size = size;
            this.mnuCommandsFind.Text = "&Find";
            this.mnuCommandsReplace.Name = "mnuCommandsReplace";
            this.mnuCommandsReplace.ShortcutKeys = Keys.Control | Keys.R;
            size = new Size(0xb8, 0x16);
            this.mnuCommandsReplace.Size = size;
            this.mnuCommandsReplace.Text = "&Replace";
            this.mnuCommandsSplit.Name = "mnuCommandsSplit";
            this.mnuCommandsSplit.ShortcutKeys = Keys.Control | Keys.T;
            size = new Size(0xb8, 0x16);
            this.mnuCommandsSplit.Size = size;
            this.mnuCommandsSplit.Text = "&Split";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            size = new Size(0xb5, 6);
            this.ToolStripSeparator1.Size = size;
            this.mnuCommandsShowGroups.Name = "mnuCommandsShowGroups";
            size = new Size(0xb8, 0x16);
            this.mnuCommandsShowGroups.Size = size;
            this.mnuCommandsShowGroups.Text = "&Show groups";
            this.mnuCommandsEscape.Name = "mnuCommandsEscape";
            size = new Size(0xb8, 0x16);
            this.mnuCommandsEscape.Size = size;
            this.mnuCommandsEscape.Text = "&Escape";
            this.mnuCommandsGenerateCode.Name = "mnuCommandsGenerateCode";
            this.mnuCommandsGenerateCode.ShortcutKeys = Keys.F2;
            size = new Size(0xb8, 0x16);
            this.mnuCommandsGenerateCode.Size = size;
            this.mnuCommandsGenerateCode.Text = "&Generate code";
            this.mnuCommandsCompile.Name = "mnuCommandsCompile";
            size = new Size(0xb8, 0x16);
            this.mnuCommandsCompile.Size = size;
            this.mnuCommandsCompile.Text = "&Compile to Assembly";
            this.mnuOptions.DropDownItems.AddRange(new ToolStripItem[] { this.mnuOptionsIgnoreCase, this.mnuOptionsIgnoreWhitespace, this.mnuOptionsMultiline, this.mnuOptionsSingleline, this.mnuOptionsCompiled, this.mnuOptionsExplicitCapture, this.mnuOptionsRightToLeft, this.mnuOptionsCultureInvariant, this.mnuOptionsEcmaScript });
            this.mnuOptions.Name = "mnuOptions";
            size = new Size(0x3b, 20);
            this.mnuOptions.Size = size;
            this.mnuOptions.Text = "&Options";
            this.mnuOptionsIgnoreCase.Name = "mnuOptionsIgnoreCase";
            size = new Size(0xac, 0x16);
            this.mnuOptionsIgnoreCase.Size = size;
            this.mnuOptionsIgnoreCase.Text = "&Ignore case";
            this.mnuOptionsIgnoreWhitespace.Name = "mnuOptionsIgnoreWhitespace";
            size = new Size(0xac, 0x16);
            this.mnuOptionsIgnoreWhitespace.Size = size;
            this.mnuOptionsIgnoreWhitespace.Text = "Ignore &Whitespace";
            this.mnuOptionsMultiline.Name = "mnuOptionsMultiline";
            size = new Size(0xac, 0x16);
            this.mnuOptionsMultiline.Size = size;
            this.mnuOptionsMultiline.Text = "&Multiline";
            this.mnuOptionsCompiled.Name = "mnuOptionsCompiled";
            size = new Size(0xac, 0x16);
            this.mnuOptionsCompiled.Size = size;
            this.mnuOptionsCompiled.Text = "&Compiled";
            this.mnuOptionsExplicitCapture.Name = "mnuOptionsExplicitCapture";
            size = new Size(0xac, 0x16);
            this.mnuOptionsExplicitCapture.Size = size;
            this.mnuOptionsExplicitCapture.Text = "&Explicit capture";
            this.mnuOptionsRightToLeft.Name = "mnuOptionsRightToLeft";
            size = new Size(0xac, 0x16);
            this.mnuOptionsRightToLeft.Size = size;
            this.mnuOptionsRightToLeft.Text = "&Right to left";
            this.mnuOptionsCultureInvariant.Name = "mnuOptionsCultureInvariant";
            size = new Size(0xac, 0x16);
            this.mnuOptionsCultureInvariant.Size = size;
            this.mnuOptionsCultureInvariant.Text = "C&ulture invariant";
            this.mnuOptionsEcmaScript.Name = "mnuOptionsEcmaScript";
            size = new Size(0xac, 0x16);
            this.mnuOptionsEcmaScript.Size = size;
            this.mnuOptionsEcmaScript.Text = "EC&MAScript";
            this.mnuResults.DropDownItems.AddRange(new ToolStripItem[] { this.mnuResultsTreeView, this.mnuResultsReport, this.mnuResultsAuto, this.ToolStripSeparator7, this.mnuResultsNoDetails, this.mnuResultsGroups, this.mnuResultsCaptures, this.ToolStripSeparator2, this.ToolStripTextBox1, this.mnuResultsIncludeEmptyGroups, this.ToolStripMenuItem1, this.mnuResultsDontSort, this.mnuResultsSortAlphabetically, this.mnuResultsShortest, this.mnuResultsLargest });
            this.mnuResults.Name = "mnuResults";
            size = new Size(0x3b, 20);
            this.mnuResults.Size = size;
            this.mnuResults.Text = "&Results";
            this.mnuResultsTreeView.Name = "mnuResultsTreeView";
            size = new Size(0xca, 0x16);
            this.mnuResultsTreeView.Size = size;
            this.mnuResultsTreeView.Text = "&Tree view";
            this.mnuResultsReport.Name = "mnuResultsReport";
            size = new Size(0xca, 0x16);
            this.mnuResultsReport.Size = size;
            this.mnuResultsReport.Text = "&Report";
            this.mnuResultsAuto.Name = "mnuResultsAuto";
            size = new Size(0xca, 0x16);
            this.mnuResultsAuto.Size = size;
            this.mnuResultsAuto.Text = "&Auto";
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            size = new Size(0xc7, 6);
            this.ToolStripSeparator7.Size = size;
            this.mnuResultsNoDetails.Name = "mnuResultsNoDetails";
            size = new Size(0xca, 0x16);
            this.mnuResultsNoDetails.Size = size;
            this.mnuResultsNoDetails.Text = "N&o details";
            this.mnuResultsGroups.Name = "mnuResultsGroups";
            size = new Size(0xca, 0x16);
            this.mnuResultsGroups.Size = size;
            this.mnuResultsGroups.Text = "&Groups";
            this.mnuResultsCaptures.Name = "mnuResultsCaptures";
            size = new Size(0xca, 0x16);
            this.mnuResultsCaptures.Size = size;
            this.mnuResultsCaptures.Text = "Groups and &Captures";
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            size = new Size(0xc7, 6);
            this.ToolStripSeparator2.Size = size;
            this.ToolStripTextBox1.DropDownItems.AddRange(new ToolStripItem[] { this.txtViewMaxMatches });
            this.ToolStripTextBox1.Name = "ToolStripTextBox1";
            size = new Size(0xca, 0x16);
            this.ToolStripTextBox1.Size = size;
            this.ToolStripTextBox1.Text = "&Max number  of results";
            this.txtViewMaxMatches.Name = "txtViewMaxMatches";
            size = new Size(100, 0x15);
            this.txtViewMaxMatches.Size = size;
            this.txtViewMaxMatches.Text = "1000";
            this.mnuResultsIncludeEmptyGroups.Name = "mnuResultsIncludeEmptyGroups";
            size = new Size(0xca, 0x16);
            this.mnuResultsIncludeEmptyGroups.Size = size;
            this.mnuResultsIncludeEmptyGroups.Text = "&Include empty groups";
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            size = new Size(0xc7, 6);
            this.ToolStripMenuItem1.Size = size;
            this.mnuResultsDontSort.Name = "mnuResultsDontSort";
            size = new Size(0xca, 0x16);
            this.mnuResultsDontSort.Size = size;
            this.mnuResultsDontSort.Text = "Sort on &Position";
            this.mnuResultsSortAlphabetically.Name = "mnuResultsSortAlphabetically";
            size = new Size(0xca, 0x16);
            this.mnuResultsSortAlphabetically.Size = size;
            this.mnuResultsSortAlphabetically.Text = "Sort on &Name";
            this.mnuResultsShortest.Name = "mnuResultsShortest";
            size = new Size(0xca, 0x16);
            this.mnuResultsShortest.Size = size;
            this.mnuResultsShortest.Text = "&Shortest matches first";
            this.mnuResultsLargest.Name = "mnuResultsLargest";
            size = new Size(0xca, 0x16);
            this.mnuResultsLargest.Size = size;
            this.mnuResultsLargest.Text = "&Largest matches first";
            this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { this.mnuHelpAbout });
            this.mnuHelp.Name = "mnuHelp";
            size = new Size(0x29, 20);
            this.mnuHelp.Size = size;
            this.mnuHelp.Text = "&Help";
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            size = new Size(100, 0x16);
            this.mnuHelpAbout.Size = size;
            this.mnuHelpAbout.Text = "&About";
            this.dlgOpenDoc.Filter = "Text files (*.txt;*.doc)|*.txt;*.doc|All files|*.*";
            this.dlgOpenDoc.Title = "Open a text document";
            this.rtbSource.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.rtbSource.DetectUrls = false;
            this.rtbSource.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.rtbSource.HideSelection = false;
            point = new Point(0x43, 0xbc);
            this.rtbSource.Location = point;
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.ScrollBars = RichTextBoxScrollBars.Vertical;
            size = new Size(0x2a2, 0x65);
            this.rtbSource.Size = size;
            this.rtbSource.TabIndex = 6;
            this.rtbSource.Text = "";
            this.ToolTip1.SetToolTip(this.rtbSource, "The text on which the regular expression is applied. se the File-Load menu to load a text file.");
            this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(12, 0xbf);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x4b, 0x26);
            this.Label2.Size = size;
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Source";
            this.lblReplace.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(12, 0x7b);
            this.lblReplace.Location = point;
            this.lblReplace.Name = "lblReplace";
            size = new Size(60, 40);
            this.lblReplace.Size = size;
            this.lblReplace.TabIndex = 3;
            this.lblReplace.Text = "Replace";
            this.StatusStrip1.Items.AddRange(new ToolStripItem[] { this.staMatches, this.staExecutionTime, this.staItemInfo });
            point = new Point(0, 0x1de);
            this.StatusStrip1.Location = point;
            size = new Size(0x2f1, 0x16);
            this.StatusStrip1.MinimumSize = size;
            this.StatusStrip1.Name = "StatusStrip1";
            size = new Size(0x2f1, 0x16);
            this.StatusStrip1.Size = size;
            this.StatusStrip1.TabIndex = 10;
            this.StatusStrip1.Text = "StatusStrip1";
            this.staMatches.ForeColor = SystemColors.ActiveCaption;
            this.staMatches.Name = "staMatches";
            size = new Size(0x53, 0x11);
            this.staMatches.Size = size;
            this.staMatches.Text = "Found matches";
            this.staExecutionTime.Name = "staExecutionTime";
            size = new Size(0x59, 0x11);
            this.staExecutionTime.Size = size;
            this.staExecutionTime.Text = "Execution time";
            this.staItemInfo.ForeColor = SystemColors.ActiveCaption;
            this.staItemInfo.Name = "staItemInfo";
            size = new Size(0x3b, 0x11);
            this.staItemInfo.Size = size;
            this.staItemInfo.Text = "Item info";
            this.ctxReplace.Name = "ctxPattern";
            size = new Size(0x3d, 4);
            this.ctxReplace.Size = size;
            this.tvwResults.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            point = new Point(0x43, 0x131);
            this.tvwResults.Location = point;
            this.tvwResults.Name = "tvwResults";
            this.tvwResults.ShowRootLines = false;
            size = new Size(0x2a2, 0xa4);
            this.tvwResults.Size = size;
            this.tvwResults.TabIndex = 8;
            this.ToolTip1.SetToolTip(this.tvwResults, "All the matches found. ouble-click on an item to see groups and captures.");
            this.rtbResults.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.rtbResults.DetectUrls = false;
            this.rtbResults.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.rtbResults.HideSelection = false;
            point = new Point(12, 360);
            this.rtbResults.Location = point;
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.ScrollBars = RichTextBoxScrollBars.Vertical;
            size = new Size(0x1c, 0x2d);
            this.rtbResults.Size = size;
            this.rtbResults.TabIndex = 9;
            this.rtbResults.Text = "";
            this.ToolTip1.SetToolTip(this.rtbResults, "The replaced text, or the split elements, or the matches in report format.");
            this.rtbRegex.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.rtbRegex.ContextMenuStrip = this.ctxPattern;
            this.rtbRegex.DetectUrls = false;
            point = new Point(0x43, 0x21);
            this.rtbRegex.Location = point;
            this.rtbRegex.Name = "rtbRegex";
            size = new Size(0x2a2, 0x54);
            this.rtbRegex.Size = size;
            this.rtbRegex.TabIndex = 2;
            this.rtbRegex.Text = "";
            this.ToolTip1.SetToolTip(this.rtbRegex, "The regular expression pattern. ight-click to display list of common patterns.");
            this.rtbReplace.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.rtbReplace.ContextMenuStrip = this.ctxReplace;
            this.rtbReplace.DetectUrls = false;
            point = new Point(0x43, 0x7b);
            this.rtbReplace.Location = point;
            this.rtbReplace.Name = "rtbReplace";
            size = new Size(0x2a2, 0x30);
            this.rtbReplace.Size = size;
            this.rtbReplace.TabIndex = 4;
            this.rtbReplace.Text = "";
            this.ToolTip1.SetToolTip(this.rtbReplace, "The replace pattern. ight-click to display list of common patterns.");
            this.lblMatches.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(12, 0x131);
            this.lblMatches.Location = point;
            this.lblMatches.Name = "lblMatches";
            size = new Size(0x4b, 0x26);
            this.lblMatches.Size = size;
            this.lblMatches.TabIndex = 7;
            this.lblMatches.Text = "Matches";
            this.dlgOpenRegex.DefaultExt = "regex";
            this.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*";
            this.dlgOpenRegex.Title = "Open a regex file";
            this.dlgSaveRegex.DefaultExt = "regex";
            this.dlgSaveRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*";
            this.dlgSaveRegex.Title = "Save a regex file";
            this.mnuOptionsSingleline.Name = "mnuOptionsSingleline";
            size = new Size(0xac, 0x16);
            this.mnuOptionsSingleline.Size = size;
            this.mnuOptionsSingleline.Text = "&Singleline";
            SizeF ef = new SizeF(8f, 16f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x2f1, 500);
            this.ClientSize = size;
            this.Controls.Add(this.rtbRegex);
            this.Controls.Add(this.tvwResults);
            this.Controls.Add(this.rtbReplace);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblMatches);
            this.Controls.Add(this.rtbSource);
            this.Controls.Add(this.Label2);
            this.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.MainMenuStrip = this.MenuStrip1;
            Padding padding = new Padding(4);
            this.Margin = padding;
            this.Name = "MainForm";
            this.Text = "Code Architects Regex Tester";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Helpers.SetTooltipsAndHelpMessages(this, this.ToolTip1, this.HelpProvider1);
            this.BuildRegexMenu();
            this.rtbResults.Bounds = this.tvwResults.Bounds;
            this.staMatches.Text = "";
            this.staExecutionTime.Text = "";
            this.staItemInfo.Text = "";
            this.Options.ClearChanges();
        }

        private void mnuCommandsCompile_Click(object sender, EventArgs e)
        {
            if (this.CompileForm == null)
            {
                this.CompileForm = new RegexTester.CompileForm();
                this.CompileForm.MainForm = this;
            }
            this.CompileForm.Show();
        }

        private void mnuCommandsEscape_Click(object sender, EventArgs e)
        {
            this.UpdateOptionFiels();
            EscapeForm form = new EscapeForm();
            form.Options = this.Options;
            form.ShowDialog();
        }

        private void mnuCommandsFind_Click(object sender, EventArgs e)
        {
            if (this.Options.Command != RegexTester.Command.Find)
            {
                this.Options.Command = RegexTester.Command.Find;
                this.rtbResults.Clear();
                this.RefreshOptionsState();
            }
        }

        private void mnuCommandsGenerateCode_Click(object sender, EventArgs e)
        {
            this.UpdateOptionFiels();
            GenerateCodeForm form = new GenerateCodeForm();
            form.Options = this.Options;
            form.ShowDialog();
        }

        private void mnuCommandsReplace_Click(object sender, EventArgs e)
        {
            if (this.Options.Command != RegexTester.Command.Replace)
            {
                this.Options.Command = RegexTester.Command.Replace;
                this.rtbResults.Clear();
                this.RefreshOptionsState();
            }
        }

        private void mnuCommandsRun_Click(object sender, EventArgs e)
        {
            this.ExecuteCommand();
        }

        private void mnuCommandsShowGroups_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                string[] groupNames = new Regex(this.rtbRegex.Text).GetGroupNames();
                int num2 = groupNames.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if (groupNames[i] == i.ToString())
                    {
                        builder.AppendFormat("group[{0}]", i);
                    }
                    else
                    {
                        builder.AppendFormat("group[{0}] = {1}", i, groupNames[i]);
                    }
                    builder.AppendLine();
                }
                MessageBox.Show(builder.ToString(), "Capturing Groups", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
        }

        private void mnuCommandsSplit_Click(object sender, EventArgs e)
        {
            if (this.Options.Command != RegexTester.Command.Split)
            {
                this.Options.Command = RegexTester.Command.Split;
                this.rtbResults.Clear();
                this.RefreshOptionsState();
            }
        }

        private void mnuEditWordWrap_Click(object sender, EventArgs e)
        {
            this.Options.WordWrap = !this.Options.WordWrap;
            this.RefreshOptionsState();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            if (this.OkToProceed())
            {
                Application.Exit();
            }
        }

        private void mnuFileLoad_Click(object sender, EventArgs e)
        {
            if (this.dlgOpenDoc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Options.SourceText = File.ReadAllText(this.dlgOpenDoc.FileName);
                    this.rtbSource.Text = this.Options.SourceText;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Unable to load document", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if (this.OkToProceed())
            {
                this.Options = new ProjectOptions();
                this.Options.ClearChanges();
                this.RefreshControlState();
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (this.OkToProceed())
            {
                this.OpenRegex(null);
            }
        }

        private void mnuFileProperties_Click(object sender, EventArgs e)
        {
            this.UpdateOptionFiels();
            PropertiesForm form = new PropertiesForm();
            form.Options = this.Options;
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                this.RefreshControlState();
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            this.UpdateOptionFiels();
            this.SaveRegex(this.Options.RegexFile);
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            this.UpdateOptionFiels();
            this.SaveRegex(null);
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }

        private void mnuOptionsCompiled_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.Compiled;
            this.RefreshOptionsState();
        }

        private void mnuOptionsCultureInvariant_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.CultureInvariant;
            this.RefreshOptionsState();
        }

        private void mnuOptionsEcmaScript_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.ECMAScript;
            this.RefreshOptionsState();
        }

        private void mnuOptionsExplicitCapture_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.ExplicitCapture;
            this.RefreshOptionsState();
        }

        private void mnuOptionsIgnoreCase_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.IgnoreCase;
            this.RefreshOptionsState();
        }

        private void mnuOptionsIgnoreWhitespace_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.IgnorePatternWhitespace;
            this.RefreshOptionsState();
        }

        private void mnuOptionsMultiline_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.Multiline;
            this.RefreshOptionsState();
        }

        private void mnuOptionsRightToLeft_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.RightToLeft;
            this.RefreshOptionsState();
        }

        private void mnuOptionsSingleline_Click(object sender, EventArgs e)
        {
            this.Options.RegexOptions ^= RegexOptions.Singleline;
            this.RefreshOptionsState();
        }

        private void mnuResultsAuto_Click(object sender, EventArgs e)
        {
            this.Options.Format = FormatOption.Auto;
            this.RefreshOptionsState();
        }

        private void mnuResultsCaptures_Click(object sender, EventArgs e)
        {
            this.Options.Detail = DetailOption.GroupAndCaptures;
            this.RefreshOptionsState();
        }

        private void mnuResultsDontSort_Click(object sender, EventArgs e)
        {
            this.Options.Sort = SortOption.Position;
            this.RefreshOptionsState();
        }

        private void mnuResultsGroups_Click(object sender, EventArgs e)
        {
            this.Options.Detail = DetailOption.Groups;
            this.RefreshOptionsState();
        }

        private void mnuResultsIncludeEmptyGroups_Click(object sender, EventArgs e)
        {
            this.Options.IncludeEmptyGroups = !this.Options.IncludeEmptyGroups;
            this.RefreshOptionsState();
        }

        private void mnuResultsLargest_Click(object sender, EventArgs e)
        {
            this.Options.Sort = SortOption.LargestFirst;
            this.RefreshOptionsState();
        }

        private void mnuResultsNoDetails_Click(object sender, EventArgs e)
        {
            this.Options.Detail = DetailOption.NoDetails;
            this.RefreshOptionsState();
        }

        private void mnuResultsReport_Click(object sender, EventArgs e)
        {
            this.Options.Format = FormatOption.Report;
            this.RefreshOptionsState();
        }

        private void mnuResultsShortest_Click(object sender, EventArgs e)
        {
            this.Options.Sort = SortOption.ShortestFirst;
            this.RefreshOptionsState();
        }

        private void mnuResultsSortAlphabetically_Click(object sender, EventArgs e)
        {
            this.Options.Sort = SortOption.Alphabetic;
            this.RefreshOptionsState();
        }

        private void mnuResultsTreeView_Click(object sender, EventArgs e)
        {
            this.Options.Format = FormatOption.TreeView;
            this.RefreshOptionsState();
        }

        public bool OkToProceed()
        {
            bool flag=false;
            this.UpdateOptionFiels();
            if (!this.Options.HasChanged)
            {
                return true;
            }
            switch (MessageBox.Show(string.Format("Current regex has been modified.{0}{0}Do you wish to save it?", "\r\n"), "Confirm action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Cancel:
                    return false;

                case DialogResult.Abort:
                case DialogResult.Retry:
                case DialogResult.Ignore:
                    return flag;

                case DialogResult.Yes:
                    return this.SaveRegex(this.Options.RegexFile);

                case DialogResult.No:
                    return true;
            }
            return flag;
        }

        public bool OpenRegex(string fileName)
        {
            bool flag;
            if (string.IsNullOrEmpty(fileName))
            {
                if (this.dlgOpenRegex.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                fileName = this.dlgOpenRegex.FileName;
            }
            try
            {
                this.Options = ProjectOptions.Load(fileName);
                this.RefreshControlState();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public void RefreshControlState()
        {
            this.rtbRegex.Text = this.Options.RegexText;
            this.rtbReplace.Text = this.Options.ReplaceText;
            this.rtbSource.Text = this.Options.SourceText;
            this.RefreshOptionsState();
            string title = MyProject.Application.Info.Title;
            if (string.IsNullOrEmpty(this.Options.RegexName))
            {
                this.Text = title + " - (unnamed regex)";
            }
            else
            {
                this.Text = title + " - " + this.Options.RegexName;
            }
        }

        public void RefreshOptionsState()
        {
            Size size;
            this.mnuEditWordWrap.Checked = this.Options.WordWrap;
            this.mnuCommandsFind.Checked = this.Options.Command == RegexTester.Command.Find;
            this.mnuCommandsReplace.Checked = this.Options.Command == RegexTester.Command.Replace;
            this.mnuCommandsSplit.Checked = this.Options.Command == RegexTester.Command.Split;
            this.mnuOptionsCompiled.Checked = (this.Options.RegexOptions & RegexOptions.Compiled) == RegexOptions.Compiled;
            this.mnuOptionsCultureInvariant.Checked = (this.Options.RegexOptions & RegexOptions.CultureInvariant) == RegexOptions.CultureInvariant;
            this.mnuOptionsEcmaScript.Checked = (this.Options.RegexOptions & RegexOptions.ECMAScript) == RegexOptions.ECMAScript;
            this.mnuOptionsExplicitCapture.Checked = (this.Options.RegexOptions & RegexOptions.ExplicitCapture) == RegexOptions.ExplicitCapture;
            this.mnuOptionsIgnoreCase.Checked = (this.Options.RegexOptions & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase;
            this.mnuOptionsIgnoreWhitespace.Checked = (this.Options.RegexOptions & RegexOptions.IgnorePatternWhitespace) == RegexOptions.IgnorePatternWhitespace;
            this.mnuOptionsMultiline.Checked = (this.Options.RegexOptions & RegexOptions.Multiline) == RegexOptions.Multiline;
            this.mnuOptionsSingleline.Checked = (this.Options.RegexOptions & RegexOptions.Singleline) == RegexOptions.Singleline;
            this.mnuOptionsRightToLeft.Checked = (this.Options.RegexOptions & RegexOptions.RightToLeft) == RegexOptions.RightToLeft;
            this.mnuResultsAuto.Checked = this.Options.Format == FormatOption.Auto;
            this.mnuResultsTreeView.Checked = this.Options.Format == FormatOption.TreeView;
            this.mnuResultsReport.Checked = this.Options.Format == FormatOption.Report;
            this.mnuResultsNoDetails.Checked = this.Options.Detail == DetailOption.NoDetails;
            this.mnuResultsGroups.Checked = this.Options.Detail == DetailOption.Groups;
            this.mnuResultsCaptures.Checked = this.Options.Detail == DetailOption.GroupAndCaptures;
            this.txtViewMaxMatches.Text = this.Options.MaxMatches.ToString();
            this.mnuResultsIncludeEmptyGroups.Checked = this.Options.IncludeEmptyGroups;
            this.mnuResultsDontSort.Checked = this.Options.Sort == SortOption.Position;
            this.mnuResultsSortAlphabetically.Checked = this.Options.Sort == SortOption.Alphabetic;
            this.mnuResultsShortest.Checked = this.Options.Sort == SortOption.ShortestFirst;
            this.mnuResultsLargest.Checked = this.Options.Sort == SortOption.LargestFirst;
            this.tvwResults.Visible = (this.Options.Format == FormatOption.TreeView) || ((this.Options.Format == FormatOption.Auto) && (this.Options.Command == RegexTester.Command.Find));
            this.rtbResults.Visible = !this.tvwResults.Visible;
            this.staItemInfo.Visible = this.tvwResults.Visible;
            if (this.tvwResults.Visible)
            {
                this.lblMatches.Text = "Matches";
            }
            else
            {
                this.lblMatches.Text = "Report";
            }
            if (this.Options.Command == RegexTester.Command.Replace)
            {
                size = new Size(this.rtbRegex.Width, (this.rtbReplace.Top - this.rtbRegex.Top) - 10);
                this.rtbRegex.Size = size;
                this.rtbReplace.Visible = true;
                this.lblReplace.Visible = true;
            }
            else
            {
                size = new Size(this.rtbRegex.Width, this.rtbReplace.Bottom - this.rtbRegex.Top);
                this.rtbRegex.Size = size;
                this.rtbReplace.Visible = false;
                this.lblReplace.Visible = false;
            }
            this.rtbRegex.WordWrap = this.Options.WordWrap;
            this.rtbReplace.WordWrap = this.Options.WordWrap;
            this.rtbSource.WordWrap = this.Options.WordWrap;
            this.rtbResults.WordWrap = this.Options.WordWrap;
            if (this.Options.WordWrap)
            {
                this.rtbRegex.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.rtbReplace.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.rtbSource.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.rtbResults.ScrollBars = RichTextBoxScrollBars.Vertical;
            }
            else
            {
                this.rtbRegex.ScrollBars = RichTextBoxScrollBars.Both;
                this.rtbReplace.ScrollBars = RichTextBoxScrollBars.Both;
                this.rtbSource.ScrollBars = RichTextBoxScrollBars.Both;
                this.rtbResults.ScrollBars = RichTextBoxScrollBars.Both;
            }
        }

        private void RegexMenu_Click(object sender, EventArgs e)
        {
            ToolStrip owner = ((ToolStripMenuItem) sender).OwnerItem.Owner;
            RichTextBox rtbRegex = this.rtbRegex;
            if (owner == this.ctxReplace)
            {
                rtbRegex = this.rtbReplace;
            }
            ToolStripMenuItem item = (ToolStripMenuItem) sender;
            string str = Conversions.ToString(item.Tag);
            int selectionStart = this.rtbRegex.SelectionStart;
            rtbRegex.SelectedText = str.Replace("?", "");
            int index = str.IndexOf("?");
            if (index >= 0)
            {
                int num3 = str.IndexOf("?", (int) (index + 1));
                rtbRegex.Select(selectionStart + index, (num3 - index) - 1);
            }
        }

        public bool SaveRegex(string fileName)
        {
            bool flag;
            if (this.Options.RegexName.Length == 0)
            {
                string str = Interaction.InputBox("Please assign a name to the current regex", "Saving Regex file", "", -1, -1);
                if (str == "")
                {
                    MessageBox.Show("Current regex hasn't been saved.", "Missing regex name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                this.Options.RegexName = str;
            }
            if (string.IsNullOrEmpty(fileName))
            {
                if (this.dlgSaveRegex.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                fileName = this.dlgSaveRegex.FileName;
            }
            try
            {
                this.Options.Save(fileName);
                this.RefreshControlState();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Unable to save regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        private void tvwResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeInfo tag = (NodeInfo) e.Node.Tag;
            string str = tag.Item.GetType().Name.ToUpper();
            this.staItemInfo.Text = string.Format("{0}[{1}]: Index={2}, Length={3}", new object[] { str, tag.Name, tag.Item.Index, tag.Item.Length });
            this.rtbSource.Select(tag.Item.Index, tag.Item.Length);
            this.rtbSource.ScrollToCaret();
        }

        private void tvwResults_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if ((e.Node.Nodes.Count == 1) || (e.Node.Nodes[0].Text == "*"))
            {
                e.Node.Nodes.Clear();
                NodeInfo tag = (NodeInfo) e.Node.Tag;
                if (tag.Item.GetType() == typeof(Match))
                {
                    Match item = (Match) tag.Item;
                    int num3 = item.Groups.Count - 1;
                    for (int i = 1; i <= num3; i++)
                    {
                        Group group = item.Groups[i];
                        if ((group.Length != 0) || this.Options.IncludeEmptyGroups)
                        {
                            TreeNode node = e.Node.Nodes.Add(group.Value);
                            node.Tag = new NodeInfo(group, this.re.GroupNameFromNumber(i));
                            if ((this.Options.Detail == DetailOption.GroupAndCaptures) && (group.Captures.Count > 0))
                            {
                                node.Nodes.Add("*");
                            }
                        }
                    }
                }
                else if (tag.Item.GetType() == typeof(Group))
                {
                    Group item = (Group) tag.Item;
                    int num4 = item.Captures.Count - 1;
                    for (int i = 0; i <= num4; i++)
                    {
                        Capture capture = item.Captures[i];
                        if (capture.GetType() != typeof(Group))
                        {
                            e.Node.Nodes.Add(capture.Value).Tag = new NodeInfo(capture, i.ToString());
                        }
                    }
                }
            }
        }

        private void txtViewMaxMatches_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.txtViewMaxMatches.Text, out num))
            {
                this.Options.MaxMatches = num;
            }
        }

        public void UpdateOptionFiels()
        {
            this.Options.RegexText = this.rtbRegex.Text;
            this.Options.ReplaceText = this.rtbReplace.Text;
            this.Options.SourceText = this.rtbSource.Text;
        }

        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }

        internal virtual MenuStrip MenuStrip1
        {
            get
            {
                return this._MenuStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MenuStrip1 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFile
        {
            get
            {
                return this._mnuFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuFile = value;
            }
        }

        internal virtual ToolStripMenuItem mnuOptions
        {
            get
            {
                return this._mnuOptions;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuOptions = value;
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsIgnoreCase
        {
            get
            {
                return this._mnuOptionsIgnoreCase;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsIgnoreCase != null)
                {
                    this._mnuOptionsIgnoreCase.Click -= new EventHandler(this.mnuOptionsIgnoreCase_Click);
                }
                this._mnuOptionsIgnoreCase = value;
                if (this._mnuOptionsIgnoreCase != null)
                {
                    this._mnuOptionsIgnoreCase.Click += new EventHandler(this.mnuOptionsIgnoreCase_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsMultiline
        {
            get
            {
                return this._mnuOptionsMultiline;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsMultiline != null)
                {
                    this._mnuOptionsMultiline.Click -= new EventHandler(this.mnuOptionsMultiline_Click);
                }
                this._mnuOptionsMultiline = value;
                if (this._mnuOptionsMultiline != null)
                {
                    this._mnuOptionsMultiline.Click += new EventHandler(this.mnuOptionsMultiline_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsIgnoreWhitespace
        {
            get
            {
                return this._mnuOptionsIgnoreWhitespace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsIgnoreWhitespace != null)
                {
                    this._mnuOptionsIgnoreWhitespace.Click -= new EventHandler(this.mnuOptionsIgnoreWhitespace_Click);
                }
                this._mnuOptionsIgnoreWhitespace = value;
                if (this._mnuOptionsIgnoreWhitespace != null)
                {
                    this._mnuOptionsIgnoreWhitespace.Click += new EventHandler(this.mnuOptionsIgnoreWhitespace_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsCompiled
        {
            get
            {
                return this._mnuOptionsCompiled;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsCompiled != null)
                {
                    this._mnuOptionsCompiled.Click -= new EventHandler(this.mnuOptionsCompiled_Click);
                }
                this._mnuOptionsCompiled = value;
                if (this._mnuOptionsCompiled != null)
                {
                    this._mnuOptionsCompiled.Click += new EventHandler(this.mnuOptionsCompiled_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsExplicitCapture
        {
            get
            {
                return this._mnuOptionsExplicitCapture;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsExplicitCapture != null)
                {
                    this._mnuOptionsExplicitCapture.Click -= new EventHandler(this.mnuOptionsExplicitCapture_Click);
                }
                this._mnuOptionsExplicitCapture = value;
                if (this._mnuOptionsExplicitCapture != null)
                {
                    this._mnuOptionsExplicitCapture.Click += new EventHandler(this.mnuOptionsExplicitCapture_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsRightToLeft
        {
            get
            {
                return this._mnuOptionsRightToLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsRightToLeft != null)
                {
                    this._mnuOptionsRightToLeft.Click -= new EventHandler(this.mnuOptionsRightToLeft_Click);
                }
                this._mnuOptionsRightToLeft = value;
                if (this._mnuOptionsRightToLeft != null)
                {
                    this._mnuOptionsRightToLeft.Click += new EventHandler(this.mnuOptionsRightToLeft_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsCultureInvariant
        {
            get
            {
                return this._mnuOptionsCultureInvariant;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsCultureInvariant != null)
                {
                    this._mnuOptionsCultureInvariant.Click -= new EventHandler(this.mnuOptionsCultureInvariant_Click);
                }
                this._mnuOptionsCultureInvariant = value;
                if (this._mnuOptionsCultureInvariant != null)
                {
                    this._mnuOptionsCultureInvariant.Click += new EventHandler(this.mnuOptionsCultureInvariant_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsEcmaScript
        {
            get
            {
                return this._mnuOptionsEcmaScript;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsEcmaScript != null)
                {
                    this._mnuOptionsEcmaScript.Click -= new EventHandler(this.mnuOptionsEcmaScript_Click);
                }
                this._mnuOptionsEcmaScript = value;
                if (this._mnuOptionsEcmaScript != null)
                {
                    this._mnuOptionsEcmaScript.Click += new EventHandler(this.mnuOptionsEcmaScript_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuFileOpen
        {
            get
            {
                return this._mnuFileOpen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileOpen != null)
                {
                    this._mnuFileOpen.Click -= new EventHandler(this.mnuFileOpen_Click);
                }
                this._mnuFileOpen = value;
                if (this._mnuFileOpen != null)
                {
                    this._mnuFileOpen.Click += new EventHandler(this.mnuFileOpen_Click);
                }
            }
        }

        internal virtual OpenFileDialog dlgOpenDoc
        {
            get
            {
                return this._dlgOpenDoc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgOpenDoc = value;
            }
        }

        internal virtual RichTextBox rtbSource
        {
            get
            {
                return this._rtbSource;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtbSource = value;
            }
        }

        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFileNew
        {
            get
            {
                return this._mnuFileNew;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileNew != null)
                {
                    this._mnuFileNew.Click -= new EventHandler(this.mnuFileNew_Click);
                }
                this._mnuFileNew = value;
                if (this._mnuFileNew != null)
                {
                    this._mnuFileNew.Click += new EventHandler(this.mnuFileNew_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResults
        {
            get
            {
                return this._mnuResults;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuResults = value;
            }
        }

        internal virtual ToolStripMenuItem mnuCommands
        {
            get
            {
                return this._mnuCommands;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuCommands = value;
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsFind
        {
            get
            {
                return this._mnuCommandsFind;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsFind != null)
                {
                    this._mnuCommandsFind.Click -= new EventHandler(this.mnuCommandsFind_Click);
                }
                this._mnuCommandsFind = value;
                if (this._mnuCommandsFind != null)
                {
                    this._mnuCommandsFind.Click += new EventHandler(this.mnuCommandsFind_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsReplace
        {
            get
            {
                return this._mnuCommandsReplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsReplace != null)
                {
                    this._mnuCommandsReplace.Click -= new EventHandler(this.mnuCommandsReplace_Click);
                }
                this._mnuCommandsReplace = value;
                if (this._mnuCommandsReplace != null)
                {
                    this._mnuCommandsReplace.Click += new EventHandler(this.mnuCommandsReplace_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsSplit
        {
            get
            {
                return this._mnuCommandsSplit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsSplit != null)
                {
                    this._mnuCommandsSplit.Click -= new EventHandler(this.mnuCommandsSplit_Click);
                }
                this._mnuCommandsSplit = value;
                if (this._mnuCommandsSplit != null)
                {
                    this._mnuCommandsSplit.Click += new EventHandler(this.mnuCommandsSplit_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator1
        {
            get
            {
                return this._ToolStripSeparator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator1 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsEscape
        {
            get
            {
                return this._mnuCommandsEscape;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsEscape != null)
                {
                    this._mnuCommandsEscape.Click -= new EventHandler(this.mnuCommandsEscape_Click);
                }
                this._mnuCommandsEscape = value;
                if (this._mnuCommandsEscape != null)
                {
                    this._mnuCommandsEscape.Click += new EventHandler(this.mnuCommandsEscape_Click);
                }
            }
        }

        internal virtual Label lblReplace
        {
            get
            {
                return this._lblReplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblReplace = value;
            }
        }

        internal virtual StatusStrip StatusStrip1
        {
            get
            {
                return this._StatusStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StatusStrip1 = value;
            }
        }

        internal virtual ToolStripStatusLabel staExecutionTime
        {
            get
            {
                return this._staExecutionTime;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._staExecutionTime = value;
            }
        }

        internal virtual ToolStripStatusLabel staMatches
        {
            get
            {
                return this._staMatches;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._staMatches = value;
            }
        }

        internal virtual TreeView tvwResults
        {
            get
            {
                return this._tvwResults;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._tvwResults != null)
                {
                    this._tvwResults.BeforeExpand -= new TreeViewCancelEventHandler(this.tvwResults_BeforeExpand);
                    this._tvwResults.AfterSelect -= new TreeViewEventHandler(this.tvwResults_AfterSelect);
                }
                this._tvwResults = value;
                if (this._tvwResults != null)
                {
                    this._tvwResults.BeforeExpand += new TreeViewCancelEventHandler(this.tvwResults_BeforeExpand);
                    this._tvwResults.AfterSelect += new TreeViewEventHandler(this.tvwResults_AfterSelect);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsGroups
        {
            get
            {
                return this._mnuResultsGroups;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsGroups != null)
                {
                    this._mnuResultsGroups.Click -= new EventHandler(this.mnuResultsGroups_Click);
                }
                this._mnuResultsGroups = value;
                if (this._mnuResultsGroups != null)
                {
                    this._mnuResultsGroups.Click += new EventHandler(this.mnuResultsGroups_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsCaptures
        {
            get
            {
                return this._mnuResultsCaptures;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsCaptures != null)
                {
                    this._mnuResultsCaptures.Click -= new EventHandler(this.mnuResultsCaptures_Click);
                }
                this._mnuResultsCaptures = value;
                if (this._mnuResultsCaptures != null)
                {
                    this._mnuResultsCaptures.Click += new EventHandler(this.mnuResultsCaptures_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsNoDetails
        {
            get
            {
                return this._mnuResultsNoDetails;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsNoDetails != null)
                {
                    this._mnuResultsNoDetails.Click -= new EventHandler(this.mnuResultsNoDetails_Click);
                }
                this._mnuResultsNoDetails = value;
                if (this._mnuResultsNoDetails != null)
                {
                    this._mnuResultsNoDetails.Click += new EventHandler(this.mnuResultsNoDetails_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator2
        {
            get
            {
                return this._ToolStripSeparator2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator2 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuResultsDontSort
        {
            get
            {
                return this._mnuResultsDontSort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsDontSort != null)
                {
                    this._mnuResultsDontSort.Click -= new EventHandler(this.mnuResultsDontSort_Click);
                }
                this._mnuResultsDontSort = value;
                if (this._mnuResultsDontSort != null)
                {
                    this._mnuResultsDontSort.Click += new EventHandler(this.mnuResultsDontSort_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsSortAlphabetically
        {
            get
            {
                return this._mnuResultsSortAlphabetically;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsSortAlphabetically != null)
                {
                    this._mnuResultsSortAlphabetically.Click -= new EventHandler(this.mnuResultsSortAlphabetically_Click);
                }
                this._mnuResultsSortAlphabetically = value;
                if (this._mnuResultsSortAlphabetically != null)
                {
                    this._mnuResultsSortAlphabetically.Click += new EventHandler(this.mnuResultsSortAlphabetically_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsShortest
        {
            get
            {
                return this._mnuResultsShortest;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsShortest != null)
                {
                    this._mnuResultsShortest.Click -= new EventHandler(this.mnuResultsShortest_Click);
                }
                this._mnuResultsShortest = value;
                if (this._mnuResultsShortest != null)
                {
                    this._mnuResultsShortest.Click += new EventHandler(this.mnuResultsShortest_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsLargest
        {
            get
            {
                return this._mnuResultsLargest;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsLargest != null)
                {
                    this._mnuResultsLargest.Click -= new EventHandler(this.mnuResultsLargest_Click);
                }
                this._mnuResultsLargest = value;
                if (this._mnuResultsLargest != null)
                {
                    this._mnuResultsLargest.Click += new EventHandler(this.mnuResultsLargest_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem ToolStripTextBox1
        {
            get
            {
                return this._ToolStripTextBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox1 = value;
            }
        }

        internal virtual ToolStripTextBox txtViewMaxMatches
        {
            get
            {
                return this._txtViewMaxMatches;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtViewMaxMatches != null)
                {
                    this._txtViewMaxMatches.TextChanged -= new EventHandler(this.txtViewMaxMatches_Click);
                }
                this._txtViewMaxMatches = value;
                if (this._txtViewMaxMatches != null)
                {
                    this._txtViewMaxMatches.TextChanged += new EventHandler(this.txtViewMaxMatches_Click);
                }
            }
        }

        internal virtual RichTextBox rtbResults
        {
            get
            {
                return this._rtbResults;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtbResults = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripMenuItem1
        {
            get
            {
                return this._ToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripMenuItem1 = value;
            }
        }

        internal virtual ContextMenuStrip ctxPattern
        {
            get
            {
                return this._ctxPattern;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ctxPattern = value;
            }
        }

        internal virtual ContextMenuStrip ctxReplace
        {
            get
            {
                return this._ctxReplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ctxReplace = value;
            }
        }

        internal virtual RichTextBox rtbRegex
        {
            get
            {
                return this._rtbRegex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtbRegex = value;
            }
        }

        internal virtual RichTextBox rtbReplace
        {
            get
            {
                return this._rtbReplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtbReplace = value;
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsRun
        {
            get
            {
                return this._mnuCommandsRun;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsRun != null)
                {
                    this._mnuCommandsRun.Click -= new EventHandler(this.mnuCommandsRun_Click);
                }
                this._mnuCommandsRun = value;
                if (this._mnuCommandsRun != null)
                {
                    this._mnuCommandsRun.Click += new EventHandler(this.mnuCommandsRun_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator3
        {
            get
            {
                return this._ToolStripSeparator3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator3 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFileSave
        {
            get
            {
                return this._mnuFileSave;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileSave != null)
                {
                    this._mnuFileSave.Click -= new EventHandler(this.mnuFileSave_Click);
                }
                this._mnuFileSave = value;
                if (this._mnuFileSave != null)
                {
                    this._mnuFileSave.Click += new EventHandler(this.mnuFileSave_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuFileSaveAs
        {
            get
            {
                return this._mnuFileSaveAs;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileSaveAs != null)
                {
                    this._mnuFileSaveAs.Click -= new EventHandler(this.mnuFileSaveAs_Click);
                }
                this._mnuFileSaveAs = value;
                if (this._mnuFileSaveAs != null)
                {
                    this._mnuFileSaveAs.Click += new EventHandler(this.mnuFileSaveAs_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator4
        {
            get
            {
                return this._ToolStripSeparator4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator4 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFileProperties
        {
            get
            {
                return this._mnuFileProperties;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileProperties != null)
                {
                    this._mnuFileProperties.Click -= new EventHandler(this.mnuFileProperties_Click);
                }
                this._mnuFileProperties = value;
                if (this._mnuFileProperties != null)
                {
                    this._mnuFileProperties.Click += new EventHandler(this.mnuFileProperties_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator5
        {
            get
            {
                return this._ToolStripSeparator5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator5 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFileLoad
        {
            get
            {
                return this._mnuFileLoad;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileLoad != null)
                {
                    this._mnuFileLoad.Click -= new EventHandler(this.mnuFileLoad_Click);
                }
                this._mnuFileLoad = value;
                if (this._mnuFileLoad != null)
                {
                    this._mnuFileLoad.Click += new EventHandler(this.mnuFileLoad_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator6
        {
            get
            {
                return this._ToolStripSeparator6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator6 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuFileExit
        {
            get
            {
                return this._mnuFileExit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuFileExit != null)
                {
                    this._mnuFileExit.Click -= new EventHandler(this.mnuFileExit_Click);
                }
                this._mnuFileExit = value;
                if (this._mnuFileExit != null)
                {
                    this._mnuFileExit.Click += new EventHandler(this.mnuFileExit_Click);
                }
            }
        }

        internal virtual ToolStripStatusLabel staItemInfo
        {
            get
            {
                return this._staItemInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._staItemInfo = value;
            }
        }

        internal virtual ToolStripMenuItem mnuResultsTreeView
        {
            get
            {
                return this._mnuResultsTreeView;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsTreeView != null)
                {
                    this._mnuResultsTreeView.Click -= new EventHandler(this.mnuResultsTreeView_Click);
                }
                this._mnuResultsTreeView = value;
                if (this._mnuResultsTreeView != null)
                {
                    this._mnuResultsTreeView.Click += new EventHandler(this.mnuResultsTreeView_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsReport
        {
            get
            {
                return this._mnuResultsReport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsReport != null)
                {
                    this._mnuResultsReport.Click -= new EventHandler(this.mnuResultsReport_Click);
                }
                this._mnuResultsReport = value;
                if (this._mnuResultsReport != null)
                {
                    this._mnuResultsReport.Click += new EventHandler(this.mnuResultsReport_Click);
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator7
        {
            get
            {
                return this._ToolStripSeparator7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator7 = value;
            }
        }

        internal virtual Label lblMatches
        {
            get
            {
                return this._lblMatches;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblMatches = value;
            }
        }

        internal virtual ToolStripMenuItem mnuResultsAuto
        {
            get
            {
                return this._mnuResultsAuto;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsAuto != null)
                {
                    this._mnuResultsAuto.Click -= new EventHandler(this.mnuResultsAuto_Click);
                }
                this._mnuResultsAuto = value;
                if (this._mnuResultsAuto != null)
                {
                    this._mnuResultsAuto.Click += new EventHandler(this.mnuResultsAuto_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuEdit
        {
            get
            {
                return this._mnuEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuEdit = value;
            }
        }

        internal virtual ToolStripMenuItem mnuEditWordWrap
        {
            get
            {
                return this._mnuEditWordWrap;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuEditWordWrap != null)
                {
                    this._mnuEditWordWrap.Click -= new EventHandler(this.mnuEditWordWrap_Click);
                }
                this._mnuEditWordWrap = value;
                if (this._mnuEditWordWrap != null)
                {
                    this._mnuEditWordWrap.Click += new EventHandler(this.mnuEditWordWrap_Click);
                }
            }
        }

        internal virtual OpenFileDialog dlgOpenRegex
        {
            get
            {
                return this._dlgOpenRegex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgOpenRegex = value;
            }
        }

        internal virtual SaveFileDialog dlgSaveRegex
        {
            get
            {
                return this._dlgSaveRegex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgSaveRegex = value;
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsGenerateCode
        {
            get
            {
                return this._mnuCommandsGenerateCode;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsGenerateCode != null)
                {
                    this._mnuCommandsGenerateCode.Click -= new EventHandler(this.mnuCommandsGenerateCode_Click);
                }
                this._mnuCommandsGenerateCode = value;
                if (this._mnuCommandsGenerateCode != null)
                {
                    this._mnuCommandsGenerateCode.Click += new EventHandler(this.mnuCommandsGenerateCode_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsShowGroups
        {
            get
            {
                return this._mnuCommandsShowGroups;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsShowGroups != null)
                {
                    this._mnuCommandsShowGroups.Click -= new EventHandler(this.mnuCommandsShowGroups_Click);
                }
                this._mnuCommandsShowGroups = value;
                if (this._mnuCommandsShowGroups != null)
                {
                    this._mnuCommandsShowGroups.Click += new EventHandler(this.mnuCommandsShowGroups_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuResultsIncludeEmptyGroups
        {
            get
            {
                return this._mnuResultsIncludeEmptyGroups;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuResultsIncludeEmptyGroups != null)
                {
                    this._mnuResultsIncludeEmptyGroups.Click -= new EventHandler(this.mnuResultsIncludeEmptyGroups_Click);
                }
                this._mnuResultsIncludeEmptyGroups = value;
                if (this._mnuResultsIncludeEmptyGroups != null)
                {
                    this._mnuResultsIncludeEmptyGroups.Click += new EventHandler(this.mnuResultsIncludeEmptyGroups_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuCommandsCompile
        {
            get
            {
                return this._mnuCommandsCompile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuCommandsCompile != null)
                {
                    this._mnuCommandsCompile.Click -= new EventHandler(this.mnuCommandsCompile_Click);
                }
                this._mnuCommandsCompile = value;
                if (this._mnuCommandsCompile != null)
                {
                    this._mnuCommandsCompile.Click += new EventHandler(this.mnuCommandsCompile_Click);
                }
            }
        }

        internal virtual ToolTip ToolTip1
        {
            get
            {
                return this._ToolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolTip1 = value;
            }
        }

        internal virtual HelpProvider HelpProvider1
        {
            get
            {
                return this._HelpProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HelpProvider1 = value;
            }
        }

        internal virtual ToolStripMenuItem mnuHelp
        {
            get
            {
                return this._mnuHelp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mnuHelp = value;
            }
        }

        internal virtual ToolStripMenuItem mnuHelpAbout
        {
            get
            {
                return this._mnuHelpAbout;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuHelpAbout != null)
                {
                    this._mnuHelpAbout.Click -= new EventHandler(this.mnuHelpAbout_Click);
                }
                this._mnuHelpAbout = value;
                if (this._mnuHelpAbout != null)
                {
                    this._mnuHelpAbout.Click += new EventHandler(this.mnuHelpAbout_Click);
                }
            }
        }

        internal virtual ToolStripMenuItem mnuOptionsSingleline
        {
            get
            {
                return this._mnuOptionsSingleline;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._mnuOptionsSingleline != null)
                {
                    this._mnuOptionsSingleline.Click -= new EventHandler(this.mnuOptionsSingleline_Click);
                }
                this._mnuOptionsSingleline = value;
                if (this._mnuOptionsSingleline != null)
                {
                    this._mnuOptionsSingleline.Click += new EventHandler(this.mnuOptionsSingleline_Click);
                }
            }
        }
    }
}

