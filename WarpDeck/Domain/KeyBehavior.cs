using Autofac;
using WarpDeck.Domain.Enums;
using WarpDeck.Domain.Model;

namespace WarpDeck.Domain
{
    public abstract class KeyBehavior 
    {

        
        public abstract void KeyStateChanged(BehaviorModel model, KeyState incomingKeyState);


        protected void FireEvent(BehaviorModel behaviorModel, string eventName)
        {
            ActionModel actionModel = behaviorModel.Actions[eventName];
            string actionTypeName = actionModel.Type;
            KeyAction keyAction = Program.Container.ResolveNamed<KeyAction>(actionTypeName);
            keyAction.StartAction(actionModel);
        }
    }
}