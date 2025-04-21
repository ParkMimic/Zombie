using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    [Header("사운드")]
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    [Header("총의 데미지")]
    public float damage = 25; // 공격력

    [Header("초기 총 탄알 수")]
    public int startAmmoRemain = 100; // 처음에 주어질 전체 탄알
    public int magCapacity = 25; // 탄창 용량

    [Header("연사속도 및 재장전 시간")]
    public float timeBetFire = 0.12f; // 탄알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
}
