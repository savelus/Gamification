using System.Collections.Generic;
using ChestScreen;
using MVP;
using UnityEngine;

namespace ChestScreen
{
    public class ChestScreenPresenter : BasePresenter<ChestScreenView>
    {
        private const int StartSpawnChest = 5;

        private readonly Queue<ChestM> _notUsableChests = new();
        private readonly List<ChestM> _viewedChests = new();

        public ChestScreenPresenter(ChestScreenView screenView)
        {
            InitializePresenter(screenView);
        }

        protected override void InitializeView()
        {
            ClearViewedChests();
            SpawnChests(5);

            SetupExampleChests();
        }

        private void SetupExampleChests()
        {
            AddChest("1");
            AddChest("2");
            AddChest("3");
            AddChest("4");
            AddChest("5");
        }

        public void AddChest(string chestText)
        {
            if (_notUsableChests.Count == 0)
            {
                SpawnOneChest();
            }

            var Chest = _notUsableChests.Dequeue();
            _viewedChests.Add(Chest);
            Chest.InitializeChest(Color.red, Color.green, chestText, ChestStateChanged);
        }

        private void SpawnChests(int chestsCount)
        {
            _notUsableChests.Clear();

            for (int i = 0; i < chestsCount; i++)
            {
                SpawnOneChest();
            }
        }

        private void SpawnOneChest()
        {
            _notUsableChests.Enqueue(View.SpawnChest());
        }

        private void ClearViewedChests()
        {
            foreach (var chest in _viewedChests)
            {
                View.DeleteChest(chest);
            }
            _viewedChests.Clear();
        }

        private void ChestStateChanged(ChestM chest)
        {
            if (chest.ChestComplete) CompleteChest(chest);
            UnCompleteChest(chest);
        }

        private void UnCompleteChest(ChestM chest)
        {
            chest.UnCompleteChest();
        }

        private void CompleteChest(ChestM chest)
        {
            chest.CompleteChest();
        }
    }
}