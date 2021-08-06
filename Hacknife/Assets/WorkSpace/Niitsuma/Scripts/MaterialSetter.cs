using UnityEngine;
using UnityEngine.UI;


[DefaultExecutionOrder(-1)]
public class MaterialSetter : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField] private Shader shader = null;
    [SerializeField] private Color color = Color.white;


    void Awake() {
        image.material = NoiseParameter.GeneratNoiseMat(shader, color);
        NoiseParameter.NoiseFade(image.material, 0);
    }
}