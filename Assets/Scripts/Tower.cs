using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 20;
    [SerializeField] float buildDelay = 3f;

    private void Start()
    {
        StartCoroutine(BuildWithDelays());
    }

    public bool BuildTower(Vector3 position)
    {
        Bank bank;
        bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }
        
        if (cost <= bank.CurrentBalance)
        {
            Instantiate(gameObject, position, Quaternion.Euler(0, 0, 0));

            bank.Withdraw(cost);

            return true;
        }
        else
        {
            Debug.Log("Not enough money");

            return false;
        }
        
    }

    IEnumerator BuildWithDelays()
    {
        DeactivateTowerParts();

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(buildDelay);
            
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }

    void DeactivateTowerParts()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }
    }
}
