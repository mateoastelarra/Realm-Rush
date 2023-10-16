using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 5;
    private int currentHP = 0;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        if (other.transform.tag == "Projectiles")
        {
            currentHP--;
            if (currentHP <= 0)
            {
                enemy.RewardGold();
                gameObject.SetActive(false);
            }
        }
    }
}
