using System;

namespace Gof.BehavioralPatterns.Observer
{
    public class DesignView : Window
    {
        public DesignView(string[] initialContent)
            : base(initialContent)
        {
        }

        public override void Save() {
            Console.WriteLine("Saving design view content");
            base.Save();
        }
    }
}