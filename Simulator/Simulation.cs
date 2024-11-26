using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }
    private Directions.Direction[] MovesList { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    {
        get
        {
            return Creatures[_currentCreature];
        }
    }

    private int _currentMove { get; set; } = 0;
    private int _currentCreature { get; set; } = 0;

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            return Moves[_currentMove].ToString().ToLower();
        }
    }
    private Creature _temporaryCreature;
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    { 
        Map = map;
        if (creatures.Count == 0)
        {
            throw new ArgumentException("List of creatures is empty");
        }
        else
        {
            Creatures = creatures;
        }
        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures differs from number of starting positions");
        }
        else
        {
            Positions = positions;
        }
        for (int i = 0; i < creatures.Count; i++)
        {
            _temporaryCreature = Creatures[i];
            _temporaryCreature.InitMapAndPosition(map, Positions[i]);
            Creatures[i] = _temporaryCreature;
        }
        Moves = moves;
        MovesList = DirectionParser.Parse(moves);
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new Exception("Simulation is finished");
        }
        else
        {
            Creatures[_currentCreature].Go(MovesList[_currentMove]);

            _currentCreature++;
            _currentMove++;
            if (_currentMove >= MovesList.Length)
            {
                Finished = true;
            }
            if (_currentCreature >= Creatures.Count)
            {
                _currentCreature = 0;
            }
        }
    }
}