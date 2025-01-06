namespace Day3.Domain;
public record Memory(List<Command> Commands)
{
    public int Summary => Commands.OfType<Mul>().Sum(mul => mul.Result);

    public int EnabledSummary
    {
        get
        {
            bool enabled = true;
            int summary = 0;

            foreach (Command command in Commands)
            {
                switch (command)
                {
                    case Mul mul:
                        if (enabled)
                        {
                            summary += mul.Result;
                        }
                        break;

                    case Do:
                        enabled = true;
                        break;

                    case Dont:
                        enabled = false;
                        break;
                }
            }

            return summary;
        }
    }
}
