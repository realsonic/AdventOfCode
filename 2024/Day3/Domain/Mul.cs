namespace Day3.Domain;
public record Mul(int FirstNumber, int SecondNumber) : Command
{
    public int Result => FirstNumber * SecondNumber;
}
