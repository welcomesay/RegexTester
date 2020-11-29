Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports RegexTester.My
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace RegexTester
    <EditorBrowsable(EditorBrowsableState.Advanced), GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0"), CompilerGenerated> _
    Friend NotInheritable Class Settings
        Inherits ApplicationSettingsBase
        ' Methods
        <DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private Shared Sub AutoSaveSettings(ByVal sender As Object, ByVal e As EventArgs)
            If MyProject.Application.SaveMySettingsOnExit Then
                MySettingsProperty.Settings.Save
            End If
        End Sub


        ' Properties
        Public Shared ReadOnly Property [Default] As Settings
            Get
                If Not Settings.addedHandler Then
                    Dim addedHandlerLockObject As Object = Settings.addedHandlerLockObject
                    ObjectFlowControl.CheckForSyncLockOnValueType(addedHandlerLockObject)
                    SyncLock addedHandlerLockObject
                        If Not Settings.addedHandler Then
                            AddHandler MyProject.Application.Shutdown, New ShutdownEventHandler(AddressOf Settings.AutoSaveSettings)
                            Settings.addedHandler = True
                        End If
                    End SyncLock
                End If
                Return Settings.defaultInstance
            End Get
        End Property


        ' Fields
        Private Shared defaultInstance As Settings = DirectCast(SettingsBase.Synchronized(New Settings), Settings)
        Private Shared addedHandler As Boolean
        Private Shared addedHandlerLockObject As Object = RuntimeHelpers.GetObjectValue(New Object)
    End Class
End Namespace

