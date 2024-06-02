namespace ComicsLoader.UI.Abstractions;

public interface IViewsDispatcher
{
    IViewModelContext GetViewModelContext(ViewModelBase viewModel);
}
