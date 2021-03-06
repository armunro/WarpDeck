using System;
using WindowsInput;
using WindowsInput.Events;
using WarpDeck.Domain;

namespace WarpDeck.Adapter.Actions
{
    public class WindowInputKeyAction : KeyAction
    {
        private readonly Func<EventBuilder, EventBuilder> _act;

        public WindowInputKeyAction(Func<EventBuilder, EventBuilder> act)
        {
            _act = act;
            
        }
        public override void ExecuteAction()
        {
            EventBuilder builder = _act(Simulate.Events());

            builder.Invoke();
        }
    }
}