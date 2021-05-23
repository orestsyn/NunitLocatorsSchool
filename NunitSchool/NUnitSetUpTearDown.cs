using NUnit.Framework;

namespace NunitSchool
{
    [TestFixture]
    public class MyTestClass2
    {
        string someText = string.Empty;

        [OneTimeSetUp]
        public void BeforeClass()
        {    
            someText = "before class";
        }

        [SetUp]
        public void BeforeMethod()
        {
            someText = "before method";
        }

        [Test]
        public void TestWithSetUpTearDownAttributes()
        {
            Assert.AreEqual("before method", someText, "Some text value differs from expected!");
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            someText = "after class";
        }

        [TearDown]
        public void AfterMethod()
        {
            someText = "after method";
        }
    }
}
