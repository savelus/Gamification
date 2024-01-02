using MVP;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace LoadScreen {
    [Preserve]
    public class LoadPresenter : BasePresenter<LoadView, LoadData> {
        public LoadPresenter(LoadView view, LoadData data = null) {
            if (data == null)
                data = new LoadData();
            InitializePresenter(view, data);
        }
        
        protected override void InitializeView() {
            View.InitializeConfirmButton(() => SceneManager.LoadScene(null));
        }
    }
}