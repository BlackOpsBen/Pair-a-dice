using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    public static RollManager Instance { get; private set; }

    [SerializeField] private int numDice = 2;

    [SerializeField] public List<DiceGraphics> diceGraphics = new List<DiceGraphics>();
    [SerializeField] public Sprite emptyDieGraphic;

    private List<Die> dice = new List<Die>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        for (int i = 0; i < numDice; i++)
        {
            dice.Add(new Die());
        }
    }

    public void RollDice()
    {
        foreach (Die die in dice)
        {
            die.Roll();
        }
    }

    public List<int> GetDiceResults()
    {
        List<int> results = new List<int>();
        foreach (Die die in dice)
        {
            results.Add(die.result);
        }
        return results;
    }
}

[System.Serializable]
public struct DiceGraphics
{
    public Sprite offSprite;
    public Sprite onSprite;
}

public class Die
{
    private int numSides = 6;

    public int result = 0;

    public Die()
    {
        Roll();
    }

    public void Roll()
    {
        result = UnityEngine.Random.Range(0, numSides);
    }
}
