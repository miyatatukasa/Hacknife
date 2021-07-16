using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseParameter
{
    private static readonly string color = "_Color";

    /// <summary>
    /// NoiseMat�쐬�p
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
    /// �m�C�Y��alpha�l��ς���
    /// </summary>
    /// <param name="mat">�m�C�Y�̃}�e���A��</param>
    /// <param name="alpha">alpha�l</param>
    public static void NoiseFade(Material mat, float alpha)
    {
        Vector4 alphaCol = new Vector4(mat.color.r, mat.color.g, mat.color.b, alpha);
        mat.SetColor(color, alphaCol);
    }
}
