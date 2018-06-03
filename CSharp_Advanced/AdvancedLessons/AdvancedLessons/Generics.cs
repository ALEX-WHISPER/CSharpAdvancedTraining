using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLessons {
    class Generics {
        public class Result<T> {
            public bool Success { get; set; }
            public T Data { get; set; }
        }

        public class Result_AB<T, K> {
            public bool Success { get; set; }
            public T DataA { get; set; }
            public K DataB { get; set; }
        }

        public class ResultPrinter {
            public void Print<T>(Result<T> result) {
                Console.WriteLine(string.Format("Success: {0}, Data: {1}", result.Success, result.Data));
            }
        }

        public class ResultABPrinter {
            public void Print<T, K>(Result_AB<T, K> result_AB) {
                Console.WriteLine(string.Format("Success: {0}, DataA: {1}, DataB: {2}",
                    result_AB.Success, result_AB.DataA, result_AB.DataB));
            }
        }
    }
}
