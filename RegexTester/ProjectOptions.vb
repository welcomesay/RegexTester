Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Namespace RegexTester
    Public Class ProjectOptions
        ' Methods
        Public Sub ClearChanges()
            Me.LoadValues = DirectCast(Me.MemberwiseClone, ProjectOptions)
        End Sub

        Public Shared Function Load(ByVal fileName As String) As ProjectOptions
            Using stream As FileStream = New FileStream(fileName, FileMode.Open)
                Dim serializer As New XmlSerializer(GetType(ProjectOptions))
                Dim options2 As ProjectOptions = DirectCast(serializer.Deserialize(stream), ProjectOptions)
                options2.RegexFile = fileName
                options2.ClearChanges
                Return options2
            End Using
        End Function

        Public Sub Save(ByVal fileName As String)
            Using stream As FileStream = New FileStream(fileName, FileMode.Create)
                New XmlSerializer(GetType(ProjectOptions)).Serialize(DirectCast(stream, Stream), Me)
                Me.RegexFile = fileName
                Me.ClearChanges
            End Using
        End Sub


        ' Properties
        Public ReadOnly Property HasChanged As Boolean
            Get
                Return (((((Me.RegexText <> Me.LoadValues.RegexText) OrElse (Me.ReplaceText <> Me.LoadValues.ReplaceText)) OrElse ((Me.SourceText <> Me.LoadValues.SourceText) OrElse (Me.Command <> Me.LoadValues.Command))) OrElse (((Me.RegexOptions <> Me.LoadValues.RegexOptions) OrElse (Me.Detail <> Me.LoadValues.Detail)) OrElse ((Me.MaxMatches <> Me.LoadValues.MaxMatches) OrElse (Me.Sort <> Me.LoadValues.Sort)))) OrElse ((Me.Format <> Me.LoadValues.Format) OrElse (Me.WordWrap <> Me.LoadValues.WordWrap)))
            End Get
        End Property


        ' Fields
        <XmlIgnore> _
        Public RegexFile As String
        Public RegexName As String = ""
        Public RegexDescription As String = ""
        Public RegexText As String = ""
        Public ReplaceText As String = ""
        Public SourceText As String = ""
        Public Command As Command = Command.Find
        Public RegexOptions As RegexOptions
        Public Detail As DetailOption = DetailOption.Groups
        Public MaxMatches As Integer = &H3E8
        Public Sort As SortOption = SortOption.Position
        Public WordWrap As Boolean = True
        Public Format As FormatOption = FormatOption.Auto
        Public IncludeEmptyGroups As Boolean = True
        Public Language As LanguageOption = LanguageOption.VisualBasic
        Public VerbatimStrings As Boolean = False
        Public InstanceMethods As Boolean = True
        Public AssumeImports As Boolean = True
        Public GenerateLoop As Boolean = True
        Public IncludeComment As Boolean = True
        Public CopyCodeOnExit As Boolean = True
        <XmlIgnore> _
        Private LoadValues As ProjectOptions
    End Class
End Namespace

