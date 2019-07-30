using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class RandomOrder : MonoBehaviour
{
    public AudioClip[] clips;
    public float delay = 3f;

    private AudioSource audioSource;
    private AudioClip[] clipOrder;
    private int currentClip = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Random rnd = new Random();
        clipOrder = clips.OrderBy(c => rnd.Next()).ToArray();

        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(delay);

        audioSource.clip = clipOrder[currentClip];
        audioSource.Play();

        while (audioSource.isPlaying)
            yield return null;

        currentClip++;
        if (currentClip >= clipOrder.Length)
            currentClip = 0;

        StartCoroutine(PlayMusic());

        yield return null;
    }
}
