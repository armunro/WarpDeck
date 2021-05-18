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
      
        
        public SinglePressIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244) : base(
            ruleManager, iconWidth, iconHeight)
        {
        }


        protected override Bitmap DrawIcon(KeyModel keyModel)
        {
            Bitmap = new Bitmap(244, 244);
            Graphics = Graphics.FromImage(Bitmap);
            string templatePath = @"C:\Users\me\OneDrive\Desktop\Untitled.svg";
         
            float newWidth = Bitmap.Width ;
            float newHeight = Bitmap.Height;

            SvgDocument svgDoc = SvgDocument.Open(templatePath);
            svgDoc.GetElementById("BG").Fill =
                new SvgColourServer(
                    IconHelpers.GetColorFromHex(Rule.GetStyleValue("background.color", keyModel, "#000")));
            svgDoc.GetElementById("GLYPH").Fill =
                new SvgColourServer(
                    IconHelpers.GetColorFromHex(Rule.GetStyleValue("svg.fill.color", keyModel, "#000")));
          
            
         
            svgDoc.Draw(Graphics, new SizeF(newWidth, newHeight));

            return Bitmap;
        }
    }
}   