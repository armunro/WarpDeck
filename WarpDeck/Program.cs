using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Newtonsoft.Json;
using OpenMacroBoard.SDK;
using StreamDeckSharp;
using WarpDeck.Adapter.Actions;
using WarpDeck.Adapter.JsonConverters;
using WarpDeck.Application.Rules;
using WarpDeck.Application.Samples;
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


            string readFileName = "testing.wpdevice.json";
            string writeFileName = "testing.wpdevice2.json";
            DeviceModel deviceModel;

            if (File.Exists(readFileName))
            {
                string fileContents = File.ReadAllText(readFileName);
                deviceModel = JsonConvert.DeserializeObject<DeviceModel>(fileContents, new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter>()
                    {
                        new TagJsonCoverter()
                    }
                });
            }
            else
                deviceModel = SampleDeviceModel.SingleLayerSingleKey;


            builder.RegisterInstance(new DeviceManager().AddDevice(streamdeck, deviceModel)).AsSelf();
            Container = builder.Build();

            SetDevelopmentRules();
            // File.WriteAllText(writeFileName,
            //     JsonConvert.SerializeObject(Container.Resolve<DeviceManager>().Devices.Values.First(),
            //         Formatting.Indented, new JsonSerializerSettings()
            //         {
            //             Converters = new List<JsonConverter>()
            //             {
            //                 new TagJsonCoverter()
            //             }
            //         }));
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
                TagRules.Always("text.fontFamily", "Segoe UI"),
                TagRules.Always("text.fontSize", "26"),
                TagRules.Always("svg.fill.color", "#FFFFFF99"),
                TagRules.Always("svg.scale.width", ".55"),
                TagRules.Always("svg.scale.height", ".55"),
                TagRules.Always("svg.position.top", "65"),
                TagRules.Always("svg.position.left", "55"),
                TagRules.Always("svg.baseDirectory", "C:/Users/andrewm/Desktop/fa/solid"),
                TagRules.WhenTagEquals("background.color", "key.category", "Multimedia", "#693c72"),
                TagRules.WhenTagEquals("background.color", "key.category", "Window", "#09015f"),
                TagRules.WhenTagEquals("background.color", "key.category", "Clipboard", "#d97642"),
                TagRules.WhenTagEquals("background.color", "key.category", "Apps", "#FF33A8"),
                TagRules.WhenTagEquals("background.color", "key.category", "Rider-VCS", "#216b44"));
        }
    }
}