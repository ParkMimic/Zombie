using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    [Header("����")]
    public AudioClip shotClip; // �߻� �Ҹ�
    public AudioClip reloadClip; // ������ �Ҹ�

    [Header("���� ������")]
    public float damage = 25; // ���ݷ�

    [Header("�ʱ� �� ź�� ��")]
    public int startAmmoRemain = 100; // ó���� �־��� ��ü ź��
    public int magCapacity = 25; // źâ �뷮

    [Header("����ӵ� �� ������ �ð�")]
    public float timeBetFire = 0.12f; // ź�� �߻� ����
    public float reloadTime = 1.8f; // ������ �ҿ� �ð�
}
