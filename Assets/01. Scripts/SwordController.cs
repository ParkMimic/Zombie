using UnityEngine;

// 주어진 Gun 오브젝트를 쏘거나 재장전
// 알맞은 애니메이션을 재생하고 IK를 사용해 캐릭터 양손이 총에 위치하도록 조정
public class SwordController : MonoBehaviour
{
    public Sword sword; // 사용할 검
    public Transform swordPivot; // 검 배치의 기준점
    public Transform rightHandMount; // 검의 오른쪽 손잡이, 오른손이 위치할 지점

    private PlayerInput playerInput; // 플레이어의 입력
    private Animator playerAnimator; // 애니메이터 컴포넌트

    void Start()
    {
        // 사용할 컴포넌트 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 슈터가 활성화될 때 검도 활성화
        sword.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // 슈터가 비활성화될 때 검도 함께 비활성화
        sword.gameObject.SetActive(false);
    }

    // 애니메이터의 IK 갱신
    private void OnAnimatorIK(int layerIndex)
    {
        // 총의 기준점 swordPivot을 3D 모델의 오른쪽 팔꿈치 위치로 이동
        swordPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK를 사용하여 오른손의 위치와 회전을 총의 오른쪽 손잡이에 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    }
}
