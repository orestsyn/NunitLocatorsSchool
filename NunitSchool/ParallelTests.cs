using NUnit.Framework;
using System.Threading;

namespace NunitSchool
{
    [TestFixture]
    public class ParallelTests
    {
        [Parallelizable]
        [Test]
        public void TestMethod1()
        {
            Thread.Sleep(5000);
            Assert.AreEqual("John", "John", "fsdfadfas");
        }

        [Parallelizable]
        [Test]
        public void TestMethod2()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("John", "John", "fsdfadfas");
        }

        [Parallelizable]
        [Test]
        public void TestMethod3()
        {
            Thread.Sleep(4000);
            Assert.AreEqual("John", "John", "fsdfadfas");
        }

        [Parallelizable]
        [Test]
        public void TestMethod4()
        {
            Thread.Sleep(2000);
            Assert.AreNotEqual("John", "John", "fsdfadfas");
        }
    }
}
