using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] UIManager uIManager;
    [SerializeField] TextMeshProUGUI goldUI;
    [SerializeField] TextMeshProUGUI goldChangesUI;

    int currentBalance;
    public int CurrentBalance { get => currentBalance;}

    private void Awake()
    {
        currentBalance = startingBalance;
        uIManager.DisplayCurrentBalance(startingBalance);
        //DisplayCurrentBalance();
    }


    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        uIManager.DisplayGoldChangesUI(Mathf.Abs(amount));
        uIManager.DisplayCurrentBalance(currentBalance);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        uIManager.DisplayGoldChangesUI(-Mathf.Abs(amount));
        uIManager.DisplayCurrentBalance(currentBalance);

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void DisplayCurrentBalance()
    {
        goldUI.text = "Gold: " + currentBalance;
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
