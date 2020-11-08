using FluentAssertions;
using NUnit.Framework;
using TaskMonitor.ViewModels;

namespace Task_Monitor.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var model = new AboutViewModel();


            model.Title.Should().Be("About");
            
        }
    }
}