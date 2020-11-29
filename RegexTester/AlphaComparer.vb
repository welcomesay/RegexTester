Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Namespace RegexTester
    Public Class AlphaComparer
        Implements IComparer(Of Match)
        ' Methods
        Public Function [Compare](ByVal x As Match, ByVal y As Match) As Integer Implements IComparer(Of Match).Compare
            Return String.Compare(x.Value, y.Value, True)
        End Function

    End Class
End Namespace

