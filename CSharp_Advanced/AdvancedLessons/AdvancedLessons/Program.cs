using System;
using System.Reflection;
using System.Linq;

namespace AdvancedLessons {
    class Program {
        static void Main(string[] args) {
            #region Implicit Typing
            /*
            var firstName = "Eric";
            var age = 22;
             
            //var lastName; //  error: implicity-typed local variables must be initialized
                            //  The compiler needs to be able to look at this initialization step and figure out the type of that variable
            
            //  now the variables' types have been confirmed
            Console.WriteLine(string.Format("firstName: {0}, age: {1}", firstName, age));
            */
            #endregion

            #region Generics
            /*
            var resultInt = new Generics.Result<int> { Success = true, Data = 22};
            var resultStr = new Generics.Result<string> { Success = false, Data = "age" };
            var resultHelper = new Generics.ResultPrinter();

            resultHelper.Print(resultInt);
            resultHelper.Print(resultStr);

            var resultAB_IntBool = new Generics.Result_AB<int, bool> { Success = false, DataA = 5, DataB = false };
            var resultAB_IntStr = new Generics.Result_AB<int, string> { Success = true, DataA = 12, DataB = "firstLove" };
            var resultABHelper = new Generics.ResultABPrinter();

            resultABHelper.Print(resultAB_IntBool);
            resultABHelper.Print(resultAB_IntStr);
            */
            #endregion

            #region Attributes
            //var types = from t in Assembly.GetExecutingAssembly().GetTypes()
            //            where t.GetCustomAttributes<Attributes.SampleAttribute>().Count() > 0
            //            select t;

            //foreach (var t in types) {
            //    Console.WriteLine(t.Name);

            //    foreach (var p in t.GetProperties()) {
            //        Console.WriteLine(string.Format("{0}.{1}", t.Name, p.Name));
            //    }
            //}
            #endregion

            #region Reflection
            Reflections reflection = new Reflections();
            //reflection.GetAllMetaData();
            //reflection.GetSpecificMetaData();
            reflection.GetAttributedClasses(typeof(Reflections.MyClassAttribute));
            reflection.GetAttributedMethods(typeof(Reflections.MyMethodAttribute));
            #endregion
        }
    }
}
