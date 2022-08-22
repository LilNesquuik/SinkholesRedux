using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Extensions;
using MEC;
using UnityEngine;

namespace SinkholesRedux
{

    public class EventHandlers
    {
        private readonly Plugin plugin;


        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnStayEnvironmentalHazard(StayingOnEnvironmentalHazardEventArgs ev)
        {
            if (ev.EnvironmentalHazard is SinkholeEnvironmentalHazard sinkholeEnvironmentalHazard)
            {
                if (ev.Player.IsScp)
                    return;

                if ((ev.Player.Position - sinkholeEnvironmentalHazard.transform.position).sqrMagnitude > plugin.Config.TeleportDistance * plugin.Config.TeleportDistance)
                    return;

                ev.Player.ReferenceHub.scp106PlayerScript.GrabbedPosition = ev.Player.Position;

                ev.Player.Position += Vector3.down * plugin.Config.fallingSpeed;

                Timing.CallDelayed(1f, () =>
                {

                    if (plugin.Config.BlackoutOnCorroding)
                    {
                        Map.TurnOffAllLights(plugin.Config.TurnOffDuration, ZoneType.LightContainment);
                    }

                    ev.Player.EnableEffect(EffectType.Corroding);
                    ev.Player.EnableEffect(EffectType.SinkHole);
                    ev.Player.Broadcast(plugin.Config.TeleportMessage);
                });
            }

        }

    }
}