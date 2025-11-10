using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private const string MASTER_KEY = "masterVolume";
    private const string MUSIC_KEY = "musicVolume";
    private const string SFX_KEY = "sfxVolume";
    private const float MAX_VOLUME = 1.0f;

    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    private float _masterVolume;
    private float _musicVolume;
    private float _sfxVolume;


    private void Start()
    {
        if (PlayerPrefs.HasKey(MASTER_KEY)) LoadVolumeSettings();
        else CreateVolumeSettings();
        mainMixer.SetFloat("Master", _masterVolume);
        mainMixer.SetFloat("Music", _musicVolume);
        mainMixer.SetFloat("SFX", _sfxVolume);
        _musicSlider.value = _musicVolume;
    }

    public void LoadVolumeSettings()
    {
        _masterVolume = PlayerPrefs.GetFloat(MASTER_KEY);
        _musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY);
        _sfxVolume = PlayerPrefs.GetFloat(SFX_KEY);
    }

    private void CreateVolumeSettings()
    {
        _masterVolume = MAX_VOLUME;
        _musicVolume = MAX_VOLUME;
        _sfxVolume = MAX_VOLUME;
        PlayerPrefs.SetFloat(MASTER_KEY, _masterVolume);
        PlayerPrefs.SetFloat(MUSIC_KEY, _musicVolume);
        PlayerPrefs.SetFloat(SFX_KEY, _sfxVolume);
    }

    public void SetVolume(string mixerGroup)
    {
        switch (mixerGroup)
        {
            case "Master":
                break;
            case "Music":
                _musicVolume = _musicSlider.value;
                mainMixer.SetFloat(mixerGroup, _musicVolume);
                PlayerPrefs.SetFloat(MUSIC_KEY, _musicVolume);
                break;
            case "SFX":
                _sfxVolume = _sfxSlider.value;
                mainMixer.SetFloat(mixerGroup, _sfxVolume);
                PlayerPrefs.SetFloat(SFX_KEY, _sfxVolume);
                break;
            default:
                Debug.LogError("Mixer group '" + mixerGroup + "' does not exist");
                break;
        }
    }
}
