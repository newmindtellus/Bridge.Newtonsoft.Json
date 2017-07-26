using System;
using System.Collections;
using Bridge;
using Bridge.Test.NUnit;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.Tests.Issues
{
    [Category("Issues")]
    [TestFixture(TestNameFormat = "#18 - {0}")]
    public class Case18
    {
        public enum Enum1
        {
            Item1,
            Item2
        }

        public class Test
        {
            public bool? A { get; set; }
            public bool B { get; set; }
            public bool? C { get; set; }

            public int? I1 { get; set; }
            public int I2 { get; set; }
            public int? I3 { get; set; }

            public Enum1? E1 { get; set; }
            public Enum1 E2 { get; set; }
            public Enum1? E3 { get; set; }
        }

        [Test]
        public static void TestNullable()
        {
            var testClass = new Test
            {
                A = true,
                B = true,

                I1 = 5,
                I2 = 6,

                E1 = Enum1.Item2,
                E2 = Enum1.Item1
            };

            var testJson = JsonConvert.SerializeObject(testClass);
            var test = JsonConvert.DeserializeObject<Test>(testJson);

            Assert.NotNull(test.A);
            Assert.True(test.A.Value);
            Assert.True(test.B);
            Assert.Null(test.C);

            Assert.NotNull(test.I1);
            Assert.AreEqual(5, test.I1.Value);
            Assert.AreEqual(6, test.I2);
            Assert.Null(test.I3);

            Assert.NotNull(test.E1);
            Assert.AreEqual(Enum1.Item2, test.E1.Value);
            Assert.AreEqual(Enum1.Item1, test.E2);
            Assert.Null(test.E3);
        }
    }
}