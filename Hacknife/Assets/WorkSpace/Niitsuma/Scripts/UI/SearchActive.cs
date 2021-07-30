using UnityEngine;

public class SearchActive : MonoBehaviour
{
    [SerializeField] private CharactorType charactorType;
    [SerializeField] private GameObject searchView;


    /// <summary>
    /// �v���C���[���n�b�N���Ă���L�����Ɠ����G�l�~�[��
    /// ���G�͈͂��A�N�e�B�u�ɂ���
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
    // ���G�͈͂̃A�N�e�B�u��
    //private void Update()
    //{
    //    CharTypeActiveSet(PlayerInfo.Instance.EnemyType);
    //}
}
