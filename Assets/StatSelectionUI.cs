using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatSelectionUI : MonoBehaviour
{
    [SerializeField] private Image selectionDieImage, resultDieImage;
    [SerializeField] private TextMeshProUGUI statLabel;
    [SerializeField] private Button button;
    private int index = 0;
    private int result = 0;
    private bool isSelected = false;

    public void InitSelection(int index)
    {
        selectionDieImage.sprite = RollManager.Instance.diceGraphics[index].offSprite;
        statLabel.text = StatManager.Instance.stats[index];
        this.index = index;
    }

    public void Highlight(int result)
    {
        if (!isSelected)
        {
            selectionDieImage.sprite = RollManager.Instance.diceGraphics[index].onSprite;
            button.interactable = true;
            resultDieImage.sprite = RollManager.Instance.diceGraphics[result].onSprite;
            this.result = result;
        }
    }

    public void Disable()
    {
        selectionDieImage.sprite = RollManager.Instance.diceGraphics[index].offSprite;
        button.interactable = false;
        resultDieImage.sprite = RollManager.Instance.emptyDieGraphic;
    }

    public void OnSelect()
    {
        StatManager.Instance.EditStat(index, result);
        selectionDieImage.sprite = null;
        button.interactable = false;
        isSelected = true;
    }

    public void OnReset()
    {
        
    }
}
