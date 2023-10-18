using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 20;


    public bool BuildTower(Vector3 position)
    {
        Bank bank;
        bank = FindAnyObjectByType<Bank>();

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
}
