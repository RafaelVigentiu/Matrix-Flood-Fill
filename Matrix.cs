using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDFS {
    public class Matrix {
        public int n;
        public int[,] values;
        public bool[,] visited;

        public Matrix(int size) {
            this.n = size;
            this.values = new int[n, n];
        }

        public void Init() {
            Random random = new Random();

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    values[i, j] = random.Next(1, n - 1);
                }
            }
        }

        public void PrintMatrix() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write(values[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Solve() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    visited = new bool[n, n];
                    int count = DFS(i, j, values[i, j]);
                    if (count >= 3) {
                        visited = new bool[n, n];
                        SetToZero(i, j, values[i, j]);
                    }
                }
            }
        }

        private int DFS(int i, int j, int target) {
            if (i < 0 || j < 0 || i >= n || j >= n) { return 0; }
            if (visited[i, j] || values[i, j] != target) { return 0; }

            visited[i, j] = true;
            return 1 + DFS(i - 1, j, target)
                     + DFS(i + 1, j, target)
                     + DFS(i, j - 1, target)
                     + DFS(i, j + 1, target);
        }

        private void SetToZero(int i, int j, int target) {
            if (i < 0 || j < 0 || i >= n || j >= n) { return; }
            if (visited[i, j] || values[i, j] != target) { return; }

            visited[i, j] = true;
            values[i, j] = 0;

            SetToZero(i - 1, j, target);
            SetToZero(i + 1, j, target);
            SetToZero(i, j - 1, target);
            SetToZero(i, j + 1, target);
        }
    }
}
