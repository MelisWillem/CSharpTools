using Autofac;
using CSharpTools.Entities;
using CSharpTools.Helpers;
using System;
using System.Collections.Generic;

namespace CSharpTools.IOC
{

    public class HelpersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<TypeNameEqualityComparer>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfaceEqualityComparer>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfacePropertyEqualityComparer>()
                .AsImplementedInterfaces();
        }
    }
}
