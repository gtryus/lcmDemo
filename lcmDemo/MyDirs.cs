// Copyright (c) 2010-2018 SIL International
// License: MIT
using SIL.LCModel;
using SIL.Tool;
using System;
using System.IO;

namespace lcmDemo
{
    public class MyDirs : ILcmDirectories
    {
        public string ProjectsDirectory
        {
            get
            {
                var dataFolder = RegistrySetting.FallbackStringValue(@"SIL\FieldWorks\9", "ProjectsDir");
                if (!string.IsNullOrEmpty(dataFolder)) return dataFolder;
                dataFolder = RegistrySetting.FallbackStringValue(@"SIL\FieldWorks\8", "ProjectsDir");
                return dataFolder ?? @"C:\ProgramData\SIL\FieldWorks\Projects";
            }
        }

        const string TemplateFolder = "Templates";
        public string TemplateDirectory
        {
            get
            {
                var dataFolder = RegistrySetting.FallbackStringValue(@"SIL\FieldWorks\9", "RootCodeDir");
                if (!string.IsNullOrEmpty(dataFolder)) return Path.Combine(dataFolder, TemplateFolder);
                dataFolder = RegistrySetting.FallbackStringValue(@"SIL\FieldWorks\8", "RootCodeDir");
                return Path.Combine( dataFolder ?? @"C:\ProgramData\SIL\FieldWorks\Projects", TemplateFolder);
            }
        }

        public string BackupDirectory
        {
            get
            {
                var backupFolder = RegistrySetting.FallbackStringValue(@"SIL\FirleWorks\9\ProjectBackup", "DefaultBackupDirectory");
                if (!string.IsNullOrEmpty(backupFolder)) return backupFolder;
                backupFolder = RegistrySetting.FallbackStringValue(@"SIL\FirleWorks\8\ProjectBackup", "DefaultBackupDirectory");
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return backupFolder ?? Path.Combine(documents, "My FieldWorks", "Backups");
            }
        }
    }
}
