using SIL.LCModel;
using SIL.Tool;
using System.IO;

namespace lcmDemo
{
    public class MyDirs : ILcmDirectories
    {
        public string ProjectsDirectory
        {
            get
            {
                var dataFolder = RegistryHelperLite.FallbackStringValue(@"SIL\FieldWorks\8", "ProjectsDir");
                return dataFolder ?? @"C:\ProgramData\SIL\FieldWorks\Projects";
            }
        }

        public string TemplateDirectory
        {
            get
            {
                var dataFolder = RegistryHelperLite.FallbackStringValue(@"SIL\FieldWorks\8", "RootCodeDir");
                return Path.Combine( dataFolder ?? @"C:\ProgramData\SIL\FieldWorks\Projects", "Templates");
            }
        }
    }
}
