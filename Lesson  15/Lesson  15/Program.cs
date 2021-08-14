using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson__15
{
    public class Node
    {
        public int Value { get; set; }
        public List<Edge> edges { get; set; }
    }

    public class Edge//ребро
    {
        public int Weeight { get; set; }
        public Node Node { get; set; }
    }
     

    class Program
    {
       const int N = 5;
        static void Main(string[] args)
        {
            NewMethod1();
            var stack = new Stack<int>();
           
            int[,] w = new int[N, N];
            Load(w);
            int[] active = new int[N];
            int[] route = new int[N];
            int[] peak = new int[N];
            int i;
            int j;
            int min;
            int kMin = 0;
            for(i=0;i<N;i++)
            {
                active[i] = 1;
                route[i] = w[0,i];
                peak[i] = 0;
            }
            active[0] = 0;
            for(i=0;i<N-1;i++)
            {
                min = int.MaxValue;
                for(j=0;j<N;j++)
                {
                    if(active[i]==1&&route[j]<min)
                    {
                        stack.Push(route[j]);
                        min = stack.Pop();
                        stack.Push( j);
                        kMin = stack.Pop();
                    }
                }
                active[kMin] = 0;
                for(j=0;j<N;j++)
                {
                    if(route[j]>route[kMin]+w[j,kMin]&&w[j,kMin]!=int.MaxValue&&active[j]==1)
                    {
                        route[j] = route[kMin] + w[j, kMin];
                      
                        peak[j] = kMin;
                    }
                }
            }
            i = N - 1;
            while(i!=0)
            {
                Console.WriteLine($"{i}");
                i = peak[i];
                Console.WriteLine(kMin);
            }
            FloydWarshal(w);

        }
        static void FloydWarshal(int[,] W)
        {
            for (int k = 0; k < N; k++)
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        if (W[i, k] + W[k, j] < W[i, j])
                            W[i, j] = W[i, k] + W[k, j];
        }

        private static void NewMethod1()
        {
            var qeue = new Queue<int>();
            int N = 5;
            int[,] w = new int[N, N];
            Load(w);

            int[,] ostonov = new int[N, 2];
            int[] a = new int[N];
            int jMin = 0;
            int iMin = 0;
            for (int k = 0; k < N - 1; k++)
            {
                int min = Int32.MaxValue;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (a[i] != a[j] && w[i, j] < min)
                        {
                            qeue.Enqueue(i);
                            iMin = qeue.Dequeue();
                            qeue.Enqueue(j);
                            jMin = qeue.Dequeue();
                            min = w[i, j];
                        }
                    }
                }
                ostonov[k, 0] = iMin;
                ostonov[k, 1] = jMin;
                int jM = a[jMin], iM = a[iMin];
                for (int i = 0; i < N; i++)
                {
                    if (a[i] == jM)
                    {
                        a[i] = iM;
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"({ostonov[i, 0]}, {ostonov[i, 1]}");

                }


            }


        }

        public static int[,] Load(int[,] w)
        {
            Random random = new Random();
            for(int i=0;i<w.GetLength(0);i++)
            {
                for (int j = 0; j < w.GetLength(1); j++)
                {
                    w[i, j] = random.Next();
                }
            }
            return w;

        }

        
    }
}
