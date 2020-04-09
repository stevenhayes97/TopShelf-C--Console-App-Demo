using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TopShelfDemo
{
    class Service
    {
        private FileSystemWatcher watcher;

        public bool Start()
        {
            watcher = new FileSystemWatcher(@"C:\CodeTesting\TopShelf", "TestingFile.txt");

            watcher.Created += FileCreated;

            watcher.IncludeSubdirectories = true;

            watcher.EnableRaisingEvents = true;

            return true;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            string content = File.ReadAllText(e.FullPath);

            string upperContent = content.ToUpperInvariant();

            var dir = Path.GetDirectoryName(e.FullPath);

            var convertedFileName = Path.GetFileName(e.FullPath).Replace(".txt", "") + "_backup.txt";

            var convertedPath = Path.Combine(dir, convertedFileName);

            File.WriteAllText(convertedPath, upperContent);
        }

        public bool Stop()
        {
            watcher.Dispose();

            return true;
        }
    }
}
