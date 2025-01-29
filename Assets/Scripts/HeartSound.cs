using UnityEngine;
using UnityEngine.InputSystem.Controls;



public class HeartSound : MonoBehaviour
{
    [SerializeField] private AudioSource heartSoundPlayer;

    [SerializeField] private AudioClip lubSound;
    [SerializeField] private AudioClip dubSound;


    private void OnEnable()
    {
        HeartBeatManager.OnVentriclesContract += PlayLubSound;
        HeartBeatManager.OnValvesClosed += PlayDubSound;
    }

    private void OnDisable()
    {
        HeartBeatManager.OnVentriclesContract -= PlayLubSound;
        HeartBeatManager.OnValvesClosed -= PlayDubSound;
    }
    private void PlayLubSound()
    {
        heartSoundPlayer.PlayOneShot(lubSound);
        heartSoundPlayer.pitch = 1.3f;
        Debug.Log("Lub");
    }
    private void PlayDubSound()
    {
        heartSoundPlayer.PlayOneShot(dubSound);
        heartSoundPlayer.pitch = 0.9f; 
        Debug.Log("Dub");
    }
}
