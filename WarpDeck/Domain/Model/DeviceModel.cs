using System.Diagnostics.CodeAnalysis;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class DeviceModel
    {
        public string DeviceId { get; set; }
        public LayerMap Layers { get; set; }
    }
}