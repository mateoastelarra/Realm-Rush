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

        Vector3 startingPosition = goldChangesUI.transform.position;
        Vector3 endPosition = startingPosition + new Vector3(0, 40, 0);
        float timer = 0;

        while (timer <= 1)
        {
            goldChangesUI.transform.position = Vector3.Lerp(startingPosition, endPosition, timer);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        goldChangesUI.transform.position = startingPosition;

        goldChangesUI.gameObject.SetActive(false);
    }
}
