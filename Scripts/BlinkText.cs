using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public Text textToBlink;
    public float blinkInterval = 0.5f; 

    void Start()
    {
        if (textToBlink != null)
        {
            StartCoroutine(BlinkText());
        }
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            textToBlink.enabled = !textToBlink.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
