using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gof.BehavioralPatterns.Observer;
using System.Linq;
using System;

namespace gof.test.BehavioralPatterns
{
    [TestClass]
    public class ObserserPatternTest
    {   
        protected MainWindow subject;
        protected DesignView designView;
        protected CodeView codeView;

        [TestInitialize]
        public void SetUp()
        {
            subject = new MainWindow();
            var initialContent = new string[] { "line 01" };
            designView = new DesignView(initialContent);
            codeView = new CodeView(initialContent);
            subject.Add("designView", designView);
            subject.Add("codeView", codeView);
        }

        [TestMethod]
        public void ShouldNotifyAllObserversTest()
        {
            designView.WriteLine("Design Line 02");
            codeView.WriteLine("Code Line 02");
            Assert.IsFalse(designView.FileContent.Any(line => line == "Design Line 02"));
            Assert.IsFalse(codeView.FileContent.Any(line => line == "Code Line 02"));
            subject.SaveAll();
            Assert.IsTrue(designView.FileContent.Any(line => line == "Design Line 02"));
            Assert.IsTrue(codeView.FileContent.Any(line => line == "Code Line 02"));
        }

        [TestMethod]
        public void ShouldNotifyOnlyCodeViewTest()
        {   
            subject.Remove("designView");
            designView.WriteLine("Design Line 02");
            codeView.WriteLine("Code Line 02");
            Assert.IsFalse(designView.FileContent.Any(line => line == "Design Line 02"));
            Assert.IsFalse(codeView.FileContent.Any(line => line == "Code Line 02"));
            subject.SaveAll();
            Assert.IsFalse(designView.FileContent.Any(line => line == "Design Line 02"));
            Assert.IsTrue(codeView.FileContent.Any(line => line == "Code Line 02"));
        }
    }
}
