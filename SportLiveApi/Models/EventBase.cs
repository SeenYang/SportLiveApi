using System;

namespace SportLiveApi.Models
{
    public abstract class EventBase
    {
        public Guid Guid { get; set; }
        public abstract EventTypeEnum EventType { get; }
        public abstract EventSubTypeEnum EventSubType { get; }
        public DateTime TimeStamp { get; set; }
    }
}