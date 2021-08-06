using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour {
    public static FadeControl Instance { get => instance; }
    private static FadeControl instance;

    [SerializeField] private float fadeInSpeed = 3;
    [SerializeField] private float fadeOutSpeed = 1;
    [SerializeField, Header("�ŏ��Ƀt�F�[�h���o�����邩")] private bool isStartFade = false;
    private Image fadeUI;
    private float alpha = 0;
    private Color myColor;
    private Color colorAlphaZero;
    private System.Action callback = null;


    void Awake() {
        instance = this;
        fadeUI = GetComponent<Image>();
        myColor = fadeUI.color;
        colorAlphaZero = new Color(myColor.r, myColor.g, myColor.b, 0);
    }

    void Start() {
        if (isStartFade) StartCoroutine(FadeIN());
    }

    /// <summary>
    /// ���邭����
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeIN() {
        // �O�̂��ߏ�����
        fadeUI.color = myColor;
        alpha = fadeUI.color.a;
        while (0 < fadeUI.color.a) {
            fadeUI.color = new Color(fadeUI.color.r, fadeUI.color.g, fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeInSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ���[�v�𔲂�����callback
        if (callback != null) callback();
    }
    /// <summary>
    /// �Â�����
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOUT() {
        // �O�̂��ߏ�����
        fadeUI.color = colorAlphaZero;
        alpha = fadeUI.color.a;
        while (fadeUI.color.a < 1) {
            fadeUI.color = new Color(fadeUI.color.r, fadeUI.color.g, fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeOutSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ���[�v�𔲂�����callback
        if (callback != null) callback();
    }

    /// <summary>
    /// �t�F�[�h�C���E�A�E�g
    /// </summary>
    /// <param name="n">false�Ȃ�t�F�[�h�A�E�g, true �Ȃ�t�F�[�h�C��</param>
    public void Fade(bool n, System.Action callback = null) {
        this.callback = callback;
        if (!n) { StartCoroutine(FadeOUT()); }
        else { StartCoroutine(FadeIN()); }
    }

    /// <summary>
    /// �m�C�Y�̃t�F�[�h�Ɏg��
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="maxAlpha"></param>
    /// <param name="callback"></param>
    public void NoiseFade(Material mat, float maxAlpha, float fadeSpeed, System.Action callback = null) {
        this.callback = callback;
        StartCoroutine(NoiseFadeOut(mat, maxAlpha, fadeSpeed));
    }

    IEnumerator NoiseFadeOut(Material mat, float maxAlpha, float fadeSpeed) {
        alpha = mat.color.a;
        while (mat.color.a < maxAlpha) {
            NoiseParameter.NoiseFade(mat, alpha);
            alpha += Time.deltaTime / fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ���[�v�𔲂�����callback
        if (callback != null) callback();
    }

}
