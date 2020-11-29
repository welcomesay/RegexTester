namespace RegexTester
{
    using Microsoft.VisualBasic.CompilerServices;
    using RegexTester.My;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public sealed class AboutBoxForm : Form
    {
        [AccessedThroughProperty("TableLayoutPanel")]
        private System.Windows.Forms.TableLayoutPanel _TableLayoutPanel;
        [AccessedThroughProperty("LogoPictureBox")]
        private PictureBox _LogoPictureBox;
        [AccessedThroughProperty("LabelProductName")]
        private Label _LabelProductName;
        [AccessedThroughProperty("LabelVersion")]
        private Label _LabelVersion;
        [AccessedThroughProperty("LabelCompanyName")]
        private Label _LabelCompanyName;
        [AccessedThroughProperty("TextBoxDescription")]
        private TextBox _TextBoxDescription;
        [AccessedThroughProperty("OKButton")]
        private Button _OKButton;
        [AccessedThroughProperty("LabelCopyright")]
        private Label _LabelCopyright;
        private IContainer components;

        public AboutBoxForm()
        {
            base.Load += new EventHandler(this.AboutBoxForm_Load);
            this.InitializeComponent();
        }

        private void AboutBoxForm_Load(object sender, EventArgs e)
        {
            string title;
            if (MyProject.Application.Info.Title != "")
            {
                title = MyProject.Application.Info.Title;
            }
            else
            {
                title = Path.GetFileNameWithoutExtension(MyProject.Application.Info.AssemblyName);
            }
            this.Text = string.Format("About {0}", title);
            this.LabelProductName.Text = MyProject.Application.Info.ProductName;
            this.LabelVersion.Text = string.Format("Version {0}", MyProject.Application.Info.Version.ToString());
            this.LabelCopyright.Text = MyProject.Application.Info.Copyright;
            this.LabelCompanyName.Text = MyProject.Application.Info.CompanyName;
            this.TextBoxDescription.Text = MyProject.Application.Info.Description;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(AboutBoxForm));
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LogoPictureBox = new PictureBox();
            this.LabelProductName = new Label();
            this.LabelVersion = new Label();
            this.LabelCopyright = new Label();
            this.LabelCompanyName = new Label();
            this.TextBoxDescription = new TextBox();
            this.OKButton = new Button();
            this.TableLayoutPanel.SuspendLayout();
            ((ISupportInitialize) this.LogoPictureBox).BeginInit();
            this.SuspendLayout();
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            this.TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
            this.TableLayoutPanel.Controls.Add(this.LogoPictureBox, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.LabelProductName, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.LabelVersion, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.LabelCopyright, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.LabelCompanyName, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.TextBoxDescription, 1, 4);
            this.TableLayoutPanel.Controls.Add(this.OKButton, 1, 5);
            this.TableLayoutPanel.Dock = DockStyle.Fill;
            Point point = new Point(9, 8);
            this.TableLayoutPanel.Location = point;
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 6;
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            Size size = new Size(0x18c, 0xef);
            this.TableLayoutPanel.Size = size;
            this.TableLayoutPanel.TabIndex = 0;
            this.LogoPictureBox.Dock = DockStyle.Fill;
            this.LogoPictureBox.Image = (Image) manager.GetObject("LogoPictureBox.Image");
            point = new Point(3, 3);
            this.LogoPictureBox.Location = point;
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.TableLayoutPanel.SetRowSpan(this.LogoPictureBox, 6);
            size = new Size(0x7c, 0xe9);
            this.LogoPictureBox.Size = size;
            this.LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            this.LabelProductName.Dock = DockStyle.Fill;
            point = new Point(0x88, 0);
            this.LabelProductName.Location = point;
            Padding padding = new Padding(6, 0, 3, 0);
            this.LabelProductName.Margin = padding;
            size = new Size(0, 0x10);
            this.LabelProductName.MaximumSize = size;
            this.LabelProductName.Name = "LabelProductName";
            size = new Size(0x101, 0x10);
            this.LabelProductName.Size = size;
            this.LabelProductName.TabIndex = 0;
            this.LabelProductName.Text = "Product Name";
            this.LabelProductName.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelVersion.Dock = DockStyle.Fill;
            point = new Point(0x88, 0x17);
            this.LabelVersion.Location = point;
            padding = new Padding(6, 0, 3, 0);
            this.LabelVersion.Margin = padding;
            size = new Size(0, 0x10);
            this.LabelVersion.MaximumSize = size;
            this.LabelVersion.Name = "LabelVersion";
            size = new Size(0x101, 0x10);
            this.LabelVersion.Size = size;
            this.LabelVersion.TabIndex = 0;
            this.LabelVersion.Text = "Version";
            this.LabelVersion.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelCopyright.Dock = DockStyle.Fill;
            point = new Point(0x88, 0x2e);
            this.LabelCopyright.Location = point;
            padding = new Padding(6, 0, 3, 0);
            this.LabelCopyright.Margin = padding;
            size = new Size(0, 0x10);
            this.LabelCopyright.MaximumSize = size;
            this.LabelCopyright.Name = "LabelCopyright";
            size = new Size(0x101, 0x10);
            this.LabelCopyright.Size = size;
            this.LabelCopyright.TabIndex = 0;
            this.LabelCopyright.Text = "Copyright";
            this.LabelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelCompanyName.Dock = DockStyle.Fill;
            point = new Point(0x88, 0x45);
            this.LabelCompanyName.Location = point;
            padding = new Padding(6, 0, 3, 0);
            this.LabelCompanyName.Margin = padding;
            size = new Size(0, 0x10);
            this.LabelCompanyName.MaximumSize = size;
            this.LabelCompanyName.Name = "LabelCompanyName";
            size = new Size(0x101, 0x10);
            this.LabelCompanyName.Size = size;
            this.LabelCompanyName.TabIndex = 0;
            this.LabelCompanyName.Text = "Company Name";
            this.LabelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            this.TextBoxDescription.Dock = DockStyle.Fill;
            point = new Point(0x88, 0x5f);
            this.TextBoxDescription.Location = point;
            padding = new Padding(6, 3, 3, 3);
            this.TextBoxDescription.Margin = padding;
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.ReadOnly = true;
            this.TextBoxDescription.ScrollBars = ScrollBars.Both;
            size = new Size(0x101, 0x71);
            this.TextBoxDescription.Size = size;
            this.TextBoxDescription.TabIndex = 0;
            this.TextBoxDescription.TabStop = false;
            this.TextBoxDescription.Text = manager.GetString("TextBoxDescription.Text");
            this.OKButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.OKButton.DialogResult = DialogResult.Cancel;
            point = new Point(0x13e, 0xd7);
            this.OKButton.Location = point;
            this.OKButton.Name = "OKButton";
            size = new Size(0x4b, 0x15);
            this.OKButton.Size = size;
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "&OK";
            SizeF ef = new SizeF(6f, 12f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.OKButton;
            size = new Size(0x19e, 0xff);
            this.ClientSize = size;
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBoxForm";
            padding = new Padding(9, 8, 9, 8);
            this.Padding = padding;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "AboutBoxForm";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((ISupportInitialize) this.LogoPictureBox).EndInit();
            this.ResumeLayout(false);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel
        {
            get
            {
                return this._TableLayoutPanel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TableLayoutPanel = value;
            }
        }

        internal PictureBox LogoPictureBox
        {
            get
            {
                return this._LogoPictureBox;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._LogoPictureBox = value;
            }
        }

        internal Label LabelProductName
        {
            get
            {
                return this._LabelProductName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._LabelProductName = value;
            }
        }

        internal Label LabelVersion
        {
            get
            {
                return this._LabelVersion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._LabelVersion = value;
            }
        }

        internal Label LabelCompanyName
        {
            get
            {
                return this._LabelCompanyName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._LabelCompanyName = value;
            }
        }

        internal TextBox TextBoxDescription
        {
            get
            {
                return this._TextBoxDescription;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBoxDescription = value;
            }
        }

        internal Button OKButton
        {
            get
            {
                return this._OKButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OKButton != null)
                {
                    this._OKButton.Click -= new EventHandler(this.OKButton_Click);
                }
                this._OKButton = value;
                if (this._OKButton != null)
                {
                    this._OKButton.Click += new EventHandler(this.OKButton_Click);
                }
            }
        }

        internal Label LabelCopyright
        {
            get
            {
                return this._LabelCopyright;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._LabelCopyright = value;
            }
        }
    }
}

