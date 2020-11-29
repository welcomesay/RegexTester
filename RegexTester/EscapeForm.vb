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
    Public Class EscapeForm
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.EscapeForm_Load)
            Me.InitializeComponent
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.chkCopyToClipboard.Checked AndAlso (Me.txtResult.TextLength > 0)) Then
                Clipboard.SetText(Me.txtResult.Text)
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

        Private Sub EscapeForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
            Me.txtText.Text = Me.Options.RegexText
            Me.lblError.Text = ""
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.Label1 = New Label
            Me.txtText = New TextBox
            Me.radEscape = New RadioButton
            Me.radUnescape = New RadioButton
            Me.Label2 = New Label
            Me.txtResult = New TextBox
            Me.chkCopyToClipboard = New CheckBox
            Me.btnOK = New Button
            Me.btnCancel = New Button
            Me.lblError = New Label
            Me.ToolTip1 = New ToolTip(Me.components)
            Me.HelpProvider1 = New HelpProvider
            Me.SuspendLayout
            Dim point As New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            Dim size As New Size(&H25, &H17)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "&Text"
            point = New Point(&H37, 9)
            Me.txtText.Location = point
            Me.txtText.Multiline = True
            Me.txtText.Name = "txtText"
            Me.txtText.ScrollBars = ScrollBars.Vertical
            size = New Size(&H228, &H61)
            Me.txtText.Size = size
            Me.txtText.TabIndex = 1
            Me.txtText.Text = "Enter a string that you want to escape or unescape."
            Me.radEscape.AutoSize = True
            Me.radEscape.Checked = True
            point = New Point(&H37, &H70)
            Me.radEscape.Location = point
            Me.radEscape.Name = "radEscape"
            size = New Size(&H3D, &H11)
            Me.radEscape.Size = size
            Me.radEscape.TabIndex = 2
            Me.radEscape.TabStop = True
            Me.radEscape.Text = "&Escape"
            Me.ToolTip1.SetToolTip(Me.radEscape, "Test the Escape command.")
            Me.radEscape.UseVisualStyleBackColor = True
            Me.radUnescape.AutoSize = True
            point = New Point(&H7A, &H70)
            Me.radUnescape.Location = point
            Me.radUnescape.Name = "radUnescape"
            size = New Size(&H4A, &H11)
            Me.radUnescape.Size = size
            Me.radUnescape.TabIndex = 3
            Me.radUnescape.Text = "&Unescape"
            Me.ToolTip1.SetToolTip(Me.radUnescape, "Test the Unescape command.")
            Me.radUnescape.UseVisualStyleBackColor = True
            point = New Point(12, &H89)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H25, &H17)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "&Result"
            point = New Point(&H37, &H89)
            Me.txtResult.Location = point
            Me.txtResult.Multiline = True
            Me.txtResult.Name = "txtResult"
            Me.txtResult.ReadOnly = True
            Me.txtResult.ScrollBars = ScrollBars.Vertical
            size = New Size(&H228, &H5E)
            Me.txtResult.Size = size
            Me.txtResult.TabIndex = 6
            Me.txtResult.Text = "The result of the Escape or Unescape method."
            Me.chkCopyToClipboard.AutoSize = True
            Me.chkCopyToClipboard.Checked = True
            Me.chkCopyToClipboard.CheckState = CheckState.Checked
            point = New Point(&H1D7, &H72)
            Me.chkCopyToClipboard.Location = point
            Me.chkCopyToClipboard.Name = "chkCopyToClipboard"
            size = New Size(&H89, &H11)
            Me.chkCopyToClipboard.Size = size
            Me.chkCopyToClipboard.TabIndex = 4
            Me.chkCopyToClipboard.Text = "C&opy result to Clipboard"
            Me.ToolTip1.SetToolTip(Me.chkCopyToClipboard, "If selected, the result is copied to the Clipboard hen the user clicks on the OK button.")
            Me.chkCopyToClipboard.UseVisualStyleBackColor = True
            Me.btnOK.DialogResult = DialogResult.OK
            point = New Point(&H1C3, &HED)
            Me.btnOK.Location = point
            Me.btnOK.Name = "btnOK"
            size = New Size(&H4B, &H17)
            Me.btnOK.Size = size
            Me.btnOK.TabIndex = 8
            Me.btnOK.Text = "OK"
            Me.ToolTip1.SetToolTip(Me.btnOK, "Close the dialog box and optionally copy the result to the Clipboard.")
            Me.btnOK.UseVisualStyleBackColor = True
            Me.btnCancel.DialogResult = DialogResult.Cancel
            point = New Point(&H214, &HED)
            Me.btnCancel.Location = point
            Me.btnCancel.Name = "btnCancel"
            size = New Size(&H4B, &H17)
            Me.btnCancel.Size = size
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without copying the result to the Clipboard.")
            Me.btnCancel.UseVisualStyleBackColor = True
            Me.lblError.AutoSize = True
            Me.lblError.ForeColor = Color.Red
            point = New Point(&H34, &HED)
            Me.lblError.Location = point
            Me.lblError.Name = "lblError"
            size = New Size(&H27, 13)
            Me.lblError.Size = size
            Me.lblError.TabIndex = 7
            Me.lblError.Text = "lblError"
            Me.AcceptButton = Me.btnOK
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            size = New Size(&H26B, 270)
            Me.ClientSize = size
            Me.Controls.Add(Me.lblError)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.chkCopyToClipboard)
            Me.Controls.Add(Me.txtResult)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.radUnescape)
            Me.Controls.Add(Me.radEscape)
            Me.Controls.Add(Me.txtText)
            Me.Controls.Add(Me.Label1)
            Me.Name = "EscapeForm"
            Me.Text = "Escape Command"
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub radUnescape_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.txtText.Text = ""
        End Sub

        Private Sub txtText_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                If Me.radEscape.Checked Then
                    Me.txtResult.Text = Regex.Escape(Me.txtText.Text)
                Else
                    Me.txtResult.Text = Regex.Unescape(Me.txtText.Text)
                End If
                Me.lblError.Text = ""
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Me.lblError.Text = exception.Message
                ProjectData.ClearProjectError
            End Try
        End Sub


        ' Properties
        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtText As TextBox
            Get
                Return Me._txtText
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                If (Not Me._txtText Is Nothing) Then
                    RemoveHandler Me._txtText.TextChanged, New EventHandler(AddressOf Me.txtText_TextChanged)
                End If
                Me._txtText = WithEventsValue
                If (Not Me._txtText Is Nothing) Then
                    AddHandler Me._txtText.TextChanged, New EventHandler(AddressOf Me.txtText_TextChanged)
                End If
            End Set
        End Property

        Friend Overridable Property radEscape As RadioButton
            Get
                Return Me._radEscape
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RadioButton)
                If (Not Me._radEscape Is Nothing) Then
                    RemoveHandler Me._radEscape.CheckedChanged, New EventHandler(AddressOf Me.radUnescape_CheckedChanged)
                End If
                Me._radEscape = WithEventsValue
                If (Not Me._radEscape Is Nothing) Then
                    AddHandler Me._radEscape.CheckedChanged, New EventHandler(AddressOf Me.radUnescape_CheckedChanged)
                End If
            End Set
        End Property

        Friend Overridable Property radUnescape As RadioButton
            Get
                Return Me._radUnescape
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RadioButton)
                If (Not Me._radUnescape Is Nothing) Then
                    RemoveHandler Me._radUnescape.CheckedChanged, New EventHandler(AddressOf Me.radUnescape_CheckedChanged)
                End If
                Me._radUnescape = WithEventsValue
                If (Not Me._radUnescape Is Nothing) Then
                    AddHandler Me._radUnescape.CheckedChanged, New EventHandler(AddressOf Me.radUnescape_CheckedChanged)
                End If
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

        Friend Overridable Property txtResult As TextBox
            Get
                Return Me._txtResult
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtResult = WithEventsValue
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

        Friend Overridable Property lblError As Label
            Get
                Return Me._lblError
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblError = WithEventsValue
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
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("txtText")> _
        Private _txtText As TextBox
        <AccessedThroughProperty("radEscape")> _
        Private _radEscape As RadioButton
        <AccessedThroughProperty("radUnescape")> _
        Private _radUnescape As RadioButton
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("txtResult")> _
        Private _txtResult As TextBox
        <AccessedThroughProperty("chkCopyToClipboard")> _
        Private _chkCopyToClipboard As CheckBox
        <AccessedThroughProperty("btnOK")> _
        Private _btnOK As Button
        <AccessedThroughProperty("btnCancel")> _
        Private _btnCancel As Button
        <AccessedThroughProperty("lblError")> _
        Private _lblError As Label
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        <AccessedThroughProperty("HelpProvider1")> _
        Private _HelpProvider1 As HelpProvider
        Public Options As ProjectOptions
    End Class
End Namespace

