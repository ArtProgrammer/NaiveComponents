using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class LandSatImage : Image
    {
        protected override imageType returnType()
        {
            return imageType.LSAT;
        }

        public override void draw()
        {
            Console.WriteLine("LandSatImage::draw {0}", ID);
        }

        protected override Image clone()
        {
            return new LandSatImage(1);
        }

        protected LandSatImage(int dummy)
        {
            ID = Count++;
        }

        private LandSatImage()
        {
            addPrototype(this);
        }

        private static LandSatImage instance = null;

        public static LandSatImage getInstance()
        {
            if (instance == null)
            {
                instance = new LandSatImage();
            }

            return instance;
        }

        private int ID = 0;

        private static int Count = 1;
    }
}
