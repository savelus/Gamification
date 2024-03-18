using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace ChestScreen
{
    public class ChestScreenView : BaseView
    {

        [SerializeField] private Chest _chestPrefab;

        [SerializeField] private Transform _chestRoot;

        public Chest SpawnChest()
        {
            var spawnedChest = Instantiate(_chestPrefab, _chestRoot);
            //TODO �������� ��� ������� � ������ ����� �������� � ��������� �������
            spawnedChest.HideChest();
            return spawnedChest;
        }

        public void DeleteChest(Chest chest)
        {
            Destroy(chest);
        }
    }
}