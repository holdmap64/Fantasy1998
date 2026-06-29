using System.Runtime.Intrinsics.X86;

namespace Fantasy1998.models.characters;
public interface IAllies
{
    double Health     { get; set; }
    double Stamina    { get; set; }
    double Mana       { get; set; }
    double MaxHealth  { get; set; }
    double MaxStamina { get; set; }
    double MaxMana    { get; set; }
    double AP         { get; set; }
    double AD         { get; set; }
    double Armor      { get; set; }
    double MR         { get; set; }
    double Speed      { get; set; }
    double XP         { get; set; }
    double MaxXP      { get; set; }
    int Level        { get; set; }
}