using System;
using WarpDeck.Domain;
using WarpDeck.Domain.Enums;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Behaviors
{
    public class PressAndHoldBehavior : KeyBehavior
    {
        private readonly int _holdDelay = 250;


        public override void KeyStateChanged(BehaviorModel behaviorModel, KeyHistoryModel keyHistory,
            KeyState incomingKeyState)
        {
            if (incomingKeyState == KeyState.Up)
                FireEvent(behaviorModel,
                    keyHistory.LastDown.AddMilliseconds(_holdDelay) < DateTime.Now ? "hold" : "press" );
        }
    }
}