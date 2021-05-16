using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Presentation
{

    public class Layer : PageModel
    {
        public List<LayerModel> Layers;

        // ReSharper disable once UnusedMember.Global
        public void OnGet()
        {
            Layers = Program.Container.Resolve<DeviceManager>().Devices.Values.First().Layers.Values.ToList();
        }
    }
}