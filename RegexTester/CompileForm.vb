Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace RegexTester
    <DesignerGenerated> _
    Public Class CompileForm
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.CompileForm_Load)
            Me.InitializeComponent
        End Sub

        Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.dlgAssemblyPath.ShowDialog = DialogResult.OK) Then
                Me.txtPath.Text = Me.dlgAssemblyPath.SelectedPath
            End If
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (MessageBox.Show("Do you want to remove all items?", "Remove all rows", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                CompileForm.regexList.Clear
            End If
        End Sub

        Private Sub btnCompile_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim list2 As New List(Of RegexInfo)
            If ((Me.txtAssemblyName.TextLength = 0) OrElse (Me.txtNamespace.TextLength = 0)) Then
                MessageBox.Show("Please type the name of the assembly and its root namespace", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf (Me.txtPath.TextLength = 0) Then
                MessageBox.Show("Please select the output path.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim info As RegexInfo
                For Each info In CompileForm.regexList
                    If ((info.Name <> "") OrElse (info.Pattern <> "")) Then
                        If ((info.Name = "") Or (info.Pattern = "")) Then
                            MessageBox.Show("Please enter name and pattern for all regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        list2.Add(info)
                    End If
                Next
                If (list2.Count = 0) Then
                    MessageBox.Show("Please enter one or more regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim list As New List(Of RegexCompilationInfo)
                    Dim info3 As RegexInfo
                    For Each info3 In list2
                        Dim item As New RegexCompilationInfo(info3.Pattern, info3.Options, info3.Name, Me.txtNamespace.Text, True)
                        list.Add(item)
                    Next
                    Dim regexinfos As RegexCompilationInfo() = list.ToArray
                    Dim assemblyname As New AssemblyName(Me.txtAssemblyName.Text) With { _
                        .CodeBase = Path.Combine(Me.txtPath.Text, Path.ChangeExtension(Me.txtAssemblyName.Text, ".dll")) _
                    }
                    Try 
                        Regex.CompileToAssembly(regexinfos, assemblyname)
                        MessageBox.Show("The assembly has been created", "Compilation Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim exception As Exception = exception1
                        MessageBox.Show(exception.Message, "Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        ProjectData.ClearProjectError
                    End Try
                End If
            End If
        End Sub

        Private Sub btnCurrent_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MainForm.UpdateOptionFiels
            Dim item As RegexInfo = RegexInfo.FromProjectOption(Me.MainForm.Options)
            CompileForm.regexList.Add(item)
        End Sub

        Private Sub btnFile_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.dlgOpenRegex.ShowDialog <> DialogResult.Cancel) Then
                Try 
                    Dim item As RegexInfo = RegexInfo.FromProjectOption(ProjectOptions.Load(Me.dlgOpenRegex.FileName))
                    CompileForm.regexList.Add(item)
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    MessageBox.Show(exception.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    ProjectData.ClearProjectError
                End Try
            End If
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs)
            CompileForm.regexList.Add(New RegexInfo)
        End Sub

        Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.dgrRegexes.SelectedRows.Count = 0) Then
                MessageBox.Show("Please select an entire row", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim enumerator As IEnumerator
                Try 
                    enumerator = Me.dgrRegexes.SelectedRows.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As DataGridViewRow = DirectCast(enumerator.Current, DataGridViewRow)
                        CompileForm.regexList.RemoveAt(current.Index)
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator,IDisposable).Dispose
                    End If
                End Try
            End If
        End Sub

        Private Sub CompileForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
            Me.RegexBindingSource.DataSource = CompileForm.regexList
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
            Me.btnRemove = New Button
            Me.btnCompile = New Button
            Me.txtNamespace = New TextBox
            Me.Label1 = New Label
            Me.btnCancel = New Button
            Me.dlgOpenRegex = New OpenFileDialog
            Me.dgrRegexes = New DataGridView
            Me.grdcolName = New DataGridViewTextBoxColumn
            Me.grdcolPattern = New DataGridViewTextBoxColumn
            Me.dgrcolOptions = New DataGridViewTextBoxColumn
            Me.RegexBindingSource = New BindingSource(Me.components)
            Me.btnFile = New Button
            Me.btnNew = New Button
            Me.btnClear = New Button
            Me.btnCurrent = New Button
            Me.Label2 = New Label
            Me.dlgSaveAssembly = New SaveFileDialog
            Me.txtAssemblyName = New TextBox
            Me.Label3 = New Label
            Me.dlgAssemblyPath = New FolderBrowserDialog
            Me.GroupBox1 = New GroupBox
            Me.btnBrowse = New Button
            Me.txtPath = New TextBox
            Me.Label4 = New Label
            Me.Label5 = New Label
            Me.ToolTip1 = New ToolTip(Me.components)
            Me.HelpProvider1 = New HelpProvider
            DirectCast(Me.dgrRegexes, ISupportInitialize).BeginInit
            DirectCast(Me.RegexBindingSource, ISupportInitialize).BeginInit
            Me.GroupBox1.SuspendLayout
            Me.SuspendLayout
            Me.btnRemove.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            Dim point As New Point(&H308, &H9A)
            Me.btnRemove.Location = point
            Me.btnRemove.Name = "btnRemove"
            Dim size As New Size(&H3A, &H17)
            Me.btnRemove.Size = size
            Me.btnRemove.TabIndex = 6
            Me.btnRemove.Text = "&Remove"
            Me.ToolTip1.SetToolTip(Me.btnRemove, "Remove the selected regular expression from the list. ?Click on the row header to the left to select an item.)")
            Me.btnRemove.UseVisualStyleBackColor = True
            Me.btnCompile.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            point = New Point(&H308, &HEF)
            Me.btnCompile.Location = point
            Me.btnCompile.Name = "btnCompile"
            size = New Size(&H3A, &H17)
            Me.btnCompile.Size = size
            Me.btnCompile.TabIndex = 9
            Me.btnCompile.Text = "&Compile"
            Me.ToolTip1.SetToolTip(Me.btnCompile, "Compile the list of regular expressions and generate an assembly.")
            Me.btnCompile.UseVisualStyleBackColor = True
            Me.txtNamespace.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H1CB, 20)
            Me.txtNamespace.Location = point
            Me.txtNamespace.Name = "txtNamespace"
            size = New Size(&H12A, 20)
            Me.txtNamespace.Size = size
            Me.txtNamespace.TabIndex = 3
            Me.ToolTip1.SetToolTip(Me.txtNamespace, "The namespace used for all the compiled regular expressions.")
            Me.Label1.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            Me.Label1.AutoSize = True
            point = New Point(&H16B, &H19)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(90, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "R&oot Namespace"
            Me.btnCancel.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.btnCancel.DialogResult = DialogResult.Cancel
            point = New Point(&H308, &H10C)
            Me.btnCancel.Location = point
            Me.btnCancel.Name = "btnCancel"
            size = New Size(&H3A, &H17)
            Me.btnCancel.Size = size
            Me.btnCancel.TabIndex = 10
            Me.btnCancel.Text = "Cancel"
            Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without compiling.")
            Me.btnCancel.UseVisualStyleBackColor = True
            Me.dlgOpenRegex.DefaultExt = "regex"
            Me.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
            Me.dlgOpenRegex.Multiselect = True
            Me.dlgOpenRegex.Title = "Open a regex file"
            Me.dgrRegexes.AllowUserToAddRows = False
            Me.dgrRegexes.AllowUserToResizeRows = False
            Me.dgrRegexes.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.dgrRegexes.AutoGenerateColumns = False
            Me.dgrRegexes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgrRegexes.Columns.AddRange(New DataGridViewColumn() { Me.grdcolName, Me.grdcolPattern, Me.dgrcolOptions })
            Me.dgrRegexes.DataSource = Me.RegexBindingSource
            point = New Point(7, &H1D)
            Me.dgrRegexes.Location = point
            Me.dgrRegexes.MultiSelect = False
            Me.dgrRegexes.Name = "dgrRegexes"
            Me.dgrRegexes.RowHeadersWidth = &H18
            size = New Size(&H2FC, &HB1)
            Me.dgrRegexes.Size = size
            Me.dgrRegexes.TabIndex = 1
            Me.ToolTip1.SetToolTip(Me.dgrRegexes, "The list of regular expressions to be compiled.")
            Me.grdcolName.DataPropertyName = "Name"
            Me.grdcolName.HeaderText = "Name"
            Me.grdcolName.MaxInputLength = 30
            Me.grdcolName.Name = "grdcolName"
            Me.grdcolName.Width = 150
            Me.grdcolPattern.DataPropertyName = "Pattern"
            Me.grdcolPattern.HeaderText = "Pattern"
            Me.grdcolPattern.MaxInputLength = &H400
            Me.grdcolPattern.Name = "grdcolPattern"
            Me.grdcolPattern.Width = 480
            Me.dgrcolOptions.DataPropertyName = "OptionsText"
            Me.dgrcolOptions.HeaderText = "Options"
            Me.dgrcolOptions.Name = "dgrcolOptions"
            Me.RegexBindingSource.AllowNew = False
            Me.btnFile.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H308, &H57)
            Me.btnFile.Location = point
            Me.btnFile.Name = "btnFile"
            size = New Size(&H3A, &H17)
            Me.btnFile.Size = size
            Me.btnFile.TabIndex = 5
            Me.btnFile.Text = "&File"
            Me.ToolTip1.SetToolTip(Me.btnFile, "Add a regular expression saved in a file to the list.")
            Me.btnFile.UseVisualStyleBackColor = True
            Me.btnNew.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H308, &H1D)
            Me.btnNew.Location = point
            Me.btnNew.Name = "btnNew"
            size = New Size(&H3A, &H17)
            Me.btnNew.Size = size
            Me.btnNew.TabIndex = 3
            Me.btnNew.Text = "&New"
            Me.ToolTip1.SetToolTip(Me.btnNew, "Add a new (blank) regular expression to the list.")
            Me.btnNew.UseVisualStyleBackColor = True
            Me.btnClear.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H308, &HB7)
            Me.btnClear.Location = point
            Me.btnClear.Name = "btnClear"
            size = New Size(&H3A, &H17)
            Me.btnClear.Size = size
            Me.btnClear.TabIndex = 7
            Me.btnClear.Text = "C&lear"
            Me.ToolTip1.SetToolTip(Me.btnClear, "Remove all items from the list.")
            Me.btnClear.UseVisualStyleBackColor = True
            Me.btnCurrent.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H308, &H3A)
            Me.btnCurrent.Location = point
            Me.btnCurrent.Name = "btnCurrent"
            size = New Size(&H3A, &H17)
            Me.btnCurrent.Size = size
            Me.btnCurrent.TabIndex = 4
            Me.btnCurrent.Text = "C&urrent"
            Me.ToolTip1.SetToolTip(Me.btnCurrent, "Add the current regular expression (the one being ested in the main window) to the list.")
            Me.btnCurrent.UseVisualStyleBackColor = True
            Me.Label2.Anchor = (AnchorStyles.Left Or AnchorStyles.Bottom)
            Me.Label2.AutoSize = True
            point = New Point(9, &HD1)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H2DE, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "OPTIONS: I=Ignore case,  M=Multiline, X=Ignore,PatternWhitespace,  C=compiled,  N=ExplicitCapture,  R=RightToLeft, U=CultureInvariant, A=EcmaScript"
            Me.dlgSaveAssembly.DefaultExt = "dll"
            Me.dlgSaveAssembly.Filter = "All assemblies (*.dll)|*.dll"
            Me.dlgSaveAssembly.Title = "Select the destination assembly"
            Me.txtAssemblyName.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            point = New Point(&H3A, &H16)
            Me.txtAssemblyName.Location = point
            Me.txtAssemblyName.Name = "txtAssemblyName"
            size = New Size(&H105, 20)
            Me.txtAssemblyName.Size = size
            Me.txtAssemblyName.TabIndex = 1
            Me.ToolTip1.SetToolTip(Me.txtAssemblyName, "The name of the compiled assembly. ?It is also used to name the generated DLL file.)")
            Me.Label3.AutoSize = True
            point = New Point(6, &H16)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H23, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "&Name"
            Me.GroupBox1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Bottom))
            Me.GroupBox1.Controls.Add(Me.btnBrowse)
            Me.GroupBox1.Controls.Add(Me.txtPath)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.txtAssemblyName)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.txtNamespace)
            point = New Point(7, &HEA)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(&H2FC, &H58)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 8
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Generated assembly"
            Me.btnBrowse.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            point = New Point(&H145, &H35)
            Me.btnBrowse.Location = point
            Me.btnBrowse.Name = "btnBrowse"
            size = New Size(&H22, &H17)
            Me.btnBrowse.Size = size
            Me.btnBrowse.TabIndex = 6
            Me.btnBrowse.Text = "..."
            Me.ToolTip1.SetToolTip(Me.btnBrowse, "Select the output path.")
            Me.btnBrowse.UseVisualStyleBackColor = True
            Me.txtPath.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            point = New Point(&H3A, &H35)
            Me.txtPath.Location = point
            Me.txtPath.Name = "txtPath"
            Me.txtPath.ReadOnly = True
            size = New Size(&H105, 20)
            Me.txtPath.Size = size
            Me.txtPath.TabIndex = 5
            Me.ToolTip1.SetToolTip(Me.txtPath, "The directory where the compiled assembly is created.")
            Me.Label4.AutoSize = True
            point = New Point(6, &H38)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H1D, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "&Path"
            Me.Label5.AutoSize = True
            point = New Point(4, 9)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H19B, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Enter the regular expressions expressions to be compiled, or add them from .regex files"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H34E, &H153)
            Me.ClientSize = size
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.btnCurrent)
            Me.Controls.Add(Me.btnClear)
            Me.Controls.Add(Me.btnNew)
            Me.Controls.Add(Me.btnFile)
            Me.Controls.Add(Me.dgrRegexes)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnCompile)
            Me.Controls.Add(Me.btnRemove)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            size = New Size(&H356, &H175)
            Me.MinimumSize = size
            Me.Name = "CompileForm"
            Me.Text = "Compile to Assembly"
            DirectCast(Me.dgrRegexes, ISupportInitialize).EndInit
            DirectCast(Me.RegexBindingSource, ISupportInitialize).EndInit
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub


        ' Properties
        Friend Overridable Property btnRemove As Button
            Get
                Return Me._btnRemove
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnRemove Is Nothing) Then
                    RemoveHandler Me._btnRemove.Click, New EventHandler(AddressOf Me.btnRemove_Click)
                End If
                Me._btnRemove = WithEventsValue
                If (Not Me._btnRemove Is Nothing) Then
                    AddHandler Me._btnRemove.Click, New EventHandler(AddressOf Me.btnRemove_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnCompile As Button
            Get
                Return Me._btnCompile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnCompile Is Nothing) Then
                    RemoveHandler Me._btnCompile.Click, New EventHandler(AddressOf Me.btnCompile_Click)
                End If
                Me._btnCompile = WithEventsValue
                If (Not Me._btnCompile Is Nothing) Then
                    AddHandler Me._btnCompile.Click, New EventHandler(AddressOf Me.btnCompile_Click)
                End If
            End Set
        End Property

        Friend Overridable Property txtNamespace As TextBox
            Get
                Return Me._txtNamespace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtNamespace = WithEventsValue
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

        Friend Overridable Property btnCancel As Button
            Get
                Return Me._btnCancel
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Me._btnCancel = WithEventsValue
            End Set
        End Property

        Friend Overridable Property dlgOpenRegex As OpenFileDialog
            Get
                Return Me._dlgOpenRegex
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As OpenFileDialog)
                Me._dlgOpenRegex = WithEventsValue
            End Set
        End Property

        Friend Overridable Property dgrRegexes As DataGridView
            Get
                Return Me._dgrRegexes
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridView)
                Me._dgrRegexes = WithEventsValue
            End Set
        End Property

        Friend Overridable Property btnFile As Button
            Get
                Return Me._btnFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnFile Is Nothing) Then
                    RemoveHandler Me._btnFile.Click, New EventHandler(AddressOf Me.btnFile_Click)
                End If
                Me._btnFile = WithEventsValue
                If (Not Me._btnFile Is Nothing) Then
                    AddHandler Me._btnFile.Click, New EventHandler(AddressOf Me.btnFile_Click)
                End If
            End Set
        End Property

        Friend Overridable Property RegexBindingSource As BindingSource
            Get
                Return Me._RegexBindingSource
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As BindingSource)
                Me._RegexBindingSource = WithEventsValue
            End Set
        End Property

        Friend Overridable Property btnNew As Button
            Get
                Return Me._btnNew
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnNew Is Nothing) Then
                    RemoveHandler Me._btnNew.Click, New EventHandler(AddressOf Me.btnNew_Click)
                End If
                Me._btnNew = WithEventsValue
                If (Not Me._btnNew Is Nothing) Then
                    AddHandler Me._btnNew.Click, New EventHandler(AddressOf Me.btnNew_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnClear As Button
            Get
                Return Me._btnClear
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnClear Is Nothing) Then
                    RemoveHandler Me._btnClear.Click, New EventHandler(AddressOf Me.btnClear_Click)
                End If
                Me._btnClear = WithEventsValue
                If (Not Me._btnClear Is Nothing) Then
                    AddHandler Me._btnClear.Click, New EventHandler(AddressOf Me.btnClear_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnCurrent As Button
            Get
                Return Me._btnCurrent
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnCurrent Is Nothing) Then
                    RemoveHandler Me._btnCurrent.Click, New EventHandler(AddressOf Me.btnCurrent_Click)
                End If
                Me._btnCurrent = WithEventsValue
                If (Not Me._btnCurrent Is Nothing) Then
                    AddHandler Me._btnCurrent.Click, New EventHandler(AddressOf Me.btnCurrent_Click)
                End If
            End Set
        End Property

        Friend Overridable Property grdcolName As DataGridViewTextBoxColumn
            Get
                Return Me._grdcolName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridViewTextBoxColumn)
                Me._grdcolName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property grdcolPattern As DataGridViewTextBoxColumn
            Get
                Return Me._grdcolPattern
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridViewTextBoxColumn)
                Me._grdcolPattern = WithEventsValue
            End Set
        End Property

        Friend Overridable Property dgrcolOptions As DataGridViewTextBoxColumn
            Get
                Return Me._dgrcolOptions
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridViewTextBoxColumn)
                Me._dgrcolOptions = WithEventsValue
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

        Friend Overridable Property dlgSaveAssembly As SaveFileDialog
            Get
                Return Me._dlgSaveAssembly
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As SaveFileDialog)
                Me._dlgSaveAssembly = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtAssemblyName As TextBox
            Get
                Return Me._txtAssemblyName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtAssemblyName = WithEventsValue
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

        Friend Overridable Property dlgAssemblyPath As FolderBrowserDialog
            Get
                Return Me._dlgAssemblyPath
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As FolderBrowserDialog)
                Me._dlgAssemblyPath = WithEventsValue
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

        Friend Overridable Property btnBrowse As Button
            Get
                Return Me._btnBrowse
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnBrowse Is Nothing) Then
                    RemoveHandler Me._btnBrowse.Click, New EventHandler(AddressOf Me.btnBrowse_Click)
                End If
                Me._btnBrowse = WithEventsValue
                If (Not Me._btnBrowse Is Nothing) Then
                    AddHandler Me._btnBrowse.Click, New EventHandler(AddressOf Me.btnBrowse_Click)
                End If
            End Set
        End Property

        Friend Overridable Property txtPath As TextBox
            Get
                Return Me._txtPath
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtPath = WithEventsValue
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

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label5 = WithEventsValue
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
        <AccessedThroughProperty("btnRemove")> _
        Private _btnRemove As Button
        <AccessedThroughProperty("btnCompile")> _
        Private _btnCompile As Button
        <AccessedThroughProperty("txtNamespace")> _
        Private _txtNamespace As TextBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("btnCancel")> _
        Private _btnCancel As Button
        <AccessedThroughProperty("dlgOpenRegex")> _
        Private _dlgOpenRegex As OpenFileDialog
        <AccessedThroughProperty("dgrRegexes")> _
        Private _dgrRegexes As DataGridView
        <AccessedThroughProperty("btnFile")> _
        Private _btnFile As Button
        <AccessedThroughProperty("RegexBindingSource")> _
        Private _RegexBindingSource As BindingSource
        <AccessedThroughProperty("btnNew")> _
        Private _btnNew As Button
        <AccessedThroughProperty("btnClear")> _
        Private _btnClear As Button
        <AccessedThroughProperty("btnCurrent")> _
        Private _btnCurrent As Button
        <AccessedThroughProperty("grdcolName")> _
        Private _grdcolName As DataGridViewTextBoxColumn
        <AccessedThroughProperty("grdcolPattern")> _
        Private _grdcolPattern As DataGridViewTextBoxColumn
        <AccessedThroughProperty("dgrcolOptions")> _
        Private _dgrcolOptions As DataGridViewTextBoxColumn
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("dlgSaveAssembly")> _
        Private _dlgSaveAssembly As SaveFileDialog
        <AccessedThroughProperty("txtAssemblyName")> _
        Private _txtAssemblyName As TextBox
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("dlgAssemblyPath")> _
        Private _dlgAssemblyPath As FolderBrowserDialog
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("btnBrowse")> _
        Private _btnBrowse As Button
        <AccessedThroughProperty("txtPath")> _
        Private _txtPath As TextBox
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        <AccessedThroughProperty("HelpProvider1")> _
        Private _HelpProvider1 As HelpProvider
        Public MainForm As MainForm
        Private Shared regexList As BindingList(Of RegexInfo) = New BindingList(Of RegexInfo)
    End Class
End Namespace

