using System;
using System.Collections.Generic;
using Autofac;
using OpenMacroBoard.SDK;
using StreamDeckSharp;
using WarpDeck.Adapter.Actions;
using WarpDeck.Application.Rules;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;
using WarpDeck.Domain.Model.Collections; //<-- Here it is


namespace WarpDeck
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static IContainer Container;


        private static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<Dependencies.IconsModule>();
            builder.RegisterModule<Dependencies.BehaviorsModule>();
            builder.RegisterModule<Dependencies.ActionsModule>();
            builder.RegisterModule<Dependencies.PresentationModule>();
            builder.RegisterModule<Dependencies.RulesModule>();

            using var streamdeck = StreamDeck.OpenDevice();

          
            builder.RegisterInstance(new DeviceManager().AddDevice(streamdeck, SetDevelopmentDevice())).AsSelf();
            Container = builder.Build();

            SetDevelopmentRules();
            Presentation.Presentation.StartAsync(args);
            Container.Resolve<DeviceManager>().RefreshBoard("office-streamdeck");

            Console.WriteLine("// --warp-deck- //");
            Console.ReadKey();
        }

        private static void SetDevelopmentRules()
        {
            Container.Resolve<DeviceManager>().Rules.AddRules(
                TagRules.Always("text", ""),
                TagRules.Always("text.top", "10"),
                TagRules.Always("text.left", "10"),
                TagRules.Always("svg.scale.width", ".5"),
                TagRules.Always("svg.scale.height", ".5"),
                TagRules.Always("svg.position.top", "40"),
                TagRules.Always("svg.position.left", "36"),
                TagRules.Always("svg.baseDirectory", "C:/Users/andrewm/Desktop/fa-pro-5.15.2/regular/"),
                TagRules.WhenTagEquals("background.color", "key.category", "Multimedia", "#370f69"),
                TagRules.WhenTagEquals("background.color", "key.category", "Window", "#0f3369"),
                TagRules.WhenTagEquals("background.color", "key.category", "Apps", "#FF33A8"));
        }

        private static DeviceModel SetDevelopmentDevice()
        {
            return new DeviceModel
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
                                            Type = "SinglePressBehavior", BehaviorId = "SinglePressBehavior",
                                            Provider = "warpdeck",
                                            Actions = new Dictionary<string, ActionModel>()
                                            {
                                                {"press", new ActionModel() {Type = nameof(WindowInputKeyAction)}}
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
}