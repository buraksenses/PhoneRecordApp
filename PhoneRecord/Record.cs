namespace PhoneRecord;

public class Record
{
    private string _name;

    private string _surname;
    
    private string _number;

    public Record(string name,string surname, string number)
    {
        this._name = name;
        this._number = number;
        this._surname = surname;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public string Surname
    {
        get => _surname;
        set => _surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Number
    {
        get => _number;
        set => _number = value ?? throw new ArgumentNullException(nameof(value));
    }
}