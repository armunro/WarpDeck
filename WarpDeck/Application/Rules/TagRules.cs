using System.Diagnostics.CodeAnalysis;
using WarpDeck.Adapter.TagRules;
using WarpDeck.Domain;

namespace WarpDeck.Application.Rules
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class TagRules
    {
        public static TagRule Always(string styleKey, string value) => new AlwaysRule(value, styleKey);

        public static TagRule WhenTagEquals(string styleKey, string tagName, string matchesText, string desiredValue,
            string tagProvider = Defaults.DefaultTagProvider) =>
            new TagEqualsRule(tagProvider, tagName, matchesText, desiredValue, styleKey);
    }
}