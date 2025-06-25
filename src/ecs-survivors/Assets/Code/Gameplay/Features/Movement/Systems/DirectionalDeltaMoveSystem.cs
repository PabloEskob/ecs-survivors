using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _timer;

        public DirectionalDeltaMoveSystem(GameContext gameContext, ITimeService timerService)
        {
            _timer = timerService;
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
            {
                mover.ReplaceWorldPosition(mover.WorldPosition + mover.Direction * mover.Speed * _timer.DeltaTime);
            }
        }
    }
}