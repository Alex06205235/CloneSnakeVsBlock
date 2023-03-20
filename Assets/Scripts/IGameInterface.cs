using Unity.PlasticSCM.Editor.WebApi;

namespace Types
{
    public interface IGameInterface
    {
        public enum State
        {
            Playing,
            Won,
            Loss,
        }
    }

    public interface IGameScores
    {
        int Current { get; }
        int Best { get; }
        void UpdateBestScores(int count);
    }
}
