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

    public List<string> stats = new List<string>();

    public void EditStat(int index, int result)
    {
        Debug.Log(stats[index] + " changed to " + (result + 1));
    }
}
