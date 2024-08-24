using Unity.Entities;

namespace BounceDOTS.Components
{
    // Add game-specific components here, for example:
    public struct Score : IComponentData
    {
        public int Value;
    }

    public struct LevelData : IComponentData
    {
        public int CurrentLevel;
    }
}