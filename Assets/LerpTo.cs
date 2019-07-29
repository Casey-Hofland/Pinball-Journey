using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    public float time;
    public float startDelay;

    public void DoLerp()
    {
        StartCoroutine(LerpIt());
    }

    IEnumerator LerpIt()
    {
        yield return new WaitForSeconds(startDelay);

        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        float t = 0;
        while (t + Mathf.Epsilon < 1)
        {
            t = Mathf.Min(t + Time.deltaTime / time, 1);

            transform.position = Vector3.Lerp(startPos, position, t);
            transform.rotation = Quaternion.Lerp(startRot, Quaternion.Euler(rotation), t);

            yield return null;
        }
    }
}
