using UnityEngine;
using UnityEngine.UI;


[DefaultExecutionOrder(-1)]
public class MaterialSetter : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Shader _shader = null;
    [SerializeField] private Color _color = Color.white;


    void Awake()
    {
        _image.material = NoiseParameter.GeneratNoiseMat(_shader, _color);
        NoiseParameter.NoiseFade(_image.material, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FadeControl.Instance.NoiseFade(_image.material, 1f, 3f, () => Debug.LogError("GameOver"));
        }
    }
}