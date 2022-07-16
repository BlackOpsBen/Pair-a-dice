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
    [SerializeField] private RollUI rollUI;
    private int index = 0;
    private int result = 0;
    private bool isSelected = false;

    public void InitSelection(int index, RollUI rollUI)
    {
        this.rollUI = rollUI;

        selectionDieImage.sprite = rollUI.diceFaces[index];
        selectionDieImage.color = rollUI.darkColor;
        statLabel.text = StatManager.Instance.stats[index];
        resultDieImage.sprite = rollUI.emptyDie;
        resultDieImage.color = rollUI.darkColor;
        this.index = index;
    }

    public void Highlight(int result)
    {
        if (!isSelected)
        {
            selectionDieImage.color = rollUI.lightColor;
            button.interactable = true;
            resultDieImage.sprite = rollUI.diceFaces[result];
            resultDieImage.color = rollUI.lightColor;
            this.result = result;
        }
    }

    public void Disable()
    {
        if (!isSelected)
        {
            selectionDieImage.color = rollUI.darkColor;
            button.interactable = false;
            resultDieImage.sprite = rollUI.emptyDie;
            resultDieImage.color = rollUI.darkColor;
        }
    }

    public void OnSelect()
    {
        StatManager.Instance.EditStat(index, result);
        selectionDieImage.color = rollUI.redColor;
        resultDieImage.color = rollUI.greenColor;
        button.interactable = false;
        isSelected = true;
    }

    public void OnReset()
    {
        
    }
}
