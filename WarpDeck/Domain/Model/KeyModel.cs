using System.Diagnostics.CodeAnalysis;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class KeyModel
    {
        public int KeyId { get; set; }
        public BehaviorModel Behavior { get; set; }
        public TagMap Tags { get; set; } = new TagMap();
    }
}