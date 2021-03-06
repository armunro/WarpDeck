using System.Collections.Generic;
using System.Linq;

namespace WarpDeck.Domain.Model.Collections
{
    public class TagMap
    {
        private Dictionary<string, Dictionary<string, TagModel>> Tags { get; }

        public TagMap()
        {
            Tags = new Dictionary<string, Dictionary<string, TagModel>>();
        }
        public TagMap(IEnumerable<TagModel> tags)
        {
            Tags = new Dictionary<string, Dictionary<string, TagModel>>();
            foreach (TagModel keyTag in tags)
            {
                AddTag(keyTag);
            }
        }

        public TagMap(params string[] unparsedTags):this()
        {
            foreach (string unparsedTag in unparsedTags)
            {
                TagModel parsedTag = TagModel.ParseTagString(unparsedTag);
                AddTag(parsedTag);
            }
        }

        public bool HasTag(string tagName, string tagProvider = Defaults.DefaultTagProvider)
        {
            return Tags.ContainsKey(tagProvider) && Tags[tagProvider].ContainsKey(tagName);
        }
        public TagModel GetTag(string tagName, string tagProvider = Defaults.DefaultTagProvider)
        {
            return Tags[tagProvider][tagName];
        }
        
        private void AddTag(TagModel tag)
        {
            if(!Tags.ContainsKey(tag.Provider))
                Tags.Add(tag.Provider, new Dictionary<string, TagModel>());
            var providerDict = Tags[tag.Provider];
            providerDict.Add(tag.Name, tag);
        }

        public TagModel this[string  tagProvider, string tagName] => Tags.ContainsKey(tagProvider) ? Tags[tagProvider].ContainsKey(tagName) ? Tags[tagProvider][tagName] : null : null;


        public IEnumerable<TagModel> GetAll() => Tags.Values.SelectMany(x => x.Values).ToList();
    }
}