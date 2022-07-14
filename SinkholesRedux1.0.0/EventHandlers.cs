using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace SinkholesRedux
{

    public class EventHandlers
    {
        private readonly Plugin plugin;


        public EventHandlers(Plugin plugin) => this.plugin = plugin;


        public void OnWalkingOnSinkhole(WalkingOnSinkholeEventArgs ev)
        {
            if (ev.Player.SessionVariables.ContainsKey("IsNPC"))
                return;

            if (ev.Player.IsScp)
                return;

            if ((ev.Player.Position - ev.Sinkhole.transform.position).sqrMagnitude > plugin.Config.TeleportDistance * plugin.Config.TeleportDistance)
                return;

            ev.IsAllowed = false;
            ev.Player.DisableEffect(EffectType.SinkHole);

            ev.Player.ReferenceHub.scp106PlayerScript.GrabbedPosition = ev.Player.Position;

            ev.Player.Position += Vector3.up * -0.55f;

            Timing.CallDelayed(2.75f, () =>
            {
                if (plugin.Config.BlackoutOnCorroding)
                {
                    Map.TurnOffAllLights(plugin.Config.TurnOffDuration, ZoneType.LightContainment);
                }

                if (plugin.Config.KillCorroding)
                {
                    ev.Player.EnableEffect(EffectType.Asphyxiated, duration: 300);
                }

                ev.Player.EnableEffect(EffectType.Corroding);
                ev.Player.Broadcast(plugin.Config.TeleportMessage);
            });


        }

    }
}