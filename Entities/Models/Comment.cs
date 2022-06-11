namespace Entities.Models;

public class Comment : ModelBase
{
    public Guid UserApplicationId { get; set; }

    public int Likes { get; set; }

    public UserApplication UserApplication { get; set; }
}