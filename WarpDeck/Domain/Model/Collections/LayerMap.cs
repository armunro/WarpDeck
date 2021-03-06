using System.Collections.Generic;
using System.Linq;

namespace WarpDeck.Domain.Model.Collections
{
    public class LayerMap
    {
        public Dictionary<string, LayerModel> ItemLookup { get; }

        public LayerMap(IEnumerable<LayerModel> layers)
        {
            ItemLookup = layers.ToDictionary(x => x.LayerId, x => x);
        }


        public List<LayerModel> GetAllLayers()
        {
            return ItemLookup.Values.ToList();
        }

        public LayerModel GetLayerById(string layerId)
        {
            ItemLookup.TryGetValue(layerId, out var returnLayerOrNull);
            return returnLayerOrNull;
        }
    }
}