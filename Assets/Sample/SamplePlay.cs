using UnityEngine;
using AkaneTools;
using UnityEngine.UI;

public class SamplePlay : MonoBehaviour
{
    [SerializeField]
    private Button _playBGMButton = null;
    [SerializeField]
    private Button _playSEButton = null;
    [SerializeField]
    private Button _playUIButton = null;
    [SerializeField]
    private Button _fadeOutButton = null;
    [SerializeField]
    private Button _fadeInButton = null;
    [SerializeField]
    private Button _fadeOutInButton = null;
    [SerializeField]
    private Button _stopBGMButton = null;

    [SerializeField]
    private Slider _mixBGMSlider = null;
    [SerializeField]
    private Slider _mixSESlider = null;
    [SerializeField]
    private Slider _mixUISlider = null;
    [SerializeField]
    private Slider _clipBGMSlider = null;
    [SerializeField]
    private Slider _clipSESlider = null;
    [SerializeField]
    private Slider _clipUISlider = null;

    private void Start()
    {
        _playBGMButton.onClick.AddListener(PlayBGM);
        _playSEButton.onClick.AddListener(PlaySE);
        _playUIButton.onClick.AddListener(PlayUI);
        _fadeOutButton.onClick.AddListener(PlayFadeOut);
        _fadeInButton.onClick.AddListener(PlayFadeIn);
        _fadeOutInButton.onClick.AddListener(PlayFadeOutIn);
        _stopBGMButton.onClick.AddListener(StopBGM);

        _mixBGMSlider.value = AudioManager.Instance.Volume.BGM_Volume;
        _mixSESlider.value = AudioManager.Instance.Volume.SE_Volume;
        _mixUISlider.value = AudioManager.Instance.Volume.UI_Volume;

        _mixBGMSlider.onValueChanged.AddListener((v) => AudioManager.Instance.Volume.BGM_Volume = v);
        _mixSESlider.onValueChanged.AddListener((v) => AudioManager.Instance.Volume.SE_Volume = v);
        _mixUISlider.onValueChanged.AddListener((v) => AudioManager.Instance.Volume.UI_Volume = v);

        _clipBGMSlider.value = 1f;
        _clipSESlider.value = 1f;
        _clipUISlider.value = 1f;
    }

    private void PlayBGM() => AudioManager.Instance.PlayBGM("Op", _clipBGMSlider.value);
    private void PlaySE() => AudioManager.Instance.PlaySE("Boom", _clipSESlider.value);
    private void PlayUI() => AudioManager.Instance.PlayUI("Click", _clipUISlider.value);
    private void PlayFadeOut() => AudioManager.Instance.FadeOutBGM(0.5f, _clipBGMSlider.value);
    private void PlayFadeIn() => AudioManager.Instance.FadeInBGM(0.5f, _clipBGMSlider.value);
    private void PlayFadeOutIn()
    {
        AudioManager.Instance.FadeOutBGM(0.5f, 0, callback:() =>
        {
            AudioManager.Instance.FadeInBGM(0.5f, 1, "Ed");
        });
    }
    private void StopBGM() => AudioManager.Instance.StopBGM();
}
