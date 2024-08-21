using System;
using UnityEngine;

public class Health
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public event Action OnDead;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void Reduce(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage can't be negative");
            return;
        }

        Debug.Log(damage);

        _currentHealth -= damage;

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            OnDead?.Invoke();
        }
    }
}