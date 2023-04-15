using Assets.Scripts.InputReader;
using Assets.Scripts.StatsSystem;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerSystem : IDisposable
    {
        private readonly StatsController _statsController;
        private readonly PlayerEntity _playerEntity;
        private readonly PlayerBrain _playerBrain;
        private readonly List<IDisposable> _disposable;

        public PlayerSystem(PlayerEntity playerEntity, List<IEntityInputSourse> inputSources)
        {
            _disposable = new List<IDisposable>();

            var statStorage = Resources.Load<StatsStorage>($"Player/{nameof(StatsStorage)}");
            var stats = statStorage.Stats.Select(stat => stat.GetCopy()).ToList();
            _statsController = new StatsController(stats);
            _disposable.Add(_statsController);

            _playerEntity = playerEntity;
            _playerEntity.Initialize(_statsController);

            _playerBrain = new PlayerBrain(_playerEntity, inputSources);
            _disposable.Add(_playerBrain);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
