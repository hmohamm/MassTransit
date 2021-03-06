namespace Grid.Distributor.Shared
{
    using MassTransit.StructureMapIntegration;
    using MassTransit.Transports.Msmq;

    public class IocRegistry : MassTransitRegistryBase
    {
        public IocRegistry(string receiverQueue, string subscriptionQueue)
        {
            RegisterEndpointFactory(efc => efc.RegisterTransport<MsmqEndpoint>());
            RegisterServiceBus(receiverQueue, x => ConfigureSubscriptionClient(subscriptionQueue, x));
        }
    }
}