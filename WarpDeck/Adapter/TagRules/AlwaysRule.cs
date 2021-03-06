using WarpDeck.Domain;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Adapter.TagRules
{
    public class AlwaysRule : TagRule
    {
        public AlwaysRule(string desiredValue, string styleKey) : base(desiredValue, styleKey)
        {
        }

        public override bool IsMetBy(TagMap tags) => true;

        public override string CalculateValue(TagMap tags)
        {
            return DesiredValue;
        }
    }
}