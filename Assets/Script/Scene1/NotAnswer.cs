using System.Collections;
using UnityEngine;

public class NotAnswer : MonoBehaviour
{
    public AudioSource[] audioSources; // Array for audio sources
    public GameObject[] subtitles;     // Array for subtitles
    public GameObject Tele;
    public AudioSource Hang_up;
    public GameObject NAStory;

    void Start()
    {
        NAStory.SetActive(false);
        StartCoroutine(DelayedAction());
    }

    private IEnumerator DelayedAction()
    {
        // Assuming you want these specific wait times between audio/subtitle pairs
        float[] waitTimesBefore = { 8f, 10f, 1f }; // Wait times before each audio/subtitle
        float[] subtitleDurations = { 5f, 3f, 1f }; // Duration each subtitle stays visible

        for (int i = 0; i < audioSources.Length; i++)
        {
            yield return new WaitForSeconds(waitTimesBefore[i]);
            yield return PlayAudioWithSubtitles(audioSources[i], subtitles[i], subtitleDurations[i]);
        }

        // After all audio/subtitles have played
        yield return new WaitForSeconds(3f);
        Tele.SetActive(false);
        Hang_up.Play();

        yield return new WaitForSeconds(3f);
        NAStory.SetActive(true);
    }

    private IEnumerator PlayAudioWithSubtitles(AudioSource audioSource, GameObject subtitle, float displayTime)
    {
        audioSource.Play();
        subtitle.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        subtitle.SetActive(false);
    }

    void Update()
    {
    }
}
