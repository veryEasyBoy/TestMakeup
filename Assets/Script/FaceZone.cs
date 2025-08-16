using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FaceZone : MonoBehaviour
{
    [Header("Image for change")]

    [SerializeField] private Image spriteAcne;
    [SerializeField] private Image spriteShadow;
    [SerializeField] private Image spriteLips;

    [Header("Button for next stage")]

    [FormerlySerializedAs("nextStage")]
    [SerializeField] private GameObject nextStageButton;

    [Header("Set objects with GetComponentsInChildren<Image> \n for clean makeup")]
    [SerializeField] private GameObject[] makeupClean;

    private RectTransform handTransform;
    private Brush brush;
    private Lipstick lipstick;

    private void Awake()
    {
        brush = GameObject.FindGameObjectWithTag("Brush").GetComponent<Brush>();
        lipstick = GameObject.FindGameObjectWithTag("Lipstick").GetComponent<Lipstick>();
        handTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    public void CleanFace()
    {
        foreach (GameObject makeup in makeupClean)
            foreach (Image image in makeup.GetComponentsInChildren<Image>())
                image.enabled = false;
    }

    public void SetShadow()
    {
        if (spriteShadow != null)
            spriteShadow.enabled = false;
        spriteShadow = brush.MakeupChangeSprite;
        spriteShadow.enabled = true;
    }

    public void SetLipstick()
    {
        if (spriteLips != null)
            spriteLips.enabled = false;
        spriteLips = handTransform.GetComponentInChildren<Lipstick>().MakeupChangeSprite;
        spriteLips.enabled = true;
    }

    public void HideAcne() => spriteAcne.enabled = false;

    public void ShowNextStageButton() => nextStageButton.SetActive(true);
}