using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligUno;

namespace ObligUnoTest
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [TestMethod]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Arne",
                LastName = "Ooga",
                DeathYear = 1983,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Arne Ooga(Id=1) D�d: 1983";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
