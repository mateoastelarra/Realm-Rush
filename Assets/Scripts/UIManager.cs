using TMPro;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldUI;
    [SerializeField] TextMeshProUGUI goldChangesUI;

    IEnumerator coroutine;

    public void DisplayCurrentBalance(int amount)
    {
        goldUI.text = "Gold: " + amount;
    }

    public void DisplayGoldChangesUI(int amount)
    {
        coroutine = DisplayGoldChanges(amount);
        StartCoroutine(coroutine);
    }

    IEnumerator DisplayGoldChanges(int amount)
    {
        if (amount > 0)
        {
            goldChangesUI.text = "+ " + amount;
            goldChangesUI.color = Color.green;
        }
        else if (amount < 0)
        {
            goldChangesUI.text = "- " + (-amount);
            goldChangesUI.color = Color.red;
        }

        goldChangesUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        goldChangesUI.gameObject.SetActive(false);
    }
}
