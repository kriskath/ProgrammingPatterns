using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Level : MonoBehaviour
{
    [SerializeField] UnityEvent onLevelUp;
    [SerializeField] int pointsPerlevel = 200;
    int experiencePoints = 0;

    public event Action onLevelUpAction;

    //coroutine
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if (GetLevel() > level)
        {
            //onLevelUp?.Invoke();

            onLevelUpAction?.Invoke();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    //no need to cache level. Calculate it to counter cache invalidation
    public int GetLevel()
    {
        return experiencePoints / pointsPerlevel;
    }
}
