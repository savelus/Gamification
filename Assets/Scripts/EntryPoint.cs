using System;
using System.Data;
using LoadScreen;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private LoadPresenter _loadPresenter;

    [Inject]
    public void Init(LoadPresenter loadPresenter) 
    {
        _loadPresenter = loadPresenter;
    }

    private void Start()
    {
        _loadPresenter.Open();
    }
}
