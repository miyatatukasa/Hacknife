using UnityEngine;

public class SearchActive : MonoBehaviour
{
    [SerializeField] private CharactorType charactorType;
    [SerializeField] private GameObject searchView;


    /// <summary>
    /// プレイヤーがハックしているキャラと同じエネミーの
    /// 索敵範囲をアクティブにする
    /// </summary>
    /// <param name="type"></param>
    private void CharTypeActiveSet(CharactorType type)
    {
        if(this.charactorType == type)
        {
            searchView.SetActive(true);
        }
        else
        {
            searchView.SetActive(false);
        }
    }
    // 索敵範囲のアクティブ化
    //private void Update()
    //{
    //    CharTypeActiveSet(PlayerInfo.Instance.EnemyType);
    //}
}
