

namespace SinkholesRedux
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using MEC;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The distance from the center of a sinkhole where a player gets teleported. This is limited to inside the sinkhole's range. 3.3 recommanded")]
        public float TeleportDistance { get; set; } = 3.3f;

        [Description("Creates interference in the site's electrical system when passing through a sinkhole.")]
        public bool BlackoutOnCorroding { get; set; } = true;

        [Description("The number of seconds of the blackout when passing through a sinkhole.")]
        public float TurnOffDuration { get; set; } = 0.9f;


        [Description("The distance from the center of a sinkhole where a player gets teleported. This is limited to inside the sinkhole's range. 2.3 recommanded")]
        public Broadcast TeleportMessage { get; set; } = new Broadcast
        {
            Content = "You've fallen into the pocket dimension!",
            Duration = 5,
            Show = false,
        };



    }

}

