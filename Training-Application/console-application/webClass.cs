namespace handlers;

public class WebClass
{
    private int privateNumber;

    public int Number
    {
        get { return privateNumber; }
        set { privateNumber = value; }
    }

    public WebClass(){}

    public int processPrivateNumber()
    {
        Console.WriteLine("privateNumber:" + privateNumber);
        int number = this.privateNumber + 2000;
        return number;
    }
}