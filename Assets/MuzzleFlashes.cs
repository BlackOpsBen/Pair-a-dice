using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashes : MonoBehaviour
{
    [SerializeField] private Transform[] muzzles;

    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    [SerializeField] private GameObject muzzleFlashPrefab;

    private void Awake()
    {
        foreach (Transform muzzle in muzzles)
        {
            particleSystems.Add(Instantiate(muzzleFlashPrefab, muzzle).GetComponent<ParticleSystem>());
        }
    }

    private int currentIndex = 0;

    public Transform GetAndUseNextMuzzle()
    {
        Transform returnValue = muzzles[currentIndex];

        particleSystems[currentIndex].Play();

        currentIndex++;
        if (currentIndex >= muzzles.Length)
        {
            currentIndex = 0;
        }

        return returnValue;
    }
}
