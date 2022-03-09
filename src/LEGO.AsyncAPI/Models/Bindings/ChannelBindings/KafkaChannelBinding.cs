// Copyright (c) The LEGO Group. All rights reserved.

namespace LEGO.AsyncAPI.Models.Bindings.ChannelBindings
{
    using LEGO.AsyncAPI.Models.Any;
    using LEGO.AsyncAPI.Models.Interfaces;

    /// <summary>
    /// Binding class for Kafka channels.
    /// </summary>
    public class KafkaChannelBinding : IChannelBinding
    {
        /// <inheritdoc/>
        public IDictionary<string, IAny> Extensions { get; set; }
    }
}