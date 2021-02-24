using System;
using WarpDeck.Action;

namespace WarpDeck.Key.Behavior
{
    public class SinglePressBehavior : KeyBehavior
    {
        private readonly WarpAction _action;

        private readonly KeyState _startActionWhen;

        public SinglePressBehavior(WarpAction action, KeyState startActionWhen = KeyState.Down)
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