using System;
using System.Collections.Generic;
using System.IO;
using Autofac;
using Newtonsoft.Json;
using StreamDeckSharp;
using WarpDeck.Adapter.JsonConverters;
using WarpDeck.Application.Rules;
using WarpDeck.Application.Samples;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

//<-- Here it is


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
            Presentation.Presentation.StartAsync(args);
            Container.Resolve<DeviceManager>().RefreshBoard("office-streamdeck");

            Console.WriteLine("//--warp-deck--//");
            Console.ReadKey();
        }

        private static void SetDevelopmentRules()
        {
            Container.Resolve<DeviceManager>().Rules.AddRules(
                TagRules.Always("svg.fill.color", "#FFF"),
                TagRules.Always("svg.baseDirectory", "C:/Users/andrewm/Desktop/fa/solid"),
                TagRules.WhenTagEquals("background.color", "key.category", "Multimedia", "#800080"),
                TagRules.WhenTagEquals("background.color", "key.category", "Window", "#ffae00"),
                TagRules.WhenTagEquals("background.color", "key.category", "Clipboard", "#ed631a"),
                TagRules.WhenTagEquals("background.color", "key.category", "Apps", "#FF33A8"),
                TagRules.WhenTagEquals("background.color", "key.category", "Rider-VCS", "#216b44"));
        }
    }
}