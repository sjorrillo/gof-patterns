using System;

namespace Gof.BehavioralPatterns.Observer
{
    public abstract class Window
    {
        protected MainWindow mainWindow;
        protected string[] fileContent;
        protected string[] newContent;

        public Window(string[] initialContent)
        {
            fileContent = initialContent != null ? initialContent : new string[0];
            newContent = new string[0];
        }

        public string[] FileContent
        {
            get
            { 
                return fileContent;
            }
        }

        public virtual void WriteLine(string line)
        {
            if (string.IsNullOrEmpty(line)) return;

            var newSize = this.newContent.Length + 1;
            Array.Resize(ref this.newContent, newSize);
            this.newContent[newSize - 1] = line;
        }

        public virtual void Save()
        {
            if (newContent.Length == 0) return;
            
            var newDataSize = this.newContent.Length;
            var resultSize = this.fileContent.Length;
            Array.Resize(ref this.fileContent, resultSize + newDataSize);
            for (int i = 0; i < newDataSize; i++)
            {
                this.fileContent[resultSize + i] = this.newContent[i];
            }
        }
    }
}