public class Enemies : Character{
    public Enemies(string name) : base(name){
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Enemies))
        {
            return false;
        }
        Enemies other = (Enemies)obj;
        return Name == other.Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override string ToString() {
        return "e";
    }
    
}