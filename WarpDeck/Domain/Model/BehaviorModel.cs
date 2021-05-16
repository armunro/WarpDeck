using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class BehaviorModel
    {
        public string Provider { get; set; }
        public string BehaviorId { get; set; }
        public string BehaviorTypeName { get; set; }
        public Dictionary<string,ActionModel> Actions { get; set; } = new Dictionary<string, ActionModel>();

    }
}