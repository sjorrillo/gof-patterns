using System.Collections.Generic;

namespace Gof.BehavioralPatterns.Observer
{
    public class MainWindow
    {
        private Dictionary<string, Window> observers;

        public MainWindow()
        {
            observers = new Dictionary<string, Window>();
        }

        public void Add(string key, Window observer)
        {
            observers.Add(key, observer);
        }

        public void Remove(string key)
        {
            observers.Remove(key);
        }

        public void SaveAll()
        {
            foreach (var name in observers.Keys)
            {
                observers[name].Save();
            }
        }
    }
}