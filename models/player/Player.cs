namespace Fantasy1998.models.player;
public class Player : IGameObjects
{
    public string Name { get; set; }
    public (int Row, int Col) Pos { get; set; }
    public Player(string name, (int row, int col) pos)
    {
        Name = name;
        Pos = pos;
    }
    // public (int Row, int Col) MovePlayer((int Row, int Col) newPos, string nameMap)
    // {
    //     if(Maps.TryGetValue(nameMap, out World map))
    //     {
    //         if(newPos.Row >= map.Grid.GetLength(0) || newPos.Row < 0 ||
    //            newPos.Col >= map.Grid.GetLength(1) || newPos.Col < 0)
    //         {
    //             Notice.Print("Fora do mapa");
    //             return Pos;
    //         } else {
    //             if(map.Grid[newPos.Row, newPos.Col] != null)
    //             {
    //                 if(map.GameObject.TryGetValue(map.Grid[newPos.Row, newPos.Col], out IGameObject obj))
    //                 {
    //                     switch(obj)
    //                     {
    //                         case Allies:
    //                             Allies allies = (Allies)obj;
    //                         break;
    //                         case Enemies:
    //                             Enemies enemies = (Enemies)obj;
    //                         break;
    //                         case Church:
    //                             Church church = (Church)obj;
    //                         break;
    //                     }
    //                 }
    //             } else
    //             {
    //                 map.Grid[Pos.Row, Pos.Col] = null;
    //                 Pos = newPos;
    //                 map.Grid[Pos.Row, Pos.Col] = this;
    //                 Screen.Show(this, nameMap);
    //             }
    //         }
    //     }
    //     return newPos;
    // }
    public char TurnLetter()
    {
        return Name[0];
    }
}