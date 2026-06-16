namespace Fantasy1998.models;
public interface IEnemyTeam : ICombat
{
    int enemy_count { get; }

    IReadOnlyList<ICombat> enemies { get; }

    void add_enemy(ICombat enemy);
    void remove_enemy(ICombat enemy);

    bool contains_enemy(ICombat enemy);

    ICombat get_enemy(int index);

    ICombat get_random_enemy();
    ICombat get_lowest_health_enemy();
    ICombat get_highest_health_enemy();

    IReadOnlyList<ICombat> get_alive_enemies();
    IReadOnlyList<ICombat> get_dead_enemies();

    bool has_alive_enemies();

    void damage_all_enemies(float amount);
    void kill_all_enemies();

    void clear_enemies();
}