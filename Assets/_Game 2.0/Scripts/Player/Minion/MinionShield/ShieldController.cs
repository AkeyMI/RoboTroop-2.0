using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] GameObject shield = default;
    [SerializeField] int lifeShield = 15;
    [SerializeField] float timeToReloadShield = 5f;

    private int currentLifeShield;
    private bool shieldIsBroken;

    private void Start()
    {
        shield.GetComponent<Shield>().Init(this);
        currentLifeShield = lifeShield;
    }

    private void Update()
    {
        if (!shieldIsBroken)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UseShield();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OffShield();
            }
        }
        else
        {
            StartCoroutine(FixShield());
        }
    }

    public void ShieldDamage(int amount)
    {
        currentLifeShield -= amount;

        if(currentLifeShield <= 0)
        {
            shieldIsBroken = true;
        }
    }

    IEnumerator FixShield()
    {
        yield return new WaitForSeconds(timeToReloadShield);

        shieldIsBroken = false;
    }

    private void UseShield()
    {
        shield.SetActive(true);
    }

    private void OffShield()
    {
        shield.SetActive(false);
    }

}
