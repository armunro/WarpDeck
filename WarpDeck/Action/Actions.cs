using System;
using WindowsInput.Events;
using WarpDeck.Action.LocalSystem;

namespace WarpDeck.Action
{
    public class Actions
    {
        public static WarpAction WindowsInput(Func<EventBuilder, EventBuilder> builder) =>
            new WindowInputWarpAction(builder);

        public static WarpAction Launch(string exePath, string arguments) =>
            new LaunchApplicationAction(exePath, arguments);
    }
}