using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ActionModel
    {
        public string ActionTypeName { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
    }
}