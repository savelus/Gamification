using System.Collections.Generic;
using ChestScreen;
using MVP;
using UnityEngine;

namespace ChestScreen
{
    public class ChestScreenPresenter : BasePresenter<ChestScreenView>
    {
        private const int StartSpawnChest = 5;

        private readonly Queue<Chest> _notUsableChests = new();
        private readonly List<Chest> _viewedChests = new();

        public ChestScreenPresenter(ChestScreenView screenView)
        {
            InitializePresenter(screenView);
            Open();
        }

        protected override void InitializeView()
        {
            ClearViewedChests();
            // SpawnChests(5);
            SetupExampleChests(3);
        }

        private void SetupExampleChests(int chestsCount)
        {
            for (int i = 0; i < chestsCount; i++)
            {
                AddChest($"{i + 1}");
            }
        }

        public void AddChest(string chestText)
        {
            if (_notUsableChests.Count == 0)
            {
                SpawnOneChest();
            }

            ChestProgressSlider.Singleton.SegmentsCount += 1;

            var Chest = _notUsableChests.Dequeue();
            _viewedChests.Add(Chest);
            Chest.InitializeChest(Color.white, Color.white, chestText, ChestStateChanged, ChestProgressSlider.Singleton.SegmentsCount);
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

        private void ChestStateChanged(Chest chest)
        {
            if (chest.ChestId <= ChestProgressSlider.Singleton.chestID)
            {
                chest.IsActive = true;
                Debug.Log($"Сундук активен!");

                if (chest.IsActive) CompleteChest(chest);
                else UnCompleteChest(chest);
            } 
            else 
            { chest.IsActive = true; }
        }

        private void UnCompleteChest(Chest chest)
        {
            chest.UnCompleteChest();
        }

        private void CompleteChest(Chest chest)
        {
            chest.CompleteChest();
        }
    }
}