using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private ShieldController shieldController;

    public void Init(ShieldController sC)
    {
        shieldController = sC;
    }

    public void ShieldHit(int amount)
    {
        shieldController.ShieldDamage(amount);
    }
}
