using UnityEngine;

public class TVSound : MonoBehaviour
{
    public AudioSource tvSpeaker;    
    public AudioClip themeSong;       
    public AudioClip[] otherChannels; 
    public AudioClip beanSound;

    private bool isTvOn = false; 
    private bool hasStartedFirstTime = false;

    public void ToggleTVPower()
    {
        isTvOn = !isTvOn; 

        if (isTvOn)
        {
            if (!hasStartedFirstTime)
            {
                tvSpeaker.clip = themeSong;
                hasStartedFirstTime = true;
            }
            tvSpeaker.Play();
            Debug.Log("TV On: Resuming " + tvSpeaker.clip.name);
        }
        else
        {
            tvSpeaker.Stop();
            Debug.Log("TV Off");
        }
    }

    public void ChangeChannel(int index)
    {
        if (isTvOn && index < otherChannels.Length)
        {
            tvSpeaker.Stop();
            tvSpeaker.clip = otherChannels[index];
            tvSpeaker.Play();
        }
    }

    public void PlayMrBeanSound()
    {
        if(tvSpeaker != null && beanSound != null)
        {
            tvSpeaker.PlayOneShot(beanSound);
        }
    }

    public void PlayFonsSound(AudioClip clip)
    {
        if(tvSpeaker != null && clip != null)
        {
            tvSpeaker.PlayOneShot(clip);
        }
    }
}