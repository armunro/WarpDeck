using System.Drawing;
using Svg;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Icons
{
    public class PressAndHoldIconGenerator : IconGenerator
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private int Middle => IconHeight / 2;


        protected override Bitmap DrawIcon (KeyModel keyModel)
        {
            _bitmap = new Bitmap(244, 244);
            _graphics = Graphics.FromImage(_bitmap);
            string templatePath = @"C:\users\andrewm\Desktop\Untitled.svg";
         

            float newWidth = _bitmap.Width;
            float newHeight = _bitmap.Height;

            SvgDocument svgDoc = SvgDocument.Open(templatePath);
            //svgDoc.Fill = new SvgColourServer(IconHelpers.GetColorFromHex("#FFF")) ;
            svgDoc.Y = 0;
            svgDoc.X = 0;
            
            svgDoc.Draw(_graphics, new SizeF(newWidth, newHeight));

            return _bitmap;
        }

        public PressAndHoldIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244) 
            : base(ruleManager, iconWidth, iconHeight)
        {
        }
    }
}