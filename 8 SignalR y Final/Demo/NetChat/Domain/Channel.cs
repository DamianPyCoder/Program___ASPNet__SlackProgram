using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Channel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Message> Messages { get; set; }

        public ChannelType ChannelType { get; set; }

        public string PrivateChannelId { get; set; }
    }
}
