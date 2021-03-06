using System.Diagnostics.CodeAnalysis;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class LayerModel
    {
        public string LayerId { get; set; }
        public KeyMap Keys { get; set; }= new KeyMap();
    }
}