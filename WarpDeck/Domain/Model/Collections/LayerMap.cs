using System.Collections.Generic;
using System.Linq;

namespace WarpDeck.Domain.Model.Collections
{
    public class LayerMap : Dictionary<string, LayerModel>
    {
    

        public LayerMap(IEnumerable<LayerModel> layers)
        {
            foreach (LayerModel layerModel in layers) 
                Add(layerModel.LayerId, layerModel);
        }

        public LayerMap()
        {
            
        }

        


        

        public LayerModel GetLayerById(string layerId)
        {
            TryGetValue(layerId, out var returnLayerOrNull);
            return returnLayerOrNull;
        }
    }
}