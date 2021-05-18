using System.Drawing;

namespace WarpDeck.Domain
{
    public class KeyIcon
    {
        private readonly Bitmap _bitmap;
       

        public Bitmap ToBitmap() => _bitmap;

        public KeyIcon(Bitmap bitmap)
        {
            _bitmap = bitmap;

        }

 

        


    }
}