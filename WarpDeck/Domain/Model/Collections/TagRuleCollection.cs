using System.Collections.Generic;
using System.Linq;

namespace WarpDeck.Domain.Model.Collections
{
    public class TagRuleCollection
    {
        private readonly List<TagRule> _rules = new List<TagRule>();

        public string EvaluateRules(TagMap tags)
        {
            string styleValue = "";

            foreach (var styleRule in _rules.Where(styleRule => styleRule.IsMetBy(tags)))
            {
                styleValue = styleRule.CalculateValue(tags);
            }

            return styleValue;
        }

        public void AddRule(TagRule tagRule)
        {
            _rules.Add(tagRule);
        }
    }
}