using WarpDeck.Domain;
using WarpDeck.Domain.Enums;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Behaviors
{
    public class SingleActionPressAndHoldBehavior : KeyBehavior
    {
        private readonly KeyState _startActionWhen = KeyState.Down;


        public override void KeyStateChanged(BehaviorModel model, KeyHistoryModel keyHistory, KeyState incomingKeyState)
        {
            if (incomingKeyState == _startActionWhen)
                FireEvent(model, "press");
        }
    }
}