namespace Fantasy1998.models;
public interface ILevel
{
    float level  { get; set; }
    float xp     { get; set; }
    float max_xp { get; set; }
    void level_up();
}