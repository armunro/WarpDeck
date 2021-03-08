using System;
using WarpDeck.Domain;
using WarpDeck.Domain.Enums;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Behaviors
{
    public class PressAndHoldBehavior : KeyBehavior
    {
        private readonly int _holdDelay;
        private DateTime _lastDown = DateTime.MinValue;

        public PressAndHoldBehavior(int holdDelay) 
        {
           _holdDelay = holdDelay;
        }

        public override void KeyStateChanged (BehaviorModel behaviorModel, KeyState incomingKeyState)
        {
            if (incomingKeyState == KeyState.Down)
                _lastDown = DateTime.Now;
            else
                FireEvent(behaviorModel, _lastDown.AddMilliseconds(_holdDelay) < DateTime.Now ? "press" : "hold");
        }
    }
}