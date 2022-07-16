using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollUI : MonoBehaviour
{
    [SerializeField] private GameObject statSelectionPrefab;
    [SerializeField] private Transform statSelectionsParentPanel;
    [SerializeField] private Image[] rolledDiceImages;
    [SerializeField] public Sprite[] diceFaces;
    [SerializeField] public Sprite emptyDie;
    [SerializeField] public Color darkColor, lightColor, redColor, greenColor;

    private List<StatSelectionUI> statSelections = new List<StatSelectionUI>();

    private void Start()
    {
        foreach (Transform tempChild in statSelectionsParentPanel.GetComponentInChildren<Transform>())
        {
            Destroy(tempChild.gameObject);
        }

        for (int i = 0; i < 6; i++)
        {
            StatSelectionUI selectionUI = Instantiate(statSelectionPrefab, statSelectionsParentPanel).GetComponent<StatSelectionUI>();
            statSelections.Add(selectionUI);
            selectionUI.InitSelection(i, this);

        }
    }

    public void OnRoll()
    {
        RollManager.Instance.RollDice();

        // TODO animate dice rolling

        List<int> diceResults = RollManager.Instance.GetDiceResults();

        for (int i = 0; i < rolledDiceImages.Length; i++)
        {
            rolledDiceImages[i].sprite = diceFaces[diceResults[i]];
        }

        // Highlight applicable selections
        for (int i = 0; i < statSelections.Count; i++)
        {
            if (i == diceResults[0])
            {
                statSelections[i].Highlight(diceResults[1]);
            }
            else if (i == diceResults[1])
            {
                statSelections[i].Highlight(diceResults[0]);
            }
            else
            {
                statSelections[i].Disable();
            }
        }
    }
}
