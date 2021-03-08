using System;
using WindowsInput;
using WindowsInput.Events;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Actions
{
    public class WindowInputKeyAction : KeyAction
    {
        private readonly Func<EventBuilder, EventBuilder> _act;

        public WindowInputKeyAction(Func<EventBuilder, EventBuilder> act)
        {
            _act = act;
        }

        public override void StartAction(ActionModel actionModel)
        {
            EventBuilder builder = _act(Simulate.Events());
            builder.Invoke();
        }
    }
}