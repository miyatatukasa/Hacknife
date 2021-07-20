using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{
    [SerializeField] private Image _noiseUI;
    private bool _noiseStart = false;

    private void Update()
    {
        if (GameManager.Instance.GameOver && !_noiseStart)
        {
            FadeControl.Instance.NoiseFade(_noiseUI.material, 1f, 3f, () => Debug.LogError("GameOver"));
            _noiseStart = true;
        }
    }

}
