using System.Windows.Forms;

namespace RegexTester.My
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.ApplicationServices;
    using Microsoft.VisualBasic.CompilerServices;
    using RegexTester;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StandardModule, GeneratedCode("MyTemplate", "8.0.0.0"), HideModuleName]
    internal sealed class MyProject
    {
        private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
        private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();
        private static readonly ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider = new ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();
        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();
        private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden]
            get
            {
                return m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden]
            get
            {
                return m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static Microsoft.VisualBasic.ApplicationServices.User User
        {
            [DebuggerHidden]
            get
            {
                return m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyForms Forms
        {
            [DebuggerHidden]
            get
            {
                return m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyWebServices WebServices
        {
            [DebuggerHidden]
            get
            {
                return m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        internal sealed class MyForms
        {
            public RegexTester.AboutBoxForm m_AboutBoxForm;
            public RegexTester.CompileForm m_CompileForm;
            public RegexTester.EscapeForm m_EscapeForm;
            public RegexTester.GenerateCodeForm m_GenerateCodeForm;
            public RegexTester.MainForm m_MainForm;
            public RegexTester.PropertiesForm m_PropertiesForm;
            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;

            [DebuggerHidden]
            private static T Create__Instance__<T>(T Instance) where T: Form, new()
            {
                if ((Instance == null) || Instance.IsDisposed)
                {
                    if (m_FormBeingCreated != null)
                    {
                        if (m_FormBeingCreated.ContainsKey(typeof(T)))
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                        }
                    }
                    else
                    {
                        m_FormBeingCreated = new Hashtable();
                    }
                    m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        return Activator.CreateInstance<T>();
                    }
                    catch 
                    {
                    }
                    finally
                    {
                        m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                return Instance;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance) where T: Form
            {
                instance.Dispose();
                instance = default(T);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }

            public RegexTester.AboutBoxForm AboutBoxForm
            {
                get
                {
                    this.m_AboutBoxForm = Create__Instance__<RegexTester.AboutBoxForm>(this.m_AboutBoxForm);
                    return this.m_AboutBoxForm;
                }
                set
                {
                    if (value != this.m_AboutBoxForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.AboutBoxForm>(ref this.m_AboutBoxForm);
                    }
                }
            }

            public RegexTester.CompileForm CompileForm
            {
                get
                {
                    this.m_CompileForm = Create__Instance__<RegexTester.CompileForm>(this.m_CompileForm);
                    return this.m_CompileForm;
                }
                set
                {
                    if (value != this.m_CompileForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.CompileForm>(ref this.m_CompileForm);
                    }
                }
            }

            public RegexTester.EscapeForm EscapeForm
            {
                get
                {
                    this.m_EscapeForm = Create__Instance__<RegexTester.EscapeForm>(this.m_EscapeForm);
                    return this.m_EscapeForm;
                }
                set
                {
                    if (value != this.m_EscapeForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.EscapeForm>(ref this.m_EscapeForm);
                    }
                }
            }

            public RegexTester.GenerateCodeForm GenerateCodeForm
            {
                get
                {
                    this.m_GenerateCodeForm = Create__Instance__<RegexTester.GenerateCodeForm>(this.m_GenerateCodeForm);
                    return this.m_GenerateCodeForm;
                }
                set
                {
                    if (value != this.m_GenerateCodeForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.GenerateCodeForm>(ref this.m_GenerateCodeForm);
                    }
                }
            }

            public RegexTester.MainForm MainForm
            {
                get
                {
                    this.m_MainForm = Create__Instance__<RegexTester.MainForm>(this.m_MainForm);
                    return this.m_MainForm;
                }
                set
                {
                    if (value != this.m_MainForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.MainForm>(ref this.m_MainForm);
                    }
                }
            }

            public RegexTester.PropertiesForm PropertiesForm
            {
                get
                {
                    this.m_PropertiesForm = Create__Instance__<RegexTester.PropertiesForm>(this.m_PropertiesForm);
                    return this.m_PropertiesForm;
                }
                set
                {
                    if (value != this.m_PropertiesForm)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RegexTester.PropertiesForm>(ref this.m_PropertiesForm);
                    }
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            [DebuggerHidden]
            private static T Create__Instance__<T>(T instance) where T: new()
            {
                if (instance == null)
                {
                    return Activator.CreateInstance<T>();
                }
                return instance;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            internal Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        [ComVisible(false), EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class ThreadSafeObjectProvider<T> where T: new()
        {
            [ThreadStatic, CompilerGenerated]
            private static T m_ThreadStaticValue;

            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
                    {
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
                    }
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
                }
            }
        }
    }
}

