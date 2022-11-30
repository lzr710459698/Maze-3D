using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShakeScript : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float timepass = 0.0f;

        while(timepass < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPosition.z);
            timepass += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
