using System.IO;
using Newtonsoft.Json;
using WarpDeck.Layers;

namespace WarpDeck.Configuration
{
    public class LayerConfigWriter
    {
        public void WriteLayerConfig(string path, KeyLayer layer)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(layer));
        }
    }
}