namespace MVP {
    public abstract class BasePresenter<TView, TData> where TView : IView
                                             where TData : IData {
        protected TView View;
        protected TData Data;

        protected void InitializePresenter(IView view, IData data) {
            View = (TView) view;
            Data = (TData) data;
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