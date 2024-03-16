using System;
using System.Data;
using LoadScreen;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private LoadPresenter _loadPresenter;

    [Inject]
    public void Init(LoadPresenter loadPresenter) {
        _loadPresenter = loadPresenter;
    }

    private void Start()
    {
        _loadPresenter.Open();
       
        DataChestController controller = new ();
        var chests = controller.GetAllChests();
        foreach (ChestM chest in chests)
        {
            Debug.Log($"ID: {chest.ID}, Reward: {chest.Reward}, PointsToComplete: {chest.PointsToComplete}");
        }
        Debug.Log(chests.Count);
    }
}
