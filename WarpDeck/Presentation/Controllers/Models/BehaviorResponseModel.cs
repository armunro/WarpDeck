using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WarpDeck.Domain.Model;

namespace WarpDeck.Presentation.Controllers.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class BehaviorResponseModel
    {
        public string Uri { get; set; }
        public string BehaviorId { get; set; }
        public string Provider { get; set; }
        public Dictionary<string, ActionModel> Actions { get; set; }
    }
}