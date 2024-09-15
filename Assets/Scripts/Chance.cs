public class Chance
{
    public Chance(string name) => Name = name;
    public string Name { get; set; }
    public float Value { get; set; }
    public int Minimum { get; set; }
    public int Maximum { get; set; }
}
