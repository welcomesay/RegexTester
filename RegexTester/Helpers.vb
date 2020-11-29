Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace RegexTester
    <StandardModule> _
    Friend NotInheritable Class Helpers
        ' Methods
        Public Shared Function GetChildControls(ByVal ctrl As Control) As Control()
            Dim enumerator As IEnumerator
            Dim list As New List(Of Control)
            Try 
                enumerator = ctrl.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As Control = DirectCast(enumerator.Current, Control)
                    list.Add(current)
                    list.AddRange(Helpers.GetChildControls(current))
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
            Return list.ToArray
        End Function

        Public Shared Sub SetTooltipsAndHelpMessages(ByVal frm As Form, ByVal tooltip As ToolTip, ByVal helpProv As HelpProvider)
            Dim control As Control
            For Each control In Helpers.GetChildControls(frm)
                Dim caption As String = tooltip.GetToolTip(control).Replace("?", ChrW(13) & ChrW(10))
                tooltip.SetToolTip(control, caption)
                helpProv.SetHelpString(control, caption)
            Next
        End Sub

    End Class
End Namespace

