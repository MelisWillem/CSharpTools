using Autofac;
using CSharpTools.CodeReader.Contracts;
using CSharpTools.CodeReader.Domain;
using CSharpTools.CodeReader.Domain.Builders;
using System;

namespace CSharpTools.IOC
{
    public class CodeReaderModule : Module
    {
        public ISourceFileReader Reader { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            
            builder.RegisterType<InterfaceBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<InterfacePropertyBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<NamespaceBuilder>()
                .AsImplementedInterfaces();
            builder.RegisterType<TypeBuilder>()
                .AsImplementedInterfaces();

            builder.RegisterType<CSharpReader>()
                .WithParameter(new TypedParameter(typeof(ISourceFileReader), Reader));
            builder.RegisterType<NamespaceTypeGenerator>()
                .AsImplementedInterfaces();
        }
    }
}
