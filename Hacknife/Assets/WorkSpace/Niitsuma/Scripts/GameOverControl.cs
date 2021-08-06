using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {
    [SerializeField] private Image noiseUI;
    [SerializeField] private FadeControl fade;
    private bool noiseStart = false;

    private void Update() {
        if (GameManager.Instance.GameOver && !noiseStart) {
            FadeControl.Instance.NoiseFade(noiseUI.material, 1f, 3f, () => StartCoroutine(GameOver()));
            noiseStart = true;
        }
    }

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(2f);
        fade.Fade(false, () => SceneManager.LoadScene("TitleMenu"));
    }

}
