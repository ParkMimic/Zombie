using UnityEngine;

// ����� �Է¿� ���� �÷��̾� ĳ���͸� �����̴� ��ũ��Ʈ
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
