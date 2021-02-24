using System;

namespace WarpDeck.Key.Behavior
{
    public abstract class KeyBehavior
    {
        public abstract void KeyStateChanged(DateTime when, KeyState incomingKeyState);
    }
}