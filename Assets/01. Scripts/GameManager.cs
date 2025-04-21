using UnityEngine;

// 사용자 입력에 따라 플레이어 캐릭터를 움직이는 스크립트
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover;


    void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<GameManager>();
        }
        else
        {
            Destroy(this);
        }

        isGameover = false;
    }
}
