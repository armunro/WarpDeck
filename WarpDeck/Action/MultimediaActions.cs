using WindowsInput.Events;

namespace WarpDeck.Action
{
    public static class MultimediaActions
    {
        public static WarpAction VolumeUp => Actions.WindowsInput(x => x.Click(KeyCode.VolumeUp));

        public static WarpAction VolumeDown => Actions.WindowsInput(x => x.Click(KeyCode.VolumeDown));

        public static WarpAction PlayPause => Actions.WindowsInput(x => x.Click(KeyCode.MediaPlayPause));
    }
}