using System.Linq;
using Svg;

namespace WarpDeck.External.MIcon.Template
{
    public class TemplateFileProvider : ITemplateProvider
    {
        public Template ProvideTemplate(string svgFilePath)
        {
            var document = SvgDocument.Open(svgFilePath);
            var templateElements =
                document.Children.Where(x => !string.IsNullOrWhiteSpace(x.ID) && x.ID.StartsWith("__micon_"));
            return new Template()
            {
                 Document = document,
                 TemplateElements = templateElements.ToList()
                
            };
        }
    }
}