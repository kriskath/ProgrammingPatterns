using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] Health health;

    private void Start()
    {
        health.onHealthChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        health.onHealthChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetFullHealth();
    }

}
