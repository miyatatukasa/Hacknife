using UnityEngine;

public class StartPlayerData : MonoBehaviour, IHackable
{
    public CharactorType GetEnemyType { get; private set; }

    void Awake()
    {
        GetEnemyType = CharactorType.StartPlayer;
    }

    void Update()
    {
        if(this.gameObject != PlayerInfo.Instance.PlayerObj) { gameObject.SetActive(false); }
    }
}
