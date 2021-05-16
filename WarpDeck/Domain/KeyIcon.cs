using System.Drawing;
using Svg;
using WarpDeck.Domain.Helpers;

namespace WarpDeck.Domain
{
    public class KeyIcon
    {
        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;

        public Bitmap ToBitmap() => _bitmap;

        public KeyIcon(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(_bitmap);
        }

        public KeyIcon Text(string text, int y, int x, string fontFamily = "Arial", float fontSize = 14f)
        {
            _graphics.DrawString(text, new Font(fontFamily, fontSize), Brushes.White, new PointF(x, y));
            return this;
        }

        public KeyIcon Background(Color color)
        {
            _graphics.Clear(color);
            return this;
        }

        public KeyIcon Svg(string svgFilePath, int top, int left, float scaleWidthToDoc = 1,
            float scaleHeightToDoc = 1, string color = "#FFFFFF")
        {
            if (string.IsNullOrWhiteSpace(svgFilePath)) return this;

            float newWidth = _bitmap.Width * scaleWidthToDoc;
            float newHeight = _bitmap.Height * scaleHeightToDoc;

            SvgDocument svgDoc = SvgDocument.Open(svgFilePath);
            svgDoc.Fill = new SvgColourServer(IconHelpers.GetColorFromHex(color)) ;
            svgDoc.Y = top;
            svgDoc.X = left;
            
            svgDoc.Draw(_graphics, new SizeF(newWidth, newHeight));

            return this;
        }

        public KeyIcon Border(float thickness, Color color)
        {
            _graphics.DrawRectangle(new Pen(color, thickness), new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));

            return this;
        }
    }
}