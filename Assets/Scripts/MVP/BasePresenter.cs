namespace MVP {
    public abstract class BasePresenter<TView> where TView : IView {
        protected TView View;

        protected void InitializePresenter(IView view) {
            View = (TView) view;
        }

        public void Open() {
            InitializeView();
            View.ShowView();
        }

        protected abstract void InitializeView();

        public void Close() {
            View.HideView();
        }
    }
}