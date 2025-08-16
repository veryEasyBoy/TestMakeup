using UnityEngine;
using UnityEngine.UI;

public class MakeupItemActivityController : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster graphicRaycasterLipstick;
    [SerializeField] private GraphicRaycaster graphicRaycasterShadow;
    [SerializeField] private GraphicRaycaster graphicRaycasterCream;

    public void DeactiveLipstick() => graphicRaycasterLipstick.enabled = false;
    public void DeactiveShadow() => graphicRaycasterShadow.enabled = false;
    public void DeactiveCream() => graphicRaycasterCream.enabled = false;

    public void AllActivityMakeupItems()
    {
        graphicRaycasterLipstick.enabled = true;
        graphicRaycasterShadow.enabled = true;
        graphicRaycasterCream.enabled = true;
    }
}
