using System;
using WarpDeck.Key.Behavior;
using WarpDeck.Key.Style;

namespace WarpDeck.Key
{
    public class WarpKey
    {
        public string Name { get; }
        public WarpKeyStyle Style { get; set; } = new WarpKeyStyle();
        public KeyBehavior Behaviour { get; set; }

        public WarpKey(string name, KeyBehavior behavior)
        {
            Name = name;
            Behaviour = behavior;
        }


        public WarpKey ConfigureAppearance(Action<WarpKeyStyle> configAction)
        {
            configAction(Style);
            return this;
        }
    }
}