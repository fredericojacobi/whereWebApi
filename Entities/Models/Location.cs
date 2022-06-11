namespace Entities.Models;

public class Location : ModelBase
{
    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

    public string Address { get; set; }
}