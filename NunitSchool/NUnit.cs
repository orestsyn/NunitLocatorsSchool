using NUnit.Framework;
using System.Collections.Generic;

namespace NunitSchoolNameSpace

{
    [TestFixture]
    public class MyTestClass
    {
        [Test]
        public void SimpleTestCheck()
        {
            string value1 = "Hello";
            string value2 = "Hello";
            string result = value1 + value2;
        }

        #region Default Nunit With Assertions
        [Test]
        public void SimpleTestPass()
        {
            string expectedResult = "Hello";
            string actualResult = "Hello";
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void SimpleTestFail()
        {
            string expectedResult = "Hello";
            string actualResult = "Hello World!";
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SimpleTestFailWithMessage()
        {
            string expectedResult = "Hello";
            string actualResult = "Hello World!";
            Assert.AreEqual(expectedResult, actualResult, "Actual result differs from expected!");
        }

        [Test]
        public void SimpleTestConstraintFailWithMessage()
        {
            string expectedLoginPageTitle = "Hello";
            string actualLoginPageTitle = "Hello World!";
            Assert.That(expectedLoginPageTitle.Equals(actualLoginPageTitle), "Login page title text differs from expected!");
        }
        #endregion

        #region Assumptions

        [Test]
        public void SimpleTestAssume()
        {
            string value1 = "Firefox";
            string value2 = "Chrome";
            Assume.That(value1.Equals(value2), "Test should be executed on chrome only");

            string expectedResult = "Hello";
            string actualResult = "Hello";
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Attributes

        #region TestCase
        [TestCase("John", "John Doe")]
        public void SimpleTestTestCase(string v1, string v2)
        {
            StringAssert.Contains(v1, v2, "String 2 doesn't contain string 1!");
        }

        [TestCase("John", "John Doe", ExpectedResult = true)]
        public bool SimpleTestTestCaseExpected(string v1, string v2)
        {
            return v2.Contains(v1);
        }
        #endregion

        #region TestCaseSource
        public static IEnumerable<TestCaseData> JohnDoeDataSource
        {
            get
            {
                yield return new TestCaseData("John Doe");
                yield return new TestCaseData("Not John Doe");
                yield return new TestCaseData("John Doe is there!");
                yield return new TestCaseData("John Not Doe");
                yield return new TestCaseData("Joe Doe");
            }
        }

        [TestCaseSource("JohnDoeDataSource")]
        public void SimpleTestTestCaseSource(string val1)
        {
            StringAssert.Contains("John", val1, "Provided value doesn't contain expected text!");
        }
        #endregion

        #region Info

        [Test]
        [Author("myName")]
        [Category("myCategory")]
        [Description("This test used to show how info attributes works!")]
        public void SimpleTestPassInfoAttributes()
        {
            string expectedResult = "Hello";
            string actualResult = "Hello";
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Ignore
        [Test]
        [Ignore("Test is currently blocked by defect and should not be executed!")]
        public void SimpleTestPassIgnored()
        {
            string expectedResult = "Hello";
            string actualResult = "Hello";
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #endregion
    }
}
