using Microsoft.AspNetCore.Mvc.RazorPages;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Presentation.Shared
{
    public class KeymapGridPartialModel : PageModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public KeyMap Keys { get; set; }

    }
}