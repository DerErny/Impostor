using System.Collections.Generic;
using System.Numerics;
using Impostor.Api.Innersloth;
using Impostor.Api.Innersloth.Maps;
using Impostor.Api.Net.Inner.Objects.ShipStatus;
using Impostor.Server.Net.Inner.Objects.Systems;
using Impostor.Server.Net.Inner.Objects.Systems.ShipStatus;
using Impostor.Server.Net.State;

namespace Impostor.Server.Net.Inner.Objects.ShipStatus
{
    internal class InnerMiraShipStatus : InnerShipStatus, IInnerMiraShipStatus
    {
        public InnerMiraShipStatus(Game game) : base(game)
        {
        }

        public override MapData Data => MapData.Maps[MapTypes.MiraHQ];

        public override Dictionary<int, bool> Doors { get; } = new Dictionary<int, bool>(0);

        public override float SpawnRadius => 1.55f;

        public override Vector2 InitialSpawnCenter { get; } = new Vector2(-4.4f, 2.2f);

        public override Vector2 MeetingSpawnCenter { get; } = new Vector2(24.043f, 1.72f);

        protected override void AddSystems(Dictionary<SystemTypes, ISystemType> systems)
        {
            base.AddSystems(systems);

            systems.Add(SystemTypes.Comms, new HudOverrideSystemType());
            systems.Add(SystemTypes.Reactor, new ReactorSystemType());
            systems.Add(SystemTypes.LifeSupp, new LifeSuppSystemType());
        }
    }
}
