using System.Collections.Generic;
using System.Linq;

namespace WarpDeck.Domain.Model.Collections
{
    public class TagMap : Dictionary<string,Dictionary<string,TagModel>>
    {
        

        public TagMap()
        {
            
        }
        public TagMap(IEnumerable<TagModel> tags)
        {
            
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
            return ContainsKey(tagProvider) && this[tagProvider].ContainsKey(tagName);
        }
        public TagModel GetTag(string tagName, string tagProvider = Defaults.DefaultTagProvider)
        {
            return this[tagProvider][tagName];
        }
        
        private void AddTag(TagModel tag)
        {
            if(!this.ContainsKey(tag.Provider))
                this.Add(tag.Provider, new Dictionary<string, TagModel>());
            var providerDict = this[tag.Provider];
            providerDict.Add(tag.Name, tag);
        }

        public TagModel this[string  tagProvider, string tagName] => ContainsKey(tagProvider) ? this[tagProvider].ContainsKey(tagName) ? this[tagProvider][tagName] : null : null;


        public IEnumerable<TagModel> GetAll() => this.Values.SelectMany(x => x.Values).ToList();
    }
}