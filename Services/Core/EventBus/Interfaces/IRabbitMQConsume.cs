using System.Threading.Tasks;

namespace EventBus.Interfaces
{
    public interface IRabbitMQConsume
    {
        Task<string> ConsumeMessage();

    }
}
