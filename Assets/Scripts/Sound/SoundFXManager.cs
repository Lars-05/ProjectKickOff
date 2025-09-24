using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance { get; private set; }

    [Header("Audio Setup")]
    public AudioSource soundFXObject;
    public AudioClip[] audioClips;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
     
            //Destroy(gameObject);
    }

    public void PlaySoundFXClip(string audioClipName, Transform spawnTransform, float volume, bool randomPitch)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        foreach (var audioClip in audioClips)
        {
            if (audioClip.name == audioClipName)
            {
                audioSource.clip = audioClip;
                audioSource.volume = volume;
                if (randomPitch)
                {
                    audioSource.pitch = Random.Range(0.95f, 1.05f);
                }
                audioSource.Play();
                Destroy(audioSource.gameObject, audioClip.length);
                return;
            }
        }
        Destroy(audioSource.gameObject);
    }
}