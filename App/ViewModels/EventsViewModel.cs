using System.Collections.ObjectModel;
using System.Diagnostics;
using App.Services;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using Shared.Models;

namespace App.ViewModels;

public partial class EventsViewModel : ViewModelBase
{
    public ObservableRangeCollection<Event> Events { get; } = new();
    
    private EventService _eventService;

    public EventsViewModel(EventService eventService)
    {
        Title = "Eventos";
        _eventService = eventService;
    }

    [ICommand]
    async Task GetEventsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var events = await _eventService.GetEvents();

            Events.ReplaceRange(events);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
            await Shell.Current.DisplayAlert("Ops!", "Algo deu errado", "OK");
        }
        finally
        {
            IsBusy = false;

        }

    }
}