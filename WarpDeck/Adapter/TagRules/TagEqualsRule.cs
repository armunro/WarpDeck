using WarpDeck.Domain;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Adapter.TagRules
{
    public class TagEqualsRule : TagRule
    {
        private readonly string _tagProvider;
        private readonly string _tagName;
        private readonly string _matchesText;


        public TagEqualsRule(string tagProvider, string tagName, string matchesText, string desiredValue,
            string styleKey)
            : base(desiredValue, styleKey)
        {
            _tagProvider = tagProvider;
            _tagName = tagName;
            _matchesText = matchesText;
        }

        public override bool IsMetBy(TagMap tags)
        {
            TagModel tag = tags[_tagProvider, _tagName];
            if (tag == null)
                return false;
            return tag.Value == _matchesText;
        }

        public override string CalculateValue(TagMap tags)
        {
            return DesiredValue;
        }
    }
}