using System;
using System.Collections.Generic;
using System.Drawing;
using WarpDeck.Key;
using WarpDeck.Layers;

namespace WarpDeck
{
    public class Device
    {
        public KeyMap KeyState = new KeyMap();
        public List<KeyLayer> Layers { get; } = new List<KeyLayer>();


        public void HandleExternalKeyChange(int keyId, bool isDown)
        {
            if(KeyState.IsKeyMapped(keyId))
                KeyState[keyId].Behaviour.KeyStateChanged(DateTime.Now, isDown? Key.KeyState.Down : Key.KeyState.Up);

        }

        public Bitmap GenerateKeyIcon(int keyId)
        {
            WarpKey key = KeyState[keyId];
            Bitmap image = new Bitmap(122, 122);
            Graphics g = Graphics.FromImage(image);
            g.Clear(key.Style.BackgroundColor);
            g.DrawString(key.Name,new Font("Arial", 14f), new SolidBrush(Color.White), new PointF(0,0));
            return image;
        }
    }
}