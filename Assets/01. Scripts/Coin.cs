using UnityEngine;
using Photon.Pun;

public class Coin : MonoBehaviourPun, IItem
{
    public int score = 200; // 증가할 점수
    
    public void Use(GameObject target)
    {
        // 게임 매니저에 접근해 점수 추가
        GameManager.instance.AddScore(score);
        // 사용 되었으므로 모든 클라이언트에서 자신을 파괴
        PhotonNetwork.Destroy(gameObject);
    }
}
