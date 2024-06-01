using System.ComponentModel;

namespace ComicsLoader.UI.Abstractions;

interface IViewModel : INotifyPropertyChanged, IDisposable
{
    IViewModelContext? ViewModelContext { get; set; }
}