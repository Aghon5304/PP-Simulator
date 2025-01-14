using System.Xml.Linq;
using Simulator;
using Simulator.Maps;

namespace Game;

public class RunGame
{
    public IMappable? Player { get; private set; }
    public Map? Map { get; private set; }
    public IMappable[]? Enemies { get; private set; }
    public Directions.Direction[] NPCMoveSet { get; private set; }
    public int MoveCount { get; private set; } = 0;
    public int ImappableCount { get; private set; } = 0;

    public RunGame(IMappable player, Map map, IMappable[] enemies, Directions.Direction[] npcMoveSet, Point[] npcStartPositon, Point playerStartPosition)
    {
        Player = player;
        Map = map;
        Enemies = enemies;
        NPCMoveSet = npcMoveSet;

        for (var enemy = 0; enemy < Enemies.Length; enemy++)
        {
            Enemies[enemy].InitMapAndPosition(Map, npcStartPositon[enemy]);
        }
        Player.InitMapAndPosition(Map, playerStartPosition);
    }

    public void Run(Directions.Direction PlayerDirection)
    {
        if (Player?.IsDead != true)
        {
            Player.Go(PlayerDirection);

            if (Map?.At(Player.Position)?.Count != 1)
            {
                fight(Player);
            }

            for (int enemyPos = 0; enemyPos < Enemies?.Length; enemyPos++)
            {
                Enemies[enemyPos].Go(NPCMoveSet[MoveCount]);
                MoveCount++;

                if (Map?.At(Enemies[enemyPos].Position)?.Count != 1)
                {
                    fight(Enemies[enemyPos]);
                }

                if (MoveCount == NPCMoveSet.Length)
                {
                    MoveCount = 0;
                }
            }
        }
    }

    private void fight(IMappable? gracz)
    {
        var enemiesInPosition = Map?.At(gracz.Position)?.ToList();
        if (enemiesInPosition == null) return;

        foreach (IMappable enemyInPosition in enemiesInPosition)
        {
            if (enemyInPosition != gracz && gracz != null)
            {
                enemyInPosition.Damage(gracz);
                if (enemyInPosition.Health != 0)
                {
                    gracz.Damage(enemyInPosition);
                }
            }
        }
        var toRemove = Map?.At(gracz.Position)?.Where(x => x.IsDead).ToList();
        if (toRemove != null)
        {
            foreach (IMappable dead in toRemove)
            {
                Map.Remove(dead,dead.Position);
                Enemies = Enemies?.Where(x => x != dead).ToArray();
            }
        }
    }

    public string wypisanie()
    {
        var Element = new string[Map.SizeX, Map.SizeY];
        var Tablica = "";
        for (var y = Map.SizeY - 1; y >= 0; y--)
        {
            Tablica += "<tr>";
            for (var x = 0; x < Map.SizeX; x++)
            {
                var mapElement = Map.At(x, y);
                if (mapElement == null)
                {
                    Element[x, y] = "";
                }
                else if (mapElement.Count == 1)
                {
                    Element[x, y] = $"{mapElement.First().Symbol}";
                }
                else
                {
                    Element[x, y] = "X";
                }
                Tablica += $"<td>{Element[x, y]}</td>";
            }
            Tablica += "</tr>";
        }
        return Tablica;
    }
}
