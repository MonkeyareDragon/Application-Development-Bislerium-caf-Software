using BisleriumCafé.Data.Models;

namespace BisleriumCafé.Data.Models;

public class StaffModel
{
    // Attributes
    public string Name { get; set; }
    public StaffPassword Password { get; set; }
    public StaffRole Role { get; set; }
}