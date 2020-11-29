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
    Public Class GenerateCodeForm
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.GenerateCodeForm_Load)
            Me.initializing = True
            Me.InitializeComponent
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.radVisualBasic.Checked Then
                Me.Options.Language = LanguageOption.VisualBasic
            Else
                Me.Options.Language = LanguageOption.VisualCsharp
            End If
            Me.Options.VerbatimStrings = Me.chkVerbatimStrings.Checked
            Me.Options.InstanceMethods = Me.chkInstanceMethods.Checked
            Me.Options.AssumeImports = Me.chkAssumeImports.Checked
            Me.Options.GenerateLoop = Me.chkGenerateLoops.Checked
            Me.Options.IncludeComment = Me.chkDescriptionAsComment.Checked
            Me.Options.CopyCodeOnExit = Me.chkCopyToClipboard.Checked
            If Me.Options.CopyCodeOnExit Then
                Clipboard.SetText(Me.txtCode.Text)
            End If
            Me.DialogResult = DialogResult.OK
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub GenerateCodeForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
            If (Me.Options.Language = LanguageOption.VisualBasic) Then
                Me.radVisualBasic.Checked = True
            Else
                Me.radVisualCSharp.Checked = True
            End If
            Me.chkVerbatimStrings.Checked = Me.Options.VerbatimStrings
            Me.chkInstanceMethods.Checked = Me.Options.InstanceMethods
            Me.chkAssumeImports.Checked = Me.Options.AssumeImports
            Me.chkGenerateLoops.Checked = Me.Options.GenerateLoop
            Me.chkDescriptionAsComment.Checked = Me.Options.IncludeComment
            Me.chkCopyToClipboard.Checked = Me.Options.CopyCodeOnExit
            Me.chkGenerateLoops.Enabled = (Me.Options.Command <> Command.Replace)
            Me.chkDescriptionAsComment.Enabled = (Me.Options.RegexDescription.Length > 0)
            Me.initializing = False
            Me.RefreshCode
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.radVisualBasic = New RadioButton
            Me.GroupBox1 = New GroupBox
            Me.chkVerbatimStrings = New CheckBox
            Me.radVisualCSharp = New RadioButton
            Me.GroupBox2 = New GroupBox
            Me.chkDescriptionAsComment = New CheckBox
            Me.chkGenerateLoops = New CheckBox
            Me.chkAssumeImports = New CheckBox
            Me.chkInstanceMethods = New CheckBox
            Me.txtCode = New TextBox
            Me.btnCancel = New Button
            Me.btnOK = New Button
            Me.chkCopyToClipboard = New CheckBox
            Me.HelpProvider1 = New HelpProvider
            Me.ToolTip1 = New ToolTip(Me.components)
            Me.GroupBox1.SuspendLayout
            Me.GroupBox2.SuspendLayout
            Me.SuspendLayout
            Me.radVisualBasic.AutoSize = True
            Dim point As New Point(&H12, &H15)
            Me.radVisualBasic.Location = point
            Me.radVisualBasic.Name = "radVisualBasic"
            Dim size As New Size(&H52, &H11)
            Me.radVisualBasic.Size = size
            Me.radVisualBasic.TabIndex = 0
            Me.radVisualBasic.TabStop = True
            Me.radVisualBasic.Text = "Visual &Basic"
            Me.ToolTip1.SetToolTip(Me.radVisualBasic, "Generate Visual Basic code")
            Me.radVisualBasic.UseVisualStyleBackColor = True
            Me.GroupBox1.Controls.Add(Me.chkVerbatimStrings)
            Me.GroupBox1.Controls.Add(Me.radVisualCSharp)
            Me.GroupBox1.Controls.Add(Me.radVisualBasic)
            point = New Point(12, 12)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(230, &H7A)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Language"
            Me.chkVerbatimStrings.AutoSize = True
            point = New Point(40, &H4B)
            Me.chkVerbatimStrings.Location = point
            Me.chkVerbatimStrings.Name = "chkVerbatimStrings"
            size = New Size(120, &H11)
            Me.chkVerbatimStrings.Size = size
            Me.chkVerbatimStrings.TabIndex = 2
            Me.chkVerbatimStrings.Text = "&Verbatim (@) strings"
            Me.ToolTip1.SetToolTip(Me.chkVerbatimStrings, "If selected, generated code uses @ C# strings.")
            Me.chkVerbatimStrings.UseVisualStyleBackColor = True
            Me.radVisualCSharp.AutoSize = True
            point = New Point(&H12, &H30)
            Me.radVisualCSharp.Location = point
            Me.radVisualCSharp.Name = "radVisualCSharp"
            size = New Size(70, &H11)
            Me.radVisualCSharp.Size = size
            Me.radVisualCSharp.TabIndex = 1
            Me.radVisualCSharp.TabStop = True
            Me.radVisualCSharp.Text = "Visual &C#"
            Me.ToolTip1.SetToolTip(Me.radVisualCSharp, "Generate C# code")
            Me.radVisualCSharp.UseVisualStyleBackColor = True
            Me.GroupBox2.Controls.Add(Me.chkDescriptionAsComment)
            Me.GroupBox2.Controls.Add(Me.chkGenerateLoops)
            Me.GroupBox2.Controls.Add(Me.chkAssumeImports)
            Me.GroupBox2.Controls.Add(Me.chkInstanceMethods)
            point = New Point(&H103, 13)
            Me.GroupBox2.Location = point
            Me.GroupBox2.Name = "GroupBox2"
            size = New Size(230, &H79)
            Me.GroupBox2.Size = size
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Options"
            Me.chkDescriptionAsComment.AutoSize = True
            point = New Point(&H10, &H62)
            Me.chkDescriptionAsComment.Location = point
            Me.chkDescriptionAsComment.Name = "chkDescriptionAsComment"
            size = New Size(&H8B, &H11)
            Me.chkDescriptionAsComment.Size = size
            Me.chkDescriptionAsComment.TabIndex = 3
            Me.chkDescriptionAsComment.Text = "&Description as comment"
            Me.ToolTip1.SetToolTip(Me.chkDescriptionAsComment, "The generated code contains a comment equal to the regex description. ?This option is disabled if the current regular expression has no description.)")
            Me.chkDescriptionAsComment.UseVisualStyleBackColor = True
            Me.chkGenerateLoops.AutoSize = True
            point = New Point(&H10, &H4A)
            Me.chkGenerateLoops.Location = point
            Me.chkGenerateLoops.Name = "chkGenerateLoops"
            size = New Size(&H5D, &H11)
            Me.chkGenerateLoops.Size = size
            Me.chkGenerateLoops.TabIndex = 2
            Me.chkGenerateLoops.Text = "&Generate loop"
            Me.ToolTip1.SetToolTip(Me.chkGenerateLoops, "The generate code contains a loop that visits all matches or split lines. ?This option is disabled if the current command is Replace.)")
            Me.chkGenerateLoops.UseVisualStyleBackColor = True
            Me.chkAssumeImports.AutoSize = True
            point = New Point(&H10, &H30)
            Me.chkAssumeImports.Location = point
            Me.chkAssumeImports.Name = "chkAssumeImports"
            size = New Size(130, &H11)
            Me.chkAssumeImports.Size = size
            Me.chkAssumeImports.TabIndex = 1
            Me.chkAssumeImports.Text = "&Assume Imports/using"
            Me.ToolTip1.SetToolTip(Me.chkAssumeImports, "Assume that the System.Text.RegularExpressions namespace as been imported in current source file.")
            Me.chkAssumeImports.UseVisualStyleBackColor = True
            Me.chkInstanceMethods.AutoSize = True
            point = New Point(&H10, 20)
            Me.chkInstanceMethods.Location = point
            Me.chkInstanceMethods.Name = "chkInstanceMethods"
            size = New Size(&H69, &H11)
            Me.chkInstanceMethods.Size = size
            Me.chkInstanceMethods.TabIndex = 0
            Me.chkInstanceMethods.Text = "&Instance method"
            Me.ToolTip1.SetToolTip(Me.chkInstanceMethods, "If selected the generated code uses the Find, Replace, or Split instance method. therwise generate code that uses the static version of these methods.")
            Me.chkInstanceMethods.UseVisualStyleBackColor = True
            point = New Point(12, &H94)
            Me.txtCode.Location = point
            Me.txtCode.Multiline = True
            Me.txtCode.Name = "txtCode"
            size = New Size(&H1DE, &H65)
            Me.txtCode.Size = size
            Me.txtCode.TabIndex = 2
            Me.ToolTip1.SetToolTip(Me.txtCode, "The generated source code.")
            Me.btnCancel.DialogResult = DialogResult.Cancel
            point = New Point(&H1AA, &HFF)
            Me.btnCancel.Location = point
            Me.btnCancel.Name = "btnCancel"
            size = New Size(&H40, &H17)
            Me.btnCancel.Size = size
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without copying the generated code to the Clipboard.")
            Me.btnCancel.UseVisualStyleBackColor = True
            Me.btnOK.DialogResult = DialogResult.OK
            point = New Point(&H162, &HFF)
            Me.btnOK.Location = point
            Me.btnOK.Name = "btnOK"
            size = New Size(&H40, &H17)
            Me.btnOK.Size = size
            Me.btnOK.TabIndex = 4
            Me.btnOK.Text = "OK"
            Me.ToolTip1.SetToolTip(Me.btnOK, "Close the dialog box and optionally copy the generated code to the Clipboard.")
            Me.btnOK.UseVisualStyleBackColor = True
            Me.chkCopyToClipboard.AutoSize = True
            point = New Point(12, &H103)
            Me.chkCopyToClipboard.Location = point
            Me.chkCopyToClipboard.Name = "chkCopyToClipboard"
            size = New Size(&HA9, &H11)
            Me.chkCopyToClipboard.Size = size
            Me.chkCopyToClipboard.TabIndex = 3
            Me.chkCopyToClipboard.Text = "C&opy code to clipboard on exit"
            Me.ToolTip1.SetToolTip(Me.chkCopyToClipboard, "If enabled, generated code is copied to the Clipboard hen the user clicks on the OK button.")
            Me.chkCopyToClipboard.UseVisualStyleBackColor = True
            Me.AcceptButton = Me.btnOK
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            size = New Size(&H1F3, &H11C)
            Me.ClientSize = size
            Me.Controls.Add(Me.chkCopyToClipboard)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GenerateCodeForm"
            Me.Text = "Generate Code"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub radVisualCSharp_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.RefreshCode
        End Sub

        Public Sub RefreshCode()
            Me.chkVerbatimStrings.Enabled = Me.radVisualCSharp.Checked
            If Me.initializing Then
                Return
            End If
            Dim regexText As String = Me.Options.RegexText
            Dim str7 As String = "re"
            Dim str6 As String = """text"""
            Dim str3 As String = ""
            If Not Me.chkAssumeImports.Checked Then
                str3 = "System.Text.RegularExpressions."
            End If
            Dim str2 As String = "//"
            Dim format As String = ""
            If ((Me.Options.RegexOptions And RegexOptions.IgnoreCase) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.IgnoreCase")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.IgnorePatternWhitespace) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.IgnorePatternWhitespace")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.Multiline) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.Multiline")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.Singleline) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.Singleline")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.Compiled) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.Compiled")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.ExplicitCapture) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.ExplicitCapture")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.RightToLeft) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.RightToLeft")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.CultureInvariant) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.CultureInvariant")
            End If
            If ((Me.Options.RegexOptions And RegexOptions.ECMAScript) > RegexOptions.None) Then
                format = (format & " | {0}RegexOptions.ECMAScript")
            End If
            If (format.Length = 0) Then
                format = "{0}RegexOptions.None"
            Else
                format = format.Substring(3)
            End If
            format = String.Format(format, str3)
            Dim str As String = Nothing
            If Not Me.radVisualBasic.Checked Then
                If Me.chkVerbatimStrings.Checked Then
                    regexText = ("@""" & regexText.Replace("""", """""") & """")
                Else
                    regexText = ("""" & regexText.Replace("\", "\\").Replace("""", "\""") & """")
                End If
                If Me.chkInstanceMethods.Checked Then
                    str = "{2}Regex {1} = new {2}Regex({3}, {4});{0}"
                End If
                Select Case Me.Options.Command
                    Case Command.Find
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "{2}MatchCollection mc = {2}Regex.Matches({5}, {3}, {4});{0}"
                        Else
                            str = (str & "{2}MatchCollection mc = re.Matches({5});{0}")
                        End If
                        If Me.chkGenerateLoops.Checked Then
                            str = (str & "foreach ({2}Match ma in mc){0}{{{0}}}{0}")
                        End If
                        Exit Select
                    Case Command.Replace
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "string result = {2}Regex.Replace({5}, {3}, {4});{0}"
                            Exit Select
                        End If
                        str = (str & "string result = {1}.Replace({5});{0}")
                        Exit Select
                    Case Command.Split
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "string[] lines = {2}Regex.Split({5}, {3}, {4});{0}"
                        Else
                            str = (str & "string[] lines= re.Split({5});{0}")
                        End If
                        If Me.chkGenerateLoops.Checked Then
                            str = (str & "foreach (string line in lines){0}{{{0}}}{0}")
                        End If
                        Exit Select
                End Select
            Else
                regexText = ("""" & regexText.Replace("""", """""") & """")
                format = format.Replace("|", "Or")
                str2 = "'"
                If Me.chkInstanceMethods.Checked Then
                    str = "Dim {1} As New {2}Regex({3}, {4}){0}"
                End If
                Select Case Me.Options.Command
                    Case Command.Find
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "Dim mc As {2}MatchCollection = {2}Regex.Matches({5}, {3}, {4}){0}"
                            Exit Select
                        End If
                        str = (str & "Dim mc As {2}MatchCollection = re.Matches({5}){0}")
                        Exit Select
                    Case Command.Replace
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "Dim result As String = {2}Regex.Replace({5}, {3}, {4}){0}"
                        Else
                            str = (str & "Dim result As String = {1}.Replace({5}){0}")
                        End If
                        goto Label_03FD
                    Case Command.Split
                        If Not Me.chkInstanceMethods.Checked Then
                            str = "Dim lines() as String = {2}Regex.Split({5}, {3}, {4}){0}"
                        Else
                            str = (str & "Dim lines() As String = re.Split({5}){0}")
                        End If
                        If Me.chkGenerateLoops.Checked Then
                            str = (str & "For Each line As String In lines{0}{0}Next{0}")
                        End If
                        goto Label_03FD
                    Case Else
                        goto Label_03FD
                End Select
                If Me.chkGenerateLoops.Checked Then
                    str = (str & "For Each ma As {2}Match in mc{0}{0}Next{0}")
                End If
            End If
        Label_03FD:
            If (Me.chkDescriptionAsComment.Checked AndAlso (Me.Options.RegexDescription.Length > 0)) Then
                Dim str8 As String = ""
                Dim str9 As String
                For Each str9 In Me.Options.RegexDescription.Split(New String() { ChrW(13) & ChrW(10) }, StringSplitOptions.RemoveEmptyEntries)
                    str8 = String.Concat(New String() { str8, str2, " ", str9, ChrW(13) & ChrW(10) })
                Next
                str = (str8 & str)
            End If
            str = String.Format(str, New Object() { ChrW(13) & ChrW(10), str7, str3, regexText, format, str6 })
            Me.txtCode.Text = str
        End Sub


        ' Properties
        Friend Overridable Property radVisualBasic As RadioButton
            Get
                Return Me._radVisualBasic
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RadioButton)
                If (Not Me._radVisualBasic Is Nothing) Then
                    RemoveHandler Me._radVisualBasic.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._radVisualBasic = WithEventsValue
                If (Not Me._radVisualBasic Is Nothing) Then
                    AddHandler Me._radVisualBasic.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property GroupBox1 As GroupBox
            Get
                Return Me._GroupBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkVerbatimStrings As CheckBox
            Get
                Return Me._chkVerbatimStrings
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                If (Not Me._chkVerbatimStrings Is Nothing) Then
                    RemoveHandler Me._chkVerbatimStrings.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._chkVerbatimStrings = WithEventsValue
                If (Not Me._chkVerbatimStrings Is Nothing) Then
                    AddHandler Me._chkVerbatimStrings.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property radVisualCSharp As RadioButton
            Get
                Return Me._radVisualCSharp
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RadioButton)
                If (Not Me._radVisualCSharp Is Nothing) Then
                    RemoveHandler Me._radVisualCSharp.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._radVisualCSharp = WithEventsValue
                If (Not Me._radVisualCSharp Is Nothing) Then
                    AddHandler Me._radVisualCSharp.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
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

        Friend Overridable Property chkGenerateLoops As CheckBox
            Get
                Return Me._chkGenerateLoops
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                If (Not Me._chkGenerateLoops Is Nothing) Then
                    RemoveHandler Me._chkGenerateLoops.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._chkGenerateLoops = WithEventsValue
                If (Not Me._chkGenerateLoops Is Nothing) Then
                    AddHandler Me._chkGenerateLoops.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property chkAssumeImports As CheckBox
            Get
                Return Me._chkAssumeImports
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                If (Not Me._chkAssumeImports Is Nothing) Then
                    RemoveHandler Me._chkAssumeImports.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._chkAssumeImports = WithEventsValue
                If (Not Me._chkAssumeImports Is Nothing) Then
                    AddHandler Me._chkAssumeImports.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property chkInstanceMethods As CheckBox
            Get
                Return Me._chkInstanceMethods
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                If (Not Me._chkInstanceMethods Is Nothing) Then
                    RemoveHandler Me._chkInstanceMethods.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._chkInstanceMethods = WithEventsValue
                If (Not Me._chkInstanceMethods Is Nothing) Then
                    AddHandler Me._chkInstanceMethods.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property txtCode As TextBox
            Get
                Return Me._txtCode
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtCode = WithEventsValue
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

        Friend Overridable Property chkCopyToClipboard As CheckBox
            Get
                Return Me._chkCopyToClipboard
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                Me._chkCopyToClipboard = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkDescriptionAsComment As CheckBox
            Get
                Return Me._chkDescriptionAsComment
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As CheckBox)
                If (Not Me._chkDescriptionAsComment Is Nothing) Then
                    RemoveHandler Me._chkDescriptionAsComment.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
                Me._chkDescriptionAsComment = WithEventsValue
                If (Not Me._chkDescriptionAsComment Is Nothing) Then
                    AddHandler Me._chkDescriptionAsComment.CheckedChanged, New EventHandler(AddressOf Me.radVisualCSharp_CheckedChanged)
                End If
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

        Friend Overridable Property ToolTip1 As ToolTip
            Get
                Return Me._ToolTip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolTip)
                Me._ToolTip1 = WithEventsValue
            End Set
        End Property


        ' Fields
        Private components As IContainer
        <AccessedThroughProperty("radVisualBasic")> _
        Private _radVisualBasic As RadioButton
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("chkVerbatimStrings")> _
        Private _chkVerbatimStrings As CheckBox
        <AccessedThroughProperty("radVisualCSharp")> _
        Private _radVisualCSharp As RadioButton
        <AccessedThroughProperty("GroupBox2")> _
        Private _GroupBox2 As GroupBox
        <AccessedThroughProperty("chkGenerateLoops")> _
        Private _chkGenerateLoops As CheckBox
        <AccessedThroughProperty("chkAssumeImports")> _
        Private _chkAssumeImports As CheckBox
        <AccessedThroughProperty("chkInstanceMethods")> _
        Private _chkInstanceMethods As CheckBox
        <AccessedThroughProperty("txtCode")> _
        Private _txtCode As TextBox
        <AccessedThroughProperty("btnCancel")> _
        Private _btnCancel As Button
        <AccessedThroughProperty("btnOK")> _
        Private _btnOK As Button
        <AccessedThroughProperty("chkCopyToClipboard")> _
        Private _chkCopyToClipboard As CheckBox
        <AccessedThroughProperty("chkDescriptionAsComment")> _
        Private _chkDescriptionAsComment As CheckBox
        <AccessedThroughProperty("HelpProvider1")> _
        Private _HelpProvider1 As HelpProvider
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        Public Options As ProjectOptions
        Private initializing As Boolean
    End Class
End Namespace

