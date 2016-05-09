using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example1
{

    public class Point
    {
        public Info info;
        public int t;
        [XmlIgnore]
        public int x;
        private int y;
        protected int z;
        public void Method1()
        {
        }
        public Point()
        {
            x = 10;
            y = 20;
            z = 30;
            t = 40;
            info = new Info { owner = "Beisenbek", version = "1.0" };
        }
    }

    public class Info
    {
        public string owner;
        public string version;
    }

    public class Point2 : Point
    {
        public void Method1()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("state.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Example1.Point));

            Example1.Point p2 = xs.Deserialize(fs) as Example1.Point;
            //Point p3 = (Point)xs.Deserialize(fs);


            fs.Close();
        }

        static void F1()
        {
            Example1.Point p = new Example1.Point();
            XmlSerializer xs = new XmlSerializer(typeof(Example1.Point));
            FileStream fs = new FileStream("state.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, p);
            fs.Close();
           
        }
    }
}

namespace Example2
{
    public class SuperPoint
    {
        public void Method1()
        {
            Example1.Point p = new Example1.Point();
        }
    }
}
