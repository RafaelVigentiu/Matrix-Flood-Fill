using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDFS {
    internal class Program {


        static void Main(string[] args) {
            Matrix matrix = new Matrix(5);
            matrix.Init();
            matrix.PrintMatrix();
            Console.WriteLine();
            matrix.Solve();
            matrix.PrintMatrix();
        }
    }
}