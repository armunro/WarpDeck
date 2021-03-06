using WarpDeck.Application.Rules;
using WarpDeck.Domain;
using WarpDeck.Domain.Helpers;
using WarpDeck.Domain.Model;

namespace WarpDeck.Application
{
    public abstract class IconGenerator
    {
        protected int IconWidth { get; }
        protected int IconHeight { get; }
        protected readonly IconHelpers Helpers;
        protected RuleManager Rule { get; }

        protected IconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244)
        {
            IconWidth = iconWidth;
            IconHeight = iconHeight;
            Helpers = new IconHelpers();
            Rule = ruleManager;
        }

        protected abstract KeyIcon DrawIconElements(KeyModel keyModel, KeyIcon wipIcon);
        
        public KeyIcon GenerateIcon(KeyModel keyModel)
        {
            KeyIcon newIcon = new KeyIcon(IconWidth, IconHeight);
            newIcon = DrawIconElements(keyModel, newIcon);
            return newIcon;
        }
    }
}