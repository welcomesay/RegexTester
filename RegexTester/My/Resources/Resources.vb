Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices

Namespace RegexTester.My.Resources
    <HideModuleName, CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), StandardModule, DebuggerNonUserCode> _
    Friend NotInheritable Class Resources
        ' Properties
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend Shared ReadOnly Property ResourceManager As ResourceManager
            Get
                If Object.ReferenceEquals(Resources.resourceMan, Nothing) Then
                    Dim manager2 As New ResourceManager("RegexTester.Resources", GetType(Resources).Assembly)
                    Resources.resourceMan = manager2
                End If
                Return Resources.resourceMan
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend Shared Property Culture As CultureInfo
            Get
                Return Resources.resourceCulture
            End Get
            Set(ByVal Value As CultureInfo)
                Resources.resourceCulture = Value
            End Set
        End Property


        ' Fields
        Private Shared resourceMan As ResourceManager
        Private Shared resourceCulture As CultureInfo
    End Class
End Namespace

