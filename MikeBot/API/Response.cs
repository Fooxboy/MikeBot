using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API
{
    /// <summary>
    /// Единый класс всех оветов.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public T obj { get; set; }
        public int error_code { get; set; }
        public Models.Error error { get; set; }
        public LongPoll.Deserialize.ErrorObject LongPollError { get; set; }
    }
}
