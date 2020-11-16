using System;

namespace SportLiveApi.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public  EventTypeEnum EventType { get; set; }
        public  EventSubTypeEnum EventSubType { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid GameId { get; set; }
        public Guid TeamId { get; set; }
        public Guid? PlayerId { get; set; }
        public string Message { get; set; }
    }
}