using System;
using SIL.LCModel;

namespace lcmDemo
{
    public class MyProjectIdentifier : IProjectIdentifier
    {
        private readonly BackendProviderType m_type;

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleProjectId"/> class.
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public MyProjectIdentifier(BackendProviderType type, string name)
        {
            m_type = type;
            Path = name;
        }

        #region IProjectIdentifier implementation
        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the UI name of the project (this will typically be formatted as [Name]
        /// for local projects and [Name]-[ServerName] for remote projects).
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public string UiName
        {
            get { return Name; }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the project path.
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public string Path { get; set; }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a token that uniquely identifies the project. This might look like a full path
        /// but should never be used as a path; use the <see cref="Path"/> property instead.
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public string Handle
        {
            get { return Path; }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a token that uniquely identifies the project that can be used for a named pipe.
        /// TODO: this will probably go away after we finish integrating LCM into Paratext
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public string PipeHandle
        {
            get { throw new NotImplementedException(); }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the project name (typically the project path without an extension or folder)
        /// </summary>
        /// <value></value>
        /// ------------------------------------------------------------------------------------
        public string Name
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(Path); }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the folder that contains the project (will typically be <c>null</c> for
        /// remote projects).
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public string ProjectFolder
        {
            get { return System.IO.Path.GetDirectoryName(Path); }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the type of back-end used for storing the project.
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public BackendProviderType Type
        {
            get { return m_type; }
        }
        #endregion
    }
}