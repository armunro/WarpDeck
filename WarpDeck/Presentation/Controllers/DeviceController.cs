using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections;
using WarpDeck.Presentation.Controllers.Models;

namespace WarpDeck.Presentation.Controllers
{
    [ApiController]
    public class DeviceController : Controller
    {

        public DeviceManager DeviceManager;

        public DeviceController(DeviceManager deviceManager)
        {
            DeviceManager = deviceManager;
        }


        // GET
        [HttpGet]
        [Route("api/[controller]/")]
        public DeviceResponseModel[] AllDevices()
        {
            return new[] {CreateSummaryModel(Program.Container.Resolve<DeviceManager>().Devices.Values.First())};
        }


        [HttpGet]
        [Route("api/[controller]/{deviceId}")]
        public DeviceResponseModel DeviceById(string deviceId)
        {
            DeviceResponseModel summaryModel = CreateSummaryModel(Program.Container.Resolve<DeviceManager>().Devices.Values.First());
            summaryModel.Layers = CreateLayerSummaryModels(Program.Container.Resolve<DeviceManager>().Devices.Values.First().Layers.Values, deviceId);
            return summaryModel;
        }

        [HttpGet]
        [Route("api/[controller]/{deviceId}/layer")]
        public DeviceResponseModel DeviceLayersByDeviceId(string deviceId)
        {
            DeviceResponseModel summaryModel = CreateSummaryModel(Program.Container.Resolve<DeviceManager>().Devices.Values.First());
            summaryModel.Layers = CreateLayerSummaryModels(Program.Container.Resolve<DeviceManager>().Devices.Values.First().Layers.Values, deviceId);
            return summaryModel;
        }

        [HttpGet]
        [Route("api/[controller]/{deviceId}/layer/{layerId}")]
        public LayerResponseModel DeviceLayerByDeviceAndLayerId(string deviceId, string layerId)
        {
            LayerResponseModel summaryModel =
                CreateLayerSummaryModel(Program.Container.Resolve<DeviceManager>().Devices.Values.First().DeviceId, layerId);
            summaryModel.Keys = CreateKeySummaryModels(deviceId, layerId,
                Program.Container.Resolve<DeviceManager>().Devices.Values.First().Layers.GetLayerById(layerId).Keys);

            return summaryModel;
        }

        private static KeyResponseModel[] CreateKeySummaryModels(string deviceId, string layerId, KeyMap keys)
        {
            return keys.Select(x => new KeyResponseModel
            {
                Uri = $"/device/{deviceId}/layer/{layerId}/key/{x.Value.KeyId}",
                IconUri = $"/render/layer/{layerId}/icon/{x.Value.KeyId}",
                KeyId = x.Value.KeyId,
                Tags = CreateTagResponseModels(x.Value.Tags),
                Behavior = new BehaviorResponseModel
                {
                    Uri = $"/behavior/{x.Value.Behavior.BehaviorTypeName}",
                    BehaviorId = x.Value.Behavior.BehaviorId,
                    Provider = x.Value.Behavior.Provider,
                    Actions =  x.Value.Behavior.Actions
                }
            }).ToArray();
        }

        private static TagResponseModel[] CreateTagResponseModels(TagMap valueTags)
        {
            return valueTags.GetAll().Select(x => new TagResponseModel
            {
                Provider = x.Provider,
                Name = x.Name,
                Value = x.Value
            }).ToArray();
        }

        private static LayerResponseModel CreateLayerSummaryModel(string deviceId, string layerId)
        {
            return new LayerResponseModel
            {
                Uri = $"/device/{deviceId}/layer/{layerId}"
            };
        }

        private static LayerResponseModel[] CreateLayerSummaryModels(IEnumerable<LayerModel> layers, string deviceId)
        {
            return layers.Select(x => CreateLayerSummaryModel(deviceId, x.LayerId)).ToArray();
        }


        private static DeviceResponseModel CreateSummaryModel(DeviceModel device)
        {
            return new DeviceResponseModel
            {
                DeviceId = device.DeviceId,
                Uri = $"/device/{device.DeviceId}"
            };
        }
    }
}