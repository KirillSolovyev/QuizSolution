using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static void Main(string[] args) {
            DateTime start = DateTime.Now;
            TimeSpan ans = new TimeSpan();
            List<TimeSpan> l = new List<TimeSpan>();
            Thread t1 = new Thread(() => {
                while(true) {
                    ConsoleKeyInfo k = Console.ReadKey();
                    if(k.Key == ConsoleKey.Spacebar) {
                        l.Add(ans);
                    }
                    for(int i = 0; i < l.Count; i++) {
                        Console.SetCursorPosition(0, i + 2);
                        Console.WriteLine(l[i]);
                    }
                }
            });
            t1.Start();
            while(true) {
                Console.SetCursorPosition(0, 0);
                DateTime cur = DateTime.Now;
                ans = cur.Subtract(start);
                Console.WriteLine(ans);
                Thread.Sleep(100);
            }
        }
    }
}
