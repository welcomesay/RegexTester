Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports RegexTester.My
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Xml

Namespace RegexTester
    <DesignerGenerated> _
    Public Class MainForm
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.MainForm_Load)
            Me.Options = New ProjectOptions
            Me.InitializeComponent
        End Sub

        Public Sub BuildRegexMenu()
            Dim reader As New StreamReader(Assembly.GetExecutingAssembly.GetManifestResourceStream("RegexTester.Regexes.xml"))
            Dim xml As String = reader.ReadToEnd
            reader.Close
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(xml)
            Me.BuildRegexMenu_Sub(xmlDoc, Me.ctxPattern, 1)
            Me.BuildRegexMenu_Sub(xmlDoc, Me.ctxReplace, 2)
        End Sub

        Public Sub BuildRegexMenu_Sub(ByVal xmlDoc As XmlDocument, ByVal rootMenu As ContextMenuStrip, ByVal bitMask As Integer)
            Dim enumerator As IEnumerator
            Try 
                enumerator = xmlDoc.SelectNodes("//group").GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As XmlElement = DirectCast(enumerator.Current, XmlElement)
                    If ((Conversions.ToInteger(current.GetAttribute("includeBits")) And bitMask) <> 0) Then
                        Dim text As String = current.GetAttribute("text").Replace("?", "&")
                        If ([text] = "-") Then
                            rootMenu.Items.Add(New ToolStripSeparator)
                        Else
                            Dim enumerator2 As IEnumerator
                            Dim str2 As String = current.GetAttribute("toolTip").Replace("?", ChrW(13) & ChrW(10))
                            Dim item As New ToolStripMenuItem([text]) With { _
                                .ToolTipText = str2 _
                            }
                            rootMenu.Items.Add(item)
                            Try 
                                enumerator2 = current.SelectNodes("item").GetEnumerator
                                Do While enumerator2.MoveNext
                                    Dim element2 As XmlElement = DirectCast(enumerator2.Current, XmlElement)
                                    Dim str3 As String = element2.GetAttribute("text").Replace("?", "&")
                                    If (str3 = "-") Then
                                        item.DropDownItems.Add(New ToolStripSeparator)
                                    Else
                                        Dim str4 As String = element2.GetAttribute("toolTip").Replace("?", ChrW(13) & ChrW(10))
                                        Dim attribute As String = element2.GetAttribute("regex")
                                        Dim item2 As New ToolStripMenuItem(str3) With { _
                                            .ToolTipText = str4, _
                                            .Tag = attribute _
                                        }
                                        item.DropDownItems.Add(item2)
                                        AddHandler item2.Click, New EventHandler(AddressOf Me.RegexMenu_Click)
                                    End If
                                Loop
                                Continue Do
                            Finally
                                If TypeOf enumerator2 Is IDisposable Then
                                    TryCast(enumerator2,IDisposable).Dispose
                                End If
                            End Try
                        End If
                    End If
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Sub ExecuteCommand()
            Dim matchs As MatchCollection
            Dim builder2 As StringBuilder
            Dim enumerator As IEnumerator
            Dim stopwatch As New Stopwatch
            Dim str As String = ""
            Dim strArray As String() = Nothing
            Try 
                Me.re = New Regex(Me.rtbRegex.Text, Me.Options.RegexOptions)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Me.staMatches.Text = "Parsing Error"
                MessageBox.Show(exception.Message, "Parsing error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                ProjectData.ClearProjectError
                Return
            End Try
            Try 
                stopwatch.Start
                matchs = Me.re.Matches(Me.rtbSource.Text)
                Dim count As Integer = matchs.Count
                stopwatch.Stop
                If (Me.Options.Command = Command.Replace) Then
                    stopwatch.Start
                    str = Me.re.Replace(Me.rtbSource.Text, Me.rtbReplace.Text)
                    stopwatch.Stop
                ElseIf (Me.Options.Command = Command.Split) Then
                    strArray = Me.re.Split(Me.rtbSource.Text)
                    stopwatch.Start
                    stopwatch.Stop
                End If
                Me.staExecutionTime.Text = String.Format("Execution: {0} msecs.   ", stopwatch.ElapsedMilliseconds)
                Me.staMatches.Text = String.Format("Found {0} matches   ", count)
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                Me.staMatches.Text = "Execution error"
                MessageBox.Show(exception2.Message, "Execution error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                ProjectData.ClearProjectError
                Return
            End Try
            Dim list As New List(Of Match)
            Try 
                enumerator = matchs.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As Match = DirectCast(enumerator.Current, Match)
                    list.Add(current)
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
            Me.Refresh
            Dim num As Integer = 0
            Select Case Me.Options.Sort
                Case SortOption.Alphabetic
                    list.Sort(New AlphaComparer)
                    Exit Select
                Case SortOption.ShortestFirst
                    list.Sort(New ShortestComparer)
                    Exit Select
                Case SortOption.LargestFirst
                    list.Sort(New LargestComparer)
                    Exit Select
            End Select
            Me.tvwResults.Nodes.Clear
            Dim num7 As Integer = (list.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num7)
                Dim item As Match = list.Item(i)
                Dim node As TreeNode = Me.tvwResults.Nodes.Add(item.Value)
                node.Tag = New NodeInfo(item, i.ToString)
                If ((Me.Options.Detail <> DetailOption.NoDetails) AndAlso (item.Groups.Count > 0)) Then
                    node.Nodes.Add("*")
                End If
                num += 1
                If (num = Me.Options.MaxMatches) Then
                    Exit Do
                End If
                i += 1
            Loop
            If (matchs.Count > Me.Options.MaxMatches) Then
                Me.staItemInfo.Text = String.Format("(Only the first {0} are displayed)", Me.Options.MaxMatches)
            End If
            num = 0
            If (Me.Options.Command <> Command.Find) Then
                If (Me.Options.Command <> Command.Split) Then
                    goto Label_0525
                End If
                builder2 = New StringBuilder
                Dim strArray2 As String() = strArray
                Dim j As Integer
                For j = 0 To strArray2.Length - 1
                    Dim obj2 As Object = strArray2(j)
                    builder2.AppendFormat("[{0,3}]: {1}", num, RuntimeHelpers.GetObjectValue(obj2))
                    builder2.AppendLine
                    num += 1
                    If (num = Me.Options.MaxMatches) Then
                        Exit For
                    End If
                Next j
            Else
                Dim builder As New StringBuilder
                Dim num8 As Integer = (list.Count - 1)
                Dim j As Integer = 0
                Do While (j <= num8)
                    Dim match3 As Match = list.Item(j)
                    builder.AppendFormat("MATCH[{0}]: '{1}'   [index={2}]", j, match3.Value, match3.Index)
                    builder.AppendLine
                    If (Me.Options.Detail <> DetailOption.NoDetails) Then
                        Dim num9 As Integer = (match3.Groups.Count - 1)
                        Dim k As Integer = 1
                        Do While (k <= num9)
                            Dim group As Group = match3.Groups.Item(k)
                            If ((group.Length <> 0) OrElse Me.Options.IncludeEmptyGroups) Then
                                builder.AppendFormat("   GROUP[{0}]: '{1}'   [index={2}]", Me.re.GroupNameFromNumber(k), group.Value, group.Index)
                                builder.AppendLine
                                If (Me.Options.Detail <> DetailOption.Groups) Then
                                    Dim num10 As Integer = (group.Captures.Count - 1)
                                    Dim m As Integer = 0
                                    Do While (m <= num10)
                                        Dim capture As Capture = group.Captures.Item(m)
                                        builder.AppendFormat("      CAPTURE[{0}]: '{1}'   [index={2}]", m, capture.Value, capture.Index)
                                        builder.AppendLine
                                        m += 1
                                    Loop
                                End If
                            End If
                            k += 1
                        Loop
                        num += 1
                        If (num = Me.Options.MaxMatches) Then
                            Exit Do
                        End If
                    End If
                    j += 1
                Loop
                str = builder.ToString
                goto Label_0525
            End If
            str = builder2.ToString
        Label_0525:
            Me.rtbResults.Text = str
            Me.rtbResults.Select(0, 0)
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.ctxPattern = New ContextMenuStrip(Me.components)
            Me.Label1 = New Label
            Me.MenuStrip1 = New MenuStrip
            Me.mnuFile = New ToolStripMenuItem
            Me.mnuFileNew = New ToolStripMenuItem
            Me.mnuFileOpen = New ToolStripMenuItem
            Me.mnuFileSave = New ToolStripMenuItem
            Me.mnuFileSaveAs = New ToolStripMenuItem
            Me.ToolStripSeparator4 = New ToolStripSeparator
            Me.mnuFileProperties = New ToolStripMenuItem
            Me.ToolStripSeparator5 = New ToolStripSeparator
            Me.mnuFileLoad = New ToolStripMenuItem
            Me.ToolStripSeparator6 = New ToolStripSeparator
            Me.mnuFileExit = New ToolStripMenuItem
            Me.mnuEdit = New ToolStripMenuItem
            Me.mnuEditWordWrap = New ToolStripMenuItem
            Me.mnuCommands = New ToolStripMenuItem
            Me.mnuCommandsRun = New ToolStripMenuItem
            Me.ToolStripSeparator3 = New ToolStripSeparator
            Me.mnuCommandsFind = New ToolStripMenuItem
            Me.mnuCommandsReplace = New ToolStripMenuItem
            Me.mnuCommandsSplit = New ToolStripMenuItem
            Me.ToolStripSeparator1 = New ToolStripSeparator
            Me.mnuCommandsShowGroups = New ToolStripMenuItem
            Me.mnuCommandsEscape = New ToolStripMenuItem
            Me.mnuCommandsGenerateCode = New ToolStripMenuItem
            Me.mnuCommandsCompile = New ToolStripMenuItem
            Me.mnuOptions = New ToolStripMenuItem
            Me.mnuOptionsIgnoreCase = New ToolStripMenuItem
            Me.mnuOptionsIgnoreWhitespace = New ToolStripMenuItem
            Me.mnuOptionsMultiline = New ToolStripMenuItem
            Me.mnuOptionsCompiled = New ToolStripMenuItem
            Me.mnuOptionsExplicitCapture = New ToolStripMenuItem
            Me.mnuOptionsRightToLeft = New ToolStripMenuItem
            Me.mnuOptionsCultureInvariant = New ToolStripMenuItem
            Me.mnuOptionsEcmaScript = New ToolStripMenuItem
            Me.mnuResults = New ToolStripMenuItem
            Me.mnuResultsTreeView = New ToolStripMenuItem
            Me.mnuResultsReport = New ToolStripMenuItem
            Me.mnuResultsAuto = New ToolStripMenuItem
            Me.ToolStripSeparator7 = New ToolStripSeparator
            Me.mnuResultsNoDetails = New ToolStripMenuItem
            Me.mnuResultsGroups = New ToolStripMenuItem
            Me.mnuResultsCaptures = New ToolStripMenuItem
            Me.ToolStripSeparator2 = New ToolStripSeparator
            Me.ToolStripTextBox1 = New ToolStripMenuItem
            Me.txtViewMaxMatches = New ToolStripTextBox
            Me.mnuResultsIncludeEmptyGroups = New ToolStripMenuItem
            Me.ToolStripMenuItem1 = New ToolStripSeparator
            Me.mnuResultsDontSort = New ToolStripMenuItem
            Me.mnuResultsSortAlphabetically = New ToolStripMenuItem
            Me.mnuResultsShortest = New ToolStripMenuItem
            Me.mnuResultsLargest = New ToolStripMenuItem
            Me.mnuHelp = New ToolStripMenuItem
            Me.mnuHelpAbout = New ToolStripMenuItem
            Me.dlgOpenDoc = New OpenFileDialog
            Me.rtbSource = New RichTextBox
            Me.Label2 = New Label
            Me.lblReplace = New Label
            Me.StatusStrip1 = New StatusStrip
            Me.staMatches = New ToolStripStatusLabel
            Me.staExecutionTime = New ToolStripStatusLabel
            Me.staItemInfo = New ToolStripStatusLabel
            Me.ctxReplace = New ContextMenuStrip(Me.components)
            Me.tvwResults = New TreeView
            Me.rtbResults = New RichTextBox
            Me.rtbRegex = New RichTextBox
            Me.rtbReplace = New RichTextBox
            Me.lblMatches = New Label
            Me.dlgOpenRegex = New OpenFileDialog
            Me.dlgSaveRegex = New SaveFileDialog
            Me.ToolTip1 = New ToolTip(Me.components)
            Me.HelpProvider1 = New HelpProvider
            Me.mnuOptionsSingleline = New ToolStripMenuItem
            Me.MenuStrip1.SuspendLayout
            Me.StatusStrip1.SuspendLayout
            Me.SuspendLayout
            Me.ctxPattern.Name = "ctxPattern"
            Dim size As New Size(&H3D, 4)
            Me.ctxPattern.Size = size
            Me.Label1.Font = New Font("Microsoft Sans Serif", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Dim point As New Point(12, &H21)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H3F, &H26)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Regex"
            Me.MenuStrip1.Items.AddRange(New ToolStripItem() { Me.mnuFile, Me.mnuEdit, Me.mnuCommands, Me.mnuOptions, Me.mnuResults, Me.mnuHelp })
            point = New Point(0, 0)
            Me.MenuStrip1.Location = point
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.RenderMode = ToolStripRenderMode.Professional
            size = New Size(&H2F1, &H18)
            Me.MenuStrip1.Size = size
            Me.MenuStrip1.TabIndex = 0
            Me.MenuStrip1.Text = "MenuStrip1"
            Me.mnuFile.DropDownItems.AddRange(New ToolStripItem() { Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveAs, Me.ToolStripSeparator4, Me.mnuFileProperties, Me.ToolStripSeparator5, Me.mnuFileLoad, Me.ToolStripSeparator6, Me.mnuFileExit })
            Me.mnuFile.Name = "mnuFile"
            size = New Size(&H29, 20)
            Me.mnuFile.Size = size
            Me.mnuFile.Text = "&File"
            Me.mnuFileNew.Name = "mnuFileNew"
            size = New Size(&HB1, &H16)
            Me.mnuFileNew.Size = size
            Me.mnuFileNew.Text = "&New"
            Me.mnuFileOpen.Name = "mnuFileOpen"
            Me.mnuFileOpen.ShortcutKeys = (Keys.Control Or Keys.O)
            size = New Size(&HB1, &H16)
            Me.mnuFileOpen.Size = size
            Me.mnuFileOpen.Text = "&Open ..."
            Me.mnuFileSave.Name = "mnuFileSave"
            Me.mnuFileSave.ShortcutKeys = (Keys.Control Or Keys.S)
            size = New Size(&HB1, &H16)
            Me.mnuFileSave.Size = size
            Me.mnuFileSave.Text = "&Save"
            Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
            size = New Size(&HB1, &H16)
            Me.mnuFileSaveAs.Size = size
            Me.mnuFileSaveAs.Text = "Save &as ..."
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            size = New Size(&HAE, 6)
            Me.ToolStripSeparator4.Size = size
            Me.mnuFileProperties.Name = "mnuFileProperties"
            Me.mnuFileProperties.ShortcutKeys = Keys.F4
            size = New Size(&HB1, &H16)
            Me.mnuFileProperties.Size = size
            Me.mnuFileProperties.Text = "&Properties"
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            size = New Size(&HAE, 6)
            Me.ToolStripSeparator5.Size = size
            Me.mnuFileLoad.Name = "mnuFileLoad"
            Me.mnuFileLoad.ShortcutKeys = (Keys.Control Or Keys.L)
            size = New Size(&HB1, &H16)
            Me.mnuFileLoad.Size = size
            Me.mnuFileLoad.Text = "&Load source"
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            size = New Size(&HAE, 6)
            Me.ToolStripSeparator6.Size = size
            Me.mnuFileExit.Name = "mnuFileExit"
            Me.mnuFileExit.ShortcutKeys = (Keys.Alt Or Keys.X)
            size = New Size(&HB1, &H16)
            Me.mnuFileExit.Size = size
            Me.mnuFileExit.Text = "E&xit"
            Me.mnuEdit.DropDownItems.AddRange(New ToolStripItem() { Me.mnuEditWordWrap })
            Me.mnuEdit.Name = "mnuEdit"
            size = New Size(&H29, 20)
            Me.mnuEdit.Size = size
            Me.mnuEdit.Text = "&Edit"
            Me.mnuEditWordWrap.Name = "mnuEditWordWrap"
            size = New Size(&H7C, &H16)
            Me.mnuEditWordWrap.Size = size
            Me.mnuEditWordWrap.Text = "&Word wrap"
            Me.mnuCommands.DropDownItems.AddRange(New ToolStripItem() { Me.mnuCommandsRun, Me.ToolStripSeparator3, Me.mnuCommandsFind, Me.mnuCommandsReplace, Me.mnuCommandsSplit, Me.ToolStripSeparator1, Me.mnuCommandsShowGroups, Me.mnuCommandsEscape, Me.mnuCommandsGenerateCode, Me.mnuCommandsCompile })
            Me.mnuCommands.Name = "mnuCommands"
            size = New Size(&H41, 20)
            Me.mnuCommands.Size = size
            Me.mnuCommands.Text = "&Commands"
            Me.mnuCommandsRun.Name = "mnuCommandsRun"
            Me.mnuCommandsRun.ShortcutKeys = Keys.F5
            size = New Size(&HB8, &H16)
            Me.mnuCommandsRun.Size = size
            Me.mnuCommandsRun.Text = "&Run"
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            size = New Size(&HB5, 6)
            Me.ToolStripSeparator3.Size = size
            Me.mnuCommandsFind.Name = "mnuCommandsFind"
            Me.mnuCommandsFind.ShortcutKeys = (Keys.Control Or Keys.F)
            size = New Size(&HB8, &H16)
            Me.mnuCommandsFind.Size = size
            Me.mnuCommandsFind.Text = "&Find"
            Me.mnuCommandsReplace.Name = "mnuCommandsReplace"
            Me.mnuCommandsReplace.ShortcutKeys = (Keys.Control Or Keys.R)
            size = New Size(&HB8, &H16)
            Me.mnuCommandsReplace.Size = size
            Me.mnuCommandsReplace.Text = "&Replace"
            Me.mnuCommandsSplit.Name = "mnuCommandsSplit"
            Me.mnuCommandsSplit.ShortcutKeys = (Keys.Control Or Keys.T)
            size = New Size(&HB8, &H16)
            Me.mnuCommandsSplit.Size = size
            Me.mnuCommandsSplit.Text = "&Split"
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            size = New Size(&HB5, 6)
            Me.ToolStripSeparator1.Size = size
            Me.mnuCommandsShowGroups.Name = "mnuCommandsShowGroups"
            size = New Size(&HB8, &H16)
            Me.mnuCommandsShowGroups.Size = size
            Me.mnuCommandsShowGroups.Text = "&Show groups"
            Me.mnuCommandsEscape.Name = "mnuCommandsEscape"
            size = New Size(&HB8, &H16)
            Me.mnuCommandsEscape.Size = size
            Me.mnuCommandsEscape.Text = "&Escape"
            Me.mnuCommandsGenerateCode.Name = "mnuCommandsGenerateCode"
            Me.mnuCommandsGenerateCode.ShortcutKeys = Keys.F2
            size = New Size(&HB8, &H16)
            Me.mnuCommandsGenerateCode.Size = size
            Me.mnuCommandsGenerateCode.Text = "&Generate code"
            Me.mnuCommandsCompile.Name = "mnuCommandsCompile"
            size = New Size(&HB8, &H16)
            Me.mnuCommandsCompile.Size = size
            Me.mnuCommandsCompile.Text = "&Compile to Assembly"
            Me.mnuOptions.DropDownItems.AddRange(New ToolStripItem() { Me.mnuOptionsIgnoreCase, Me.mnuOptionsIgnoreWhitespace, Me.mnuOptionsMultiline, Me.mnuOptionsSingleline, Me.mnuOptionsCompiled, Me.mnuOptionsExplicitCapture, Me.mnuOptionsRightToLeft, Me.mnuOptionsCultureInvariant, Me.mnuOptionsEcmaScript })
            Me.mnuOptions.Name = "mnuOptions"
            size = New Size(&H3B, 20)
            Me.mnuOptions.Size = size
            Me.mnuOptions.Text = "&Options"
            Me.mnuOptionsIgnoreCase.Name = "mnuOptionsIgnoreCase"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsIgnoreCase.Size = size
            Me.mnuOptionsIgnoreCase.Text = "&Ignore case"
            Me.mnuOptionsIgnoreWhitespace.Name = "mnuOptionsIgnoreWhitespace"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsIgnoreWhitespace.Size = size
            Me.mnuOptionsIgnoreWhitespace.Text = "Ignore &Whitespace"
            Me.mnuOptionsMultiline.Name = "mnuOptionsMultiline"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsMultiline.Size = size
            Me.mnuOptionsMultiline.Text = "&Multiline"
            Me.mnuOptionsCompiled.Name = "mnuOptionsCompiled"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsCompiled.Size = size
            Me.mnuOptionsCompiled.Text = "&Compiled"
            Me.mnuOptionsExplicitCapture.Name = "mnuOptionsExplicitCapture"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsExplicitCapture.Size = size
            Me.mnuOptionsExplicitCapture.Text = "&Explicit capture"
            Me.mnuOptionsRightToLeft.Name = "mnuOptionsRightToLeft"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsRightToLeft.Size = size
            Me.mnuOptionsRightToLeft.Text = "&Right to left"
            Me.mnuOptionsCultureInvariant.Name = "mnuOptionsCultureInvariant"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsCultureInvariant.Size = size
            Me.mnuOptionsCultureInvariant.Text = "C&ulture invariant"
            Me.mnuOptionsEcmaScript.Name = "mnuOptionsEcmaScript"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsEcmaScript.Size = size
            Me.mnuOptionsEcmaScript.Text = "EC&MAScript"
            Me.mnuResults.DropDownItems.AddRange(New ToolStripItem() { Me.mnuResultsTreeView, Me.mnuResultsReport, Me.mnuResultsAuto, Me.ToolStripSeparator7, Me.mnuResultsNoDetails, Me.mnuResultsGroups, Me.mnuResultsCaptures, Me.ToolStripSeparator2, Me.ToolStripTextBox1, Me.mnuResultsIncludeEmptyGroups, Me.ToolStripMenuItem1, Me.mnuResultsDontSort, Me.mnuResultsSortAlphabetically, Me.mnuResultsShortest, Me.mnuResultsLargest })
            Me.mnuResults.Name = "mnuResults"
            size = New Size(&H3B, 20)
            Me.mnuResults.Size = size
            Me.mnuResults.Text = "&Results"
            Me.mnuResultsTreeView.Name = "mnuResultsTreeView"
            size = New Size(&HCA, &H16)
            Me.mnuResultsTreeView.Size = size
            Me.mnuResultsTreeView.Text = "&Tree view"
            Me.mnuResultsReport.Name = "mnuResultsReport"
            size = New Size(&HCA, &H16)
            Me.mnuResultsReport.Size = size
            Me.mnuResultsReport.Text = "&Report"
            Me.mnuResultsAuto.Name = "mnuResultsAuto"
            size = New Size(&HCA, &H16)
            Me.mnuResultsAuto.Size = size
            Me.mnuResultsAuto.Text = "&Auto"
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            size = New Size(&HC7, 6)
            Me.ToolStripSeparator7.Size = size
            Me.mnuResultsNoDetails.Name = "mnuResultsNoDetails"
            size = New Size(&HCA, &H16)
            Me.mnuResultsNoDetails.Size = size
            Me.mnuResultsNoDetails.Text = "N&o details"
            Me.mnuResultsGroups.Name = "mnuResultsGroups"
            size = New Size(&HCA, &H16)
            Me.mnuResultsGroups.Size = size
            Me.mnuResultsGroups.Text = "&Groups"
            Me.mnuResultsCaptures.Name = "mnuResultsCaptures"
            size = New Size(&HCA, &H16)
            Me.mnuResultsCaptures.Size = size
            Me.mnuResultsCaptures.Text = "Groups and &Captures"
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            size = New Size(&HC7, 6)
            Me.ToolStripSeparator2.Size = size
            Me.ToolStripTextBox1.DropDownItems.AddRange(New ToolStripItem() { Me.txtViewMaxMatches })
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            size = New Size(&HCA, &H16)
            Me.ToolStripTextBox1.Size = size
            Me.ToolStripTextBox1.Text = "&Max number  of results"
            Me.txtViewMaxMatches.Name = "txtViewMaxMatches"
            size = New Size(100, &H15)
            Me.txtViewMaxMatches.Size = size
            Me.txtViewMaxMatches.Text = "1000"
            Me.mnuResultsIncludeEmptyGroups.Name = "mnuResultsIncludeEmptyGroups"
            size = New Size(&HCA, &H16)
            Me.mnuResultsIncludeEmptyGroups.Size = size
            Me.mnuResultsIncludeEmptyGroups.Text = "&Include empty groups"
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            size = New Size(&HC7, 6)
            Me.ToolStripMenuItem1.Size = size
            Me.mnuResultsDontSort.Name = "mnuResultsDontSort"
            size = New Size(&HCA, &H16)
            Me.mnuResultsDontSort.Size = size
            Me.mnuResultsDontSort.Text = "Sort on &Position"
            Me.mnuResultsSortAlphabetically.Name = "mnuResultsSortAlphabetically"
            size = New Size(&HCA, &H16)
            Me.mnuResultsSortAlphabetically.Size = size
            Me.mnuResultsSortAlphabetically.Text = "Sort on &Name"
            Me.mnuResultsShortest.Name = "mnuResultsShortest"
            size = New Size(&HCA, &H16)
            Me.mnuResultsShortest.Size = size
            Me.mnuResultsShortest.Text = "&Shortest matches first"
            Me.mnuResultsLargest.Name = "mnuResultsLargest"
            size = New Size(&HCA, &H16)
            Me.mnuResultsLargest.Size = size
            Me.mnuResultsLargest.Text = "&Largest matches first"
            Me.mnuHelp.DropDownItems.AddRange(New ToolStripItem() { Me.mnuHelpAbout })
            Me.mnuHelp.Name = "mnuHelp"
            size = New Size(&H29, 20)
            Me.mnuHelp.Size = size
            Me.mnuHelp.Text = "&Help"
            Me.mnuHelpAbout.Name = "mnuHelpAbout"
            size = New Size(100, &H16)
            Me.mnuHelpAbout.Size = size
            Me.mnuHelpAbout.Text = "&About"
            Me.dlgOpenDoc.Filter = "Text files (*.txt;*.doc)|*.txt;*.doc|All files|*.*"
            Me.dlgOpenDoc.Title = "Open a text document"
            Me.rtbSource.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.rtbSource.DetectUrls = False
            Me.rtbSource.Font = New Font("Microsoft Sans Serif", 10!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.rtbSource.HideSelection = False
            point = New Point(&H43, &HBC)
            Me.rtbSource.Location = point
            Me.rtbSource.Name = "rtbSource"
            Me.rtbSource.ScrollBars = RichTextBoxScrollBars.Vertical
            size = New Size(&H2A2, &H65)
            Me.rtbSource.Size = size
            Me.rtbSource.TabIndex = 6
            Me.rtbSource.Text = ""
            Me.ToolTip1.SetToolTip(Me.rtbSource, "The text on which the regular expression is applied. se the File-Load menu to load a text file.")
            Me.Label2.Font = New Font("Microsoft Sans Serif", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(12, &HBF)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H4B, &H26)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Source"
            Me.lblReplace.Font = New Font("Microsoft Sans Serif", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(12, &H7B)
            Me.lblReplace.Location = point
            Me.lblReplace.Name = "lblReplace"
            size = New Size(60, 40)
            Me.lblReplace.Size = size
            Me.lblReplace.TabIndex = 3
            Me.lblReplace.Text = "Replace"
            Me.StatusStrip1.Items.AddRange(New ToolStripItem() { Me.staMatches, Me.staExecutionTime, Me.staItemInfo })
            point = New Point(0, &H1DE)
            Me.StatusStrip1.Location = point
            size = New Size(&H2F1, &H16)
            Me.StatusStrip1.MinimumSize = size
            Me.StatusStrip1.Name = "StatusStrip1"
            size = New Size(&H2F1, &H16)
            Me.StatusStrip1.Size = size
            Me.StatusStrip1.TabIndex = 10
            Me.StatusStrip1.Text = "StatusStrip1"
            Me.staMatches.ForeColor = SystemColors.ActiveCaption
            Me.staMatches.Name = "staMatches"
            size = New Size(&H53, &H11)
            Me.staMatches.Size = size
            Me.staMatches.Text = "Found matches"
            Me.staExecutionTime.Name = "staExecutionTime"
            size = New Size(&H59, &H11)
            Me.staExecutionTime.Size = size
            Me.staExecutionTime.Text = "Execution time"
            Me.staItemInfo.ForeColor = SystemColors.ActiveCaption
            Me.staItemInfo.Name = "staItemInfo"
            size = New Size(&H3B, &H11)
            Me.staItemInfo.Size = size
            Me.staItemInfo.Text = "Item info"
            Me.ctxReplace.Name = "ctxPattern"
            size = New Size(&H3D, 4)
            Me.ctxReplace.Size = size
            Me.tvwResults.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            point = New Point(&H43, &H131)
            Me.tvwResults.Location = point
            Me.tvwResults.Name = "tvwResults"
            Me.tvwResults.ShowRootLines = False
            size = New Size(&H2A2, &HA4)
            Me.tvwResults.Size = size
            Me.tvwResults.TabIndex = 8
            Me.ToolTip1.SetToolTip(Me.tvwResults, "All the matches found. ouble-click on an item to see groups and captures.")
            Me.rtbResults.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.rtbResults.DetectUrls = False
            Me.rtbResults.Font = New Font("Microsoft Sans Serif", 10!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.rtbResults.HideSelection = False
            point = New Point(12, 360)
            Me.rtbResults.Location = point
            Me.rtbResults.Name = "rtbResults"
            Me.rtbResults.ScrollBars = RichTextBoxScrollBars.Vertical
            size = New Size(&H1C, &H2D)
            Me.rtbResults.Size = size
            Me.rtbResults.TabIndex = 9
            Me.rtbResults.Text = ""
            Me.ToolTip1.SetToolTip(Me.rtbResults, "The replaced text, or the split elements, or the matches in report format.")
            Me.rtbRegex.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.rtbRegex.ContextMenuStrip = Me.ctxPattern
            Me.rtbRegex.DetectUrls = False
            point = New Point(&H43, &H21)
            Me.rtbRegex.Location = point
            Me.rtbRegex.Name = "rtbRegex"
            size = New Size(&H2A2, &H54)
            Me.rtbRegex.Size = size
            Me.rtbRegex.TabIndex = 2
            Me.rtbRegex.Text = ""
            Me.ToolTip1.SetToolTip(Me.rtbRegex, "The regular expression pattern. ight-click to display list of common patterns.")
            Me.rtbReplace.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.rtbReplace.ContextMenuStrip = Me.ctxReplace
            Me.rtbReplace.DetectUrls = False
            point = New Point(&H43, &H7B)
            Me.rtbReplace.Location = point
            Me.rtbReplace.Name = "rtbReplace"
            size = New Size(&H2A2, &H30)
            Me.rtbReplace.Size = size
            Me.rtbReplace.TabIndex = 4
            Me.rtbReplace.Text = ""
            Me.ToolTip1.SetToolTip(Me.rtbReplace, "The replace pattern. ight-click to display list of common patterns.")
            Me.lblMatches.Font = New Font("Microsoft Sans Serif", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(12, &H131)
            Me.lblMatches.Location = point
            Me.lblMatches.Name = "lblMatches"
            size = New Size(&H4B, &H26)
            Me.lblMatches.Size = size
            Me.lblMatches.TabIndex = 7
            Me.lblMatches.Text = "Matches"
            Me.dlgOpenRegex.DefaultExt = "regex"
            Me.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
            Me.dlgOpenRegex.Title = "Open a regex file"
            Me.dlgSaveRegex.DefaultExt = "regex"
            Me.dlgSaveRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
            Me.dlgSaveRegex.Title = "Save a regex file"
            Me.mnuOptionsSingleline.Name = "mnuOptionsSingleline"
            size = New Size(&HAC, &H16)
            Me.mnuOptionsSingleline.Size = size
            Me.mnuOptionsSingleline.Text = "&Singleline"
            Dim ef As New SizeF(8!, 16!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H2F1, 500)
            Me.ClientSize = size
            Me.Controls.Add(Me.rtbRegex)
            Me.Controls.Add(Me.tvwResults)
            Me.Controls.Add(Me.rtbReplace)
            Me.Controls.Add(Me.MenuStrip1)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Controls.Add(Me.rtbResults)
            Me.Controls.Add(Me.lblReplace)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lblMatches)
            Me.Controls.Add(Me.rtbSource)
            Me.Controls.Add(Me.Label2)
            Me.Font = New Font("Microsoft Sans Serif", 10!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.MainMenuStrip = Me.MenuStrip1
            Dim padding As New Padding(4)
            Me.Margin = padding
            Me.Name = "MainForm"
            Me.Text = "Code Architects Regex Tester"
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
            Me.BuildRegexMenu
            Me.rtbResults.Bounds = Me.tvwResults.Bounds
            Me.staMatches.Text = ""
            Me.staExecutionTime.Text = ""
            Me.staItemInfo.Text = ""
            Me.Options.ClearChanges
        End Sub

        Private Sub mnuCommandsCompile_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.CompileForm Is Nothing) Then
                Me.CompileForm = New CompileForm
                Me.CompileForm.MainForm = Me
            End If
            Me.CompileForm.Show
        End Sub

        Private Sub mnuCommandsEscape_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdateOptionFiels
            New EscapeForm() With { _
                .Options = Me.Options _
            }.ShowDialog
        End Sub

        Private Sub mnuCommandsFind_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.Options.Command <> Command.Find) Then
                Me.Options.Command = Command.Find
                Me.rtbResults.Clear
                Me.RefreshOptionsState
            End If
        End Sub

        Private Sub mnuCommandsGenerateCode_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdateOptionFiels
            New GenerateCodeForm() With { _
                .Options = Me.Options _
            }.ShowDialog
        End Sub

        Private Sub mnuCommandsReplace_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.Options.Command <> Command.Replace) Then
                Me.Options.Command = Command.Replace
                Me.rtbResults.Clear
                Me.RefreshOptionsState
            End If
        End Sub

        Private Sub mnuCommandsRun_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.ExecuteCommand
        End Sub

        Private Sub mnuCommandsShowGroups_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim builder As New StringBuilder
            Try 
                Dim groupNames As String() = New Regex(Me.rtbRegex.Text).GetGroupNames
                Dim num2 As Integer = (groupNames.Length - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (groupNames(i) = i.ToString) Then
                        builder.AppendFormat("group[{0}]", i)
                    Else
                        builder.AppendFormat("group[{0}] = {1}", i, groupNames(i))
                    End If
                    builder.AppendLine
                    i += 1
                Loop
                MessageBox.Show(builder.ToString, "Capturing Groups", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub mnuCommandsSplit_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.Options.Command <> Command.Split) Then
                Me.Options.Command = Command.Split
                Me.rtbResults.Clear
                Me.RefreshOptionsState
            End If
        End Sub

        Private Sub mnuEditWordWrap_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.WordWrap = Not Me.Options.WordWrap
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.OkToProceed Then
                Application.Exit
            End If
        End Sub

        Private Sub mnuFileLoad_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.dlgOpenDoc.ShowDialog = DialogResult.OK) Then
                Try 
                    Me.Options.SourceText = File.ReadAllText(Me.dlgOpenDoc.FileName)
                    Me.rtbSource.Text = Me.Options.SourceText
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    MessageBox.Show(exception.Message, "Unable to load document", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    ProjectData.ClearProjectError
                End Try
            End If
        End Sub

        Private Sub mnuFileNew_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.OkToProceed Then
                Me.Options = New ProjectOptions
                Me.Options.ClearChanges
                Me.RefreshControlState
            End If
        End Sub

        Private Sub mnuFileOpen_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.OkToProceed Then
                Me.OpenRegex(Nothing)
            End If
        End Sub

        Private Sub mnuFileProperties_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdateOptionFiels
            Dim form As New PropertiesForm With { _
                .Options = Me.Options _
            }
            If (form.ShowDialog <> DialogResult.Cancel) Then
                Me.RefreshControlState
            End If
        End Sub

        Private Sub mnuFileSave_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdateOptionFiels
            Me.SaveRegex(Me.Options.RegexFile)
        End Sub

        Private Sub mnuFileSaveAs_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdateOptionFiels
            Me.SaveRegex(Nothing)
        End Sub

        Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs)
            New AboutBoxForm().ShowDialog
        End Sub

        Private Sub mnuOptionsCompiled_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.Compiled)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsCultureInvariant_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.CultureInvariant)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsEcmaScript_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.ECMAScript)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsExplicitCapture_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.ExplicitCapture)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsIgnoreCase_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.IgnoreCase)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsIgnoreWhitespace_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.IgnorePatternWhitespace)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsMultiline_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.Multiline)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsRightToLeft_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.RightToLeft)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuOptionsSingleline_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.RegexOptions = (Me.Options.RegexOptions Xor RegexOptions.Singleline)
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsAuto_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Format = FormatOption.Auto
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsCaptures_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Detail = DetailOption.GroupAndCaptures
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsDontSort_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Sort = SortOption.Position
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsGroups_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Detail = DetailOption.Groups
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsIncludeEmptyGroups_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.IncludeEmptyGroups = Not Me.Options.IncludeEmptyGroups
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsLargest_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Sort = SortOption.LargestFirst
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsNoDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Detail = DetailOption.NoDetails
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsReport_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Format = FormatOption.Report
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsShortest_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Sort = SortOption.ShortestFirst
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsSortAlphabetically_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Sort = SortOption.Alphabetic
            Me.RefreshOptionsState
        End Sub

        Private Sub mnuResultsTreeView_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Options.Format = FormatOption.TreeView
            Me.RefreshOptionsState
        End Sub

        Public Function OkToProceed() As Boolean
            Dim flag As Boolean
            Me.UpdateOptionFiels
            If Not Me.Options.HasChanged Then
                Return True
            End If
            Select Case MessageBox.Show(String.Format("Current regex has been modified.{0}{0}Do you wish to save it?", ChrW(13) & ChrW(10)), "Confirm action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Cancel
                    Return False
                Case DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore
                    Return flag
                Case DialogResult.Yes
                    Return Me.SaveRegex(Me.Options.RegexFile)
                Case DialogResult.No
                    Return True
            End Select
            Return flag
        End Function

        Public Function OpenRegex(ByVal fileName As String) As Boolean
            Dim flag As Boolean
            If String.IsNullOrEmpty(fileName) Then
                If (Me.dlgOpenRegex.ShowDialog <> DialogResult.OK) Then
                    Return False
                End If
                fileName = Me.dlgOpenRegex.FileName
            End If
            Try 
                Me.Options = ProjectOptions.Load(fileName)
                Me.RefreshControlState
                flag = True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                MessageBox.Show(exception.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                flag = False
                ProjectData.ClearProjectError
            End Try
            Return flag
        End Function

        Public Sub RefreshControlState()
            Me.rtbRegex.Text = Me.Options.RegexText
            Me.rtbReplace.Text = Me.Options.ReplaceText
            Me.rtbSource.Text = Me.Options.SourceText
            Me.RefreshOptionsState
            Dim title As String = MyProject.Application.Info.Title
            If String.IsNullOrEmpty(Me.Options.RegexName) Then
                Me.Text = (title & " - (unnamed regex)")
            Else
                Me.Text = (title & " - " & Me.Options.RegexName)
            End If
        End Sub

        Public Sub RefreshOptionsState()
            Dim size As Size
            Me.mnuEditWordWrap.Checked = Me.Options.WordWrap
            Me.mnuCommandsFind.Checked = (Me.Options.Command = Command.Find)
            Me.mnuCommandsReplace.Checked = (Me.Options.Command = Command.Replace)
            Me.mnuCommandsSplit.Checked = (Me.Options.Command = Command.Split)
            Me.mnuOptionsCompiled.Checked = ((Me.Options.RegexOptions And RegexOptions.Compiled) = RegexOptions.Compiled)
            Me.mnuOptionsCultureInvariant.Checked = ((Me.Options.RegexOptions And RegexOptions.CultureInvariant) = RegexOptions.CultureInvariant)
            Me.mnuOptionsEcmaScript.Checked = ((Me.Options.RegexOptions And RegexOptions.ECMAScript) = RegexOptions.ECMAScript)
            Me.mnuOptionsExplicitCapture.Checked = ((Me.Options.RegexOptions And RegexOptions.ExplicitCapture) = RegexOptions.ExplicitCapture)
            Me.mnuOptionsIgnoreCase.Checked = ((Me.Options.RegexOptions And RegexOptions.IgnoreCase) = RegexOptions.IgnoreCase)
            Me.mnuOptionsIgnoreWhitespace.Checked = ((Me.Options.RegexOptions And RegexOptions.IgnorePatternWhitespace) = RegexOptions.IgnorePatternWhitespace)
            Me.mnuOptionsMultiline.Checked = ((Me.Options.RegexOptions And RegexOptions.Multiline) = RegexOptions.Multiline)
            Me.mnuOptionsSingleline.Checked = ((Me.Options.RegexOptions And RegexOptions.Singleline) = RegexOptions.Singleline)
            Me.mnuOptionsRightToLeft.Checked = ((Me.Options.RegexOptions And RegexOptions.RightToLeft) = RegexOptions.RightToLeft)
            Me.mnuResultsAuto.Checked = (Me.Options.Format = FormatOption.Auto)
            Me.mnuResultsTreeView.Checked = (Me.Options.Format = FormatOption.TreeView)
            Me.mnuResultsReport.Checked = (Me.Options.Format = FormatOption.Report)
            Me.mnuResultsNoDetails.Checked = (Me.Options.Detail = DetailOption.NoDetails)
            Me.mnuResultsGroups.Checked = (Me.Options.Detail = DetailOption.Groups)
            Me.mnuResultsCaptures.Checked = (Me.Options.Detail = DetailOption.GroupAndCaptures)
            Me.txtViewMaxMatches.Text = Me.Options.MaxMatches.ToString
            Me.mnuResultsIncludeEmptyGroups.Checked = Me.Options.IncludeEmptyGroups
            Me.mnuResultsDontSort.Checked = (Me.Options.Sort = SortOption.Position)
            Me.mnuResultsSortAlphabetically.Checked = (Me.Options.Sort = SortOption.Alphabetic)
            Me.mnuResultsShortest.Checked = (Me.Options.Sort = SortOption.ShortestFirst)
            Me.mnuResultsLargest.Checked = (Me.Options.Sort = SortOption.LargestFirst)
            Me.tvwResults.Visible = ((Me.Options.Format = FormatOption.TreeView) OrElse ((Me.Options.Format = FormatOption.Auto) AndAlso (Me.Options.Command = Command.Find)))
            Me.rtbResults.Visible = Not Me.tvwResults.Visible
            Me.staItemInfo.Visible = Me.tvwResults.Visible
            If Me.tvwResults.Visible Then
                Me.lblMatches.Text = "Matches"
            Else
                Me.lblMatches.Text = "Report"
            End If
            If (Me.Options.Command = Command.Replace) Then
                size = New Size(Me.rtbRegex.Width, ((Me.rtbReplace.Top - Me.rtbRegex.Top) - 10))
                Me.rtbRegex.Size = size
                Me.rtbReplace.Visible = True
                Me.lblReplace.Visible = True
            Else
                size = New Size(Me.rtbRegex.Width, (Me.rtbReplace.Bottom - Me.rtbRegex.Top))
                Me.rtbRegex.Size = size
                Me.rtbReplace.Visible = False
                Me.lblReplace.Visible = False
            End If
            Me.rtbRegex.WordWrap = Me.Options.WordWrap
            Me.rtbReplace.WordWrap = Me.Options.WordWrap
            Me.rtbSource.WordWrap = Me.Options.WordWrap
            Me.rtbResults.WordWrap = Me.Options.WordWrap
            If Me.Options.WordWrap Then
                Me.rtbRegex.ScrollBars = RichTextBoxScrollBars.Vertical
                Me.rtbReplace.ScrollBars = RichTextBoxScrollBars.Vertical
                Me.rtbSource.ScrollBars = RichTextBoxScrollBars.Vertical
                Me.rtbResults.ScrollBars = RichTextBoxScrollBars.Vertical
            Else
                Me.rtbRegex.ScrollBars = RichTextBoxScrollBars.Both
                Me.rtbReplace.ScrollBars = RichTextBoxScrollBars.Both
                Me.rtbSource.ScrollBars = RichTextBoxScrollBars.Both
                Me.rtbResults.ScrollBars = RichTextBoxScrollBars.Both
            End If
        End Sub

        Private Sub RegexMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim owner As ToolStrip = DirectCast(sender, ToolStripMenuItem).OwnerItem.Owner
            Dim rtbRegex As RichTextBox = Me.rtbRegex
            If (owner Is Me.ctxReplace) Then
                rtbRegex = Me.rtbReplace
            End If
            Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            Dim str As String = Conversions.ToString(item.Tag)
            Dim selectionStart As Integer = Me.rtbRegex.SelectionStart
            rtbRegex.SelectedText = str.Replace("?", "")
            Dim index As Integer = str.IndexOf("?")
            If (index >= 0) Then
                Dim num3 As Integer = str.IndexOf("?", CInt((index + 1)))
                rtbRegex.Select((selectionStart + index), ((num3 - index) - 1))
            End If
        End Sub

        Public Function SaveRegex(ByVal fileName As String) As Boolean
            Dim flag As Boolean
            If (Me.Options.RegexName.Length = 0) Then
                Dim str As String = Interaction.InputBox("Please assign a name to the current regex", "Saving Regex file", "", -1, -1)
                If (str = "") Then
                    MessageBox.Show("Current regex hasn't been saved.", "Missing regex name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                Me.Options.RegexName = str
            End If
            If String.IsNullOrEmpty(fileName) Then
                If (Me.dlgSaveRegex.ShowDialog <> DialogResult.OK) Then
                    Return False
                End If
                fileName = Me.dlgSaveRegex.FileName
            End If
            Try 
                Me.Options.Save(fileName)
                Me.RefreshControlState
                flag = True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                MessageBox.Show(exception.Message, "Unable to save regex file", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                flag = False
                ProjectData.ClearProjectError
            End Try
            Return flag
        End Function

        Private Sub tvwResults_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
            Dim tag As NodeInfo = DirectCast(e.Node.Tag, NodeInfo)
            Dim str As String = tag.Item.GetType.Name.ToUpper
            Me.staItemInfo.Text = String.Format("{0}[{1}]: Index={2}, Length={3}", New Object() { str, tag.Name, tag.Item.Index, tag.Item.Length })
            Me.rtbSource.Select(tag.Item.Index, tag.Item.Length)
            Me.rtbSource.ScrollToCaret
        End Sub

        Private Sub tvwResults_BeforeExpand(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            If ((e.Node.Nodes.Count = 1) OrElse (e.Node.Nodes.Item(0).Text = "*")) Then
                e.Node.Nodes.Clear
                Dim tag As NodeInfo = DirectCast(e.Node.Tag, NodeInfo)
                If (tag.Item.GetType Is GetType(Match)) Then
                    Dim item As Match = DirectCast(tag.Item, Match)
                    Dim num3 As Integer = (item.Groups.Count - 1)
                    Dim i As Integer = 1
                    Do While (i <= num3)
                        Dim group As Group = item.Groups.Item(i)
                        If ((group.Length <> 0) OrElse Me.Options.IncludeEmptyGroups) Then
                            Dim node As TreeNode = e.Node.Nodes.Add(group.Value)
                            node.Tag = New NodeInfo(group, Me.re.GroupNameFromNumber(i))
                            If ((Me.Options.Detail = DetailOption.GroupAndCaptures) AndAlso (group.Captures.Count > 0)) Then
                                node.Nodes.Add("*")
                            End If
                        End If
                        i += 1
                    Loop
                ElseIf (tag.Item.GetType Is GetType(Group)) Then
                    Dim item As Group = DirectCast(tag.Item, Group)
                    Dim num4 As Integer = (item.Captures.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num4)
                        Dim capture As Capture = item.Captures.Item(i)
                        If (Not capture.GetType Is GetType(Group)) Then
                            e.Node.Nodes.Add(capture.Value).Tag = New NodeInfo(capture, i.ToString)
                        End If
                        i += 1
                    Loop
                End If
            End If
        End Sub

        Private Sub txtViewMaxMatches_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim num As Integer
            If Integer.TryParse(Me.txtViewMaxMatches.Text, num) Then
                Me.Options.MaxMatches = num
            End If
        End Sub

        Public Sub UpdateOptionFiels()
            Me.Options.RegexText = Me.rtbRegex.Text
            Me.Options.ReplaceText = Me.rtbReplace.Text
            Me.Options.SourceText = Me.rtbSource.Text
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

        Friend Overridable Property MenuStrip1 As MenuStrip
            Get
                Return Me._MenuStrip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As MenuStrip)
                Me._MenuStrip1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuFile As ToolStripMenuItem
            Get
                Return Me._mnuFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuFile = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuOptions As ToolStripMenuItem
            Get
                Return Me._mnuOptions
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuOptions = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuOptionsIgnoreCase As ToolStripMenuItem
            Get
                Return Me._mnuOptionsIgnoreCase
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsIgnoreCase Is Nothing) Then
                    RemoveHandler Me._mnuOptionsIgnoreCase.Click, New EventHandler(AddressOf Me.mnuOptionsIgnoreCase_Click)
                End If
                Me._mnuOptionsIgnoreCase = WithEventsValue
                If (Not Me._mnuOptionsIgnoreCase Is Nothing) Then
                    AddHandler Me._mnuOptionsIgnoreCase.Click, New EventHandler(AddressOf Me.mnuOptionsIgnoreCase_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsMultiline As ToolStripMenuItem
            Get
                Return Me._mnuOptionsMultiline
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsMultiline Is Nothing) Then
                    RemoveHandler Me._mnuOptionsMultiline.Click, New EventHandler(AddressOf Me.mnuOptionsMultiline_Click)
                End If
                Me._mnuOptionsMultiline = WithEventsValue
                If (Not Me._mnuOptionsMultiline Is Nothing) Then
                    AddHandler Me._mnuOptionsMultiline.Click, New EventHandler(AddressOf Me.mnuOptionsMultiline_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsIgnoreWhitespace As ToolStripMenuItem
            Get
                Return Me._mnuOptionsIgnoreWhitespace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsIgnoreWhitespace Is Nothing) Then
                    RemoveHandler Me._mnuOptionsIgnoreWhitespace.Click, New EventHandler(AddressOf Me.mnuOptionsIgnoreWhitespace_Click)
                End If
                Me._mnuOptionsIgnoreWhitespace = WithEventsValue
                If (Not Me._mnuOptionsIgnoreWhitespace Is Nothing) Then
                    AddHandler Me._mnuOptionsIgnoreWhitespace.Click, New EventHandler(AddressOf Me.mnuOptionsIgnoreWhitespace_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsCompiled As ToolStripMenuItem
            Get
                Return Me._mnuOptionsCompiled
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsCompiled Is Nothing) Then
                    RemoveHandler Me._mnuOptionsCompiled.Click, New EventHandler(AddressOf Me.mnuOptionsCompiled_Click)
                End If
                Me._mnuOptionsCompiled = WithEventsValue
                If (Not Me._mnuOptionsCompiled Is Nothing) Then
                    AddHandler Me._mnuOptionsCompiled.Click, New EventHandler(AddressOf Me.mnuOptionsCompiled_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsExplicitCapture As ToolStripMenuItem
            Get
                Return Me._mnuOptionsExplicitCapture
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsExplicitCapture Is Nothing) Then
                    RemoveHandler Me._mnuOptionsExplicitCapture.Click, New EventHandler(AddressOf Me.mnuOptionsExplicitCapture_Click)
                End If
                Me._mnuOptionsExplicitCapture = WithEventsValue
                If (Not Me._mnuOptionsExplicitCapture Is Nothing) Then
                    AddHandler Me._mnuOptionsExplicitCapture.Click, New EventHandler(AddressOf Me.mnuOptionsExplicitCapture_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsRightToLeft As ToolStripMenuItem
            Get
                Return Me._mnuOptionsRightToLeft
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsRightToLeft Is Nothing) Then
                    RemoveHandler Me._mnuOptionsRightToLeft.Click, New EventHandler(AddressOf Me.mnuOptionsRightToLeft_Click)
                End If
                Me._mnuOptionsRightToLeft = WithEventsValue
                If (Not Me._mnuOptionsRightToLeft Is Nothing) Then
                    AddHandler Me._mnuOptionsRightToLeft.Click, New EventHandler(AddressOf Me.mnuOptionsRightToLeft_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsCultureInvariant As ToolStripMenuItem
            Get
                Return Me._mnuOptionsCultureInvariant
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsCultureInvariant Is Nothing) Then
                    RemoveHandler Me._mnuOptionsCultureInvariant.Click, New EventHandler(AddressOf Me.mnuOptionsCultureInvariant_Click)
                End If
                Me._mnuOptionsCultureInvariant = WithEventsValue
                If (Not Me._mnuOptionsCultureInvariant Is Nothing) Then
                    AddHandler Me._mnuOptionsCultureInvariant.Click, New EventHandler(AddressOf Me.mnuOptionsCultureInvariant_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsEcmaScript As ToolStripMenuItem
            Get
                Return Me._mnuOptionsEcmaScript
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsEcmaScript Is Nothing) Then
                    RemoveHandler Me._mnuOptionsEcmaScript.Click, New EventHandler(AddressOf Me.mnuOptionsEcmaScript_Click)
                End If
                Me._mnuOptionsEcmaScript = WithEventsValue
                If (Not Me._mnuOptionsEcmaScript Is Nothing) Then
                    AddHandler Me._mnuOptionsEcmaScript.Click, New EventHandler(AddressOf Me.mnuOptionsEcmaScript_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuFileOpen As ToolStripMenuItem
            Get
                Return Me._mnuFileOpen
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileOpen Is Nothing) Then
                    RemoveHandler Me._mnuFileOpen.Click, New EventHandler(AddressOf Me.mnuFileOpen_Click)
                End If
                Me._mnuFileOpen = WithEventsValue
                If (Not Me._mnuFileOpen Is Nothing) Then
                    AddHandler Me._mnuFileOpen.Click, New EventHandler(AddressOf Me.mnuFileOpen_Click)
                End If
            End Set
        End Property

        Friend Overridable Property dlgOpenDoc As OpenFileDialog
            Get
                Return Me._dlgOpenDoc
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As OpenFileDialog)
                Me._dlgOpenDoc = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbSource As RichTextBox
            Get
                Return Me._rtbSource
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbSource = WithEventsValue
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

        Friend Overridable Property mnuFileNew As ToolStripMenuItem
            Get
                Return Me._mnuFileNew
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileNew Is Nothing) Then
                    RemoveHandler Me._mnuFileNew.Click, New EventHandler(AddressOf Me.mnuFileNew_Click)
                End If
                Me._mnuFileNew = WithEventsValue
                If (Not Me._mnuFileNew Is Nothing) Then
                    AddHandler Me._mnuFileNew.Click, New EventHandler(AddressOf Me.mnuFileNew_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResults As ToolStripMenuItem
            Get
                Return Me._mnuResults
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuResults = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuCommands As ToolStripMenuItem
            Get
                Return Me._mnuCommands
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuCommands = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuCommandsFind As ToolStripMenuItem
            Get
                Return Me._mnuCommandsFind
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsFind Is Nothing) Then
                    RemoveHandler Me._mnuCommandsFind.Click, New EventHandler(AddressOf Me.mnuCommandsFind_Click)
                End If
                Me._mnuCommandsFind = WithEventsValue
                If (Not Me._mnuCommandsFind Is Nothing) Then
                    AddHandler Me._mnuCommandsFind.Click, New EventHandler(AddressOf Me.mnuCommandsFind_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuCommandsReplace As ToolStripMenuItem
            Get
                Return Me._mnuCommandsReplace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsReplace Is Nothing) Then
                    RemoveHandler Me._mnuCommandsReplace.Click, New EventHandler(AddressOf Me.mnuCommandsReplace_Click)
                End If
                Me._mnuCommandsReplace = WithEventsValue
                If (Not Me._mnuCommandsReplace Is Nothing) Then
                    AddHandler Me._mnuCommandsReplace.Click, New EventHandler(AddressOf Me.mnuCommandsReplace_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuCommandsSplit As ToolStripMenuItem
            Get
                Return Me._mnuCommandsSplit
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsSplit Is Nothing) Then
                    RemoveHandler Me._mnuCommandsSplit.Click, New EventHandler(AddressOf Me.mnuCommandsSplit_Click)
                End If
                Me._mnuCommandsSplit = WithEventsValue
                If (Not Me._mnuCommandsSplit Is Nothing) Then
                    AddHandler Me._mnuCommandsSplit.Click, New EventHandler(AddressOf Me.mnuCommandsSplit_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator1 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuCommandsEscape As ToolStripMenuItem
            Get
                Return Me._mnuCommandsEscape
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsEscape Is Nothing) Then
                    RemoveHandler Me._mnuCommandsEscape.Click, New EventHandler(AddressOf Me.mnuCommandsEscape_Click)
                End If
                Me._mnuCommandsEscape = WithEventsValue
                If (Not Me._mnuCommandsEscape Is Nothing) Then
                    AddHandler Me._mnuCommandsEscape.Click, New EventHandler(AddressOf Me.mnuCommandsEscape_Click)
                End If
            End Set
        End Property

        Friend Overridable Property lblReplace As Label
            Get
                Return Me._lblReplace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblReplace = WithEventsValue
            End Set
        End Property

        Friend Overridable Property StatusStrip1 As StatusStrip
            Get
                Return Me._StatusStrip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As StatusStrip)
                Me._StatusStrip1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property staExecutionTime As ToolStripStatusLabel
            Get
                Return Me._staExecutionTime
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripStatusLabel)
                Me._staExecutionTime = WithEventsValue
            End Set
        End Property

        Friend Overridable Property staMatches As ToolStripStatusLabel
            Get
                Return Me._staMatches
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripStatusLabel)
                Me._staMatches = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tvwResults As TreeView
            Get
                Return Me._tvwResults
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TreeView)
                If (Not Me._tvwResults Is Nothing) Then
                    RemoveHandler Me._tvwResults.BeforeExpand, New TreeViewCancelEventHandler(AddressOf Me.tvwResults_BeforeExpand)
                    RemoveHandler Me._tvwResults.AfterSelect, New TreeViewEventHandler(AddressOf Me.tvwResults_AfterSelect)
                End If
                Me._tvwResults = WithEventsValue
                If (Not Me._tvwResults Is Nothing) Then
                    AddHandler Me._tvwResults.BeforeExpand, New TreeViewCancelEventHandler(AddressOf Me.tvwResults_BeforeExpand)
                    AddHandler Me._tvwResults.AfterSelect, New TreeViewEventHandler(AddressOf Me.tvwResults_AfterSelect)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsGroups As ToolStripMenuItem
            Get
                Return Me._mnuResultsGroups
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsGroups Is Nothing) Then
                    RemoveHandler Me._mnuResultsGroups.Click, New EventHandler(AddressOf Me.mnuResultsGroups_Click)
                End If
                Me._mnuResultsGroups = WithEventsValue
                If (Not Me._mnuResultsGroups Is Nothing) Then
                    AddHandler Me._mnuResultsGroups.Click, New EventHandler(AddressOf Me.mnuResultsGroups_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsCaptures As ToolStripMenuItem
            Get
                Return Me._mnuResultsCaptures
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsCaptures Is Nothing) Then
                    RemoveHandler Me._mnuResultsCaptures.Click, New EventHandler(AddressOf Me.mnuResultsCaptures_Click)
                End If
                Me._mnuResultsCaptures = WithEventsValue
                If (Not Me._mnuResultsCaptures Is Nothing) Then
                    AddHandler Me._mnuResultsCaptures.Click, New EventHandler(AddressOf Me.mnuResultsCaptures_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsNoDetails As ToolStripMenuItem
            Get
                Return Me._mnuResultsNoDetails
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsNoDetails Is Nothing) Then
                    RemoveHandler Me._mnuResultsNoDetails.Click, New EventHandler(AddressOf Me.mnuResultsNoDetails_Click)
                End If
                Me._mnuResultsNoDetails = WithEventsValue
                If (Not Me._mnuResultsNoDetails Is Nothing) Then
                    AddHandler Me._mnuResultsNoDetails.Click, New EventHandler(AddressOf Me.mnuResultsNoDetails_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator2 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuResultsDontSort As ToolStripMenuItem
            Get
                Return Me._mnuResultsDontSort
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsDontSort Is Nothing) Then
                    RemoveHandler Me._mnuResultsDontSort.Click, New EventHandler(AddressOf Me.mnuResultsDontSort_Click)
                End If
                Me._mnuResultsDontSort = WithEventsValue
                If (Not Me._mnuResultsDontSort Is Nothing) Then
                    AddHandler Me._mnuResultsDontSort.Click, New EventHandler(AddressOf Me.mnuResultsDontSort_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsSortAlphabetically As ToolStripMenuItem
            Get
                Return Me._mnuResultsSortAlphabetically
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsSortAlphabetically Is Nothing) Then
                    RemoveHandler Me._mnuResultsSortAlphabetically.Click, New EventHandler(AddressOf Me.mnuResultsSortAlphabetically_Click)
                End If
                Me._mnuResultsSortAlphabetically = WithEventsValue
                If (Not Me._mnuResultsSortAlphabetically Is Nothing) Then
                    AddHandler Me._mnuResultsSortAlphabetically.Click, New EventHandler(AddressOf Me.mnuResultsSortAlphabetically_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsShortest As ToolStripMenuItem
            Get
                Return Me._mnuResultsShortest
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsShortest Is Nothing) Then
                    RemoveHandler Me._mnuResultsShortest.Click, New EventHandler(AddressOf Me.mnuResultsShortest_Click)
                End If
                Me._mnuResultsShortest = WithEventsValue
                If (Not Me._mnuResultsShortest Is Nothing) Then
                    AddHandler Me._mnuResultsShortest.Click, New EventHandler(AddressOf Me.mnuResultsShortest_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsLargest As ToolStripMenuItem
            Get
                Return Me._mnuResultsLargest
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsLargest Is Nothing) Then
                    RemoveHandler Me._mnuResultsLargest.Click, New EventHandler(AddressOf Me.mnuResultsLargest_Click)
                End If
                Me._mnuResultsLargest = WithEventsValue
                If (Not Me._mnuResultsLargest Is Nothing) Then
                    AddHandler Me._mnuResultsLargest.Click, New EventHandler(AddressOf Me.mnuResultsLargest_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox1 As ToolStripMenuItem
            Get
                Return Me._ToolStripTextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._ToolStripTextBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtViewMaxMatches As ToolStripTextBox
            Get
                Return Me._txtViewMaxMatches
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripTextBox)
                If (Not Me._txtViewMaxMatches Is Nothing) Then
                    RemoveHandler Me._txtViewMaxMatches.TextChanged, New EventHandler(AddressOf Me.txtViewMaxMatches_Click)
                End If
                Me._txtViewMaxMatches = WithEventsValue
                If (Not Me._txtViewMaxMatches Is Nothing) Then
                    AddHandler Me._txtViewMaxMatches.TextChanged, New EventHandler(AddressOf Me.txtViewMaxMatches_Click)
                End If
            End Set
        End Property

        Friend Overridable Property rtbResults As RichTextBox
            Get
                Return Me._rtbResults
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbResults = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ToolStripMenuItem1 As ToolStripSeparator
            Get
                Return Me._ToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripMenuItem1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ctxPattern As ContextMenuStrip
            Get
                Return Me._ctxPattern
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ContextMenuStrip)
                Me._ctxPattern = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ctxReplace As ContextMenuStrip
            Get
                Return Me._ctxReplace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ContextMenuStrip)
                Me._ctxReplace = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbRegex As RichTextBox
            Get
                Return Me._rtbRegex
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbRegex = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbReplace As RichTextBox
            Get
                Return Me._rtbReplace
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbReplace = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuCommandsRun As ToolStripMenuItem
            Get
                Return Me._mnuCommandsRun
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsRun Is Nothing) Then
                    RemoveHandler Me._mnuCommandsRun.Click, New EventHandler(AddressOf Me.mnuCommandsRun_Click)
                End If
                Me._mnuCommandsRun = WithEventsValue
                If (Not Me._mnuCommandsRun Is Nothing) Then
                    AddHandler Me._mnuCommandsRun.Click, New EventHandler(AddressOf Me.mnuCommandsRun_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator3 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuFileSave As ToolStripMenuItem
            Get
                Return Me._mnuFileSave
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileSave Is Nothing) Then
                    RemoveHandler Me._mnuFileSave.Click, New EventHandler(AddressOf Me.mnuFileSave_Click)
                End If
                Me._mnuFileSave = WithEventsValue
                If (Not Me._mnuFileSave Is Nothing) Then
                    AddHandler Me._mnuFileSave.Click, New EventHandler(AddressOf Me.mnuFileSave_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuFileSaveAs As ToolStripMenuItem
            Get
                Return Me._mnuFileSaveAs
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileSaveAs Is Nothing) Then
                    RemoveHandler Me._mnuFileSaveAs.Click, New EventHandler(AddressOf Me.mnuFileSaveAs_Click)
                End If
                Me._mnuFileSaveAs = WithEventsValue
                If (Not Me._mnuFileSaveAs Is Nothing) Then
                    AddHandler Me._mnuFileSaveAs.Click, New EventHandler(AddressOf Me.mnuFileSaveAs_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator4 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuFileProperties As ToolStripMenuItem
            Get
                Return Me._mnuFileProperties
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileProperties Is Nothing) Then
                    RemoveHandler Me._mnuFileProperties.Click, New EventHandler(AddressOf Me.mnuFileProperties_Click)
                End If
                Me._mnuFileProperties = WithEventsValue
                If (Not Me._mnuFileProperties Is Nothing) Then
                    AddHandler Me._mnuFileProperties.Click, New EventHandler(AddressOf Me.mnuFileProperties_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator5 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuFileLoad As ToolStripMenuItem
            Get
                Return Me._mnuFileLoad
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileLoad Is Nothing) Then
                    RemoveHandler Me._mnuFileLoad.Click, New EventHandler(AddressOf Me.mnuFileLoad_Click)
                End If
                Me._mnuFileLoad = WithEventsValue
                If (Not Me._mnuFileLoad Is Nothing) Then
                    AddHandler Me._mnuFileLoad.Click, New EventHandler(AddressOf Me.mnuFileLoad_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator6 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuFileExit As ToolStripMenuItem
            Get
                Return Me._mnuFileExit
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuFileExit Is Nothing) Then
                    RemoveHandler Me._mnuFileExit.Click, New EventHandler(AddressOf Me.mnuFileExit_Click)
                End If
                Me._mnuFileExit = WithEventsValue
                If (Not Me._mnuFileExit Is Nothing) Then
                    AddHandler Me._mnuFileExit.Click, New EventHandler(AddressOf Me.mnuFileExit_Click)
                End If
            End Set
        End Property

        Friend Overridable Property staItemInfo As ToolStripStatusLabel
            Get
                Return Me._staItemInfo
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripStatusLabel)
                Me._staItemInfo = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuResultsTreeView As ToolStripMenuItem
            Get
                Return Me._mnuResultsTreeView
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsTreeView Is Nothing) Then
                    RemoveHandler Me._mnuResultsTreeView.Click, New EventHandler(AddressOf Me.mnuResultsTreeView_Click)
                End If
                Me._mnuResultsTreeView = WithEventsValue
                If (Not Me._mnuResultsTreeView Is Nothing) Then
                    AddHandler Me._mnuResultsTreeView.Click, New EventHandler(AddressOf Me.mnuResultsTreeView_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsReport As ToolStripMenuItem
            Get
                Return Me._mnuResultsReport
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsReport Is Nothing) Then
                    RemoveHandler Me._mnuResultsReport.Click, New EventHandler(AddressOf Me.mnuResultsReport_Click)
                End If
                Me._mnuResultsReport = WithEventsValue
                If (Not Me._mnuResultsReport Is Nothing) Then
                    AddHandler Me._mnuResultsReport.Click, New EventHandler(AddressOf Me.mnuResultsReport_Click)
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator7 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripSeparator)
                Me._ToolStripSeparator7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMatches As Label
            Get
                Return Me._lblMatches
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblMatches = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuResultsAuto As ToolStripMenuItem
            Get
                Return Me._mnuResultsAuto
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsAuto Is Nothing) Then
                    RemoveHandler Me._mnuResultsAuto.Click, New EventHandler(AddressOf Me.mnuResultsAuto_Click)
                End If
                Me._mnuResultsAuto = WithEventsValue
                If (Not Me._mnuResultsAuto Is Nothing) Then
                    AddHandler Me._mnuResultsAuto.Click, New EventHandler(AddressOf Me.mnuResultsAuto_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuEdit As ToolStripMenuItem
            Get
                Return Me._mnuEdit
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuEdit = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuEditWordWrap As ToolStripMenuItem
            Get
                Return Me._mnuEditWordWrap
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuEditWordWrap Is Nothing) Then
                    RemoveHandler Me._mnuEditWordWrap.Click, New EventHandler(AddressOf Me.mnuEditWordWrap_Click)
                End If
                Me._mnuEditWordWrap = WithEventsValue
                If (Not Me._mnuEditWordWrap Is Nothing) Then
                    AddHandler Me._mnuEditWordWrap.Click, New EventHandler(AddressOf Me.mnuEditWordWrap_Click)
                End If
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

        Friend Overridable Property dlgSaveRegex As SaveFileDialog
            Get
                Return Me._dlgSaveRegex
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As SaveFileDialog)
                Me._dlgSaveRegex = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuCommandsGenerateCode As ToolStripMenuItem
            Get
                Return Me._mnuCommandsGenerateCode
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsGenerateCode Is Nothing) Then
                    RemoveHandler Me._mnuCommandsGenerateCode.Click, New EventHandler(AddressOf Me.mnuCommandsGenerateCode_Click)
                End If
                Me._mnuCommandsGenerateCode = WithEventsValue
                If (Not Me._mnuCommandsGenerateCode Is Nothing) Then
                    AddHandler Me._mnuCommandsGenerateCode.Click, New EventHandler(AddressOf Me.mnuCommandsGenerateCode_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuCommandsShowGroups As ToolStripMenuItem
            Get
                Return Me._mnuCommandsShowGroups
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsShowGroups Is Nothing) Then
                    RemoveHandler Me._mnuCommandsShowGroups.Click, New EventHandler(AddressOf Me.mnuCommandsShowGroups_Click)
                End If
                Me._mnuCommandsShowGroups = WithEventsValue
                If (Not Me._mnuCommandsShowGroups Is Nothing) Then
                    AddHandler Me._mnuCommandsShowGroups.Click, New EventHandler(AddressOf Me.mnuCommandsShowGroups_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuResultsIncludeEmptyGroups As ToolStripMenuItem
            Get
                Return Me._mnuResultsIncludeEmptyGroups
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuResultsIncludeEmptyGroups Is Nothing) Then
                    RemoveHandler Me._mnuResultsIncludeEmptyGroups.Click, New EventHandler(AddressOf Me.mnuResultsIncludeEmptyGroups_Click)
                End If
                Me._mnuResultsIncludeEmptyGroups = WithEventsValue
                If (Not Me._mnuResultsIncludeEmptyGroups Is Nothing) Then
                    AddHandler Me._mnuResultsIncludeEmptyGroups.Click, New EventHandler(AddressOf Me.mnuResultsIncludeEmptyGroups_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuCommandsCompile As ToolStripMenuItem
            Get
                Return Me._mnuCommandsCompile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuCommandsCompile Is Nothing) Then
                    RemoveHandler Me._mnuCommandsCompile.Click, New EventHandler(AddressOf Me.mnuCommandsCompile_Click)
                End If
                Me._mnuCommandsCompile = WithEventsValue
                If (Not Me._mnuCommandsCompile Is Nothing) Then
                    AddHandler Me._mnuCommandsCompile.Click, New EventHandler(AddressOf Me.mnuCommandsCompile_Click)
                End If
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

        Friend Overridable Property mnuHelp As ToolStripMenuItem
            Get
                Return Me._mnuHelp
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                Me._mnuHelp = WithEventsValue
            End Set
        End Property

        Friend Overridable Property mnuHelpAbout As ToolStripMenuItem
            Get
                Return Me._mnuHelpAbout
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuHelpAbout Is Nothing) Then
                    RemoveHandler Me._mnuHelpAbout.Click, New EventHandler(AddressOf Me.mnuHelpAbout_Click)
                End If
                Me._mnuHelpAbout = WithEventsValue
                If (Not Me._mnuHelpAbout Is Nothing) Then
                    AddHandler Me._mnuHelpAbout.Click, New EventHandler(AddressOf Me.mnuHelpAbout_Click)
                End If
            End Set
        End Property

        Friend Overridable Property mnuOptionsSingleline As ToolStripMenuItem
            Get
                Return Me._mnuOptionsSingleline
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ToolStripMenuItem)
                If (Not Me._mnuOptionsSingleline Is Nothing) Then
                    RemoveHandler Me._mnuOptionsSingleline.Click, New EventHandler(AddressOf Me.mnuOptionsSingleline_Click)
                End If
                Me._mnuOptionsSingleline = WithEventsValue
                If (Not Me._mnuOptionsSingleline Is Nothing) Then
                    AddHandler Me._mnuOptionsSingleline.Click, New EventHandler(AddressOf Me.mnuOptionsSingleline_Click)
                End If
            End Set
        End Property


        ' Fields
        Private components As IContainer
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("MenuStrip1")> _
        Private _MenuStrip1 As MenuStrip
        <AccessedThroughProperty("mnuFile")> _
        Private _mnuFile As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptions")> _
        Private _mnuOptions As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsIgnoreCase")> _
        Private _mnuOptionsIgnoreCase As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsMultiline")> _
        Private _mnuOptionsMultiline As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsIgnoreWhitespace")> _
        Private _mnuOptionsIgnoreWhitespace As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsCompiled")> _
        Private _mnuOptionsCompiled As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsExplicitCapture")> _
        Private _mnuOptionsExplicitCapture As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsRightToLeft")> _
        Private _mnuOptionsRightToLeft As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsCultureInvariant")> _
        Private _mnuOptionsCultureInvariant As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsEcmaScript")> _
        Private _mnuOptionsEcmaScript As ToolStripMenuItem
        <AccessedThroughProperty("mnuFileOpen")> _
        Private _mnuFileOpen As ToolStripMenuItem
        <AccessedThroughProperty("dlgOpenDoc")> _
        Private _dlgOpenDoc As OpenFileDialog
        <AccessedThroughProperty("rtbSource")> _
        Private _rtbSource As RichTextBox
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("mnuFileNew")> _
        Private _mnuFileNew As ToolStripMenuItem
        <AccessedThroughProperty("mnuResults")> _
        Private _mnuResults As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommands")> _
        Private _mnuCommands As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommandsFind")> _
        Private _mnuCommandsFind As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommandsReplace")> _
        Private _mnuCommandsReplace As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommandsSplit")> _
        Private _mnuCommandsSplit As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator1")> _
        Private _ToolStripSeparator1 As ToolStripSeparator
        <AccessedThroughProperty("mnuCommandsEscape")> _
        Private _mnuCommandsEscape As ToolStripMenuItem
        <AccessedThroughProperty("lblReplace")> _
        Private _lblReplace As Label
        <AccessedThroughProperty("StatusStrip1")> _
        Private _StatusStrip1 As StatusStrip
        <AccessedThroughProperty("staExecutionTime")> _
        Private _staExecutionTime As ToolStripStatusLabel
        <AccessedThroughProperty("staMatches")> _
        Private _staMatches As ToolStripStatusLabel
        <AccessedThroughProperty("tvwResults")> _
        Private _tvwResults As TreeView
        <AccessedThroughProperty("mnuResultsGroups")> _
        Private _mnuResultsGroups As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsCaptures")> _
        Private _mnuResultsCaptures As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsNoDetails")> _
        Private _mnuResultsNoDetails As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator2")> _
        Private _ToolStripSeparator2 As ToolStripSeparator
        <AccessedThroughProperty("mnuResultsDontSort")> _
        Private _mnuResultsDontSort As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsSortAlphabetically")> _
        Private _mnuResultsSortAlphabetically As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsShortest")> _
        Private _mnuResultsShortest As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsLargest")> _
        Private _mnuResultsLargest As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripTextBox1")> _
        Private _ToolStripTextBox1 As ToolStripMenuItem
        <AccessedThroughProperty("txtViewMaxMatches")> _
        Private _txtViewMaxMatches As ToolStripTextBox
        <AccessedThroughProperty("rtbResults")> _
        Private _rtbResults As RichTextBox
        <AccessedThroughProperty("ToolStripMenuItem1")> _
        Private _ToolStripMenuItem1 As ToolStripSeparator
        <AccessedThroughProperty("ctxPattern")> _
        Private _ctxPattern As ContextMenuStrip
        <AccessedThroughProperty("ctxReplace")> _
        Private _ctxReplace As ContextMenuStrip
        <AccessedThroughProperty("rtbRegex")> _
        Private _rtbRegex As RichTextBox
        <AccessedThroughProperty("rtbReplace")> _
        Private _rtbReplace As RichTextBox
        <AccessedThroughProperty("mnuCommandsRun")> _
        Private _mnuCommandsRun As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator3")> _
        Private _ToolStripSeparator3 As ToolStripSeparator
        <AccessedThroughProperty("mnuFileSave")> _
        Private _mnuFileSave As ToolStripMenuItem
        <AccessedThroughProperty("mnuFileSaveAs")> _
        Private _mnuFileSaveAs As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator4")> _
        Private _ToolStripSeparator4 As ToolStripSeparator
        <AccessedThroughProperty("mnuFileProperties")> _
        Private _mnuFileProperties As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator5")> _
        Private _ToolStripSeparator5 As ToolStripSeparator
        <AccessedThroughProperty("mnuFileLoad")> _
        Private _mnuFileLoad As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator6")> _
        Private _ToolStripSeparator6 As ToolStripSeparator
        <AccessedThroughProperty("mnuFileExit")> _
        Private _mnuFileExit As ToolStripMenuItem
        <AccessedThroughProperty("staItemInfo")> _
        Private _staItemInfo As ToolStripStatusLabel
        <AccessedThroughProperty("mnuResultsTreeView")> _
        Private _mnuResultsTreeView As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsReport")> _
        Private _mnuResultsReport As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator7")> _
        Private _ToolStripSeparator7 As ToolStripSeparator
        <AccessedThroughProperty("lblMatches")> _
        Private _lblMatches As Label
        <AccessedThroughProperty("mnuResultsAuto")> _
        Private _mnuResultsAuto As ToolStripMenuItem
        <AccessedThroughProperty("mnuEdit")> _
        Private _mnuEdit As ToolStripMenuItem
        <AccessedThroughProperty("mnuEditWordWrap")> _
        Private _mnuEditWordWrap As ToolStripMenuItem
        <AccessedThroughProperty("dlgOpenRegex")> _
        Private _dlgOpenRegex As OpenFileDialog
        <AccessedThroughProperty("dlgSaveRegex")> _
        Private _dlgSaveRegex As SaveFileDialog
        <AccessedThroughProperty("mnuCommandsGenerateCode")> _
        Private _mnuCommandsGenerateCode As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommandsShowGroups")> _
        Private _mnuCommandsShowGroups As ToolStripMenuItem
        <AccessedThroughProperty("mnuResultsIncludeEmptyGroups")> _
        Private _mnuResultsIncludeEmptyGroups As ToolStripMenuItem
        <AccessedThroughProperty("mnuCommandsCompile")> _
        Private _mnuCommandsCompile As ToolStripMenuItem
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        <AccessedThroughProperty("HelpProvider1")> _
        Private _HelpProvider1 As HelpProvider
        <AccessedThroughProperty("mnuHelp")> _
        Private _mnuHelp As ToolStripMenuItem
        <AccessedThroughProperty("mnuHelpAbout")> _
        Private _mnuHelpAbout As ToolStripMenuItem
        <AccessedThroughProperty("mnuOptionsSingleline")> _
        Private _mnuOptionsSingleline As ToolStripMenuItem
        Friend Options As ProjectOptions
        Friend re As Regex
        Friend CompileForm As CompileForm
    End Class
End Namespace

