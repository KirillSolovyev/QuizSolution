using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMe {
    [Serializable]
    public class Point {
        public int X { get; set; }
        public int Y { get; set; }
    }

    [Serializable]
    public class Snake {
        List<Point> body = new List<Point>();
        public ConsoleColor BodyColor { get; set; }

        public Snake() {
            body.Add(new Point { X = 47, Y = 4});
            body.Add(new Point { X = 48, Y = 4 });
            body.Add(new Point { X = 49, Y = 4 });
            body.Add(new Point { X = 50, Y = 4 });
            body.Add(new Point { X = 51, Y = 4 });
            BodyColor = ConsoleColor.Red;
        }

        public void Draw() {
            foreach(var el in body) {
                Console.SetCursorPosition(el.X, el.Y);
                Console.ForegroundColor = BodyColor;
                Console.Write("@");
            }
        }
    }


    class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            Snake sn;
            XmlSerializer xSer = new XmlSerializer(typeof(Snake));
            using(FileStream fs = new FileStream(@"C:\Users\Kirill\Desktop\snake.xml", FileMode.OpenOrCreate)) {
                sn = xSer.Deserialize(fs) as Snake;
            }
            sn.Draw();
            Console.ReadKey();
        }
    }
}
