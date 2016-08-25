using Autofac;
using ToyRobot.Abstractions;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Models;
using ToyRobot.Handler;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;
using ToyRobot.Infrastructure.Loggers;
using ToyRobot.Providers;

namespace ToyRobot.IoC
{
    /*
     *  Using Autofac Dependency Injection Container to reduce poorman dependency injection
     */
    public class BindingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            //Map
            var mapWidth = ConfigHelper.LoadOrDefault(CONSTANTS.TEXTS.CONFIG_MAP_WIDTH, CONSTANTS.NUMBERS.TABLETOP_WIDTH);
            var mapLength = ConfigHelper.LoadOrDefault(CONSTANTS.TEXTS.CONFIG_MAP_LENGTH, CONSTANTS.NUMBERS.TABLETOP_WIDTH);

            builder.RegisterType<TableTop>()
                .As<Map>()
                .WithParameter("width", mapWidth)
                .WithParameter("length", mapLength);

            //Command - Receiver Provider
            builder.RegisterType<ReceiverProvider>()
                .As<IProvider<Receiver>>();


            /* Input Handler Strategies */
            builder.RegisterType<FileInputHandler>()
                .As<IConsoleApplicationHandler>()
                .Keyed<IConsoleApplicationHandler>("file");

            builder.RegisterType<KeyboardInputHandler>()
                .As<IConsoleApplicationHandler>()
                .Keyed<IConsoleApplicationHandler>("keyboard");
        }
    }
}
