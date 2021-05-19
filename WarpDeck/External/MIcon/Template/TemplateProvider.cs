namespace WarpDeck.External.MIcon.Template
{
    public interface ITemplateProvider
    {
        Template ProvideTemplate(string svgFilePath);
    }
}