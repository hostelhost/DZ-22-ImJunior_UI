using UnityEngine;

public class Player : MonoBehaviour, ITakingDamage
{
    private const int MaximumLifeForce = 100;

    private int _lifeForce = MaximumLifeForce;

    public void TakeDamage(int damage)
    {
        _lifeForce -= damage;
        Debug.Log("Жизненная сила Player" + _lifeForce);
        IsAlive();       
    }

    private void TryToAcceptLifeForce(int lifeForce)
    {
        if (MaximumLifeForce <= lifeForce + _lifeForce)
            _lifeForce = MaximumLifeForce;
        else
            _lifeForce += lifeForce;
    }

    private void IsAlive()
    {
        if (0 >= _lifeForce)
            Destroy(gameObject);
    }
}
