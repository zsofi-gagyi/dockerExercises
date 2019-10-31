using System.Collections.Generic;

namespace consumer.Memory
{
    public class NewsStore
    {
        public static LinkedList<string[]> news;

        public NewsStore()
        {
            news = new LinkedList<string[]>();
        }
    }
}
