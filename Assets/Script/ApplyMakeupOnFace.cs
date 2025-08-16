using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ApplyMakeupOnFace : MonoBehaviour
{
    [Header("Setting animation")]
    [SerializeField]
    private float duration;
    [SerializeField]
    private float rightPositionX;
    [SerializeField]
    private float leftPositionX;
    [SerializeField]
    private float positionY;

    private RectTransform handTransform;
    private GameObject face;
    private MakeupItemActivityController makeupActivityController;

    [FormerlySerializedAs("OnEndFaceAnimation")]
    public UnityEvent onEndFaceAnimation;

    public UnityEvent onEndFullAnimation;

    private void Awake()
    {
        makeupActivityController = FindFirstObjectByType<MakeupItemActivityController>();
        face = GameObject.FindGameObjectWithTag("FaceZone");
        handTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FaceZone"))
            PlayAnimations();
    }

    private void PlayAnimations()
    {
        var faceAnimation = FaceAnimation(rightPositionX, leftPositionX, positionY, duration);
        faceAnimation
            .OnKill(() =>
            {
                onEndFaceAnimation?.Invoke();
                PlayReturnAnimation()
                    .OnComplete(() =>
                    {
                        makeupActivityController.AllActivityMakeupItems();
                        onEndFullAnimation?.Invoke();
                    });
            })
            .Play();
    }


    private Tween FaceAnimation(float rightPositionX, float leftPositionX, float positionY, float duration)
    {
        var leftHandPosition = face.transform.position + new Vector3(leftPositionX, positionY, 0);
        var rightHandPosition = face.transform.position + new Vector3(rightPositionX, positionY, 0);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(handTransform.DOMove(leftHandPosition, duration));
        sequence.Append(handTransform.DOMove(rightHandPosition, duration)
            .SetEase(Ease.Linear)
            .SetLoops(4, LoopType.Yoyo));
        return sequence;
    }

    private Tween PlayReturnAnimation()
    {
        return GetComponent<MakeupItems>()
            .TweenReturnOfPositions();
    }
}