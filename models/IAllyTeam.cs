namespace Fantasy1998.models;
public interface IAllyTeam : ICombat
{
    int ally_count { get; }

    IReadOnlyList<ICombat> allies { get; }

    void add_ally(ICombat ally);
    void remove_ally(ICombat ally);

    bool contains_ally(ICombat ally);

    ICombat get_ally(int index);

    ICombat get_random_ally();
    ICombat get_lowest_health_ally();
    ICombat get_highest_health_ally();

    IReadOnlyList<ICombat> get_alive_allies();
    IReadOnlyList<ICombat> get_dead_allies();

    bool has_alive_allies();

    void heal_all_allies(float amount);
    void revive_all_allies();

    void clear_allies();
}