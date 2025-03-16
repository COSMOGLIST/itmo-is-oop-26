namespace Application.Models;

public record User(string Number, string Pin, decimal AmountOfMoney)
{
    public decimal AmountOfMoney { get; set; } = AmountOfMoney;
}