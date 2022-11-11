namespace API.Dto;

public class OrderResponse
{
    public string WallertAddress { get; set; }
    public decimal Units { get; set; }
    public DateTime Created { get; set; }
    public bool Status { get; set; }
}