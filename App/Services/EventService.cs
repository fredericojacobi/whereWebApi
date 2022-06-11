using System.Diagnostics;
using System.Net.Http.Json;
using Shared.Models;

namespace App.Services;

public class EventService
{
    private readonly HttpClient _client;

    public List<Event> eventList = new();

    public EventService()
    {
        _client = new HttpClient();
    }
    public async Task<List<Event>> GetEvents()
    {
        if (eventList.Any())
            return eventList;

        var url = "https://api.coindesk.com/v1/bpi/currentprice.json";

        try
        {
            
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
               
                //eventList = await response.Content.ReadFromJsonAsync<List<Event>>();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }


        return eventList;
    }
}