using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Presentation
{
    public class Index : PageModel
    {
        public DeviceModel Device { get; private set; }
        
        // ReSharper disable once UnusedMember.Global
        public void OnGet()
        {
            Device = Program.Container.Resolve<DeviceManager>().Devices.Values.First();
        }
    }
}