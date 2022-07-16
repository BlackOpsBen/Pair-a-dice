using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private List<Projectile> projectiles = new List<Projectile>();

    private int currentIndex = 0;

    [SerializeField] private int maxObjects = 10;

    private void Start()
    {
        for (int i = 0; i < maxObjects; i++)
        {
            GameObject newObject = Instantiate(prefab);
            projectiles.Add(newObject.GetComponent<Projectile>());
            newObject.SetActive(false);
        }
    }

    public Projectile GetNextPooledProjectile()
    {
        Projectile returnValue = projectiles[currentIndex];

        returnValue.gameObject.SetActive(true);

        currentIndex++;
        if (currentIndex >= projectiles.Count)
        {
            currentIndex = 0;
        }

        return returnValue;
    }
}
