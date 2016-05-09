using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    [Serializable]
    public class Point
    {
        [NonSerialized]
        public int x;
        public int y;
        private int z;
        public void ChangeValueOfZ()
        {
            z = 30;
        }
        public Point()
        {
            y = 10;
        }

        internal void ChangeValueOfX()
        {
            x = 50;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("state.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                Point p = bf.Deserialize(fs) as Point;

            }
            catch (Exception e)
            {

            }
            finally
            {
                fs.Close();
            }
        }

        private static void F1()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("state.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Point p = new Point();
            p.ChangeValueOfZ();
            p.ChangeValueOfX();

            bf.Serialize(fs, p);

            fs.Close();
        }
    }
}
