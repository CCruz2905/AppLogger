using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace AppLogger
{
    public class Logger
    {
        private readonly string _path;
        private readonly string AppName = Assembly.GetEntryAssembly().GetName().Name;
        private readonly string BaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string DateFormat = DateTime.Now.ToString("G", CultureInfo.InvariantCulture);

        /// <summary>
        /// Creates an object where the path is by default on My Documents
        /// </summary>
        public Logger()
        {
            _path = Path.Combine(
                BaseDirectory, // Documents
                AppName, // Directory Name
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
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

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
