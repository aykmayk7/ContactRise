using System.Threading.Tasks;

namespace EventBus.Interfaces
{
    public interface IRabbitMQPublish<T>
    {
        Task SendMessage(T Model);
    }
}
