using System;

namespace AdvancedLessons {
    class Attributes {

        [AttributeUsage(AttributeTargets.Class)]
        public class SampleAttribute : Attribute {
            public SampleAttribute(string name, int version) {
                this.Name = name;
                this.Version = version;
            }

            public string Name { get; set; }
            public int Version { get; set; }
        }


        [Sample("Eason", 1)]
        public class AttrTest {
            public int IntValue { get; set; }
            public string StrValue { get; set; }
        }

        [Sample("Eason", 2)]
        public class AttrTest_A {

        }
    }
}
