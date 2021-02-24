using WarpDeck.Action;

namespace WarpDeck.Key.Behavior
{
    public class Behaviors
    {
        public static KeyBehavior SinglePress(WarpAction action, KeyState startActionWhen = KeyState.Down) =>
            new SinglePressBehavior(action, startActionWhen);
    }
}