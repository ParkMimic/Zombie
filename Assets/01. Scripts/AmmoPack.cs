using Photon.Pun;
using UnityEngine;

// ź���� �����ϴ� ������
public class AmmoPack : MonoBehaviourPun, IItem
{
    public int ammo = 30; // ������ ź�� ��
    
    public void Use(GameObject target)
    {
        // ���޹��� ���� ������Ʈ�κ��� PlayerShooter ������Ʈ �������� �õ�
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        // playerShooter ������Ʈ�� ������ �� ������Ʈ�� �����ϸ�
        if (playerShooter != null && playerShooter.gun != null)
        {
            // ���� ���� źȯ ���� ammo��ŭ ���ϱ�, ��� Ŭ���̾�Ʈ���� ����
            playerShooter.gun.photonView.RPC("AddAmmo", RpcTarget.All, ammo);
        }

        // ��� Ŭ���̾�Ʈ���� �ڽ� �ı�
        PhotonNetwork.Destroy(gameObject);
    }
}
