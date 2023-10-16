using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI goldUI;

    int currentBalance;
    public int CurrentBalance { get => currentBalance;}

    private void Awake()
    {
        currentBalance = startingBalance;
        DisplayCurrentBalance();
    }


    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        DisplayCurrentBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        DisplayCurrentBalance();

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
}
