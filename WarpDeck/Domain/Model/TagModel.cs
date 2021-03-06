using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace WarpDeck.Domain.Model
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    
    public class TagModel
    {
     
        public string Provider { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        
        public static TagModel ParseTagString(string tagString)
        {
            Match match = Regex.Match(tagString, "(.*)[ ]?=[ ]?(.*)");
            string key = match.Groups[1].Value;
            string value = match.Groups[2].Value;
            string provider = Defaults.DefaultTagProvider;
            
            if (!key.ToLower().Contains(":"))
                return new TagModel {Provider = provider.Trim(), Name = key.Trim(), Value = value.Trim()};
            
            string[] keyParts = key.Split(':');
            provider = keyParts[0];
            key = keyParts[1];

            return new TagModel {Provider = provider.Trim(), Name = key.Trim(), Value = value.Trim()};
        }
    }
}