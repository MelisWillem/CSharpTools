using Autofac;
using CSharpTools.CodeWriter.Domain.Builders;
using System;

namespace CSharpTools.IOC
{

    public class CodeWriterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<AccessModifierBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfaceMockBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfaceMockMethodBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<NamespaceBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<PropertyBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<TypeBuilder>()
               .AsImplementedInterfaces();
        }
    }
}
