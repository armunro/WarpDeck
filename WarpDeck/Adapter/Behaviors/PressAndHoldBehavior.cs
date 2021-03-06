using System;
using WarpDeck.Domain;
using WarpDeck.Domain.Enums;

namespace WarpDeck.Adapter.Behaviors
{
    public class PressAndHoldBehavior : KeyBehavior
    {
        private readonly KeyAction _pressAction;
        private readonly int _holdDelay;
        private readonly KeyAction _holdAction;
        private DateTime _lastDown = DateTime.MinValue;

        public PressAndHoldBehavior(KeyAction pressAction, int holdDelay, KeyAction holdAction) 
        {
            _pressAction = pressAction;
            _holdDelay = holdDelay;
            _holdAction = holdAction;
        }

        public override void KeyStateChanged(DateTime when, KeyState incomingKeyState)
        {
            if (incomingKeyState == KeyState.Down)
                _lastDown = DateTime.Now;
            else
            {
                if(_lastDown.AddMilliseconds(_holdDelay) < DateTime.Now)
                    _holdAction.ExecuteAction();
                else
                    _pressAction.ExecuteAction();
            }
        }
    }
}