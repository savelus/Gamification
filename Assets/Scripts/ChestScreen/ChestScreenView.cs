using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace ChestScreen
{
    public class ChestScreenView : BaseView
    {

        [SerializeField] private ChestM _chestPrefab;

        [SerializeField] private Transform _chestRoot;

        public ChestM SpawnChest()
        {
            var spawnedChest = Instantiate(_chestPrefab, _chestRoot);
            //TODO �������� ��� ������� � ������ ����� �������� � ��������� �������
            spawnedChest.HideChest();
            return spawnedChest;
        }

        public void DeleteChest(ChestM chest)
        {
            Destroy(chest);
        }
    }
}