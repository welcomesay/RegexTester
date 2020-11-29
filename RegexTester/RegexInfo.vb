Imports System
Imports System.Text.RegularExpressions

Namespace RegexTester
    Friend Class RegexInfo
        ' Methods
        Public Shared Function FromProjectOption(ByVal prjOptions As ProjectOptions) As RegexInfo
            Return New RegexInfo With { _
                .Name = prjOptions.RegexName, _
                .Pattern = prjOptions.RegexText, _
                .Options = prjOptions.RegexOptions _
            }
        End Function


        ' Properties
        Public Property Name As String
            Get
                Return Me.m_Name
            End Get
            Set(ByVal value As String)
                Me.m_Name = value
            End Set
        End Property

        Public Property Pattern As String
            Get
                Return Me.m_Pattern
            End Get
            Set(ByVal value As String)
                Me.m_Pattern = value
            End Set
        End Property

        Public Property Options As RegexOptions
            Get
                Return Me.m_Options
            End Get
            Set(ByVal value As RegexOptions)
                Me.m_Options = value
            End Set
        End Property

        Public Property OptionsText As String
            Get
                Dim str2 As String = ""
                If ((Me.m_Options And RegexOptions.IgnoreCase) > RegexOptions.None) Then
                    str2 = (str2 & "I")
                End If
                If ((Me.m_Options And RegexOptions.IgnorePatternWhitespace) > RegexOptions.None) Then
                    str2 = (str2 & "X")
                End If
                If ((Me.m_Options And RegexOptions.Multiline) > RegexOptions.None) Then
                    str2 = (str2 & "M")
                End If
                If ((Me.m_Options And RegexOptions.Compiled) > RegexOptions.None) Then
                    str2 = (str2 & "C")
                End If
                If ((Me.m_Options And RegexOptions.ExplicitCapture) > RegexOptions.None) Then
                    str2 = (str2 & "N")
                End If
                If ((Me.m_Options And RegexOptions.RightToLeft) > RegexOptions.None) Then
                    str2 = (str2 & "R")
                End If
                If ((Me.m_Options And RegexOptions.CultureInvariant) > RegexOptions.None) Then
                    str2 = (str2 & "U")
                End If
                If ((Me.m_Options And RegexOptions.ECMAScript) > RegexOptions.None) Then
                    str2 = (str2 & "A")
                End If
                Return str2
            End Get
            Set(ByVal value As String)
                value = value.ToUpper
                Me.m_Options = RegexOptions.None
                If value.Contains("I") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.IgnoreCase)
                End If
                If value.Contains("X") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.IgnorePatternWhitespace)
                End If
                If value.Contains("M") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.Multiline)
                End If
                If value.Contains("C") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.Compiled)
                End If
                If value.Contains("N") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.ExplicitCapture)
                End If
                If value.Contains("R") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.RightToLeft)
                End If
                If value.Contains("U") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.CultureInvariant)
                End If
                If value.Contains("A") Then
                    Me.m_Options = (Me.m_Options Or RegexOptions.ECMAScript)
                End If
            End Set
        End Property


        ' Fields
        Private m_Name As String = ""
        Private m_Pattern As String = ""
        Private m_Options As RegexOptions
    End Class
End Namespace

