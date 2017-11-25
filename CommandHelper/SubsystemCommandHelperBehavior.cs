using System;
namespace Game
{
    public class SubsystemCommandHelperBehavior : SubsystemBlockBehavior
    {

        public override int[] HandledBlocks
        {
            get
            {
                return new int[] { 502 };
            }
        }

        public override bool OnUse(Engine.Vector3 start, Engine.Vector3 direction, ComponentMiner componentMiner)
        {
            var bodyResult = componentMiner.PickBody(start, direction);
            var terrainResult = componentMiner.PickTerrainForDigging(start, direction);

            return false;
        }
    }
}
