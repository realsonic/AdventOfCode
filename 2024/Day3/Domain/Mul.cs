namespace Day3.Domain;
public record Mul(int FirstNumber, int SecondNumber)
{
    public int Result => FirstNumber * SecondNumber;
}
