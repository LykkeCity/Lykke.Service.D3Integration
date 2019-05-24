using Autofac;
using JetBrains.Annotations;
using Lykke.HttpClientGenerator;
using Lykke.HttpClientGenerator.Infrastructure;
using System;

namespace Lykke.Service.D3Integration.Client
{
    /// <summary>
    /// Extension for client registration
    /// </summary>
    [PublicAPI]
    public static class AutofacExtension
    {
        /// <summary>
        /// Registers <see cref="ID3IntegrationClient"/> in Autofac container using <see cref="D3IntegrationServiceClientSettings"/>.
        /// </summary>
        /// <param name="builder">Autofac container builder.</param>
        /// <param name="settings">D3Integration client settings.</param>
        /// <param name="builderConfigure">Optional <see cref="HttpClientGeneratorBuilder"/> configure handler.</param>
        public static void RegisterD3IntegrationClient(
            [NotNull] this ContainerBuilder builder,
            [NotNull] D3IntegrationServiceClientSettings settings,
            [CanBeNull] Func<HttpClientGeneratorBuilder, HttpClientGeneratorBuilder> builderConfigure)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrWhiteSpace(settings.ServiceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(D3IntegrationServiceClientSettings.ServiceUrl));

            var clientBuilder = HttpClientGenerator.HttpClientGenerator.BuildForUrl(settings.ServiceUrl)
                .WithAdditionalCallsWrapper(new ExceptionHandlerCallsWrapper());

            clientBuilder = builderConfigure?.Invoke(clientBuilder) ?? clientBuilder.WithoutRetries();

            builder.RegisterInstance(new D3IntegrationClient(clientBuilder.Create()))
                .As<ID3IntegrationClient>()
                .SingleInstance();
        }
    }
}
