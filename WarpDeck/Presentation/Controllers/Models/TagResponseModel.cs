using System.Diagnostics.CodeAnalysis;

namespace WarpDeck.Presentation.Controllers.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class TagResponseModel
    {
        public string Provider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}