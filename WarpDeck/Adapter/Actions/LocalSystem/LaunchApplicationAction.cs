using System.Diagnostics;
using WarpDeck.Domain;

namespace WarpDeck.Adapter.Actions.LocalSystem
{
    public class LaunchApplicationAction : KeyAction
    {
        private readonly string _executablePath;
        private readonly string _arguments;

        public LaunchApplicationAction(string executablePath, string arguments)
        {
            _executablePath = executablePath;
            _arguments = arguments;
        }
        public override void ExecuteAction()
        {
            ProcessStartInfo process = new ProcessStartInfo(_executablePath, _arguments);
            Process.Start(process);
        }
    }
}