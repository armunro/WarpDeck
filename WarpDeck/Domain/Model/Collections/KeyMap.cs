using System.Collections.Generic;

namespace WarpDeck.Domain.Model.Collections
{
    public class KeyMap: Dictionary<int, KeyModel>
    {
       

        public KeyMap()
        {
           
        }

        public KeyMap(Dictionary<int, KeyModel> items)
        {
            foreach (var keyValuePair in items)
            {
                this[keyValuePair.Key] = keyValuePair.Value;
            }
        }

        public void UpdateKeyState(int keyId, KeyModel keyModel)
        {
            this[keyId] = keyModel;
        }

       

        public bool IsKeyMapped(int keyId) => ContainsKey(keyId);

    }
}