public class Church : Structure {
    public Church(string name) : base(name){
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Church))
        {
            return false;
        }
        Church other = (Church)obj;
        return Name == other.Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override string ToString() {
        return "c";
    }
}