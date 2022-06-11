namespace CommBank.Models;

interface IUpdatedIcon
{
    string IconName { get; set; }
}


public class UpdatedIcon : IUpdatedIcon
{
    public UpdatedIcon(string iconName)
    {
        IconName = iconName;
    }

    public string IconName { get; set; }
}
