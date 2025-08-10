using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FaceZone : MonoBehaviour
{
    [Header("Image for change")]
    [SerializeField] private Image sprite;
    [Header("Target for hand move towards")]
    [SerializeField] private RectTransform targetToward;
    [Header("Set MakeupItem")]
    [SerializeField] private MakeupItems makeUpItem;
    [Header("Duration animation")]
    [SerializeField] private float duration;
    [SerializeField] private GameObject nextStage;

    private RectTransform handTransform;
    private Collider2D myCollider;
    private bool isPress = false;

    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        handTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cream"))
        {
            StartCreamAnimations(collision, -100f, 0, 0);
            return;
        }
        if (collision.CompareTag("Brush"))
        {
            StartBrushAnimations(collision, 200f, -100f, -300f);
            return;
        }
    }

    public void ActivateToColliderZone() => myCollider.enabled = true;

    public void DeactivateToColliderZone() => myCollider.enabled = false;

    private void StartCreamAnimations(Collider2D collision, float newPositionX, float transformPositionX, float positionY)
    {
        StartDefaultAnimation(collision, newPositionX, transformPositionX, positionY).
            OnKill(() => EndDefaultAnimation(collision));
    }

    private void StartBrushAnimations(Collider2D collision, float newPositionX, float transformPositionX, float positionY)
    {
        StartDefaultAnimation(collision, newPositionX, transformPositionX, positionY).
            OnComplete(() => EndAnimationsBrush(collision));
    }

    private void EndDefaultAnimation(Collider2D collision)
    {
        sprite.enabled = false;
        collision.GetComponent<MakeupItems>().TweenReturnOfPositions().OnComplete(()=> NextStageButton());
    }

    private void NextStageButton()
    {
        if (!isPress)
        {
            isPress = true;
            nextStage.SetActive(true);
        }
    }

    private void EndAnimationsBrush(Collider2D collision)
    {
        EndDefaultAnimation(collision);
        SetShadow(collision);
    }

    private void SetShadow(Collider2D collision)
    {
        if (sprite != null)
            sprite.enabled = false;
        sprite = collision.GetComponent<Brush>().MakeupChangeColor;
        sprite.enabled = true;
    }

    private Tween StartDefaultAnimation(Collider2D collision, float newPositionX, float transformPositionX, float positionY)
    {
        Vector3 originPosition = new Vector3(transform.position.x, transform.position.y + positionY, transform.position.z);
        originPosition = VectorCalculate(originPosition, transformPositionX);
        Vector3 newPosition = VectorCalculate(originPosition, newPositionX);

        myCollider.enabled = false;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(handTransform.DOMove(originPosition, duration));
        sequence.Append(handTransform.DOMove(newPosition, duration).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo));
        return sequence.Play();
    }

    private Vector3 VectorCalculate(Vector3 vector, float newPositionX)
    {
        return vector = new Vector3(vector.x + newPositionX, vector.y, vector.z);
    }
}
