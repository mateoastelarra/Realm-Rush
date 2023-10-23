using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 20;
    [SerializeField] float buildTime = 3f;
    [SerializeField] GameObject[] towerParts;

    private void OnEnable()
    {
        StartCoroutine(ActivateTower());
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

    IEnumerator ActivateTower()
    {
        foreach (GameObject towerPart in towerParts)
        {
            towerPart.SetActive(true);

            yield return new WaitForSeconds(buildTime / towerParts.Length);
        }
    }
}
