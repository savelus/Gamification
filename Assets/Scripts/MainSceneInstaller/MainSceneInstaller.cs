using LoadScreen;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace MainSceneInstaller {
    public class MainSceneInstaller : MonoInstaller {

        [SerializeField] private LoadView _loadView;
        public override void InstallBindings() {

            InstallPresenters();
            InstallViews();
        }

        private void InstallViews() {

            Instantiate(_loadView);
            _loadView.HideView();
            
            Container
                .Bind<LoadView>()
                .FromInstance(_loadView)
                .AsSingle()
                .NonLazy();
        }

        private void InstallPresenters() {
            Container
                .BindInterfacesAndSelfTo<LoadPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}