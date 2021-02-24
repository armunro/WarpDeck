using System;
using WindowsInput.Events;
using OpenMacroBoard.SDK;
using StreamDeckSharp;
using WarpDeck.Action;
using WarpDeck.Configuration;
using WarpDeck.Key.Behavior;
using WarpDeck.Layers;


namespace WarpDeck
{
    class Program
    {
        static Device _warpDevice = new Device();


        static void Main(string[] args)
        {
            KeyLayer layer = new KeyLayer()
                .Key(0, "Volume Down", Behaviors.SinglePress(MultimediaActions.VolumeDown))
                .Key(1, "Play/Pause", Behaviors.SinglePress(MultimediaActions.PlayPause))
                .Key(2, "Volume Up", Behaviors.SinglePress(MultimediaActions.VolumeUp))
                .Key(3, "Swap Display",
                    Behaviors.SinglePress(Actions.WindowsInput(builder =>
                        builder.ClickChord(KeyCode.LWin, KeyCode.Shift, KeyCode.Left))))
                .Key(4, "Minimize",
                    Behaviors.SinglePress(Actions.WindowsInput(builder =>
                        builder.ClickChord(KeyCode.LAlt, KeyCode.Space).Click(KeyCode.N))))
                .Key(5, "Notepad",
                    Behaviors.SinglePress(Actions.WindowsInput(builder =>
                        builder.ClickChord(KeyCode.LWin, KeyCode.Shift, KeyCode.Left))));

            _warpDevice = new Device();
            _warpDevice.Layers.Add(layer);

            using var deck = StreamDeck.OpenDevice();
            deck.KeyStateChanged += (sender, e) => _warpDevice.HandleExternalKeyChange(e.Key, e.IsDown);

            new LayerConfigWriter().WriteLayerConfig("multi.wdlayer.json", layer);

            RefreshBoard(deck, _warpDevice);
            Console.ReadKey();
        }


        static void RefreshBoard(IStreamDeckBoard board, Device device)
        {
            foreach (KeyLayer layer in device.Layers)
                DrawLayerOnBoard(board, layer);
        }

        private static void DrawLayerOnBoard(IStreamDeckBoard board, KeyLayer layer)
        {
            foreach (var layerKey in layer.MappedKeys.Keys)
            {
                _warpDevice.KeyState.UpdateKeyState(layerKey.Key, layerKey.Value);
                board.SetKeyBitmap(layerKey.Key,
                    KeyBitmap.Create.FromBitmap(_warpDevice.GenerateKeyIcon(layerKey.Key)));
            }
        }
    }
}