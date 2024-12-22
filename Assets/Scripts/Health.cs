using System;
using System.Text;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumLifeForce = 100;

    public int LifeForce { get; private set; }

    public event Action HealthHasChanged;

    private void Awake()
    {
        LifeForce = _maximumLifeForce;
    }

    public int GetMaximumLifeForce() =>
        _maximumLifeForce;

    public void TakeDamage(int damage)
    {
        if (CheckerIncoming(damage))
        {
            LifeForce -= damage;

            if (IsAlive() == false)
                Destroy(gameObject);

            HealthHasChanged?.Invoke();
        }
    }

    public void TryToAcceptLifeForce(int lifeForce)
    {
        if (CheckerIncoming(lifeForce))
        {
            AcceptLifeForce(lifeForce);

            HealthHasChanged?.Invoke();
        }
    }

    private void AcceptLifeForce(int lifeForce)
    {
            if (_maximumLifeForce <= lifeForce + LifeForce)
                LifeForce = _maximumLifeForce;
            else
                LifeForce += lifeForce;
    }

    private bool CheckerIncoming(int incoming) =>
        incoming > 0;

    private bool IsAlive() =>
        0 < LifeForce;
}
