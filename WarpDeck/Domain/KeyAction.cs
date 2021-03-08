using WarpDeck.Domain.Model;

namespace WarpDeck.Domain
{
    public abstract class KeyAction
    {
        public abstract void StartAction(ActionModel actionModel);
    }
}