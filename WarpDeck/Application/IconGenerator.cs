using System.Drawing;
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
        protected Bitmap Bitmap;
        protected Graphics Graphics;

        protected readonly IconHelpers Helpers;
        protected RuleManager Rule { get; }
        
        protected IconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244)
        {
            IconWidth = iconWidth;
            IconHeight = iconHeight;
            Bitmap = new Bitmap(244, 244);
            Graphics = Graphics.FromImage(Bitmap);
            Helpers = new IconHelpers();
            Rule = ruleManager;
        }

        protected abstract Bitmap DrawIcon(KeyModel keyModel);
        
        public KeyIcon GenerateIcon(KeyModel keyModel)
        {
            KeyIcon newIcon = new KeyIcon(DrawIcon(keyModel));
            return newIcon;
        }
    }
}