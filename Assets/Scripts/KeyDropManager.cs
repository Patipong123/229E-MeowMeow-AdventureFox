using System.Collections.Generic;
using UnityEngine;

public class KeyDropManager : MonoBehaviour
{
    public List<EnemyTarget> targetEnemies; 
    public GameObject keyPrefab;


    public void NotifyEnemyKilled(GameObject enemy)
    {
        for (int i = 0; i < targetEnemies.Count; i++)
        {
            if (targetEnemies[i].enemyObject == enemy && !targetEnemies[i].isKilled)
            {
                targetEnemies[i].isKilled = true;

                if (AllEnemiesKilled())
                {
                    
                    Instantiate(keyPrefab, enemy.transform.position, Quaternion.identity);
                }
                break;
            }
        }
    }

    private bool AllEnemiesKilled()
    {
        foreach (var target in targetEnemies)
        {
            if (!target.isKilled)
                return false;
        }
        return true;
    }
}

[System.Serializable]
public class EnemyTarget
{
    public GameObject enemyObject;
    public bool isKilled = false;
}



