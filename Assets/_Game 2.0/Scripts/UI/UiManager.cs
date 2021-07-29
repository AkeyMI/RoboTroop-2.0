using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Stunable stunable;
    [SerializeField] Image stunBarImage;
    [SerializeField] Image minion1Ui;
    [SerializeField] Image minion2Ui;

    private Image minionAtkImage;
    private Image minionShieldImage;

    private MinionController minionController;

    private void Awake()
    {
        minionController = FindObjectOfType<MinionController>().GetComponent<MinionController>();
    }

    private void Start()
    {
        //minionController = FindObjectOfType<MinionController>().GetComponent<MinionController>();
        minionAtkImage = minion1Ui;
        minionShieldImage = minion2Ui;
    }

    private void OnEnable()
    {
        //stunable.onStunStarted += StartStunBar;
        //stunable.onStunFinished += StopStun;
        minionController.onChengeMinion += ChangeUiMinion;
    }

    private void OnDisable()
    {
        //stunable.onStunStarted -= StartStunBar;
        //stunable.onStunFinished -= StopStun;
        minionController.onChengeMinion -= ChangeUiMinion;
    }

    private void ChangeUiMinion(bool minionToChange)
    {
        minionAtkImage.enabled = minionToChange;
        minionShieldImage.enabled = !minionToChange;
    }

    private void StartStunBar(float time)
    {
        StartCoroutine(StunBarCoroutine(time));
    }

    private IEnumerator StunBarCoroutine(float time)
    {
        stunBarImage.enabled = true;
        float currentTime = time;

        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            stunBarImage.fillAmount = 1 - (currentTime / time);
            yield return null;
        }

        stunBarImage.fillAmount = 1;
    }

    private void StopStun()
    {
        stunBarImage.enabled = false;
    }
}
