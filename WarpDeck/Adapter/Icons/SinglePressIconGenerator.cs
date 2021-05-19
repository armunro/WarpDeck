using System.Drawing;
using System.IO;
using System.Linq;
using Svg;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain.Helpers;
using WarpDeck.Domain.Model;
using WarpDeck.External.MIcon;
using WarpDeck.External.MIcon.Template;

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
            

            ITemplateProvider templateProvider = new TemplateFileProvider();
            Template template = templateProvider.ProvideTemplate("Untitled.svg");
            foreach (SvgElement svgElement in template.TemplateElements)
            {
                if (Rule.HasRule(svgElement.ID))
                {
                    svgElement.Fill= new SvgColourServer(
                        IconHelpers.GetColorFromHex(Rule.GetStyleValue(svgElement.ID, keyModel, "#000")));
                
                }
                
            }

            System.Drawing.Bitmap bitm = new Bitmap(244, 244);
            Graphics g = Graphics.FromImage(bitm);
            
            template.Document.Draw(g, new SizeF(Bitmap.Width, Bitmap.Height));

            return bitm;
        }
    }
}