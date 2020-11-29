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
    public class EscapeForm : Form
    {
        private IContainer components;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("txtText")]
        private TextBox _txtText;
        [AccessedThroughProperty("radEscape")]
        private RadioButton _radEscape;
        [AccessedThroughProperty("radUnescape")]
        private RadioButton _radUnescape;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("txtResult")]
        private TextBox _txtResult;
        [AccessedThroughProperty("chkCopyToClipboard")]
        private CheckBox _chkCopyToClipboard;
        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("lblError")]
        private Label _lblError;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("HelpProvider1")]
        private HelpProvider _HelpProvider1;
        public ProjectOptions Options;

        public EscapeForm()
        {
            base.Load += new EventHandler(this.EscapeForm_Load);
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.chkCopyToClipboard.Checked && (this.txtResult.TextLength > 0))
            {
                Clipboard.SetText(this.txtResult.Text);
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

        private void EscapeForm_Load(object sender, EventArgs e)
        {
            Helpers.SetTooltipsAndHelpMessages(this, this.ToolTip1, this.HelpProvider1);
            this.txtText.Text = this.Options.RegexText;
            this.lblError.Text = "";
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label1 = new Label();
            this.txtText = new TextBox();
            this.radEscape = new RadioButton();
            this.radUnescape = new RadioButton();
            this.Label2 = new Label();
            this.txtResult = new TextBox();
            this.chkCopyToClipboard = new CheckBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.lblError = new Label();
            this.ToolTip1 = new ToolTip(this.components);
            this.HelpProvider1 = new HelpProvider();
            this.SuspendLayout();
            Point point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size(0x25, 0x17);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "&Text";
            point = new Point(0x37, 9);
            this.txtText.Location = point;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = ScrollBars.Vertical;
            size = new Size(0x228, 0x61);
            this.txtText.Size = size;
            this.txtText.TabIndex = 1;
            this.txtText.Text = "Enter a string that you want to escape or unescape.";
            this.radEscape.AutoSize = true;
            this.radEscape.Checked = true;
            point = new Point(0x37, 0x70);
            this.radEscape.Location = point;
            this.radEscape.Name = "radEscape";
            size = new Size(0x3d, 0x11);
            this.radEscape.Size = size;
            this.radEscape.TabIndex = 2;
            this.radEscape.TabStop = true;
            this.radEscape.Text = "&Escape";
            this.ToolTip1.SetToolTip(this.radEscape, "Test the Escape command.");
            this.radEscape.UseVisualStyleBackColor = true;
            this.radUnescape.AutoSize = true;
            point = new Point(0x7a, 0x70);
            this.radUnescape.Location = point;
            this.radUnescape.Name = "radUnescape";
            size = new Size(0x4a, 0x11);
            this.radUnescape.Size = size;
            this.radUnescape.TabIndex = 3;
            this.radUnescape.Text = "&Unescape";
            this.ToolTip1.SetToolTip(this.radUnescape, "Test the Unescape command.");
            this.radUnescape.UseVisualStyleBackColor = true;
            point = new Point(12, 0x89);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x25, 0x17);
            this.Label2.Size = size;
            this.Label2.TabIndex = 5;
            this.Label2.Text = "&Result";
            point = new Point(0x37, 0x89);
            this.txtResult.Location = point;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = ScrollBars.Vertical;
            size = new Size(0x228, 0x5e);
            this.txtResult.Size = size;
            this.txtResult.TabIndex = 6;
            this.txtResult.Text = "The result of the Escape or Unescape method.";
            this.chkCopyToClipboard.AutoSize = true;
            this.chkCopyToClipboard.Checked = true;
            this.chkCopyToClipboard.CheckState = CheckState.Checked;
            point = new Point(0x1d7, 0x72);
            this.chkCopyToClipboard.Location = point;
            this.chkCopyToClipboard.Name = "chkCopyToClipboard";
            size = new Size(0x89, 0x11);
            this.chkCopyToClipboard.Size = size;
            this.chkCopyToClipboard.TabIndex = 4;
            this.chkCopyToClipboard.Text = "C&opy result to Clipboard";
            this.ToolTip1.SetToolTip(this.chkCopyToClipboard, "If selected, the result is copied to the Clipboard hen the user clicks on the OK button.");
            this.chkCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnOK.DialogResult = DialogResult.OK;
            point = new Point(0x1c3, 0xed);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new Size(0x4b, 0x17);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.ToolTip1.SetToolTip(this.btnOK, "Close the dialog box and optionally copy the result to the Clipboard.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            point = new Point(0x214, 0xed);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(0x4b, 0x17);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.ToolTip1.SetToolTip(this.btnCancel, "Close the dialog box without copying the result to the Clipboard.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = Color.Red;
            point = new Point(0x34, 0xed);
            this.lblError.Location = point;
            this.lblError.Name = "lblError";
            size = new Size(0x27, 13);
            this.lblError.Size = size;
            this.lblError.TabIndex = 7;
            this.lblError.Text = "lblError";
            this.AcceptButton = this.btnOK;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            size = new Size(0x26b, 270);
            this.ClientSize = size;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkCopyToClipboard);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.radUnescape);
            this.Controls.Add(this.radEscape);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.Label1);
            this.Name = "EscapeForm";
            this.Text = "Escape Command";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void radUnescape_CheckedChanged(object sender, EventArgs e)
        {
            this.txtText.Text = "";
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radEscape.Checked)
                {
                    this.txtResult.Text = Regex.Escape(this.txtText.Text);
                }
                else
                {
                    this.txtResult.Text = Regex.Unescape(this.txtText.Text);
                }
                this.lblError.Text = "";
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.lblError.Text = exception.Message;
                ProjectData.ClearProjectError();
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

        internal virtual TextBox txtText
        {
            get
            {
                return this._txtText;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtText != null)
                {
                    this._txtText.TextChanged -= new EventHandler(this.txtText_TextChanged);
                }
                this._txtText = value;
                if (this._txtText != null)
                {
                    this._txtText.TextChanged += new EventHandler(this.txtText_TextChanged);
                }
            }
        }

        internal virtual RadioButton radEscape
        {
            get
            {
                return this._radEscape;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._radEscape != null)
                {
                    this._radEscape.CheckedChanged -= new EventHandler(this.radUnescape_CheckedChanged);
                }
                this._radEscape = value;
                if (this._radEscape != null)
                {
                    this._radEscape.CheckedChanged += new EventHandler(this.radUnescape_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton radUnescape
        {
            get
            {
                return this._radUnescape;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._radUnescape != null)
                {
                    this._radUnescape.CheckedChanged -= new EventHandler(this.radUnescape_CheckedChanged);
                }
                this._radUnescape = value;
                if (this._radUnescape != null)
                {
                    this._radUnescape.CheckedChanged += new EventHandler(this.radUnescape_CheckedChanged);
                }
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

        internal virtual TextBox txtResult
        {
            get
            {
                return this._txtResult;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtResult = value;
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

        internal virtual Label lblError
        {
            get
            {
                return this._lblError;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblError = value;
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

