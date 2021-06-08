using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float MoveSpeed;
    // 旋回速度
    [SerializeField]
    float rotateSpeed;
    // カプセルコライダの参照
    private CapsuleCollider col;
    // リジッドボディの参照
    private Rigidbody rb;
    // カプセルコライダの移動量
    private Vector3 velocity;

    void Start()
    {
        // カプセルコライダ―コンポーネントを取得する
        col = GetComponent<CapsuleCollider>();
        // リジッドボディコンポーネントを取得する
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log(MoveSpeed);

        // キャラクター移動処理
        velocity = new Vector3(0, 0, v);    // 上下のキー入力からZ軸の移動量を取得

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // 移動速度を掛ける
        }


        // モデルのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);

        //上下のキー入力でキャラクターを移動させる
        transform.localPosition += velocity * Time.fixedDeltaTime;
        // 左右のキー入力でキャラクタをY軸で旋回させる
        transform.Rotate(0, h * rotateSpeed, 0);
    }
}
