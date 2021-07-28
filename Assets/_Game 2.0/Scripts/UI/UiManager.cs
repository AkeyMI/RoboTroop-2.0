using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Stunable stunable;
    [SerializeField] Image stunBarImage;

    private void OnEnable()
    {
        stunable.onStunStarted += StartStunBar;
        stunable.onStunFinished += StopStun;
    }

    private void OnDisable()
    {
        stunable.onStunStarted -= StartStunBar;
        stunable.onStunFinished -= StopStun;
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
