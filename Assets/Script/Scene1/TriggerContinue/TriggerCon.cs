using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TriggerCon : MonoBehaviour
{
    public List<AudioSource> audioSources;
    //public List<string> subtitles;
    public List<float> audioDelays;
    public Collider triggerCollider;
    public static TriggerCon activeTrigger;
    public int currentAudioIndex = 0;
    public List<Collider> nextTriggers;

    [Header("UI Elements")]
    //public Text subtitleText;

    [Header("Audio Start Delay")]
    public float initialDelay = 1.0f;

    void Start()
    {
        triggerCollider = GetComponent<Collider>();
        //subtitleText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activeTrigger != null && activeTrigger != this)
            {
                activeTrigger.triggerCollider.enabled = false;
            }

            activeTrigger = this;
            if (!IsAudioPlaying())
            {
                StartCoroutine(StartAudioWithDelay(initialDelay));
            }
        }
    }

    private System.Collections.IEnumerator StartAudioWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayAudio();
    }

    bool IsAudioPlaying()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    void PlayAudio()
    {
        if (currentAudioIndex >= audioSources.Count) return;

        AudioSource currentPlayingAudio = audioSources[currentAudioIndex];
        if (!currentPlayingAudio.isPlaying)
        {
            currentPlayingAudio.Play();
            //DisplaySubtitle(currentAudioIndex);
            StartCoroutine(PlayNextAudioAfterCurrentEnds(currentPlayingAudio.clip.length, audioDelays[currentAudioIndex]));
        }
    }

    /*void DisplaySubtitle(int index)
    {
        if (index < subtitles.Count)
        {
            subtitleText.text = subtitles[index];
        }
    }*/

    private System.Collections.IEnumerator PlayNextAudioAfterCurrentEnds(float audioLength, float audioDelay)
    {
        yield return new WaitForSeconds(audioLength);
        //subtitleText.text = "";
        yield return new WaitForSeconds(audioDelay);

        if (currentAudioIndex < nextTriggers.Count)
        {
            nextTriggers[currentAudioIndex].enabled = true;
        }

        currentAudioIndex++;
        PlayAudio();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerCollider.enabled = false;
            //subtitleText.text = "";

        }
    }
}
