using LoadScreen;
using TaskScreen;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace MainSceneInstaller {
    public class MainSceneInstaller : MonoInstaller {

        [SerializeField] private LoadView _loadView;
        [SerializeField] private TaskScreenView _taskScreenView;

        public override void InstallBindings() {

            InstallPresenters();
            InstallViews();
        }

        private void InstallViews() {

            var f = _loadView.GetType();
            Instantiate(_loadView);
            _loadView.HideView();
            
            Container
                .Bind<LoadView>()
                .FromInstance(_loadView)
                .AsSingle()
                .NonLazy();
            
            Instantiate(_taskScreenView);
            _taskScreenView.HideView();
            
            Container
                .Bind<TaskScreenView>()
                .FromInstance(_taskScreenView)
                .AsSingle()
                .NonLazy();
        }

        private void InstallPresenters() {
            Container
                .BindInterfacesAndSelfTo<LoadPresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<TaskScreenPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}