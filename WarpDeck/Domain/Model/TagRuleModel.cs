using System.Diagnostics.CodeAnalysis;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class TagRuleModel
    {
        public string RuleType { get; set; }
        public string TargetTagProvider { get; set; }
        public string TargetTagName { get; set; }
        public string DesiredValue { get; set; }
    }
}