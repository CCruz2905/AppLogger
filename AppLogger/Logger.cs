using System;
using System.IO;
using System.Reflection;

namespace AppLogger
{
    public class Logger
    {
        private readonly string _path;
        private readonly string AppName = Assembly.GetEntryAssembly().GetName().Name;

        /// <summary>
        /// Creates an object where the path is by default on My Documents
        /// </summary>
        public Logger()
        {
            _path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                AppName,
                $"{AppName}Log.txt");
        }

        /// <summary>
        /// Creates an object with path and file specified
        /// </summary>
        /// <param name="path">Relative path where log is going to be</param>
        public Logger(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateFile()
        {

        }
    }
}
