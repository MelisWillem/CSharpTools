using Autofac;
using CSharpTools.CodeReader.Domain;
using CSharpTools.CodeReader.Domain.Builders;
using System;

namespace CSharpTools.IOC
{

    public class CodeReaderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<SyntaxTokenTypeNameBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<TypeNameBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfacePropertyBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfaceBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<NamespaceTypeGenerator>()
                .AsImplementedInterfaces();
        }
    }
}
