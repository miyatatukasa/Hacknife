using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    [SerializeField] private Image _noiseUI;
    [SerializeField] private FadeControl fade;
    private bool _noiseStart = false;

    private void Update()
    {
        if (GameManager.Instance.GameOver && !_noiseStart)
        {
            FadeControl.Instance.NoiseFade(_noiseUI.material, 1f, 3f, () => StartCoroutine(GameOver()));
            _noiseStart = true;
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        fade.Fade(false, () => SceneManager.LoadScene("TitleMenu"));
    }

}
