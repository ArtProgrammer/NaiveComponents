using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class SpotImage : Image
    {
        protected override imageType returnType()
        {
            return imageType.SPOT;
        }

        public override void draw()
        {
            Console.WriteLine("SpotImage::draw {0}", ID);
        }

        protected override Image clone()
        {
            return new SpotImage(1);
        }

        protected SpotImage(int dummy)
        {
            ID = Count++;
        }

        private SpotImage()
        {
            addPrototype(this);
        }

        private static SpotImage instance = null;

        public static SpotImage getInstance()
        {
            if (null == instance)
            {
                instance = new SpotImage();
            }

            return instance;
        }

        private int ID = 0;

        private static int Count = 1;
    }
}
