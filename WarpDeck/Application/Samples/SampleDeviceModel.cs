using System.Collections.Generic;
using WarpDeck.Adapter.Actions;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Application.Samples
{
    public class SampleDeviceModel
    {
        public static DeviceModel SingleLayerSingleKey = new DeviceModel
        {
            DeviceId = "office-streamdeck",
            Layers = new LayerMap(new[]
            {
                new LayerModel
                {
                    LayerId = "windows-media",
                    Keys = new KeyMap(
                        new Dictionary<int, KeyModel>
                        {
                            {
                                0, new KeyModel
                                {
                                    KeyId = 0,
                                    Behavior = new BehaviorModel
                                    {
                                        BehaviorTypeName = "SinglePressBehavior",
                                        BehaviorId = "SinglePressBehavior",
                                        Provider = "warpdeck",
                                        Actions = new Dictionary<string, ActionModel>()
                                        {
                                            {
                                                "press", new ActionModel()
                                                {
                                                    ActionTypeName = nameof(WindowInputKeyAction),
                                                    Parameters = new Dictionary<string, string>()
                                                    {
                                                        {"keys", "{volumedown)"}
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    Tags = new TagMap("key.category = Window", "svg.path = volume-down.svg")
                                }
                            }
                        })
                }
            })
        };
    }
}