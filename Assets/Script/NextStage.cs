using DG.Tweening;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    [SerializeField] private GameObject[] stages;
    [SerializeField] private float durations;
    private int numStage = 0;

    public void Next()
    {
        if (numStage < stages.Length - 1)
        {
            numStage++;
            ActivateStage();
        }
    }
    public void Back()
    {
        if (numStage > 0)
        {
            numStage--;
            ActivateStage();
        }
    }

    private void ActivateStage()
    {
        stages[numStage].GetComponent<CanvasGroup>().DOFade(1, durations);
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].SetActive(i == numStage);
            if (i != numStage)
                stages[i].GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}