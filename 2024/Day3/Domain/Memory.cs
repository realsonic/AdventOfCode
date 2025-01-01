namespace Day3.Domain;
public record Memory(IEnumerable<Mul> Muls)
{
    public int Summary => Muls.Sum(mul => mul.Result);
}
