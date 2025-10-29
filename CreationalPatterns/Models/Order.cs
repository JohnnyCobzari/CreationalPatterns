namespace CreationalPatterns.Models;

public class Order
{
    public int OrderId { get; set; }
    public string PastaType { get; set; } = "";
    public Pasta? PreparedPasta { get; set; }
}