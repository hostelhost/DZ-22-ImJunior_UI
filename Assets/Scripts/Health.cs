using System;
using UnityEngine;

public class Health : MonoBehaviour, ITakingDamage, IGettingLife
{
    [SerializeField] private int _maximumLifeForce = 100;

    public int LifeForce { get; private set; }

    public event Action HealthHasChanged;

    private void Awake()
    {
        LifeForce = _maximumLifeForce;
    }

    public void TakeDamage(int damage)
    {
        LifeForce -= damage;       
        IsAlive();
        HealthHasChanged?.Invoke();
    }

    public void TryToAcceptLifeForce(int lifeForce)
    {
        if (_maximumLifeForce <= lifeForce + LifeForce)
            LifeForce = _maximumLifeForce;
        else
            LifeForce += lifeForce;

        HealthHasChanged?.Invoke();
    }

    public int GetMaximumLifeForce()
    {
        return _maximumLifeForce;
    }

    private void IsAlive()
    {
        if (0 >= LifeForce)
            Destroy(gameObject);
    }
}
