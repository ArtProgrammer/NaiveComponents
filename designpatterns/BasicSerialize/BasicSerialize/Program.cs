using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicSerialize
{
    [Serializable]
    public class MineObject
    {
        public int id;
        public float x;
        public float y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MineObject mo = new MineObject();
            mo.id = 1;
            mo.x = 1.0f;
            mo.y = 2.0f;

            MemoryStream ms = new MemoryStream();
        }
    }
}
