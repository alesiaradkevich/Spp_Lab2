using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;

namespace FakerTests
{
    [TestClass]
    public class Fakertests
    {
        private Faker Faker = new Faker();
       // [TestMethod]
        public void GenerateByte()
        {
            byte A = Faker.Create<byte>();
            Assert.IsTrue(A != 0);
        }
       // [TestMethod]
        public void GenerateShort()
        {
            short A;
            A = Faker.Create < short > ();
            Assert.IsTrue(A != 0);
        }
        //[TestMethod]
        public void GenerateInt()
        {
            int A = Faker.Create<int>();
            Assert.IsTrue(A != 0);
        }
        [TestMethod]
        public void GenerateString()
        {
            //Faker faker = new Faker(); 
            string str = Faker.Create<string>();
            Assert.IsTrue(str!=null);
        }
        
        [TestMethod]
        public void GenerateFloat()
        {
            float f = Faker.Create<float>();
            Assert.IsTrue(f != 0);
        }

    }
}
