using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour, IDamagable
{
    [SerializeField] int life = 10;
    [SerializeField] int shieldLife = 10;
    [SerializeField] GameObject shield = default;

    private int currentLife;

    private void Start()
    {
        currentLife = life;
    }


    public void Damage(int amount)
    {
        currentLife -= amount;

        if(currentLife <= 0)
        {
            //Dead
        }
    }
}
