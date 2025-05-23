using Photon.Pun;
using UnityEngine;

// 탄알을 충전하는 아이템
public class AmmoPack : MonoBehaviourPun, IItem
{
    public int ammo = 30; // 충전할 탄알 수
    
    public void Use(GameObject target)
    {
        // 전달받은 게임 오브젝트로부터 PlayerShooter 컴포넌트 가져오기 시도
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        // playerShooter 컴포넌트가 있으며 총 오브젝트가 존재하면
        if (playerShooter != null && playerShooter.gun != null)
        {
            // 총의 남은 탄환 수를 ammo만큼 더하기, 모든 클라이언트에서 실행
            playerShooter.gun.photonView.RPC("AddAmmo", RpcTarget.All, ammo);
        }

        // 모든 클라이언트에서 자신 파괴
        PhotonNetwork.Destroy(gameObject);
    }
}
