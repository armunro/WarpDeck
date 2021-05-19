using Svg;

namespace WarpDeck.External.MIcon.Template
{
    public class TemplateStringFileProvider : ITemplateProvider
    {
        public Template ProvideTemplate(string svgFilePath)
        {
            return new Template()
            {
                Document = SvgDocument.FromSvg<SvgDocument>(svgFilePath)
            };
        }
    }
}