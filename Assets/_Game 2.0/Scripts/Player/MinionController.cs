using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    [SerializeField] MinionData minion1 = default;
    [SerializeField] MinionDefenceData minion2 = default;
    [SerializeField] GameObject minionArt = default;

    private GameObject minionAtk;
    private GameObject minionShield;
    private GameObject minionItem;

    private bool minionChange = false;

    private void Start()
    {
        minionAtk = Instantiate(minion1.minionPrefab, Vector3.zero, Quaternion.identity);
        minionAtk.transform.SetParent(minionArt.transform, false);

        minionShield = Instantiate(minion2.minionPrefab, Vector3.zero, Quaternion.identity);
        minionShield.transform.SetParent(minionArt.transform, false);
        minionShield.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangeMinion();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseMinion();
        }
    }

    private void ChangeMinion()
    {
        minionAtk.SetActive(minionChange);

        minionChange = !minionChange;

        minionShield.SetActive(minionChange);
    }

    private void UseMinion()
    {

    }

    public void ChangeAtkMinion(MinionData data)
    {
        if (minionAtk.activeSelf)
        {
            Destroy(minionAtk);
            minionAtk = Instantiate(data.minionPrefab, Vector3.zero, Quaternion.identity);
            minionAtk.transform.SetParent(minionArt.transform, false);
        }
        else
        {
            Destroy(minionAtk);
            minionAtk = Instantiate(data.minionPrefab, Vector3.zero, Quaternion.identity);
            minionAtk.transform.SetParent(minionArt.transform, false);
            minionAtk.SetActive(false);

        }
    }

    public void ChangeShieldMinion(MinionDefenceData data)
    {
        if (minionShield.activeSelf)
        {
            Destroy(minionShield);
            minionShield = Instantiate(data.minionPrefab, Vector3.zero, Quaternion.identity);
            minionShield.transform.SetParent(minionArt.transform, false);
        }
        else
        {
            Destroy(minionShield);
            minionShield = Instantiate(data.minionPrefab, Vector3.zero, Quaternion.identity);
            minionShield.transform.SetParent(minionArt.transform, false);
            minionShield.SetActive(false);

        }
    }

    public void ChangeItemMinion()
    {

    }
}
