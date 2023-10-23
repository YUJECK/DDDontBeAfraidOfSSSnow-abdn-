using UnityEngine;

public sealed class PlayerAudioPlayer : MonoBehaviour
{
    public AudioSource MineSound;
    public AudioSource SnowSound;

    public void PlaySnow()
    {
        SnowSound.Play();
    }
    
    public void StopSnow()
    {
        SnowSound.Stop();
    }
    
    public void PlayMine()
    {
        MineSound.Play();
    }
}
