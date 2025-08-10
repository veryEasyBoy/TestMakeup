using DG.Tweening;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    [SerializeField] private GameObject[] stages;
    [SerializeField] private float durations;
    private CanvasGroup canvasGroup;

    public void Next(int numStage)
    {
        stages[numStage].SetActive(true);
        for(int i = 0; i < stages.Length;)
        {
            if (i != numStage)
            {
                stages[i].SetActive(false);
                i++;
            }
            else
            {
                stages[i].GetComponent<CanvasGroup>().DOFade(1, durations);
                stages[i].SetActive(true);
                i++;
                gameObject.SetActive(false);
            }
        }
    }
}
