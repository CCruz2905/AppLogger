using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace AppLogger
{
    /// <summary>
    /// Creates a file that will be used to known some important actions on an application
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Full path of the file
        /// </summary>
        private readonly string _path;
        private readonly string AppName;
        /// <summary>
        /// Result of combining Documents/AppName
        /// </summary>
        private readonly string BaseDirectory;
        /// <summary>
        /// Date format used to register date time log
        /// </summary>
        private readonly string DateFormat;

        /// <summary>
        /// Creates an object where the path is by default on My Documents
        /// </summary>
        public Logger()
        {
            AppName = Assembly.GetEntryAssembly().GetName().Name;
            BaseDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), // My Documents
                AppName); // Directory with the name of the app
            DateFormat = DateTime.Now.ToString("G", CultureInfo.InvariantCulture);

            _path = Path.Combine(
                BaseDirectory, // Documents/AppName
                $"{AppName}Log.txt"); // Log file name
        }

        /// <summary>
        /// Creates an object with path and file specified
        /// </summary>
        /// <param name="path">Full path where log is going to be</param>
        public Logger(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Write text into file log
        /// </summary>
        /// <param name="message">Text that contains importan information</param>
        public void Log(string message)
        {
            if (!Directory.Exists(BaseDirectory))
                Directory.CreateDirectory(BaseDirectory);

            using (StreamWriter wr = File.AppendText(_path))
            {
                wr.WriteLine($"{DateFormat}: {message}");
            }
        }

        /// <summary>
        /// Shows into a console what log contains
        /// </summary>
        public void ReadLog()
        {
            using (StreamReader sr = File.OpenText(_path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
