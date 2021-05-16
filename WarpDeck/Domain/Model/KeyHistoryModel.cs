using System;

namespace WarpDeck.Domain.Model
{
    public class KeyHistoryModel
    {
        public DateTime LastDown { get; set; }
        public DateTime LastUp { get; set; }
        public DateTime LastSetIcon { get; set; }
    }
}