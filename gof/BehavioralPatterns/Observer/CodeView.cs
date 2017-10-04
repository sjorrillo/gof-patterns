using System;

namespace Gof.BehavioralPatterns.Observer
{
    public class CodeView : Window
    {
        public CodeView(string[] initialContent)
            : base(initialContent)
        {
        }

        public override void Save()
        {
            Console.WriteLine("Saving code view content");
            base.Save();
        }
    }
}