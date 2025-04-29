using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int score = 200; // ������ ����
    
    public void Use(GameObject target)
    {
        // ���� �Ŵ����� ������ ���� �߰�
        GameManager.instance.AddScore(score);
        // ��� �Ǿ����Ƿ� �ڽ��� �ı�
        Destroy(gameObject);
    }
}
