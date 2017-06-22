using System;
using System.Collections;
using Bridge;
using Bridge.Test.NUnit;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.Tests.Issues
{
    [Category("Issues")]
    [TestFixture(TestNameFormat = "#6 - {0}")]
    public class Case6
    {
        public class MyOtherString
        {
            public static MyOtherString Empty { get; } = new MyOtherString("");
            [JsonConstructor]
            private MyOtherString(string value)
            {
                Value = value;
            }
            public string Value { get; }
            public MyOtherString Add(string value)
            {
                return new MyOtherString(Value + value);
            }
        }

        public class MultipleJsonConstructors
        {
            [JsonConstructor]
            public MultipleJsonConstructors(string s)
            {
            }

            [JsonConstructor]
            public MultipleJsonConstructors(int i)
            {
            }
        }

        [Test]
        public static void TestJsonConstructor()
        {
            var x = MyOtherString.Empty.Add("abc");
            var json = JsonConvert.SerializeObject(x);
            Assert.AreEqual("{\"Value\":\"abc\"}", json);

            var cloneX = JsonConvert.DeserializeObject<MyOtherString>(json);
            Assert.NotNull(cloneX);
            Assert.AreEqual("abc", cloneX.Value);
        }

        [Test]
        public static void TestMultipleJsonConstructor()
        {
            Assert.Throws<JsonException>(() =>
            {
                JsonConvert.DeserializeObject<MultipleJsonConstructors>("{}");
            });
        }
    }
}