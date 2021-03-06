using System;
using WarpDeck.Domain.Enums;

namespace WarpDeck.Domain
{
    public abstract class KeyBehavior 
    {
        public abstract void KeyStateChanged(DateTime when, KeyState incomingKeyState);

      

       
    }
}