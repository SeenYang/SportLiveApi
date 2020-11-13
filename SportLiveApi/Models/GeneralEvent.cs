using System;

namespace SportLiveApi.Models.Entities
{
    public class GeneralEvent : EventBase
    {
        public override EventTypeEnum EventType { get; } = EventTypeEnum.Default;
        public override EventSubTypeEnum EventSubType { get; }
    }
}