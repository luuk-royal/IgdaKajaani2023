using UnityEngine;

public class TempoControl : MonoBehaviour
{
    public float initialPitch = 1.0f;
    public float targetPitch = 1.5f;
    public float tempoChangeDuration = 60.0f;

    private AudioSource audioSource;
    private double startTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = initialPitch;
        startTime = AudioSettings.dspTime;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + tempoChangeDuration);
    }

    void Update()
    {
        double currentTime = AudioSettings.dspTime;

        if (currentTime - startTime < tempoChangeDuration)
        {
            float t = (float)((currentTime - startTime) / tempoChangeDuration);
            float newPitch = Mathf.Lerp(initialPitch, targetPitch, t);
            audioSource.pitch = newPitch;
        }
        else
        {
            audioSource.pitch = targetPitch;
        }
    }
}
