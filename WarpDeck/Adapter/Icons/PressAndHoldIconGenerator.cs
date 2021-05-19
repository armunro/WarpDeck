using System.Drawing;
using Svg;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain.Helpers;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Icons
{
    public class PressAndHoldIconGenerator : IconGenerator
    {
        protected override Bitmap DrawIcon(KeyModel keyModel)
        {
            string templatePath = @"Untitled.svg";

            SvgDocument svgDoc = SvgDocument.Open(templatePath);

            svgDoc.GetElementById("__micon_background").Fill =
                new SvgColourServer(
                    IconHelpers.GetColorFromHex(Rule.GetStyleValue("background.color", keyModel, "#000")));
            svgDoc.GetElementById("__micon_glyph").Fill =
                new SvgColourServer(
                    IconHelpers.GetColorFromHex(Rule.GetStyleValue("svg.fill.color", keyModel, "#000")));

            svgDoc.Draw(Graphics, new SizeF(Bitmap.Width, Bitmap.Height));

            return Bitmap;
        }

        public PressAndHoldIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244)
            : base(ruleManager, iconWidth, iconHeight)
        {
        }
    }
}