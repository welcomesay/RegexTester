namespace RegexTester
{
    using System;
    using System.Text.RegularExpressions;

    internal class RegexInfo
    {
        private string m_Name = "";
        private string m_Pattern = "";
        private RegexOptions m_Options;

        public static RegexInfo FromProjectOption(ProjectOptions prjOptions)
        {
            RegexInfo info2 = new RegexInfo();
            info2.Name = prjOptions.RegexName;
            info2.Pattern = prjOptions.RegexText;
            info2.Options = prjOptions.RegexOptions;
            return info2;
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public string Pattern
        {
            get
            {
                return this.m_Pattern;
            }
            set
            {
                this.m_Pattern = value;
            }
        }

        public RegexOptions Options
        {
            get
            {
                return this.m_Options;
            }
            set
            {
                this.m_Options = value;
            }
        }

        public string OptionsText
        {
            get
            {
                string str2 = "";
                if ((this.m_Options & RegexOptions.IgnoreCase) > RegexOptions.None)
                {
                    str2 = str2 + "I";
                }
                if ((this.m_Options & RegexOptions.IgnorePatternWhitespace) > RegexOptions.None)
                {
                    str2 = str2 + "X";
                }
                if ((this.m_Options & RegexOptions.Multiline) > RegexOptions.None)
                {
                    str2 = str2 + "M";
                }
                if ((this.m_Options & RegexOptions.Compiled) > RegexOptions.None)
                {
                    str2 = str2 + "C";
                }
                if ((this.m_Options & RegexOptions.ExplicitCapture) > RegexOptions.None)
                {
                    str2 = str2 + "N";
                }
                if ((this.m_Options & RegexOptions.RightToLeft) > RegexOptions.None)
                {
                    str2 = str2 + "R";
                }
                if ((this.m_Options & RegexOptions.CultureInvariant) > RegexOptions.None)
                {
                    str2 = str2 + "U";
                }
                if ((this.m_Options & RegexOptions.ECMAScript) > RegexOptions.None)
                {
                    str2 = str2 + "A";
                }
                return str2;
            }
            set
            {
                value = value.ToUpper();
                this.m_Options = RegexOptions.None;
                if (value.Contains("I"))
                {
                    this.m_Options |= RegexOptions.IgnoreCase;
                }
                if (value.Contains("X"))
                {
                    this.m_Options |= RegexOptions.IgnorePatternWhitespace;
                }
                if (value.Contains("M"))
                {
                    this.m_Options |= RegexOptions.Multiline;
                }
                if (value.Contains("C"))
                {
                    this.m_Options |= RegexOptions.Compiled;
                }
                if (value.Contains("N"))
                {
                    this.m_Options |= RegexOptions.ExplicitCapture;
                }
                if (value.Contains("R"))
                {
                    this.m_Options |= RegexOptions.RightToLeft;
                }
                if (value.Contains("U"))
                {
                    this.m_Options |= RegexOptions.CultureInvariant;
                }
                if (value.Contains("A"))
                {
                    this.m_Options |= RegexOptions.ECMAScript;
                }
            }
        }
    }
}

