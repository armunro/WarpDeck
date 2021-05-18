using System.Drawing;
using System.IO;
using Svg;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain.Helpers;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Icons
{
    public class SinglePressIconGenerator : IconGenerator
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        
        public SinglePressIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244) : base(
            ruleManager, iconWidth, iconHeight)
        {
        }

        private string CalculateSvgFilePath(KeyModel key)
        {
            string svgBaseDir = Rule.GetStyleValue("svg.baseDirectory", key, string.Empty);
            string svgPath = Rule.GetStyleValue("svg.path", key, string.Empty);

            return !string.IsNullOrWhiteSpace(svgBaseDir)
                ? Path.Combine(svgBaseDir, svgPath)
                : svgPath;
        }

        protected override Bitmap DrawIcon(KeyModel key)
        {
            _bitmap = new Bitmap(244, 244);
            _graphics = Graphics.FromImage(_bitmap);
            string templatePath = @"C:\users\andrewm\Desktop\Untitled.svg";
         
            float newWidth = _bitmap.Width ;
            float newHeight = _bitmap.Height;

            SvgDocument svgDoc = SvgDocument.Open(templatePath);
            SvgElement iconElem = svgDoc.GetElementById("mainIcon");
            iconElem.Fill = new SvgColourServer(IconHelpers.GetColorFromHex("#000"));
            
            svgDoc.Draw(_graphics, new SizeF(newWidth, newHeight));

            return _bitmap;
        }
    }
}