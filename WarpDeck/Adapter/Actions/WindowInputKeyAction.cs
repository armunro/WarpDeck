using System;
using System.Collections.Generic;
using WindowsInput;
using WindowsInput.Events;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Actions
{
    public class WindowInputKeyAction : KeyAction
    {
        public override void StartAction(ActionModel actionModel)
        {
            string keys = actionModel.Parameters["keys"];
            EventBuilder eventBuilder = Simulate.Events();

            string[] events = keys.Split('|');
            foreach (string keyEvent in events)
            {
                if (keyEvent.StartsWith('(') && keyEvent.EndsWith(")"))
                {
                    //its a chord
                    eventBuilder.ClickChord(ParseChord(keyEvent));

                }
            }

            eventBuilder.Invoke();
        }

        private KeyCode[] ParseChord(string chordString)
        {
            List<KeyCode> returnCodes = new List<KeyCode>();
            string[] chordParts = chordString.Trim('(', ')').Split('+');
            foreach (string chordPart in chordParts)
            {
                KeyCode code = ParseKeyCode(chordPart);
                returnCodes.Add(code);
            }

            return returnCodes.ToArray();
        }

        private KeyCode ParseKeyCode(string chordPart)
        {
            return Enum.Parse<KeyCode>(chordPart,true);
        }
    }
}