namespace RegexTester
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class GenerateCodeForm : Form
    {
        private IContainer components;
        [AccessedThroughProperty("radVisualBasic")]
        private RadioButton _radVisualBasic;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("chkVerbatimStrings")]
        private CheckBox _chkVerbatimStrings;
        [AccessedThroughProperty("radVisualCSharp")]
        private RadioButton _radVisualCSharp;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("chkGenerateLoops")]
        private CheckBox _chkGenerateLoops;
        [AccessedThroughProperty("chkAssumeImports")]
        private CheckBox _chkAssumeImports;
        [AccessedThroughProperty("chkInstanceMethods")]
        private CheckBox _chkInstanceMethods;
        [AccessedThroughProperty("txtCode")]
        private TextBox _txtCode;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;
        [AccessedThroughProperty("chkCopyToClipboard")]
        private CheckBox _chkCopyToClipboard;
        [AccessedThroughProperty("chkDescriptionAsComment")]
        private CheckBox _chkDescriptionAsComment;
        [AccessedThroughProperty("HelpProvider1")]
        private HelpProvider _HelpProvider1;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        public ProjectOptions Options;
        private bool initializing;

        public GenerateCodeForm()
        {
            base.Load += new EventHandler(this.GenerateCodeForm_Load);
            this.initializing = true;
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.radVisualBasic.Checked)
            {
                this.Options.Language = LanguageOption.VisualBasic;
            }
            else
            {
                this.Options.Language = LanguageOption.VisualCsharp;
            }
            this.Options.VerbatimStrings = this.chkVerbatimStrings.Checked;
            this.Options.InstanceMethods = this.chkInstanceMethods.Checked;
            this.Options.AssumeImports = this.chkAssumeImports.Checked;
            this.Options.GenerateLoop = this.chkGenerateLoops.Checked;
            this.Options.IncludeComment = this.chkDescriptionAsComment.Checked;
            this.Options.CopyCodeOnExit = this.chkCopyToClipboard.Checked;
            if (this.Options.CopyCodeOnExit)
            {
                Clipboard.SetText(this.txtCode.Text);
            }
            this.DialogResult = DialogResult.OK;
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

        private void GenerateCodeForm_Load(object sender, EventArgs e)
        {
            Helpers.SetTooltipsAndHelpMessages(this, this.ToolTip1, this.HelpProvider1);
            if (this.Options.Language == LanguageOption.VisualBasic)
            {
                this.radVisualBasic.Checked = true;
            }
            else
            {
                this.radVisualCSharp.Checked = true;
            }
            this.chkVerbatimStrings.Checked = this.Options.VerbatimStrings;
            this.chkInstanceMethods.Checked = this.Options.InstanceMethods;
            this.chkAssumeImports.Checked = this.Options.AssumeImports;
            this.chkGenerateLoops.Checked = this.Options.GenerateLoop;
            this.chkDescriptionAsComment.Checked = this.Options.IncludeComment;
            this.chkCopyToClipboard.Checked = this.Options.CopyCodeOnExit;
            this.chkGenerateLoops.Enabled = this.Options.Command != RegexTester.Command.Replace;
            this.chkDescriptionAsComment.Enabled = this.Options.RegexDescription.Length > 0;
            this.initializing = false;
            this.RefreshCode();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radVisualBasic = new RadioButton();
            this.GroupBox1 = new GroupBox();
            this.chkVerbatimStrings = new CheckBox();
            this.radVisualCSharp = new RadioButton();
            this.GroupBox2 = new GroupBox();
            this.chkDescriptionAsComment = new CheckBox();
            this.chkGenerateLoops = new CheckBox();
            this.chkAssumeImports = new CheckBox();
            this.chkInstanceMethods = new CheckBox();
            this.txtCode = new TextBox();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.chkCopyToClipboard = new CheckBox();
            this.HelpProvider1 = new HelpProvider();
            this.ToolTip1 = new ToolTip(this.components);
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            this.radVisualBasic.AutoSize = true;
            Point point = new Point(0x12, 0x15);
            this.radVisualBasic.Location = point;
            this.radVisualBasic.Name = "radVisualBasic";
            Size size = new Size(0x52, 0x11);
            this.radVisualBasic.Size = size;
            this.radVisualBasic.TabIndex = 0;
            this.radVisualBasic.TabStop = true;
            this.radVisualBasic.Text = "Visual &Basic";
            this.ToolTip1.SetToolTip(this.radVisualBasic, "Generate Visual Basic code");
            this.radVisualBasic.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add(this.chkVerbatimStrings);
            this.GroupBox1.Controls.Add(this.radVisualCSharp);
            this.GroupBox1.Controls.Add(this.radVisualBasic);
            point = new Point(12, 12);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(230, 0x7a);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Language";
            this.chkVerbatimStrings.AutoSize = true;
            point = new Point(40, 0x4b);
            this.chkVerbatimStrings.Location = point;
            this.chkVerbatimStrings.Name = "chkVerbatimStrings";
            size = new Size(120, 0x11);
            this.chkVerbatimStrings.Size = size;
            this.chkVerbatimStrings.TabIndex = 2;
            this.chkVerbatimStrings.Text = "&Verbatim (@) strings";
            this.ToolTip1.SetToolTip(this.chkVerbatimStrings, "If selected, generated code uses @ C# strings.");
            this.chkVerbatimStrings.UseVisualStyleBackColor = true;
            this.radVisualCSharp.AutoSize = true;
            point = new Point(0x12, 0x30);
            this.radVisualCSharp.Location = point;
            this.radVisualCSharp.Name = "radVisualCSharp";
            size = new Size(70, 0x11);
            this.radVisualCSharp.Size = size;
            this.radVisualCSharp.TabIndex = 1;
            this.radVisualCSharp.TabStop = true;
            this.radVisualCSharp.Text = "Visual &C#";
            this.ToolTip1.SetToolTip(this.radVisualCSharp, "Generate C# code");
            this.radVisualCSharp.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add(this.chkDescriptionAsComment);
            this.GroupBox2.Controls.Add(this.chkGenerateLoops);
            this.GroupBox2.Controls.Add(this.chkAssumeImports);
            this.GroupBox2.Controls.Add(this.chkInstanceMethods);
            point = new Point(0x103, 13);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(230, 0x79);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Options";
            this.chkDescriptionAsComment.AutoSize = true;
            point = new Point(0x10, 0x62);
            this.chkDescriptionAsComment.Location = point;
            this.chkDescriptionAsComment.Name = "chkDescriptionAsComment";
            size = new Size(0x8b, 0x11);
            this.chkDescriptionAsComment.Size = size;
            this.chkDescriptionAsComment.TabIndex = 3;
            this.chkDescriptionAsComment.Text = "&Description as comment";
            this.ToolTip1.SetToolTip(this.chkDescriptionAsComment, "The generated code contains a comment equal to the regex description. ?This option is disabled if the current regular expression has no description.)");
            this.chkDescriptionAsComment.UseVisualStyleBackColor = true;
            this.chkGenerateLoops.AutoSize = true;
            point = new Point(0x10, 0x4a);
            this.chkGenerateLoops.Location = point;
            this.chkGenerateLoops.Name = "chkGenerateLoops";
            size = new Size(0x5d, 0x11);
            this.chkGenerateLoops.Size = size;
            this.chkGenerateLoops.TabIndex = 2;
            this.chkGenerateLoops.Text = "&Generate loop";
            this.ToolTip1.SetToolTip(this.chkGenerateLoops, "The generate code contains a loop that visits all matches or split lines. ?This option is disabled if the current command is Replace.)");
            this.chkGenerateLoops.UseVisualStyleBackColor = true;
            this.chkAssumeImports.AutoSize = true;
            point = new Point(0x10, 0x30);
            this.chkAssumeImports.Location = point;
            this.chkAssumeImports.Name = "chkAssumeImports";
            size = new Size(130, 0x11);
            this.chkAssumeImports.Size = size;
            this.chkAssumeImports.TabIndex = 1;
            this.chkAssumeImports.Text = "&Assume Imports/using";
            this.ToolTip1.SetToolTip(this.chkAssumeImports, "Assume that the System.Text.RegularExpressions namespace as been imported in current source file.");
            this.chkAssumeImports.UseVisualStyleBackColor = true;
            this.chkInstanceMethods.AutoSize = true;
            point = new Point(0x10, 20);
            this.chkInstanceMethods.Location = point;
            this.chkInstanceMethods.Name = "chkInstanceMethods";
            size = new Size(0x69, 0x11);
            this.chkInstanceMethods.Size = size;
            this.chkInstanceMethods.TabIndex = 0;
            this.chkInstanceMethods.Text = "&Instance method";
            this.ToolTip1.SetToolTip(this.chkInstanceMethods, "If selected the generated code uses the Find, Replace, or Split instance method. therwise generate code that uses the static version of these methods.");
            this.chkInstanceMethods.UseVisualStyleBackColor = true;
            point = new Point(12, 0x94);
            this.txtCode.Location = point;
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            size = new Size(0x1de, 0x65);
            this.txtCode.Size = size;
            this.txtCode.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.txtCode, "The generated source code.");
            this.btnCancel.DialogResult = DialogResult.Cancel;
            point = new Point(0x1aa, 0xff);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(0x40, 0x17);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.ToolTip1.SetToolTip(this.btnCancel, "Close the dialog box without copying the generated code to the Clipboard.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.DialogResult = DialogResult.OK;
            point = new Point(0x162, 0xff);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new Size(0x40, 0x17);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.ToolTip1.SetToolTip(this.btnOK, "Close the dialog box and optionally copy the generated code to the Clipboard.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.chkCopyToClipboard.AutoSize = true;
            point = new Point(12, 0x103);
            this.chkCopyToClipboard.Location = point;
            this.chkCopyToClipboard.Name = "chkCopyToClipboard";
            size = new Size(0xa9, 0x11);
            this.chkCopyToClipboard.Size = size;
            this.chkCopyToClipboard.TabIndex = 3;
            this.chkCopyToClipboard.Text = "C&opy code to clipboard on exit";
            this.ToolTip1.SetToolTip(this.chkCopyToClipboard, "If enabled, generated code is copied to the Clipboard hen the user clicks on the OK button.");
            this.chkCopyToClipboard.UseVisualStyleBackColor = true;
            this.AcceptButton = this.btnOK;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            size = new Size(0x1f3, 0x11c);
            this.ClientSize = size;
            this.Controls.Add(this.chkCopyToClipboard);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateCodeForm";
            this.Text = "Generate Code";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void radVisualCSharp_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshCode();
        }

        public void RefreshCode()
        {
            this.chkVerbatimStrings.Enabled = this.radVisualCSharp.Checked;
            if (this.initializing)
            {
                return;
            }
            string regexText = this.Options.RegexText;
            string str7 = "re";
            string str6 = "\"text\"";
            string str3 = "";
            if (!this.chkAssumeImports.Checked)
            {
                str3 = "System.Text.RegularExpressions.";
            }
            string str2 = "//";
            string format = "";
            if ((this.Options.RegexOptions & RegexOptions.IgnoreCase) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.IgnoreCase";
            }
            if ((this.Options.RegexOptions & RegexOptions.IgnorePatternWhitespace) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.IgnorePatternWhitespace";
            }
            if ((this.Options.RegexOptions & RegexOptions.Multiline) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.Multiline";
            }
            if ((this.Options.RegexOptions & RegexOptions.Singleline) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.Singleline";
            }
            if ((this.Options.RegexOptions & RegexOptions.Compiled) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.Compiled";
            }
            if ((this.Options.RegexOptions & RegexOptions.ExplicitCapture) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.ExplicitCapture";
            }
            if ((this.Options.RegexOptions & RegexOptions.RightToLeft) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.RightToLeft";
            }
            if ((this.Options.RegexOptions & RegexOptions.CultureInvariant) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.CultureInvariant";
            }
            if ((this.Options.RegexOptions & RegexOptions.ECMAScript) > RegexOptions.None)
            {
                format = format + " | {0}RegexOptions.ECMAScript";
            }
            if (format.Length == 0)
            {
                format = "{0}RegexOptions.None";
            }
            else
            {
                format = format.Substring(3);
            }
            format = string.Format(format, str3);
            string str = null;
            if (!this.radVisualBasic.Checked)
            {
                if (this.chkVerbatimStrings.Checked)
                {
                    regexText = "@\"" + regexText.Replace("\"", "\"\"") + "\"";
                }
                else
                {
                    regexText = "\"" + regexText.Replace(@"\", @"\\").Replace("\"", "\\\"") + "\"";
                }
                if (this.chkInstanceMethods.Checked)
                {
                    str = "{2}Regex {1} = new {2}Regex({3}, {4});{0}";
                }
                switch (this.Options.Command)
                {
                    case RegexTester.Command.Find:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "{2}MatchCollection mc = {2}Regex.Matches({5}, {3}, {4});{0}";
                        }
                        else
                        {
                            str = str + "{2}MatchCollection mc = re.Matches({5});{0}";
                        }
                        if (this.chkGenerateLoops.Checked)
                        {
                            str = str + "foreach ({2}Match ma in mc){0}{{{0}}}{0}";
                        }
                        break;

                    case RegexTester.Command.Replace:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "string result = {2}Regex.Replace({5}, {3}, {4});{0}";
                            break;
                        }
                        str = str + "string result = {1}.Replace({5});{0}";
                        break;

                    case RegexTester.Command.Split:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "string[] lines = {2}Regex.Split({5}, {3}, {4});{0}";
                        }
                        else
                        {
                            str = str + "string[] lines= re.Split({5});{0}";
                        }
                        if (this.chkGenerateLoops.Checked)
                        {
                            str = str + "foreach (string line in lines){0}{{{0}}}{0}";
                        }
                        break;
                }
            }
            else
            {
                regexText = "\"" + regexText.Replace("\"", "\"\"") + "\"";
                format = format.Replace("|", "Or");
                str2 = "'";
                if (this.chkInstanceMethods.Checked)
                {
                    str = "Dim {1} As New {2}Regex({3}, {4}){0}";
                }
                switch (this.Options.Command)
                {
                    case RegexTester.Command.Find:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "Dim mc As {2}MatchCollection = {2}Regex.Matches({5}, {3}, {4}){0}";
                            break;
                        }
                        str = str + "Dim mc As {2}MatchCollection = re.Matches({5}){0}";
                        break;

                    case RegexTester.Command.Replace:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "Dim result As String = {2}Regex.Replace({5}, {3}, {4}){0}";
                        }
                        else
                        {
                            str = str + "Dim result As String = {1}.Replace({5}){0}";
                        }
                        goto Label_03FD;

                    case RegexTester.Command.Split:
                        if (!this.chkInstanceMethods.Checked)
                        {
                            str = "Dim lines() as String = {2}Regex.Split({5}, {3}, {4}){0}";
                        }
                        else
                        {
                            str = str + "Dim lines() As String = re.Split({5}){0}";
                        }
                        if (this.chkGenerateLoops.Checked)
                        {
                            str = str + "For Each line As String In lines{0}{0}Next{0}";
                        }
                        goto Label_03FD;

                    default:
                        goto Label_03FD;
                }
                if (this.chkGenerateLoops.Checked)
                {
                    str = str + "For Each ma As {2}Match in mc{0}{0}Next{0}";
                }
            }
        Label_03FD:
            if (this.chkDescriptionAsComment.Checked && (this.Options.RegexDescription.Length > 0))
            {
                string str8 = "";
                foreach (string str9 in this.Options.RegexDescription.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    str8 = str8 + str2 + " " + str9 + "\r\n";
                }
                str = str8 + str;
            }
            str = string.Format(str, new object[] { "\r\n", str7, str3, regexText, format, str6 });
            this.txtCode.Text = str;
        }

        internal virtual RadioButton radVisualBasic
        {
            get
            {
                return this._radVisualBasic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._radVisualBasic != null)
                {
                    this._radVisualBasic.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._radVisualBasic = value;
                if (this._radVisualBasic != null)
                {
                    this._radVisualBasic.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }

        internal virtual CheckBox chkVerbatimStrings
        {
            get
            {
                return this._chkVerbatimStrings;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkVerbatimStrings != null)
                {
                    this._chkVerbatimStrings.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._chkVerbatimStrings = value;
                if (this._chkVerbatimStrings != null)
                {
                    this._chkVerbatimStrings.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton radVisualCSharp
        {
            get
            {
                return this._radVisualCSharp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._radVisualCSharp != null)
                {
                    this._radVisualCSharp.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._radVisualCSharp = value;
                if (this._radVisualCSharp != null)
                {
                    this._radVisualCSharp.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }

        internal virtual CheckBox chkGenerateLoops
        {
            get
            {
                return this._chkGenerateLoops;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkGenerateLoops != null)
                {
                    this._chkGenerateLoops.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._chkGenerateLoops = value;
                if (this._chkGenerateLoops != null)
                {
                    this._chkGenerateLoops.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkAssumeImports
        {
            get
            {
                return this._chkAssumeImports;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkAssumeImports != null)
                {
                    this._chkAssumeImports.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._chkAssumeImports = value;
                if (this._chkAssumeImports != null)
                {
                    this._chkAssumeImports.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkInstanceMethods
        {
            get
            {
                return this._chkInstanceMethods;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkInstanceMethods != null)
                {
                    this._chkInstanceMethods.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._chkInstanceMethods = value;
                if (this._chkInstanceMethods != null)
                {
                    this._chkInstanceMethods.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
            }
        }

        internal virtual TextBox txtCode
        {
            get
            {
                return this._txtCode;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtCode = value;
            }
        }

        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._btnCancel = value;
            }
        }

        internal virtual Button btnOK
        {
            get
            {
                return this._btnOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnOK != null)
                {
                    this._btnOK.Click -= new EventHandler(this.btnOK_Click);
                }
                this._btnOK = value;
                if (this._btnOK != null)
                {
                    this._btnOK.Click += new EventHandler(this.btnOK_Click);
                }
            }
        }

        internal virtual CheckBox chkCopyToClipboard
        {
            get
            {
                return this._chkCopyToClipboard;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkCopyToClipboard = value;
            }
        }

        internal virtual CheckBox chkDescriptionAsComment
        {
            get
            {
                return this._chkDescriptionAsComment;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkDescriptionAsComment != null)
                {
                    this._chkDescriptionAsComment.CheckedChanged -= new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
                this._chkDescriptionAsComment = value;
                if (this._chkDescriptionAsComment != null)
                {
                    this._chkDescriptionAsComment.CheckedChanged += new EventHandler(this.radVisualCSharp_CheckedChanged);
                }
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
    }
}

