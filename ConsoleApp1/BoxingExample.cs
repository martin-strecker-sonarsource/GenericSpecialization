struct S : IFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider) => null;
}

public class BoxingExample
{
    void M1(IFormattable f)
    {
        _ = f.ToString(null, null);
    }

    void M2<T>(T t)
    {
        IFormattable f = (IFormattable)t;
        f.ToString(null, null);
    }

    void M3<T>(T f) where T: IFormattable
    {
        f.ToString(null, null);
    }

    public void Show()
    {
        var s = new S();
        M1(s);
        M3(s);
    }
}



class SBox : IFormattable
{
    private readonly S s;

    public SBox(S s)
    {
        this.s = s;
    }

    public string ToString(string? format, IFormatProvider? formatProvider) => s.ToString(format, formatProvider);
}