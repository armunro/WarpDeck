using System;
using WindowsInput.Events;

namespace WarpDeck.Action
{
    public class WindowInputWarpAction : WarpAction
    {
        private readonly Func<EventBuilder, EventBuilder> _act;

        public WindowInputWarpAction(Func<EventBuilder, EventBuilder> act)
        {
            _act = act;
            
        }
        public override void ExecuteAction()
        {
            EventBuilder builder = _act(WindowsInput.Simulate.Events());

            builder.Invoke();
        }
    }
}