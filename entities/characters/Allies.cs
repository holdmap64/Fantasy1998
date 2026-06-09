public class Allies : Character{
    public Allies(string name) : base(name){
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Allies))
        {
            return false;
        }
        Allies other = (Allies)obj;
        return Name == other.Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override string ToString() {
        return "a";
    }
    
}