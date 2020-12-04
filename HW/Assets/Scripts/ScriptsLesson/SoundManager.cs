using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioMixerGroup mixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ollSound(float value)
    {
        float volume = Mathf.Lerp(-80f, 0f, value);
        mixer.audioMixer.SetFloat("OllVolume", volume);
    }
}
