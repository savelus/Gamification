using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace ChestScreen
{
    public class ChestScreenView : BaseView
    {
        [SerializeField] private Chest _chestPrefab;

        [SerializeField] private Transform _chestRoot;

        private void Start()
        {
            ChestScreenPresenter chestScreenPresenter = new ChestScreenPresenter(this);
        }

        public Chest SpawnChest()
        {
            var spawnedChest = Instantiate(_chestPrefab, _chestRoot);
            spawnedChest.ShowChest();
            return spawnedChest;
        }

        public void DeleteChest(Chest chest)
        {
            Destroy(chest);
        }
    }
}