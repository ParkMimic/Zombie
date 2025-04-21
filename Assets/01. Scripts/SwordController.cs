using UnityEngine;

// �־��� Gun ������Ʈ�� ��ų� ������
// �˸��� �ִϸ��̼��� ����ϰ� IK�� ����� ĳ���� ����� �ѿ� ��ġ�ϵ��� ����
public class SwordController : MonoBehaviour
{
    public Sword sword; // ����� ��
    public Transform swordPivot; // �� ��ġ�� ������
    public Transform rightHandMount; // ���� ������ ������, �������� ��ġ�� ����

    private PlayerInput playerInput; // �÷��̾��� �Է�
    private Animator playerAnimator; // �ִϸ����� ������Ʈ

    void Start()
    {
        // ����� ������Ʈ ��������
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // ���Ͱ� Ȱ��ȭ�� �� �˵� Ȱ��ȭ
        sword.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // ���Ͱ� ��Ȱ��ȭ�� �� �˵� �Բ� ��Ȱ��ȭ
        sword.gameObject.SetActive(false);
    }

    // �ִϸ������� IK ����
    private void OnAnimatorIK(int layerIndex)
    {
        // ���� ������ swordPivot�� 3D ���� ������ �Ȳ�ġ ��ġ�� �̵�
        swordPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK�� ����Ͽ� �������� ��ġ�� ȸ���� ���� ������ �����̿� ����
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    }
}
