using System.Drawing;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using WarpDeck.Domain;
using WarpDeck.Domain.Helpers.Extensions;
using WarpDeck.Domain.Model;

namespace WarpDeck.Presentation.Controllers
{
    [ApiController]
    public class RenderController : Controller
    {
        [HttpGet]
        [Route("api/render/live/icon/{keyId:int}")]
        public IActionResult RenderLiveStateIcon(int keyId)
        {
            KeyModel keyInput = null;
            if (Program.Container.Resolve<DeviceManager>().KeyStates.Values.First().IsKeyMapped(keyId))
                keyInput = Program.Container.Resolve<DeviceManager>().KeyStates.Values.First()[keyId];
            Bitmap icon =Program.Container.Resolve<DeviceManager>().GenerateKeyIcon(keyInput);
            return File(icon.ToMemoryStream(), "image/png", "key.png");
        }

        [HttpGet]
        [Route("api/render/layer/{layerId}/icon/{keyId}")]
        public IActionResult RenderLayerIcon(string layerId, int keyId)
        {
            KeyModel mappedKey = Program.Container.Resolve<DeviceManager>().Devices.Values.First().Layers.GetLayerById(layerId).Keys[keyId];

            Bitmap icon = Program.Container.Resolve<DeviceManager>().GenerateKeyIcon(mappedKey);
            return File(icon.ToMemoryStream(), "image/png", "key.png");
        }
    }
}