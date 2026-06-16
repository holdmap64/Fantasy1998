namespace Fantasy1998.models;
public interface ICombat
{
    float current_health { get; set; }
    float max_health { get; set; }

    float current_mana { get; set; }
    float max_mana { get; set; }

    float current_stamina { get; set; }
    float max_stamina { get; set; }

    float attack_power { get; set; }
    float magic_power { get; set; }

    float defense { get; set; }
    float magic_defense { get; set; }

    float critical_chance { get; set; }
    float critical_multiplier { get; set; }

    float accuracy { get; set; }
    float evasion { get; set; }

    float attack_speed { get; set; }
    float range { get; set; }

    bool is_alive { get; }
    bool is_dead { get; }

    bool is_attacking { get; }
    bool is_defending { get; }
    bool is_casting { get; }

    bool is_stunned { get; }
    bool is_silenced { get; }
    bool is_invulnerable { get; }

    void attack(ICombat target);
    void basic_attack(ICombat target);
    void heavy_attack(ICombat target);
    void critical_attack(ICombat target);

    void take_damage(float amount);
    void take_physical_damage(float amount);
    void take_magic_damage(float amount);
    void take_true_damage(float amount);

    void heal(float amount);

    bool spend_mana(float amount);
    bool spend_stamina(float amount);

    void restore_mana(float amount);
    void restore_stamina(float amount);

    void defend();
    void stop_defending();

    bool block_damage(float amount);
    bool dodge_attack();

    bool can_use_skill(int skill_id);
    void use_skill(int skill_id);
    void cancel_skill();

    void apply_buff(string id);
    void remove_buff(string id);

    void apply_debuff(string id);
    void remove_debuff(string id);

    bool has_buff(string id);
    bool has_debuff(string id);

    void set_target(ICombat target);
    void clear_target();

    bool is_target_in_range(ICombat target);

    float calculate_damage(ICombat target);
    float calculate_critical_damage(float damage);
    float calculate_defense_reduction(float damage);

    void enter_combat();
    void exit_combat();
    bool is_in_combat();

    void die();
    void revive(float health_percent, float mana_percent, float stamina_percent);

    event Action<float> damage_taken;
    event Action<float> healed;
    event Action<float> mana_spent;
    event Action<float> stamina_spent;
    event Action<ICombat> attack_performed;
    event Action died;
    event Action revived;
}