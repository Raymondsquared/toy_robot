using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ToyRobot.Abstractions;
using ToyRobot.Helpers;
using ToyRobot.Models;
using ToyRobot.Providers;
using ToyRobot.Services;

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
        }
    }
}
