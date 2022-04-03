using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPresenter : MonoBehaviour
{
    //Model
    [SerializeField] Level level; 

    //View
    [SerializeField] TMP_Text displayText;
    [SerializeField] TMP_Text experienceText;
    [SerializeField] Button increaseXPButton;

    private void Start()
    {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.onExperienceChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        level.onExperienceChanged -= UpdateUI;
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        displayText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"XP: {level.GetExperience()}";
    }
}
