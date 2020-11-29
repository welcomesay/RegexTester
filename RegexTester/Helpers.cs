namespace RegexTester
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;

    [StandardModule]
    internal sealed class Helpers
    {
        public static Control[] GetChildControls(Control ctrl)
        {
            IEnumerator enumerator;
            List<Control> list = new List<Control>();
            try
            {
                enumerator = ctrl.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    list.Add(current);
                    list.AddRange(GetChildControls(current));
                }
            }
            finally
            { 
            }
            return list.ToArray();
        }

        public static void SetTooltipsAndHelpMessages(Form frm, ToolTip tooltip, HelpProvider helpProv)
        {
            foreach (Control control in GetChildControls(frm))
            {
                string caption = tooltip.GetToolTip(control).Replace("?", "\r\n");
                tooltip.SetToolTip(control, caption);
                helpProv.SetHelpString(control, caption);
            }
        }
    }
}

