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
    internal class InnerSkeldShipStatus : InnerShipStatus, IInnerSkeldShipStatus
    {
        public InnerSkeldShipStatus(Game game) : base(game)
        {
        }

        public override MapData Data { get; } = MapData.Maps[MapTypes.Skeld];

        public override Dictionary<int, bool> Doors { get; } = new Dictionary<int, bool>(13);

        public override float SpawnRadius => 1.6f;

        public override Vector2 InitialSpawnCenter { get; } = new Vector2(-0.72f, 0.62f);

        public override Vector2 MeetingSpawnCenter { get; } = new Vector2(-0.72f, 0.62f);

        protected override void AddSystems(Dictionary<SystemTypes, ISystemType> systems)
        {
            base.AddSystems(systems);

            systems.Add(SystemTypes.Doors, new AutoDoorsSystemType(Doors));
            systems.Add(SystemTypes.Comms, new HudOverrideSystemType());
            systems.Add(SystemTypes.Security, new SecurityCameraSystemType());
            systems.Add(SystemTypes.Reactor, new ReactorSystemType());
            systems.Add(SystemTypes.LifeSupp, new LifeSuppSystemType());
        }
    }
}
