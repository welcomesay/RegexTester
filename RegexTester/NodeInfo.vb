Imports System
Imports System.Text.RegularExpressions

Namespace RegexTester
    Friend Class NodeInfo
        ' Methods
        Public Sub New(ByVal item As Capture, ByVal name As String)
            Me.Item = item
            Me.Name = name
        End Sub


        ' Fields
        Public ReadOnly Item As Capture
        Public ReadOnly Name As String
    End Class
End Namespace

