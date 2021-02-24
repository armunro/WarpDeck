using System.Collections.Generic;
using WarpDeck.Key;

namespace WarpDeck
{
    public class KeyMap
    {
        public Dictionary<int, WarpKey> Keys { get; } = new Dictionary<int, WarpKey>();

        public KeyMap Map(int keyId, WarpKey key)
        {
            Keys.Add(keyId, key);
            return this;
        }

        public void UpdateKeyState(int keyId, WarpKey key)
        {
            Keys[keyId] = key;
        }

        public WarpKey this[int key]
        {
            get => Keys[key];
            set => Keys[key] = value;
        }

        public static KeyMap Create()
        {
            return new KeyMap();
        }

        public bool IsKeyMapped(int keyId) => Keys.ContainsKey(keyId);

    }
}