using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    public event Action onHealthChanged;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
    public float GetFullHealth()
    {
        return fullHealth;
    }

    private void ResetHealth()
    {
        currentHealth = fullHealth;
        onHealthChanged?.Invoke();
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            onHealthChanged?.Invoke();
            yield return new WaitForSeconds(1);
        }
    }

}
