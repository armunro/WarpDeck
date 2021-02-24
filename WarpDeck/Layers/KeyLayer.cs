using WarpDeck.Key;
using WarpDeck.Key.Behavior;

namespace WarpDeck.Layers
{
    public class KeyLayer
    {
        public KeyMap MappedKeys { get; }

        public KeyLayer() : this(KeyMap.Create())
        {
            
        }

        public KeyLayer(KeyMap map)
        {
            MappedKeys = map;
        }

        public KeyLayer Key(int keyId, string keyName, KeyBehavior behavior)
        {
           MappedKeys.Map(keyId, new WarpKey(keyName, behavior));
           return this;
        }

        public static KeyLayer Create()
        {
            return new KeyLayer();
        }
    }
}