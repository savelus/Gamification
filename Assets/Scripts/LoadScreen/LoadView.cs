using Extensions;
using MVP;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LoadScreen {
    public class LoadView : BaseView {

        [SerializeField] private Button _confirmButton;

        public void InitializeConfirmButton(UnityAction onClickAction) {
            _confirmButton.AddSingleListener(onClickAction);
            _confirmButton.onClick.AddListener(()=>print("fff"));
            
        }
    }
}