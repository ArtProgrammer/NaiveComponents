using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public enum imageType
    {
        LSAT, SPOT
    }

    public abstract class Image
    {
        public abstract void draw();

        static public Image findAndClone(imageType type)
        {
            for (int i = 0; i < NextSlot; ++i)
            {
                if (type == PrototypeList[i].returnType())
                {
                    return PrototypeList[i].clone();
                }
            }

            return null;
        }

        protected abstract imageType returnType();

        protected abstract Image clone();

        protected static void addPrototype(Image val)
        {
            PrototypeList.Add(val);
            NextSlot++;
        }

        private static List<Image> PrototypeList = new List<Image>();

        private static int NextSlot = 0;
    }
}
