using System.Diagnostics;

namespace Entities.Models;

public class Event : ModelBase
{
    public Guid LocationId { get; set; }

    public Guid EventTypeId { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }
    
    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }
    
    public string PriceRate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsCovered { get; set; }

    public int MinAge { get; set; }

    public int Likes { get; set; }

    public int Shares { get; set; }
    
    public EventType EventType { get; set; }

    public Location Location { get; set; }

    public ICollection<UserApplication>? UserApplications { get; set; }

    public ICollection<Comment>? Comments { get; set; }
}