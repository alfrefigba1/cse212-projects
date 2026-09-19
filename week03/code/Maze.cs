/// <summary>
/// Defines a maze using a dictionary.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.
    /// </summary>
    public void MoveLeft()
    {
        bool[] directions = _mazeMap[(_currX, _currY)];

        if (directions[0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.
    /// </summary>
    public void MoveRight()
    {
        bool[] directions = _mazeMap[(_currX, _currY)];

        if (directions[1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.
    /// </summary>
    public void MoveUp()
    {
        bool[] directions = _mazeMap[(_currX, _currY)];

        if (directions[2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.
    /// </summary>
    public void MoveDown()
    {
        bool[] directions = _mazeMap[(_currX, _currY)];

        if (directions[3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}