using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public List<Renderer> PlayerMaterial;
    
    public void StartShowBlink()
    {
        StartCoroutine(ShowBlink());
    }
    
    public IEnumerator ShowBlink()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < PlayerMaterial.Count; i++)
            {
                for (int j = 0; j < PlayerMaterial[i].materials.Length; j++)
                {
                    PlayerMaterial[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t*30) * 0.5f + 0.5f,0,0,0));
                }
            }
            yield return null;
        }
    }
}
