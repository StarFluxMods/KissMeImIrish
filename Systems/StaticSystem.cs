using System.Linq;
using Kitchen;
using KitchenMods;
using StPatricksDay.Components;
using Unity.Collections;
using Unity.Entities;

namespace StPatricksDay.Systems
{
    public class StaticSystem : GameSystemBase, IModSystem
    {
        public static StaticSystem instance;
        protected override void Initialise()
        {
            base.Initialise();
            instance = this;
        }

        protected override void OnUpdate()
        {
        }

        public bool TESTMEPLZ(Entity e)
        {
            return EntityManager.HasComponent<CCustomerGroup>(e);
        }

        public bool IsGroupAtLuckyTable(Entity e)
        {
            if (Require(e, out CAssignedTable cAssignedTable))
            {
                if (cAssignedTable.Table != Entity.Null)
                {
                    DynamicBuffer<CTableSetParts> parts = EntityManager.GetBuffer<CTableSetParts>(cAssignedTable.Table);
                    if (parts.Length > 0)
                    {
                        return EntityManager.HasComponent<CLuckyTable>(parts[0].Entity);
                    }
                }
            }

            return false;
        }
    }
}