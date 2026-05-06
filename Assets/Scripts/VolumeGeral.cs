using UnityEngine;
using Unity.Audio;
using UnityEngine.Audio;
public class VolumeGeral : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        
    }
}
