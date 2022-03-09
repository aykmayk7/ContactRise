namespace CR.Core
{
    public class QueueService { }

    public class QueueService<T> : QueueService
    {
        public QueueService(T data) { Data = data; }
        public T Data { get; set; }
    }
}
