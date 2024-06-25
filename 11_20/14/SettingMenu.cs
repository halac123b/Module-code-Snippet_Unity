using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
  private AudioSource _audioSource;
  [SerializeField] private AudioMixer _audioMixer;

  private void Start()
  {
    _audioSource = GetComponent<AudioSource>();
  }
  public void PlayMusic()
  {
    _audioSource.Play();
  }

  // Set value for a exposed variable of AudioMixer (cần thực hiện expose thủ công trên Editor)
  public void AdjustVolume(float volume)
  {
    _audioMixer.SetFloat("volume", volume);
  }
}
