using System;
using WarpDeck.Domain;
using WarpDeck.Domain.Enums;

namespace WarpDeck.Adapter.Behaviors
{
    public class SinglePressBehavior : KeyBehavior
    {
        private readonly KeyAction _action;

        private readonly KeyState _startActionWhen;

        public SinglePressBehavior( KeyAction action, KeyState startActionWhen = KeyState.Down) 
        {
            _action = action;
            _startActionWhen = startActionWhen;
        }

        public override void KeyStateChanged(DateTime when, KeyState incomingKeyState)
        {
            if (incomingKeyState == _startActionWhen)
                _action.ExecuteAction();
        }
    }
}