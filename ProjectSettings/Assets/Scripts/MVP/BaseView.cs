using UnityEngine;

namespace MVP {
    public abstract class BaseView : MonoBehaviour, IView {
        public virtual void ShowView() {
            gameObject.SetActive(true);
        }

        public virtual void HideView() {
            gameObject.SetActive(false);
        }
    }
}