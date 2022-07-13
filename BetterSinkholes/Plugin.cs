namespace SinkholesRedux
{
    using System;
    using Exiled.API.Features;

    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;


        public override string Author => "LilNesquuik";
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 2);

        public override Version Version { get; } = new Version(0, 1, 0);

        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.WalkingOnSinkhole += eventHandlers.OnWalkingOnSinkhole;
            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.WalkingOnSinkhole -= eventHandlers.OnWalkingOnSinkhole;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}
