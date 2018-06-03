using System;
using System.Linq;
using System.Reflection;

namespace AdvancedLessons {
    class Reflections {

        public void GetAllMetaData() {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types) {
                Console.WriteLine(string.Format("Type: {0}", type.Name));

                //  get base type
                Console.WriteLine(string.Format("\tBaseType: {0}", type.BaseType));

                //  get properties
                foreach (var prop in type.GetProperties()) {
                    Console.WriteLine(string.Format("\tProperty: {0}", prop.Name));
                }

                //  get methods
                foreach (var method in type.GetMethods()) {
                    Console.WriteLine(string.Format("\tMethod: {0}", method.Name));
                }

                //  get fields
                foreach (var field in type.GetFields()) {
                    Console.WriteLine(string.Format("\tField: {0}", field.Name));
                }
            }
        }

        public void GetSpecificMetaData() {
            var sampleA = new TestA { MyPropertyA = 1, MyStrA = "A" };
            var typeA = typeof(TestA);

            var sampleB = new TestB { MyPropertyB = 2, MyStrB = "B" };
            var typeB = typeof(TestB);


            //  get property
            var propA = typeA.GetProperty("MyPropertyA");   //  get property through type
            var propA_value = propA.GetValue(sampleA);      //  get the property value on the specific object

            //  get field
            var strA = typeA.GetField("MyStrA");
            var strA_value = strA.GetValue(sampleA);

            Console.WriteLine(string.Format("({0}){1}.{2}: {3}", typeA.Name, "sampleA", propA.Name, propA_value));
            Console.WriteLine(string.Format("({0}){1}.{2}: {3}", typeA.Name, "sampleA", strA.Name, strA_value));

            //  invoke method
            var methodB = typeB.GetMethod("MyMethodB");
            methodB.Invoke(sampleB, null);
        }
        
        public void GetAttributedClasses(Type tType) {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.GetCustomAttributes(tType).Any());
            foreach (var t in types) {
                Console.WriteLine(t.Name);
            }
        }

        public void GetAttributedMethods(Type mType) {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            foreach (var t in types) {
                var methods = t.GetMethods().Where(m => m.GetCustomAttributes(mType).Any());
                foreach (var m in methods) {
                    Console.WriteLine(m.Name);
                }
            }
        }
        #region Test classes
        [MyClass]
        public class TestA {
            public int MyPropertyA { get; set; }
            public void MyMethodA() { Console.WriteLine("Hello from MyMethodA!"); }

            public string MyStrA;
        }

        [MyClass]
        public class TestB {
            public int MyPropertyB { get; set; }
            
            [MyMethod]
            public void MyMethodB() {
                Console.WriteLine(string.Format("MyPropertyB: {0}, MyStrB: {1}", this.MyPropertyB, this.MyStrB));
            }

            public string MyStrB;
        }
        #endregion

        #region Attributes helper
        [AttributeUsage(AttributeTargets.Class)]    //  the usage is only be able to assgin this attribute to class
        public class MyClassAttribute : Attribute { }

        [AttributeUsage(AttributeTargets.Method)]   //  only be able to assgin this attribute to method
        public class MyMethodAttribute : Attribute { }
        #endregion
    }
}
