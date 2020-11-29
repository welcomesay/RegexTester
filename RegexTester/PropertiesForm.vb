Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace RegexTester
    <DesignerGenerated> _
    Public Class PropertiesForm
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.PropertiesForm_Load)
            Me.InitializeComponent
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexName = Me.txtName.Text
            Me.Options.RegexDescription = Me.txtDescription.Text
            Me.SetRegexOption(RegexOptions.IgnoreCase, Me.chkIgnoreCase.Checked)
            Me.SetRegexOption(RegexOptions.IgnorePatternWhitespace, Me.chkIgnoreWhitespace.Checked)
            Me.SetRegexOption(RegexOptions.Multiline, Me.chkMultiline.Checked)
            Me.SetRegexOption(RegexOptions.Compiled, Me.chkCompiled.Checked)
            Me.SetRegexOption(RegexOptions.ExplicitCapture, Me.chkExplicitCapture.Checked)
            Me.SetRegexOption(RegexOptions.RightToLeft, Me.chkRightToLeft.Checked)
            Me.SetRegexOption(RegexOptions.CultureInvariant, Me.chkCultureInvariant.Checked)
            Me.SetRegexOption(RegexOptions.ECMAScript, Me.chkEcmaScript.Checked)
            Me.Options.MaxMatches = Convert.ToInt32(Me.numMatches.Value)
            Me.Options.WordWrap = Me.chkWordWrap.Checked
            Me.Options.Format = DirectCast(Me.cboFormat.SelectedIndex, FormatOption)
            Me.Options.Detail = DirectCast(Me.cboDetails.SelectedIndex, DetailOption)
            Me.Options.Sort = DirectCast(Me.cboSort.SelectedIndex, SortOption)
            Me.Options.IncludeEmptyGroups = Me.chkIncludeEmptyGroups.Checked
            Me.DialogResult = DialogResult.OK
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose
            End If
            MyBase.Dispose(disposing)
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.GroupBox1 = New GroupBox
            Me.chkEcmaScript = New CheckBox
            Me.chkCultureInvariant = New CheckBox
            Me.chkRightToLeft = New CheckBox
            Me.chkExplicitCapture = New CheckBox
            Me.chkCompiled = New CheckBox
            Me.chkMultiline = New CheckBox
            Me.chkIgnoreWhitespace = New CheckBox
            Me.chkIgnoreCase = New CheckBox
            Me.Label3 = New Label
            Me.txtDescription = New TextBox
            Me.Label2 = New Label
            Me.txtName = New TextBox
            Me.Label1 = New Label
            Me.GroupBox2 = New GroupBox
            Me.chkIncludeEmptyGroups = New CheckBox
            Me.numMatches = New NumericUpDown
            Me.Label7 = New Label
            Me.cboDetails = New ComboBox
            Me.Label6 = New Label
            Me.cboSort = New ComboBox
            Me.Label5 = New Label
            Me.cboFormat = New ComboBox
            Me.Label4 = New Label
            Me.chkWordWrap = New CheckBox
            Me.btnOK = New Button
            Me.btnCancel = New Button
            Me.GroupBox3 = New GroupBox
            Me.ToolTip1 = New ToolTip(Me.components)
            Me.HelpProvider1 = New HelpProvider
            Me.GroupBox1.SuspendLayout
            Me.GroupBox2.SuspendLayout
            Me.numMatches.BeginInit
            Me.GroupBox3.SuspendLayout
            Me.SuspendLayout
            Me.GroupBox1.Controls.Add(Me.chkEcmaScript)
            Me.GroupBox1.Controls.Add(Me.chkCultureInvariant)
            Me.GroupBox1.Controls.Add(Me.chkRightToLeft)
            Me.GroupBox1.Controls.Add(Me.chkExplicitCapture)
            Me.GroupBox1.Controls.Add(Me.chkCompiled)
            Me.GroupBox1.Controls.Add(Me.chkMultiline)
            Me.GroupBox1.Controls.Add(Me.chkIgnoreWhitespace)
            Me.GroupBox1.Controls.Add(Me.chkIgnoreCase)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.txtDescription)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.txtName)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Dim point As New Point(12, 12)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            Dim size As New Size(&H268, &HB6)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Regex"
            Me.chkEcmaScript.AutoSize = True
            point = New Point(460, 150)
            Me.chkEcmaScript.Location = point
            Me.chkEcmaScript.Name = "chkEcmaScript"
            size = New Size(&H53, &H11)
            Me.chkEcmaScript.Size = size
            Me.chkEcmaScript.TabIndex = 12
            Me.chkEcmaScript.Text = "ECM&AScript"
            Me.ToolTip1.SetToolTip(Me.chkEcmaScript, "Enables ECMAScript-compliant behavior. his flag can be used only in conjunction with the IgnoreCase, Multiline, and Compiled flags. ")
            Me.chkEcmaScript.UseVisualStyleBackColor = True
            Me.chkCultureInvariant.AutoSize = True
            point = New Point(460, &H7F)
            Me.chkCultureInvariant.Location = point
            Me.chkCultureInvariant.Name = "chkCultureInvariant"
            size = New Size(&H66, &H11)
            Me.chkCultureInvariant.Size = size
            Me.chkCultureInvariant.TabIndex = 11
            Me.chkCultureInvariant.Text = "C&ulture invariant"
            Me.ToolTip1.SetToolTip(Me.chkCultureInvariant, "Uses the culture implied by CultureInfo.InvariantCulture, instead of he locale assigned to the current thread.")
            Me.chkCultureInvariant.UseVisualStyleBackColor = True
            Me.chkRightToLeft.AutoSize = True
            point = New Point(310, &H97)
            Me.chkRightToLeft.Location = point
            Me.chkRightToLeft.Name = "chkRightToLeft"
            size = New Size(80, &H11)
            Me.chkRightToLeft.Size = size
            Me.chkRightToLeft.TabIndex = 10
            Me.chkRightToLeft.Text = "&Right to left"
            Me.ToolTip1.SetToolTip(Me.chkRightToLeft, "Specifies that the search is from right to left nstead of from left to right. If a starting index is specified, t should point to the end of the string. ")
            Me.chkRightToLeft.UseVisualStyleBackColor = True
            Me.chkExplicitCapture.AutoSize = True
            point = New Point(310, &H80)
            Me.chkExplicitCapture.Location = point
            Me.chkExplicitCapture.Name = "chkExplicitCapture"
            size = New Size(&H62, &H11)
            Me.chkExplicitCapture.Size = size
            Me.chkExplicitCapture.TabIndex = 9
            Me.chkExplicitCapture.Text = "&Explicit capture"
            Me.ToolTip1.SetToolTip(Me.chkExplicitCapture, "Captures only explicitly named or numbered groups f the form (?<name>) so that naked parentheses act as noncapturing roups without your having to use the (?:) construct.")
            Me.chkExplicitCapture.UseVisualStyleBackColor = True
            Me.chkCompiled.AutoSize = True
            point = New Point(&HCE, &H97)
            Me.chkCompiled.Location = point
            Me.chkCompiled.Name = "chkCompiled"
            size = New Size(&H45, &H11)
            Me.chkCompiled.Size = size
            Me.chkCompiled.TabIndex = 8
            Me.chkCompiled.Text = "&Compiled"
            Me.ToolTip1.SetToolTip(Me.chkCompiled, "Compiles the regular expression and generates MSIL code; his option generates faster code at the expense of longer start-up time.")
            Me.chkCompiled.UseVisualStyleBackColor = True
            Me.chkMultiline.AutoSize = True
            point = New Point(&HCE, &H7F)
            Me.chkMultiline.Location = point
            Me.chkMultiline.Name = "chkMultiline"
            size = New Size(&H40, &H11)
            Me.chkMultiline.Size = size
            Me.chkMultiline.TabIndex = 7
            Me.chkMultiline.Text = "&Multiline"
            Me.ToolTip1.SetToolTip(Me.chkMultiline, "Multiline mode; changes the behavior of  and $ so that they match the beginning and end of individual lines, respectively, nstead of the whole string.")
            Me.chkMultiline.UseVisualStyleBackColor = True
            Me.chkIgnoreWhitespace.AutoSize = True
            point = New Point(&H4B, &H97)
            Me.chkIgnoreWhitespace.Location = point
            Me.chkIgnoreWhitespace.Name = "chkIgnoreWhitespace"
            size = New Size(&H74, &H11)
            Me.chkIgnoreWhitespace.Size = size
            Me.chkIgnoreWhitespace.TabIndex = 6
            Me.chkIgnoreWhitespace.Text = "Ignore &Whitespace"
            Me.ToolTip1.SetToolTip(Me.chkIgnoreWhitespace, "Ignores unescaped white space from the pattern and nables comments marked with #. Significant spaces n the pattern must be specified as [ ] or \x20.")
            Me.chkIgnoreWhitespace.UseVisualStyleBackColor = True
            Me.chkIgnoreCase.AutoSize = True
            point = New Point(&H4B, &H80)
            Me.chkIgnoreCase.Location = point
            Me.chkIgnoreCase.Name = "chkIgnoreCase"
            size = New Size(&H53, &H11)
            Me.chkIgnoreCase.Size = size
            Me.chkIgnoreCase.TabIndex = 5
            Me.chkIgnoreCase.Text = "&Ignore Case"
            Me.ToolTip1.SetToolTip(Me.chkIgnoreCase, "Ignore case in searches")
            Me.chkIgnoreCase.UseVisualStyleBackColor = True
            Me.Label3.AutoSize = True
            point = New Point(9, &H80)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H2B, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Options"
            Me.txtDescription.AcceptsReturn = True
            point = New Point(&H4B, &H3A)
            Me.txtDescription.Location = point
            Me.txtDescription.Multiline = True
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.ScrollBars = ScrollBars.Vertical
            size = New Size(&H211, &H34)
            Me.txtDescription.Size = size
            Me.txtDescription.TabIndex = 3
            Me.ToolTip1.SetToolTip(Me.txtDescription, "The free-format description of the regular expression.an be used to generate comments in code.")
            Me.Label2.AutoSize = True
            point = New Point(9, &H3A)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(60, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "&Description"
            point = New Point(&H4A, &H19)
            Me.txtName.Location = point
            Me.txtName.Name = "txtName"
            size = New Size(530, 20)
            Me.txtName.Size = size
            Me.txtName.TabIndex = 1
            Me.ToolTip1.SetToolTip(Me.txtName, "The name of the regular expression. t is used when the expression is compiled.")
            Me.Label1.AutoSize = True
            point = New Point(9, &H1C)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H23, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "&Name"
            Me.GroupBox2.Controls.Add(Me.chkIncludeEmptyGroups)
            Me.GroupBox2.Controls.Add(Me.numMatches)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.cboDetails)
            Me.GroupBox2.Controls.Add(Me.Label6)
            Me.GroupBox2.Controls.Add(Me.cboSort)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.cboFormat)
            Me.GroupBox2.Controls.Add(Me.Label4)
            point = New Point(12, &HD4)
            Me.GroupBox2.Location = point
            Me.GroupBox2.Name = "GroupBox2"
            size = New Size(&H127, &HB1)
            Me.GroupBox2.Size = size
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Results"
            Me.chkIncludeEmptyGroups.AutoSize = True
            point = New Point(&H4B, 150)
            Me.chkIncludeEmptyGroups.Location = point
            Me.chkIncludeEmptyGroups.Name = "chkIncludeEmptyGroups"
            size = New Size(&H7F, &H11)
            Me.chkIncludeEmptyGroups.Size = size
            Me.chkIncludeEmptyGroups.TabIndex = 8
            Me.chkIncludeEmptyGroups.Text = "Include empty g&roups"
            Me.ToolTip1.SetToolTip(Me.chkIncludeEmptyGroups, "If selected, groups are included in results ven if they match an empty string.")
            Me.chkIncludeEmptyGroups.UseVisualStyleBackColor = True
            Dim num As New Decimal(New Integer() { 100, 0, 0, 0 })
            Me.numMatches.Increment = num
            point = New Point(&H4B, &H1A)
            Me.numMatches.Location = point
            num = New Decimal(New Integer() { &H2710, 0, 0, 0 })
            Me.numMatches.Maximum = num
            num = New Decimal(New Integer() { 100, 0, 0, 0 })
            Me.numMatches.Minimum = num
            Me.numMatches.Name = "numMatches"
            size = New Size(&H53, 20)
            Me.numMatches.Size = size
            Me.numMatches.TabIndex = 1
            Me.numMatches.TextAlign = HorizontalAlignment.Right
            Me.ToolTip1.SetToolTip(Me.numMatches, "Maximum number of matches that are displayed.")
            num = New Decimal(New Integer() { 100, 0, 0, 0 })
            Me.numMatches.Value = num
            point = New Point(9, &H1A)
            Me.Label7.Location = point
            Me.Label7.Name = "Label7"
            size = New Size(&H49, 30)
            Me.Label7.Size = size
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Ma&x number of matches"
            Me.cboDetails.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboDetails.FormattingEnabled = True
            Me.cboDetails.Items.AddRange(New Object() { "No details", "Groups", "Groups and Captures" })
            point = New Point(&H4B, &H7B)
            Me.cboDetails.Location = point
            Me.cboDetails.Name = "cboDetails"
            size = New Size(&HBA, &H15)
            Me.cboDetails.Size = size
            Me.cboDetails.TabIndex = 7
            Me.ToolTip1.SetToolTip(Me.cboDetails, "Whether groups and captures are displayed in results")
            Me.Label6.AutoSize = True
            point = New Point(9, &H7B)
            Me.Label6.Location = point
            Me.Label6.Name = "Label6"
            size = New Size(&H27, 13)
            Me.Label6.Size = size
            Me.Label6.TabIndex = 6
            Me.Label6.Text = "De&tails"
            Me.cboSort.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboSort.FormattingEnabled = True
            Me.cboSort.Items.AddRange(New Object() { "Sort on Position", "Sort on Name", "Shortest first", "Longest first" })
            point = New Point(&H4A, &H5D)
            Me.cboSort.Location = point
            Me.cboSort.Name = "cboSort"
            size = New Size(&HBA, &H15)
            Me.cboSort.Size = size
            Me.cboSort.TabIndex = 5
            Me.ToolTip1.SetToolTip(Me.cboSort, "How results are sorted")
            Me.Label5.AutoSize = True
            point = New Point(10, &H5D)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H1A, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "&Sort"
            Me.cboFormat.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboFormat.FormattingEnabled = True
            Me.cboFormat.Items.AddRange(New Object() { "Auto", "Treeview", "Report" })
            point = New Point(&H4A, &H3A)
            Me.cboFormat.Location = point
            Me.cboFormat.Name = "cboFormat"
            size = New Size(&HBA, &H15)
            Me.cboFormat.Size = size
            Me.cboFormat.TabIndex = 3
            Me.ToolTip1.SetToolTip(Me.cboFormat, "Sets the format used to display results. esults are displayed either in a treeview or a textbox. y default, the Find command uses the treeview, all other commands use the textbox.")
            Me.Label4.AutoSize = True
            point = New Point(9, &H3D)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H27, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "&Format"
            Me.chkWordWrap.AutoSize = True
            point = New Point(&H23, &H1D)
            Me.chkWordWrap.Location = point
            Me.chkWordWrap.Name = "chkWordWrap"
            size = New Size(&H4E, &H11)
            Me.chkWordWrap.Size = size
            Me.chkWordWrap.TabIndex = 0
            Me.chkWordWrap.Text = "&Word wrap"
            Me.ToolTip1.SetToolTip(Me.chkWordWrap, "Word-wrap mode for all textboxes in the main form.")
            Me.chkWordWrap.UseVisualStyleBackColor = True
            point = New Point(&H1D8, &H195)
            Me.btnOK.Location = point
            Me.btnOK.Name = "btnOK"
            size = New Size(&H4B, &H17)
            Me.btnOK.Size = size
            Me.btnOK.TabIndex = 3
            Me.btnOK.Text = "OK"
            Me.ToolTip1.SetToolTip(Me.btnOK, "Save all properties and close the dialog box.")
            Me.btnOK.UseVisualStyleBackColor = True
            Me.btnCancel.DialogResult = DialogResult.Cancel
            point = New Point(&H229, &H195)
            Me.btnCancel.Location = point
            Me.btnCancel.Name = "btnCancel"
            size = New Size(&H4B, &H17)
            Me.btnCancel.Size = size
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without saving.")
            Me.btnCancel.UseVisualStyleBackColor = True
            Me.GroupBox3.Controls.Add(Me.chkWordWrap)
            point = New Point(&H142, &HD4)
            Me.GroupBox3.Location = point
            Me.GroupBox3.Name = "GroupBox3"
            size = New Size(&H132, &HB1)
            Me.GroupBox3.Size = size
            Me.GroupBox3.TabIndex = 2
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Miscellaneous"
            Me.AcceptButton = Me.btnOK
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            size = New Size(&H27F, &H1B7)
            Me.ClientSize = size
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PropertiesForm"
            Me.Text = "Properties"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout
            Me.numMatches.EndInit
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout
            Me.ResumeLayout(False)
        End Sub

        Private Sub PropertiesForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
            Me.txtName.Text = Me.Options.RegexName
            Me.txtDescription.Text = Me.Options.RegexDescription
            Me.chkIgnoreCase.Checked = ((Me.Options.RegexOptions And RegexOptions.IgnoreCase) > RegexOptions.None)
            Me.chkIgnoreWhitespace.Checked = ((Me.Options.RegexOptions And RegexOptions.IgnorePatternWhitespace) > RegexOptions.None)
            Me.chkMultiline.Checked = ((Me.Options.RegexOptions And RegexOptions.Multiline) > RegexOptions.None)
            Me.chkCompiled.Checked = ((Me.Options.RegexOptions And RegexOptions.Compiled) > RegexOptions.None)
            Me.chkExplicitCapture.Checked = ((Me.Options.RegexOptions And RegexOptions.ExplicitCapture) > RegexOptions.None)
            Me.chkRightToLeft.Checked = ((Me.Options.RegexOptions And RegexOptions.RightToLeft) > RegexOptions.None)
            Me.chkCultureInvariant.Checked = ((Me.Options.RegexOptions And RegexOptions.CultureInvariant) > RegexOptions.None)
            Me.chkEcmaScript.Checked = ((Me.Options.RegexOptions And RegexOptions.ECMAScript) > RegexOptions.None)
            Me.numMatches.Value = New Decimal(Me.Options.MaxMatches)
            Me.chkWordWrap.Checked = Me.Options.WordWrap
            Me.cboFormat.SelectedIndex = CInt(Me.Options.Format)
            Me.cboDetails.SelectedIndex = CInt(Me.Options.Detail)
            Me.cboSort.SelectedIndex = CInt(Me.Options.Sort)
            Me.chkIncludeEmptyGroups.Checked = Me.Options.IncludeEmptyGroups
        End Sub

        Private Sub SetRegexOption(ByVal bitMask As RegexOptions, ByVal value As Boolean)
            If value Then
                Me.Options.RegexOptions = (Me.Options.RegexOptions Or bitMask)
            Else
                Me.Options.RegexOptions = (Me.Options.RegexOptions And Not bitMask)
            End If
        End Sub


        ' Properties
        Friend Overridable Property GroupBox1 As GroupBox
            Get
                Return Me._GroupBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkEcmaScript As CheckBox
            Get
                Return Me._chkEcmaScript
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkEcmaScript = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkCultureInvariant As CheckBox
            Get
                Return Me._chkCultureInvariant
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkCultureInvariant = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkRightToLeft As CheckBox
            Get
                Return Me._chkRightToLeft
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkRightToLeft = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkExplicitCapture As CheckBox
            Get
                Return Me._chkExplicitCapture
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkExplicitCapture = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkCompiled As CheckBox
            Get
                Return Me._chkCompiled
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkCompiled = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkMultiline As CheckBox
            Get
                Return Me._chkMultiline
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkMultiline = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkIgnoreWhitespace As CheckBox
            Get
                Return Me._chkIgnoreWhitespace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkIgnoreWhitespace = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkIgnoreCase As CheckBox
            Get
                Return Me._chkIgnoreCase
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkIgnoreCase = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label3 As Label
            Get
                Return Me._Label3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtDescription As TextBox
            Get
                Return Me._txtDescription
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtDescription = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            Get
                Return Me._Label2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtName As TextBox
            Get
                Return Me._txtName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property GroupBox2 As GroupBox
            Get
                Return Me._GroupBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboSort As ComboBox
            Get
                Return Me._cboSort
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ComboBox)
                Me._cboSort = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboFormat As ComboBox
            Get
                Return Me._cboFormat
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ComboBox)
                Me._cboFormat = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label4 As Label
            Get
                Return Me._Label4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label7 As Label
            Get
                Return Me._Label7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboDetails As ComboBox
            Get
                Return Me._cboDetails
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ComboBox)
                Me._cboDetails = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label6 As Label
            Get
                Return Me._Label6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property btnOK As Button
            Get
                Return Me._btnOK
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnOK Is Nothing) Then
                    RemoveHandler Me._btnOK.Click, New EventHandler(AddressOf Me.btnOK_Click)
                End If
                Me._btnOK = WithEventsValue
                If (Not Me._btnOK Is Nothing) Then
                    AddHandler Me._btnOK.Click, New EventHandler(AddressOf Me.btnOK_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnCancel As Button
            Get
                Return Me._btnCancel
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Me._btnCancel = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numMatches As NumericUpDown
            Get
                Return Me._numMatches
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numMatches = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkWordWrap As CheckBox
            Get
                Return Me._chkWordWrap
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkWordWrap = WithEventsValue
            End Set
        End Property

        Friend Overridable Property GroupBox3 As GroupBox
            Get
                Return Me._GroupBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkIncludeEmptyGroups As CheckBox
            Get
                Return Me._chkIncludeEmptyGroups
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkIncludeEmptyGroups = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ToolTip1 As ToolTip
            Get
                Return Me._ToolTip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolTip)
                Me._ToolTip1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property HelpProvider1 As HelpProvider
            Get
                Return Me._HelpProvider1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As HelpProvider)
                Me._HelpProvider1 = WithEventsValue
            End Set
        End Property


        ' Fields
        Private components As IContainer
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("chkEcmaScript")> _
        Private _chkEcmaScript As CheckBox
        <AccessedThroughProperty("chkCultureInvariant")> _
        Private _chkCultureInvariant As CheckBox
        <AccessedThroughProperty("chkRightToLeft")> _
        Private _chkRightToLeft As CheckBox
        <AccessedThroughProperty("chkExplicitCapture")> _
        Private _chkExplicitCapture As CheckBox
        <AccessedThroughProperty("chkCompiled")> _
        Private _chkCompiled As CheckBox
        <AccessedThroughProperty("chkMultiline")> _
        Private _chkMultiline As CheckBox
        <AccessedThroughProperty("chkIgnoreWhitespace")> _
        Private _chkIgnoreWhitespace As CheckBox
        <AccessedThroughProperty("chkIgnoreCase")> _
        Private _chkIgnoreCase As CheckBox
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("txtDescription")> _
        Private _txtDescription As TextBox
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("txtName")> _
        Private _txtName As TextBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("GroupBox2")> _
        Private _GroupBox2 As GroupBox
        <AccessedThroughProperty("cboSort")> _
        Private _cboSort As ComboBox
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("cboFormat")> _
        Private _cboFormat As ComboBox
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("cboDetails")> _
        Private _cboDetails As ComboBox
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("btnOK")> _
        Private _btnOK As Button
        <AccessedThroughProperty("btnCancel")> _
        Private _btnCancel As Button
        <AccessedThroughProperty("numMatches")> _
        Private _numMatches As NumericUpDown
        <AccessedThroughProperty("chkWordWrap")> _
        Private _chkWordWrap As CheckBox
        <AccessedThroughProperty("GroupBox3")> _
        Private _GroupBox3 As GroupBox
        <AccessedThroughProperty("chkIncludeEmptyGroups")> _
        Private _chkIncludeEmptyGroups As CheckBox
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        <AccessedThroughProperty("HelpProvider1")> _
        Private _HelpProvider1 As HelpProvider
        Public Options As ProjectOptions
    End Class
End Namespace

