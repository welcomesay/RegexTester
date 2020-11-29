Imports Microsoft.VisualBasic.ApplicationServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace RegexTester.My
    <GeneratedCode("MyTemplate", "8.0.0.0"), EditorBrowsable(EditorBrowsableState.Never)> _
    Friend Class MyApplication
        Inherits WindowsFormsApplicationBase
        ' Methods
        <DebuggerStepThrough> _
        Public Sub New()
            MyBase.New(AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = False
            Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses
        End Sub

        <EditorBrowsable(EditorBrowsableState.Advanced), DebuggerHidden, STAThread> _
        Friend Shared Sub Main(ByVal Args As String())
            Try 
                Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering)
            End Try
            MyProject.Application.Run(Args)
        End Sub

        <DebuggerStepThrough> _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = MyProject.Forms.MainForm
        End Sub

    End Class
End Namespace

