using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LandSatImage.getInstance();
            SpotImage.getInstance();

            //
            Image[] imageList = new Image[8];
            imageType[] input = { imageType.LSAT, imageType.LSAT, imageType.SPOT,
                                  imageType.LSAT, imageType.LSAT, imageType.SPOT,
                                  imageType.SPOT, imageType.SPOT};

            for (int i = 0; i < 8; i++)
            {
                imageList[i] = Image.findAndClone(input[i]);
            }

            for (int i = 0; i < 8; i++)
            {
                imageList[i].draw();
            }

            for (int i = 0; i < 8; i++)
            {
                imageList[i] = null;
            }

            imageList = null;
        }
    }
}
