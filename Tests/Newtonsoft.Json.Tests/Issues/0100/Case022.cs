using System;
using System.Collections;
using Bridge;
using Bridge.Test.NUnit;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.Tests.Issues
{
    [Category("Issues")]
    [TestFixture(TestNameFormat = "#22 - {0}")]
    public class Case22
    {
        public enum TestEnum
        {
            Test1,
            Test2,
            Test3
        }

        public class TestObj
        {
            public int A { get; set; }
            public TestEnum B { get; set; }
        }


        [Test]
        public static void TestEnumJson()
        {
            TestObj obj = new TestObj();
            obj.A = 123;
            obj.B = TestEnum.Test3;

            var json = JsonConvert.SerializeObject(obj);
            Assert.AreEqual("{\"A\":123,\"B\":2}", json);

            obj = JsonConvert.DeserializeObject<TestObj>(json);
            Assert.AreEqual(123, obj.A);
            Assert.AreEqual(TestEnum.Test3, obj.B);
        }
    }
}