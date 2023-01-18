using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Extensions;
using MEC;
using UnityEngine;
using Hazards;
using CustomPlayerEffects;
using PlayerStatsSystem;
using System.Collections.Generic;
using System;

namespace SinkholesRedux
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "LilNesquuik";
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        public override Version Version { get; } = new Version(0, 1, 0);
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.StayingOnEnvironmentalHazard += OnStayEnvironmentalHazard;
            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.StayingOnEnvironmentalHazard -= OnStayEnvironmentalHazard;
            base.OnDisabled();
        }

        public void OnStayEnvironmentalHazard(StayingOnEnvironmentalHazardEventArgs ev)
        {
            if (ev.Player is null || ev.Player.IsScp)
                return;

            if (ev.EnvironmentalHazard is SinkholeEnvironmentalHazard && Vector3.Distance(ev.Player.Position, ev.EnvironmentalHazard.transform.position) < 2.5f)
            {
                Timing.RunCoroutine(PortalAnimation(ev.Player));
            }
        }

        public static readonly HashSet<Player> _SinkholesPlayer = new HashSet<Player>();
        public static IEnumerator<float> PortalAnimation(Player player)
        {
            if (_SinkholesPlayer.Contains(player))
                yield break;

            _SinkholesPlayer.Add(player);

            bool inGodMode = player.IsGodModeEnabled;
            player.IsGodModeEnabled = true;

            Vector3 startPosition = player.Position, endPosition = player.Position -= Vector3.up * 1.23f * player.GameObject.transform.localScale.y;
            for (int i = 0; i < 30; i++)
            {
                player.Position = Vector3.Lerp(startPosition, endPosition, i / 30f);
                yield return 0f;
            }

            player.Position = Vector3.down * 1997f;
            player.IsGodModeEnabled = inGodMode;

            if (Warhead.IsDetonated)
            {
                player.Kill(DeathTranslations.PocketDecay.LogLabel);
                yield break;
            }

            player.Hurt(10, DamageType.PocketDimension);
            player.EnableEffect<Corroding>();

            _SinkholesPlayer.Remove(player);
        }

    }
}
