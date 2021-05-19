using System.Collections.Generic;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Application.Rules
{
    public class RuleManager
    {
        private readonly Dictionary<string, TagRuleCollection> _rules = new Dictionary<string, TagRuleCollection>();

        public string GetStyleValue(string styleKey, KeyModel key, string defaultValue)
        {
            //check for explicit tags
            if (key.Tags.HasTag(styleKey))
                return key.Tags.GetTag(styleKey).Value;

            //check for style rules
            var hasRuleSetForStyleKey = _rules.ContainsKey(styleKey);
            if (!hasRuleSetForStyleKey) return defaultValue; // no rules match


            TagRuleCollection foundRuleCollection = _rules[styleKey];
            var evaluatedStyleValue = foundRuleCollection.EvaluateRules(key.Tags);
            return !string.IsNullOrEmpty(evaluatedStyleValue) 
                ? evaluatedStyleValue 
                : defaultValue;
        }

        private void AddRule(TagRule tagRule)
        {
            if (!_rules.ContainsKey(tagRule.StyleKey))
                _rules[tagRule.StyleKey] = new TagRuleCollection();
            _rules[tagRule.StyleKey].AddRule(tagRule);
        }

        public bool HasRule(string key)
        {
            return _rules.ContainsKey(key);
        }
        
        public void AddRules(params TagRule[] rules)
        {
            foreach (TagRule rule in rules) AddRule(rule);
        }
    }
}