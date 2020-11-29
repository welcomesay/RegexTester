namespace RegexTester
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class CompileForm : Form
    {
        private IContainer components;
        [AccessedThroughProperty("btnRemove")]
        private Button _btnRemove;
        [AccessedThroughProperty("btnCompile")]
        private Button _btnCompile;
        [AccessedThroughProperty("txtNamespace")]
        private TextBox _txtNamespace;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("dlgOpenRegex")]
        private OpenFileDialog _dlgOpenRegex;
        [AccessedThroughProperty("dgrRegexes")]
        private DataGridView _dgrRegexes;
        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;
        [AccessedThroughProperty("RegexBindingSource")]
        private BindingSource _RegexBindingSource;
        [AccessedThroughProperty("btnNew")]
        private Button _btnNew;
        [AccessedThroughProperty("btnClear")]
        private Button _btnClear;
        [AccessedThroughProperty("btnCurrent")]
        private Button _btnCurrent;
        [AccessedThroughProperty("grdcolName")]
        private DataGridViewTextBoxColumn _grdcolName;
        [AccessedThroughProperty("grdcolPattern")]
        private DataGridViewTextBoxColumn _grdcolPattern;
        [AccessedThroughProperty("dgrcolOptions")]
        private DataGridViewTextBoxColumn _dgrcolOptions;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("dlgSaveAssembly")]
        private SaveFileDialog _dlgSaveAssembly;
        [AccessedThroughProperty("txtAssemblyName")]
        private TextBox _txtAssemblyName;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("dlgAssemblyPath")]
        private FolderBrowserDialog _dlgAssemblyPath;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("btnBrowse")]
        private Button _btnBrowse;
        [AccessedThroughProperty("txtPath")]
        private TextBox _txtPath;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("HelpProvider1")]
        private HelpProvider _HelpProvider1;
        public RegexTester.MainForm MainForm;
        private static BindingList<RegexInfo> regexList = new BindingList<RegexInfo>();

        public CompileForm()
        {
            base.Load += new EventHandler(this.CompileForm_Load);
            this.InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.dlgAssemblyPath.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.dlgAssemblyPath.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove all items?", "Remove all rows", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                regexList.Clear();
            }
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            List<RegexInfo> list2 = new List<RegexInfo>();
            if ((this.txtAssemblyName.TextLength == 0) || (this.txtNamespace.TextLength == 0))
            {
                MessageBox.Show("Please type the name of the assembly and its root namespace", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.txtPath.TextLength == 0)
            {
                MessageBox.Show("Please select the output path.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (RegexInfo info in regexList)
                {
                    if ((info.Name != "") || (info.Pattern != ""))
                    {
                        if ((info.Name == "") | (info.Pattern == ""))
                        {
                            MessageBox.Show("Please enter name and pattern for all regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        list2.Add(info);
                    }
                }
                if (list2.Count == 0)
                {
                    MessageBox.Show("Please enter one or more regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    List<RegexCompilationInfo> list = new List<RegexCompilationInfo>();
                    foreach (RegexInfo info3 in list2)
                    {
                        RegexCompilationInfo item = new RegexCompilationInfo(info3.Pattern, info3.Options, info3.Name, this.txtNamespace.Text, true);
                        list.Add(item);
                    }
                    RegexCompilationInfo[] regexinfos = list.ToArray();
                    AssemblyName assemblyname = new AssemblyName(this.txtAssemblyName.Text);
                    assemblyname.CodeBase = Path.Combine(this.txtPath.Text, Path.ChangeExtension(this.txtAssemblyName.Text, ".dll"));
                    try
                    {
                        Regex.CompileToAssembly(regexinfos, assemblyname);
                        MessageBox.Show("The assembly has been created", "Compilation Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        MessageBox.Show(exception.Message, "Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ProjectData.ClearProjectError();
                    }
                }
            }
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            this.MainForm.UpdateOptionFiels();
            RegexInfo item = RegexInfo.FromProjectOption(this.MainForm.Options);
            regexList.Add(item);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (this.dlgOpenRegex.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    RegexInfo item = RegexInfo.FromProjectOption(ProjectOptions.Load(this.dlgOpenRegex.FileName));
                    regexList.Add(item);
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            regexList.Add(new RegexInfo());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgrRegexes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an entire row", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = this.dgrRegexes.SelectedRows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataGridViewRow current = (DataGridViewRow) enumerator.Current;
                        regexList.RemoveAt(current.Index);
                    }
                }
                finally
                {
                }
            }
        }

        private void CompileForm_Load(object sender, EventArgs e)
        {
            Helpers.SetTooltipsAndHelpMessages(this, this.ToolTip1, this.HelpProvider1);
            this.RegexBindingSource.DataSource = regexList;
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRemove = new Button();
            this.btnCompile = new Button();
            this.txtNamespace = new TextBox();
            this.Label1 = new Label();
            this.btnCancel = new Button();
            this.dlgOpenRegex = new OpenFileDialog();
            this.dgrRegexes = new DataGridView();
            this.grdcolName = new DataGridViewTextBoxColumn();
            this.grdcolPattern = new DataGridViewTextBoxColumn();
            this.dgrcolOptions = new DataGridViewTextBoxColumn();
            this.RegexBindingSource = new BindingSource(this.components);
            this.btnFile = new Button();
            this.btnNew = new Button();
            this.btnClear = new Button();
            this.btnCurrent = new Button();
            this.Label2 = new Label();
            this.dlgSaveAssembly = new SaveFileDialog();
            this.txtAssemblyName = new TextBox();
            this.Label3 = new Label();
            this.dlgAssemblyPath = new FolderBrowserDialog();
            this.GroupBox1 = new GroupBox();
            this.btnBrowse = new Button();
            this.txtPath = new TextBox();
            this.Label4 = new Label();
            this.Label5 = new Label();
            this.ToolTip1 = new ToolTip(this.components);
            this.HelpProvider1 = new HelpProvider();
            ((ISupportInitialize) this.dgrRegexes).BeginInit();
            ((ISupportInitialize) this.RegexBindingSource).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.btnRemove.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            Point point = new Point(0x308, 0x9a);
            this.btnRemove.Location = point;
            this.btnRemove.Name = "btnRemove";
            Size size = new Size(0x3a, 0x17);
            this.btnRemove.Size = size;
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "&Remove";
            this.ToolTip1.SetToolTip(this.btnRemove, "Remove the selected regular expression from the list. ?Click on the row header to the left to select an item.)");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnCompile.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            point = new Point(0x308, 0xef);
            this.btnCompile.Location = point;
            this.btnCompile.Name = "btnCompile";
            size = new Size(0x3a, 0x17);
            this.btnCompile.Size = size;
            this.btnCompile.TabIndex = 9;
            this.btnCompile.Text = "&Compile";
            this.ToolTip1.SetToolTip(this.btnCompile, "Compile the list of regular expressions and generate an assembly.");
            this.btnCompile.UseVisualStyleBackColor = true;
            this.txtNamespace.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x1cb, 20);
            this.txtNamespace.Location = point;
            this.txtNamespace.Name = "txtNamespace";
            size = new Size(0x12a, 20);
            this.txtNamespace.Size = size;
            this.txtNamespace.TabIndex = 3;
            this.ToolTip1.SetToolTip(this.txtNamespace, "The namespace used for all the compiled regular expressions.");
            this.Label1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.Label1.AutoSize = true;
            point = new Point(0x16b, 0x19);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(90, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = "R&oot Namespace";
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            point = new Point(0x308, 0x10c);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(0x3a, 0x17);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.ToolTip1.SetToolTip(this.btnCancel, "Close the dialog box without compiling.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.dlgOpenRegex.DefaultExt = "regex";
            this.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*";
            this.dlgOpenRegex.Multiselect = true;
            this.dlgOpenRegex.Title = "Open a regex file";
            this.dgrRegexes.AllowUserToAddRows = false;
            this.dgrRegexes.AllowUserToResizeRows = false;
            this.dgrRegexes.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.dgrRegexes.AutoGenerateColumns = false;
            this.dgrRegexes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrRegexes.Columns.AddRange(new DataGridViewColumn[] { this.grdcolName, this.grdcolPattern, this.dgrcolOptions });
            this.dgrRegexes.DataSource = this.RegexBindingSource;
            point = new Point(7, 0x1d);
            this.dgrRegexes.Location = point;
            this.dgrRegexes.MultiSelect = false;
            this.dgrRegexes.Name = "dgrRegexes";
            this.dgrRegexes.RowHeadersWidth = 0x18;
            size = new Size(0x2fc, 0xb1);
            this.dgrRegexes.Size = size;
            this.dgrRegexes.TabIndex = 1;
            this.ToolTip1.SetToolTip(this.dgrRegexes, "The list of regular expressions to be compiled.");
            this.grdcolName.DataPropertyName = "Name";
            this.grdcolName.HeaderText = "Name";
            this.grdcolName.MaxInputLength = 30;
            this.grdcolName.Name = "grdcolName";
            this.grdcolName.Width = 150;
            this.grdcolPattern.DataPropertyName = "Pattern";
            this.grdcolPattern.HeaderText = "Pattern";
            this.grdcolPattern.MaxInputLength = 0x400;
            this.grdcolPattern.Name = "grdcolPattern";
            this.grdcolPattern.Width = 480;
            this.dgrcolOptions.DataPropertyName = "OptionsText";
            this.dgrcolOptions.HeaderText = "Options";
            this.dgrcolOptions.Name = "dgrcolOptions";
            this.RegexBindingSource.AllowNew = false;
            this.btnFile.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x308, 0x57);
            this.btnFile.Location = point;
            this.btnFile.Name = "btnFile";
            size = new Size(0x3a, 0x17);
            this.btnFile.Size = size;
            this.btnFile.TabIndex = 5;
            this.btnFile.Text = "&File";
            this.ToolTip1.SetToolTip(this.btnFile, "Add a regular expression saved in a file to the list.");
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnNew.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x308, 0x1d);
            this.btnNew.Location = point;
            this.btnNew.Name = "btnNew";
            size = new Size(0x3a, 0x17);
            this.btnNew.Size = size;
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.ToolTip1.SetToolTip(this.btnNew, "Add a new (blank) regular expression to the list.");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnClear.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x308, 0xb7);
            this.btnClear.Location = point;
            this.btnClear.Name = "btnClear";
            size = new Size(0x3a, 0x17);
            this.btnClear.Size = size;
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "C&lear";
            this.ToolTip1.SetToolTip(this.btnClear, "Remove all items from the list.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnCurrent.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x308, 0x3a);
            this.btnCurrent.Location = point;
            this.btnCurrent.Name = "btnCurrent";
            size = new Size(0x3a, 0x17);
            this.btnCurrent.Size = size;
            this.btnCurrent.TabIndex = 4;
            this.btnCurrent.Text = "C&urrent";
            this.ToolTip1.SetToolTip(this.btnCurrent, "Add the current regular expression (the one being ested in the main window) to the list.");
            this.btnCurrent.UseVisualStyleBackColor = true;
            this.Label2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.Label2.AutoSize = true;
            point = new Point(9, 0xd1);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x2de, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "OPTIONS: I=Ignore case,  M=Multiline, X=Ignore,PatternWhitespace,  C=compiled,  N=ExplicitCapture,  R=RightToLeft, U=CultureInvariant, A=EcmaScript";
            this.dlgSaveAssembly.DefaultExt = "dll";
            this.dlgSaveAssembly.Filter = "All assemblies (*.dll)|*.dll";
            this.dlgSaveAssembly.Title = "Select the destination assembly";
            this.txtAssemblyName.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            point = new Point(0x3a, 0x16);
            this.txtAssemblyName.Location = point;
            this.txtAssemblyName.Name = "txtAssemblyName";
            size = new Size(0x105, 20);
            this.txtAssemblyName.Size = size;
            this.txtAssemblyName.TabIndex = 1;
            this.ToolTip1.SetToolTip(this.txtAssemblyName, "The name of the compiled assembly. ?It is also used to name the generated DLL file.)");
            this.Label3.AutoSize = true;
            point = new Point(6, 0x16);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x23, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 0;
            this.Label3.Text = "&Name";
            this.GroupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.GroupBox1.Controls.Add(this.btnBrowse);
            this.GroupBox1.Controls.Add(this.txtPath);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtAssemblyName);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtNamespace);
            point = new Point(7, 0xea);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x2fc, 0x58);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Generated assembly";
            this.btnBrowse.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            point = new Point(0x145, 0x35);
            this.btnBrowse.Location = point;
            this.btnBrowse.Name = "btnBrowse";
            size = new Size(0x22, 0x17);
            this.btnBrowse.Size = size;
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.ToolTip1.SetToolTip(this.btnBrowse, "Select the output path.");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.txtPath.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            point = new Point(0x3a, 0x35);
            this.txtPath.Location = point;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            size = new Size(0x105, 20);
            this.txtPath.Size = size;
            this.txtPath.TabIndex = 5;
            this.ToolTip1.SetToolTip(this.txtPath, "The directory where the compiled assembly is created.");
            this.Label4.AutoSize = true;
            point = new Point(6, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x1d, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 4;
            this.Label4.Text = "&Path";
            this.Label5.AutoSize = true;
            point = new Point(4, 9);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x19b, 13);
            this.Label5.Size = size;
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Enter the regular expressions expressions to be compiled, or add them from .regex files";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x34e, 0x153);
            this.ClientSize = size;
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnCurrent);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.dgrRegexes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.btnRemove);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            size = new Size(0x356, 0x175);
            this.MinimumSize = size;
            this.Name = "CompileForm";
            this.Text = "Compile to Assembly";
            ((ISupportInitialize) this.dgrRegexes).EndInit();
            ((ISupportInitialize) this.RegexBindingSource).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal virtual Button btnRemove
        {
            get
            {
                return this._btnRemove;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnRemove != null)
                {
                    this._btnRemove.Click -= new EventHandler(this.btnRemove_Click);
                }
                this._btnRemove = value;
                if (this._btnRemove != null)
                {
                    this._btnRemove.Click += new EventHandler(this.btnRemove_Click);
                }
            }
        }

        internal virtual Button btnCompile
        {
            get
            {
                return this._btnCompile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCompile != null)
                {
                    this._btnCompile.Click -= new EventHandler(this.btnCompile_Click);
                }
                this._btnCompile = value;
                if (this._btnCompile != null)
                {
                    this._btnCompile.Click += new EventHandler(this.btnCompile_Click);
                }
            }
        }

        internal virtual TextBox txtNamespace
        {
            get
            {
                return this._txtNamespace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtNamespace = value;
            }
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

        internal virtual DataGridView dgrRegexes
        {
            get
            {
                return this._dgrRegexes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dgrRegexes = value;
            }
        }

        internal virtual Button btnFile
        {
            get
            {
                return this._btnFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnFile != null)
                {
                    this._btnFile.Click -= new EventHandler(this.btnFile_Click);
                }
                this._btnFile = value;
                if (this._btnFile != null)
                {
                    this._btnFile.Click += new EventHandler(this.btnFile_Click);
                }
            }
        }

        internal virtual BindingSource RegexBindingSource
        {
            get
            {
                return this._RegexBindingSource;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RegexBindingSource = value;
            }
        }

        internal virtual Button btnNew
        {
            get
            {
                return this._btnNew;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnNew != null)
                {
                    this._btnNew.Click -= new EventHandler(this.btnNew_Click);
                }
                this._btnNew = value;
                if (this._btnNew != null)
                {
                    this._btnNew.Click += new EventHandler(this.btnNew_Click);
                }
            }
        }

        internal virtual Button btnClear
        {
            get
            {
                return this._btnClear;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnClear != null)
                {
                    this._btnClear.Click -= new EventHandler(this.btnClear_Click);
                }
                this._btnClear = value;
                if (this._btnClear != null)
                {
                    this._btnClear.Click += new EventHandler(this.btnClear_Click);
                }
            }
        }

        internal virtual Button btnCurrent
        {
            get
            {
                return this._btnCurrent;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCurrent != null)
                {
                    this._btnCurrent.Click -= new EventHandler(this.btnCurrent_Click);
                }
                this._btnCurrent = value;
                if (this._btnCurrent != null)
                {
                    this._btnCurrent.Click += new EventHandler(this.btnCurrent_Click);
                }
            }
        }

        internal virtual DataGridViewTextBoxColumn grdcolName
        {
            get
            {
                return this._grdcolName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._grdcolName = value;
            }
        }

        internal virtual DataGridViewTextBoxColumn grdcolPattern
        {
            get
            {
                return this._grdcolPattern;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._grdcolPattern = value;
            }
        }

        internal virtual DataGridViewTextBoxColumn dgrcolOptions
        {
            get
            {
                return this._dgrcolOptions;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dgrcolOptions = value;
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

        internal virtual SaveFileDialog dlgSaveAssembly
        {
            get
            {
                return this._dlgSaveAssembly;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgSaveAssembly = value;
            }
        }

        internal virtual TextBox txtAssemblyName
        {
            get
            {
                return this._txtAssemblyName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtAssemblyName = value;
            }
        }

        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }

        internal virtual FolderBrowserDialog dlgAssemblyPath
        {
            get
            {
                return this._dlgAssemblyPath;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgAssemblyPath = value;
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

        internal virtual Button btnBrowse
        {
            get
            {
                return this._btnBrowse;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBrowse != null)
                {
                    this._btnBrowse.Click -= new EventHandler(this.btnBrowse_Click);
                }
                this._btnBrowse = value;
                if (this._btnBrowse != null)
                {
                    this._btnBrowse.Click += new EventHandler(this.btnBrowse_Click);
                }
            }
        }

        internal virtual TextBox txtPath
        {
            get
            {
                return this._txtPath;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPath = value;
            }
        }

        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
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
    }
}

