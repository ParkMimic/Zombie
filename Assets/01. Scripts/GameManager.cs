using UnityEngine;

// ������ ���ӿ��� ���θ� �����ϴ� ���� �Ŵ���
public class GameManager : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ� ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindAnyObjectByType<GameManager>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����

    private int score = 0; // ���� ���� ����
    public bool isGameover { get; private set; } // ���ӿ��� ����


    void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �÷��̾� ĳ������ ��� �̺�Ʈ �߻� �� ���ӿ���
        FindAnyObjectByType<PlayerHealth>().onDeath += EndGame;
    }
    
    // ������ �߰��ϰ� UI ����
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ� ���¿����� ���� �߰� ����
        if (!isGameover)
        {
            // ���� �߰�
            score += newScore;
            // ���� UI �ؽ�Ʈ ����
            UIManager.instance.UpdateScoreText(score);
        }
    }

    // ���ӿ��� ó��
    public void EndGame()
    {
        // ���ӿ��� ���¸� ������ ����
        isGameover = true;
        // ���ӿ��� UI Ȱ��ȭ
        UIManager.instance.SetActiveGameoverUI(true);
    }
}
