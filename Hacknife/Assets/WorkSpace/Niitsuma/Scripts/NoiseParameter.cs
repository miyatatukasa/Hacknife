using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseParameter
{
    private static readonly string color = "_Color";

    /// <summary>
    /// NoiseMat作成用
    /// </summary>
    /// <param name="sha"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Material GeneratNoiseMat(Shader sha, Color col)
    {
        Material m = new Material(sha);
        m.SetColor(color, col);
        return m;
    }

    /// <summary>
    /// ノイズのalpha値を変える
    /// </summary>
    /// <param name="mat">ノイズのマテリアル</param>
    /// <param name="alpha">alpha値</param>
    public static void NoiseFade(Material mat, float alpha)
    {
        Vector4 alphaCol = new Vector4(mat.color.r, mat.color.g, mat.color.b, alpha);
        mat.SetColor(color, alphaCol);
    }
}
