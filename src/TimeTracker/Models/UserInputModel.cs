using TimeTracker.Domain;
                                                                                
namespace TimeTracker.Models
{
    /// <summary>
    /// Represents a single user to add or modify.
    /// </summary>
    public class UserInputModel
    {
        public string Name { get; set; }
        public decimal HourRate { get; set; }

        public void MapTo(User user)
        {
            user.Name = Name;
            user.HourRate = HourRate;
        }
    }
}