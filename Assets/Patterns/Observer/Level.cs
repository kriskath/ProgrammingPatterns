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
    public event Action onExperienceChanged;


    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;

        onExperienceChanged?.Invoke();

        if (GetLevel() > level)
        {
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
