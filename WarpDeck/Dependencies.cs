using Autofac;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WarpDeck.Adapter.Actions;
using WarpDeck.Adapter.Actions.LocalSystem;
using WarpDeck.Adapter.Behaviors;
using WarpDeck.Adapter.Icons;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain;

namespace WarpDeck
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Dependencies
    {
        public class BehaviorsModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<SinglePressBehavior>().Named<KeyBehavior>(nameof(SinglePressBehavior));
                builder.RegisterType<PressAndHoldBehavior>().Named<KeyBehavior>(nameof(PressAndHoldBehavior));
                base.Load(builder);
            }
        }

        public class IconsModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<SinglePressIconGenerator>().Named<IconGenerator>(nameof(SinglePressBehavior));
                builder.RegisterType<PressAndHoldIconGenerator>().Named<IconGenerator>(nameof(PressAndHoldBehavior));
                base.Load(builder);
            }
        }

        public class ActionsModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<WindowInputKeyAction>().Named<KeyAction>(nameof(WindowInputKeyAction));
                builder.RegisterType<LaunchApplicationAction>().Named<KeyAction>(nameof(LaunchApplicationAction));
                base.Load(builder);
            }
        }

        public class PresentationModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<Presentation.Presentation>();
                base.Load(builder);
            }
        }

        public class RulesModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<RuleManager>().SingleInstance();
                base.Load(builder);
            }
        }
    }
}