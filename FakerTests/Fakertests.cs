using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using FakerTests.Classes;
using System;
namespace FakerTests
{
    [TestClass]
    public class Fakertests
    {
        private Faker Faker = new Faker();
        [TestMethod]
        public void GenerateByte()
        {
            byte A = Faker.Create<byte>();
            Assert.IsTrue(A != 0);
        }
        [TestMethod]
        public void GenerateShort()
        {
            short A;
            A = Faker.Create < short > ();
            Assert.IsTrue(A != 0);
        }
        [TestMethod]
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
        public void GenerateChar()
        {
            char C = Faker.Create<char>();
            Assert.IsTrue(C != Convert.ToChar(0));
        }
        
        [TestMethod]
        public void GenerateFloat()
        {
            float f = Faker.Create<float>();
            Assert.IsTrue(f != 0);
        }

        [TestMethod]
        public void GenerateClassWithInnerClass()
        {
            ClassWithInnerClass C = Faker.Create<ClassWithInnerClass>();
            Assert.IsTrue(C.A != 0);
            Assert.IsTrue(C.allTypes.I != 0);
            Assert.IsTrue(C.allTypes.C != 0);
            Assert.IsTrue(C.allTypes.f != 0);
            Assert.IsTrue(C.allTypes.S != null);

        }

        [TestMethod]
        public void GenerateRecursion()
        {
            A a = Faker.Create<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.b);
            Assert.IsNotNull(a.b.c);
            Assert.IsNull(a.b.c.a);
        }

        public struct _Struct
        {
            public int A;
            public float B;
           // public char C;
        }
        [TestMethod]
        public void GenerateStruct()
        {
            _Struct _struct = Faker.Create<_Struct>();
            //Assert.IsTrue(_struct != null);
            Assert.IsTrue(_struct.A != 0);
            Assert.IsTrue(_struct.B != 0);
        }
    }
}
