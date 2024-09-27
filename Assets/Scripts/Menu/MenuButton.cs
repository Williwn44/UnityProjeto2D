using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButton : MonoBehaviour
{
    public List<GameObject> button;
    public float duration = .2f;
    public float delay = .1f;
    public Ease ease = Ease.OutBack;

    public void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }
    private void HideAllButtons()
    {
        foreach (var b in button)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }

    }
    public void ShowButtons()
    {
        for(int i = 0; i < button.Count; i++)
        {
            var b = button[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }
    
  

}
