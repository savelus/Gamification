using MVP;
using TaskScreen;
using UnityEngine;

namespace LoadScreen 
{
    public class LoadPresenter : BasePresenter<LoadView> 
    {
        private readonly TaskScreenPresenter _taskScreenPresenter;

        public LoadPresenter(LoadView view,
            TaskScreenPresenter taskScreenPresenter) 
        {
            _taskScreenPresenter = taskScreenPresenter;
            InitializePresenter(view);
        }
        
        protected override void InitializeView() 
        {
            View.InitializeConfirmButton(ButtonClickAction);
        }

        private void ButtonClickAction() 
        {
            Debug.Log("CloseButton");
            Close();
            _taskScreenPresenter.Open();
        }
    }
}