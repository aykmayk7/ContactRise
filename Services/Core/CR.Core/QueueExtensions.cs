using Newtonsoft.Json;

namespace CR.Core
{
    public static class QueueExtensions
    {
        public static string SerializeObject(this QueueService request)
        {
            return JsonConvert.SerializeObject(request);
        }

        public static T DeserializeObject<T>(this object request)
        {
            return JsonConvert.DeserializeObject<T>(request.ToString());
        }
    }
}
