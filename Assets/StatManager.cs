using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }

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
    }

    public List<Stat> stats = new();

    public void EditStat(int index, int result)
    {
        stats[index].diceMultiplier = result;
        Debug.Log(stats[index] + " changed to " + (result + 1));
    }
}

[System.Serializable]
public class Stat
{
    public string name;
    [HideInInspector]
    public int diceMultiplier = 1;
}
