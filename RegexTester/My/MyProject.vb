Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports RegexTester
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace RegexTester.My
    <StandardModule, GeneratedCode("MyTemplate", "8.0.0.0"), HideModuleName> _
    Friend NotInheritable Class MyProject
        ' Properties
        <HelpKeyword("My.Computer")> _
        Friend Shared ReadOnly Property Computer As MyComputer
            <DebuggerHidden> _
            Get
                Return MyProject.m_ComputerObjectProvider.GetInstance
            End Get
        End Property

        <HelpKeyword("My.Application")> _
        Friend Shared ReadOnly Property Application As MyApplication
            <DebuggerHidden> _
            Get
                Return MyProject.m_AppObjectProvider.GetInstance
            End Get
        End Property

        <HelpKeyword("My.User")> _
        Friend Shared ReadOnly Property User As User
            <DebuggerHidden> _
            Get
                Return MyProject.m_UserObjectProvider.GetInstance
            End Get
        End Property

        <HelpKeyword("My.Forms")> _
        Friend Shared ReadOnly Property Forms As MyForms
            <DebuggerHidden> _
            Get
                Return MyProject.m_MyFormsObjectProvider.GetInstance
            End Get
        End Property

        <HelpKeyword("My.WebServices")> _
        Friend Shared ReadOnly Property WebServices As MyWebServices
            <DebuggerHidden> _
            Get
                Return MyProject.m_MyWebServicesObjectProvider.GetInstance
            End Get
        End Property


        ' Fields
        Private Shared ReadOnly m_ComputerObjectProvider As ThreadSafeObjectProvider(Of MyComputer) = New ThreadSafeObjectProvider(Of MyComputer)
        Private Shared ReadOnly m_AppObjectProvider As ThreadSafeObjectProvider(Of MyApplication) = New ThreadSafeObjectProvider(Of MyApplication)
        Private Shared ReadOnly m_UserObjectProvider As ThreadSafeObjectProvider(Of User) = New ThreadSafeObjectProvider(Of User)
        Private Shared m_MyFormsObjectProvider As ThreadSafeObjectProvider(Of MyForms) = New ThreadSafeObjectProvider(Of MyForms)
        Private Shared ReadOnly m_MyWebServicesObjectProvider As ThreadSafeObjectProvider(Of MyWebServices) = New ThreadSafeObjectProvider(Of MyWebServices)

        ' Nested Types
        <EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")> _
        Friend NotInheritable Class MyForms
            ' Methods
            <DebuggerHidden> _
            Private Shared Function Create__Instance__(Of T As { Form, New })(ByVal Instance As T) As T
                If ((Instance Is Nothing) OrElse Instance.IsDisposed) Then
                    If (Not MyForms.m_FormBeingCreated Is Nothing) Then
                        If MyForms.m_FormBeingCreated.ContainsKey(GetType(T)) Then
                            Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(0  - 1) {}))
                        End If
                    Else
                        MyForms.m_FormBeingCreated = New Hashtable
                    End If
                    MyForms.m_FormBeingCreated.Add(GetType(T), Nothing)
                    Try 
                        Return Activator.CreateInstance(Of T)
                    Catch obj1 As Object When (?)
                        Dim exception As TargetInvocationException
                        Throw New InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", New String() { exception.InnerException.Message }), exception.InnerException)
                    Finally
                        MyForms.m_FormBeingCreated.Remove(GetType(T))
                    End Try
                End If
                Return Instance
            End Function

            <DebuggerHidden> _
            Private Sub Dispose__Instance__(Of T As Form)(ByRef instance As T)
                instance.Dispose
                instance = CType(Nothing, T)
            End Sub

            <EditorBrowsable(EditorBrowsableState.Never)> _
            Public Overrides Function Equals(ByVal o As Object) As Boolean
                Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
            End Function

            <EditorBrowsable(EditorBrowsableState.Never)> _
            Public Overrides Function GetHashCode() As Integer
                Return MyBase.GetHashCode
            End Function

            <EditorBrowsable(EditorBrowsableState.Never)> _
            Friend Function [GetType]() As Type
                Return GetType(MyForms)
            End Function

            <EditorBrowsable(EditorBrowsableState.Never)> _
            Public Overrides Function ToString() As String
                Return MyBase.ToString
            End Function


            ' Properties
            Public Property AboutBoxForm As AboutBoxForm
                Get
                    Me.m_AboutBoxForm = MyForms.Create__Instance__(Of AboutBoxForm)(Me.m_AboutBoxForm)
                    Return Me.m_AboutBoxForm
                End Get
                Set(ByVal Value As AboutBoxForm)
                    If (Not Value Is Me.m_AboutBoxForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of AboutBoxForm)(Me.m_AboutBoxForm)
                    End If
                End Set
            End Property

            Public Property CompileForm As CompileForm
                Get
                    Me.m_CompileForm = MyForms.Create__Instance__(Of CompileForm)(Me.m_CompileForm)
                    Return Me.m_CompileForm
                End Get
                Set(ByVal Value As CompileForm)
                    If (Not Value Is Me.m_CompileForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of CompileForm)(Me.m_CompileForm)
                    End If
                End Set
            End Property

            Public Property EscapeForm As EscapeForm
                Get
                    Me.m_EscapeForm = MyForms.Create__Instance__(Of EscapeForm)(Me.m_EscapeForm)
                    Return Me.m_EscapeForm
                End Get
                Set(ByVal Value As EscapeForm)
                    If (Not Value Is Me.m_EscapeForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of EscapeForm)(Me.m_EscapeForm)
                    End If
                End Set
            End Property

            Public Property GenerateCodeForm As GenerateCodeForm
                Get
                    Me.m_GenerateCodeForm = MyForms.Create__Instance__(Of GenerateCodeForm)(Me.m_GenerateCodeForm)
                    Return Me.m_GenerateCodeForm
                End Get
                Set(ByVal Value As GenerateCodeForm)
                    If (Not Value Is Me.m_GenerateCodeForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of GenerateCodeForm)(Me.m_GenerateCodeForm)
                    End If
                End Set
            End Property

            Public Property MainForm As MainForm
                Get
                    Me.m_MainForm = MyForms.Create__Instance__(Of MainForm)(Me.m_MainForm)
                    Return Me.m_MainForm
                End Get
                Set(ByVal Value As MainForm)
                    If (Not Value Is Me.m_MainForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of MainForm)(Me.m_MainForm)
                    End If
                End Set
            End Property

            Public Property PropertiesForm As PropertiesForm
                Get
                    Me.m_PropertiesForm = MyForms.Create__Instance__(Of PropertiesForm)(Me.m_PropertiesForm)
                    Return Me.m_PropertiesForm
                End Get
                Set(ByVal Value As PropertiesForm)
                    If (Not Value Is Me.m_PropertiesForm) Then
                        If (Not Value Is Nothing) Then
                            Throw New ArgumentException("Property can only be set to Nothing")
                        End If
                        Me.Dispose__Instance__(Of PropertiesForm)(Me.m_PropertiesForm)
                    End If
                End Set
            End Property


            ' Fields
            Public m_AboutBoxForm As AboutBoxForm
            Public m_CompileForm As CompileForm
            Public m_EscapeForm As EscapeForm
            Public m_GenerateCodeForm As GenerateCodeForm
            Public m_MainForm As MainForm
            Public m_PropertiesForm As PropertiesForm
            <ThreadStatic> _
            Private Shared m_FormBeingCreated As Hashtable
        End Class

        <EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")> _
        Friend NotInheritable Class MyWebServices
            ' Methods
            <DebuggerHidden> _
            Private Shared Function Create__Instance__(Of T As New)(ByVal instance As T) As T
                If (instance Is Nothing) Then
                    Return Activator.CreateInstance(Of T)
                End If
                Return instance
            End Function

            <DebuggerHidden> _
            Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
                instance = CType(Nothing, T)
            End Sub

            <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
            Public Overrides Function Equals(ByVal o As Object) As Boolean
                Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
            End Function

            <EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden> _
            Public Overrides Function GetHashCode() As Integer
                Return MyBase.GetHashCode
            End Function

            <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
            Friend Function [GetType]() As Type
                Return GetType(MyWebServices)
            End Function

            <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
            Public Overrides Function ToString() As String
                Return MyBase.ToString
            End Function

        End Class

        <ComVisible(False), EditorBrowsable(EditorBrowsableState.Never)> _
        Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
            ' Properties
            Friend ReadOnly Property GetInstance As T
                <DebuggerHidden> _
                Get
                    If (ThreadSafeObjectProvider(Of T).m_ThreadStaticValue Is Nothing) Then
                        ThreadSafeObjectProvider(Of T).m_ThreadStaticValue = Activator.CreateInstance(Of T)
                    End If
                    Return ThreadSafeObjectProvider(Of T).m_ThreadStaticValue
                End Get
            End Property


            ' Fields
            <ThreadStatic, CompilerGenerated> _
            Private Shared m_ThreadStaticValue As T
        End Class
    End Class
End Namespace

