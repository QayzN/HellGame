using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    public AudioSource audioSource;
    public float duration;
    public float targetVolume;



    private void Start()
    {
        StartCoroutine(FadeAudioSource.StartFade(audioSource, duration, targetVolume));
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedposition = Vector3.Lerp (transform.position, desiredPosition, (smoothSpeed*Time.fixedDeltaTime));
        transform.position = smoothedposition;

  
    }



    public static class FadeAudioSource
    {

        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }



}
