using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
    public static FadeControl Instance { get => _instance; }
    private static FadeControl _instance;

    [SerializeField] private float fadeInSpeed = 3;
    [SerializeField] private float fadeOutSpeed = 1;
    [SerializeField, Header("�ŏ��Ƀt�F�[�h���o�����邩")] private bool isStartFade = false;
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
    /// ���邭����
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeIN()
    {
        // �O�̂��ߏ�����
        _fadeUI.color = myColor;
        alpha = _fadeUI.color.a;
        while (0 < _fadeUI.color.a)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeInSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ���[�v�𔲂�����callback
        if (_callback != null) _callback();
    }
    /// <summary>
    /// �Â�����
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOUT()
    {
        // �O�̂��ߏ�����
        _fadeUI.color = colorAlphaZero;
        alpha = _fadeUI.color.a;
        while (_fadeUI.color.a < 1)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeOutSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ���[�v�𔲂�����callback
        if (_callback != null) _callback();
    }

    /// <summary>
    /// �t�F�[�h�C���E�A�E�g
    /// </summary>
    /// <param name="n">false�Ȃ�t�F�[�h�A�E�g, true �Ȃ�t�F�[�h�C��</param>
    public void Fade(bool n, System.Action callback = null)
    {
        _callback = callback;
        if (!n) { StartCoroutine(FadeOUT()); }
        else { StartCoroutine(FadeIN()); }
    }

    /// <summary>
    /// �m�C�Y�̃t�F�[�h�Ɏg��
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
        // ���[�v�𔲂�����callback
        if (_callback != null) _callback();
    }

}
