namespace Application.Interfaces
{
    public interface IToDoItemStatus
    {
        int Id { get; set; }
        string Status { get; set; }
        string Description { get; set; }
    }
}
