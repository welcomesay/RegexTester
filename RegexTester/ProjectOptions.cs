namespace RegexTester
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public class ProjectOptions
    {
        [XmlIgnore]
        public string RegexFile;
        public string RegexName = "";
        public string RegexDescription = "";
        public string RegexText = "";
        public string ReplaceText = "";
        public string SourceText = "";
        public RegexTester.Command Command = RegexTester.Command.Find;
        public System.Text.RegularExpressions.RegexOptions RegexOptions;
        public DetailOption Detail = DetailOption.Groups;
        public int MaxMatches = 0x3e8;
        public SortOption Sort = SortOption.Position;
        public bool WordWrap = true;
        public FormatOption Format = FormatOption.Auto;
        public bool IncludeEmptyGroups = true;
        public LanguageOption Language = LanguageOption.VisualBasic;
        public bool VerbatimStrings = false;
        public bool InstanceMethods = true;
        public bool AssumeImports = true;
        public bool GenerateLoop = true;
        public bool IncludeComment = true;
        public bool CopyCodeOnExit = true;
        [XmlIgnore]
        private ProjectOptions LoadValues;

        public void ClearChanges()
        {
            this.LoadValues = (ProjectOptions) this.MemberwiseClone();
        }

        public static ProjectOptions Load(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProjectOptions));
                ProjectOptions options2 = (ProjectOptions) serializer.Deserialize(stream);
                options2.RegexFile = fileName;
                options2.ClearChanges();
                return options2;
            }
        }

        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                new XmlSerializer(typeof(ProjectOptions)).Serialize((Stream) stream, this);
                this.RegexFile = fileName;
                this.ClearChanges();
            }
        }

        public bool HasChanged
        {
            get
            {
                return (((((this.RegexText != this.LoadValues.RegexText) || (this.ReplaceText != this.LoadValues.ReplaceText)) || ((this.SourceText != this.LoadValues.SourceText) || (this.Command != this.LoadValues.Command))) || (((this.RegexOptions != this.LoadValues.RegexOptions) || (this.Detail != this.LoadValues.Detail)) || ((this.MaxMatches != this.LoadValues.MaxMatches) || (this.Sort != this.LoadValues.Sort)))) || ((this.Format != this.LoadValues.Format) || (this.WordWrap != this.LoadValues.WordWrap)));
            }
        }
    }
}

