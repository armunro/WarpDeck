using System.Collections.Generic;

namespace WarpDeck.Domain.Model.Collections
{
    public class KeyMap
    {
        public Dictionary<int, KeyModel> Keys { get; }

        public KeyMap()
        {
            Keys =  new Dictionary<int,KeyModel>();
        }

        public KeyMap(Dictionary<int, KeyModel> keys)
        {
            Keys = keys;
        }

        public void UpdateKeyState(int keyId, KeyModel keyModel)
        {
            Keys[keyId] = keyModel;
        }

        public KeyModel this[int key]
        {
            get => Keys[key];
            set => Keys[key] = value;
        }

        public bool IsKeyMapped(int keyId) => Keys.ContainsKey(keyId);

    }
}