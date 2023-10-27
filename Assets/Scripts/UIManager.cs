using TMPro;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldUI;
    [SerializeField] TextMeshProUGUI[] goldChangesUI;
    [SerializeField] float goldAnimationSpeed = 2f;
    [SerializeField] float goldAnimationMovement = 30f;

    int currentGoldChangesUIindex = 0;

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
        currentGoldChangesUIindex = (currentGoldChangesUIindex + 1) % goldChangesUI.Length;
        TextMeshProUGUI currentGoldChangesUI = goldChangesUI[currentGoldChangesUIindex];

        if (amount > 0)
        {
            currentGoldChangesUI.text = "+ " + amount;
            currentGoldChangesUI.color = Color.green;
        }
        else if (amount < 0)
        {
            currentGoldChangesUI.text = "- " + (-amount);
            currentGoldChangesUI.color = Color.red;
        }

        currentGoldChangesUI.gameObject.SetActive(true);

        Vector3 startingPosition = currentGoldChangesUI.transform.position;
        Vector3 endPosition = startingPosition + new Vector3(0, goldAnimationMovement, 0);
        float timer = 0;

        while (timer <= 1)
        {
            currentGoldChangesUI.transform.position = Vector3.Lerp(startingPosition, endPosition, timer);
            timer += Time.deltaTime * goldAnimationSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        currentGoldChangesUI.transform.position = startingPosition;

        currentGoldChangesUI.gameObject.SetActive(false);
    }
}
