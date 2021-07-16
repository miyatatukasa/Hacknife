using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
    public static FadeControl Instance { get => _instance; }
    private static FadeControl _instance;

    [SerializeField] private float fadeInSpeed = 3;
    [SerializeField] private float fadeOutSpeed = 1;
    [SerializeField, Header("最初にフェード演出を入れるか")] private bool isStartFade = false;
    private Image _fadeUI;
    private float alpha = 0;
    private Color myColor;
    private Color colorAlphaZero;
    private System.Action _callback = null;


    void Awake()
    {
        _instance = this;
        _fadeUI = GetComponent<Image>();
        myColor = _fadeUI.color;
        colorAlphaZero = new Color(myColor.r, myColor.g, myColor.b, 0);
    }

    void Start()
    {
        if (isStartFade) StartCoroutine(FadeIN());
    }

    /// <summary>
    /// 明るくする
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeIN()
    {
        // 念のため初期化
        _fadeUI.color = myColor;
        alpha = _fadeUI.color.a;
        while (0 < _fadeUI.color.a)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeInSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }
    /// <summary>
    /// 暗くする
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOUT()
    {
        // 念のため初期化
        _fadeUI.color = colorAlphaZero;
        alpha = _fadeUI.color.a;
        while (_fadeUI.color.a < 1)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeOutSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }

    /// <summary>
    /// フェードイン・アウト
    /// </summary>
    /// <param name="n">falseならフェードアウト, true ならフェードイン</param>
    public void Fade(bool n, System.Action callback = null)
    {
        _callback = callback;
        if (!n) { StartCoroutine(FadeOUT()); }
        else { StartCoroutine(FadeIN()); }
    }

    /// <summary>
    /// ノイズのフェードに使う
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="maxAlpha"></param>
    /// <param name="callback"></param>
    public void NoiseFade(Material mat, float maxAlpha, float fadeSpeed, System.Action callback = null)
    {
        _callback = callback;
        StartCoroutine(NoiseFadeOut(mat, maxAlpha, fadeSpeed));
    }

    IEnumerator NoiseFadeOut(Material mat, float maxAlpha, float fadeSpeed)
    {
        alpha = mat.color.a;
        while (mat.color.a < maxAlpha)
        {
            NoiseParameter.NoiseFade(mat, alpha);
            alpha += Time.deltaTime / fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }

}
