using Photon.Pun; // PUN ���� �ڵ�
using Unity.Cinemachine; // �ó׸ӽ� ���� �ڵ�
using UnityEngine;

// �ó׸ӽ� ī�޶� ���� �÷��̾ �����ϵ��� ����
public class CameraSetup : MonoBehaviourPun
{
    void Start()
    {
        // ���� �ڽ��� ���� �÷��̾���
        if (photonView.IsMine)
        {
            // ���� �ִ� �ó׸ӽ� ���� ī�޶� ã��
            CinemachineCamera followCam = FindAnyObjectByType<CinemachineCamera>();
            // ���� ī�޶��� ���� ����� �ڽ��� Ʈ���������� ����
            followCam.Follow = transform;
            followCam.LookAt = transform;
        }
    }
}
