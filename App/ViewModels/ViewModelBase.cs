using System.ComponentModel;
using System.Runtime.CompilerServices;
using App.Annotations;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace App.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    private bool _isBusy;

    public bool IsNotBusy => !_isBusy;

    public ViewModelBase()
    {
    }
}