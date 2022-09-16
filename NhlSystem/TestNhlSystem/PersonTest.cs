using NhlSystem;
using System.Data;

namespace TestNhlSystem
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Leon Draistal")]
        public void FullName_ValidName_FullNameSet(string fullName)
        {
            //var validPerson = new Person("Connor McDavid");
            //Assert.AreEqual("Connor McDavid", validPerson.FullName);
            var validPerson = new Person(fullName);
            Assert.AreEqual(fullName, validPerson.FullName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("  ")]
        public void FullName_InvalidName_ArgumentNullException(string fullName)
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new Person(fullName));
            Assert.AreEqual("FullName value is required", ex.ParamName);
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow(" A ")]
        public void FullName_InvalidNameLength_ArgumentException(string fullName)
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new Person(fullName));
            Assert.AreEqual("FullName must contain 3 or more characters", ex.Message);
        }
    }
}