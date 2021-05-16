using System;
using System.Collections.Generic;
using System.Drawing;
using Autofac;
using OpenMacroBoard.SDK;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain.Enums;
using WarpDeck.Domain.Helpers;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Domain
{
    public class DeviceManager
    {
        public Dictionary<string, DeviceModel> Devices { get; } = new Dictionary<string, DeviceModel>();
        public Dictionary<string, IMacroBoard> Boards { get; } = new Dictionary<string, IMacroBoard>();
        public Dictionary<string, KeyMap> KeyStates { get; } = new Dictionary<string, KeyMap>();
        public Dictionary<string, KeyHistoryMap> KeyHistory { get; } = new Dictionary<string, KeyHistoryMap>();
        public RuleManager Rules { get; private set; }

        public DeviceManager AddDevice(IMacroBoard board, DeviceModel device)
        {
            board.KeyStateChanged += (sender, e) => HandleBoardKeyStateChange(e.Key, e.IsDown, device.DeviceId);

            Devices.Add(device.DeviceId, device);
            Boards.Add(device.DeviceId, board);
            KeyStates.Add(device.DeviceId, new KeyMap());
            KeyHistory.Add(device.DeviceId, new KeyHistoryMap());
            Rules = new RuleManager();

            return this;
        }

        private void HandleBoardKeyStateChange(int keyId, bool isDown, string deviceId)
        {
            if (!KeyStates[deviceId].IsKeyMapped(keyId)) return;
            if (!KeyHistory[deviceId].ContainsKey(keyId))
                KeyHistory[deviceId][keyId] = new KeyHistoryModel();
            if (isDown)
                KeyHistory[deviceId][keyId].LastDown = DateTime.Now;
            else
                KeyHistory[deviceId][keyId].LastUp = DateTime.Now;

            string behaviorTypeName = KeyStates[deviceId][keyId].Behavior.BehaviorTypeName;
            KeyBehavior behavior = Program.Container.ResolveNamed<KeyBehavior>(behaviorTypeName);
            behavior.KeyStateChanged(KeyStates[deviceId][keyId].Behavior,KeyHistory[deviceId][keyId], isDown ? KeyState.Down : KeyState.Up);
        }

        public void RefreshBoard(string deviceId)
        {
            DeviceModel device = Devices[deviceId];
            foreach (LayerModel layer in device.Layers.Values)
                DrawLayerOnBoard(layer, deviceId);
        }

        private void DrawLayerOnBoard(LayerModel layer, string deviceId)
        {
            foreach (var (keyId, keyModel) in layer.Keys)
            {
                KeyStates[deviceId].UpdateKeyState(keyId, keyModel);
                if (!KeyHistory[deviceId].ContainsKey(keyId))
                    KeyHistory[deviceId][keyId] = new KeyHistoryModel();

                Boards[deviceId].SetKeyBitmap(keyId,
                    KeyBitmap.Create.FromBitmap(GenerateKeyIcon(keyModel)));
            }
        }

        public Bitmap GenerateKeyIcon(KeyModel keyModel)
        {
            if (keyModel == null)
                return IconHelpers.DrawBlankKeyIcon(144, 144);


            KeyIcon newIcon = null;

            IconGenerator generator = Program.Container.ResolveNamed<IconGenerator>(
                keyModel.Behavior.BehaviorId,
                new TypedParameter(Rules.GetType(), Rules));
            newIcon = generator.GenerateIcon(keyModel);

            return newIcon.ToBitmap();
        }
    }
}