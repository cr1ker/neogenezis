using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image DamageImage;

    public void StartShowDamageEffect()
    {
        StartCoroutine(ShowScreenEffect(1, 0, 0));
    }

    public void StartShowHealEffect()
    {
        StartCoroutine(ShowScreenEffect(0, 255, 0));
    }

    public void StartShowBulletEffect()
    {
        StartCoroutine(ShowScreenEffect(0, 191, 255));
    }

    private IEnumerator ShowScreenEffect(float r, float g, float b)
    {
        DamageImage.enabled = true;
        for (float t = 1; t > 0f ; t-=Time.deltaTime)
        {
            DamageImage.color = new Color(r, g, b, t);
            yield return null;
        }
        DamageImage.enabled = false;
    }
}
