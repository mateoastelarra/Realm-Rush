using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;

    [Tooltip("Ads amount to maxHP when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHP = 0;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHP = maxHP;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    void ProcessHit(GameObject other)
    {
        if (other.transform.tag == "Projectiles")
        {
            currentHP--;
            if (currentHP <= 0)
            {
                enemy.RewardGold();
                maxHP += difficultyRamp;
                gameObject.SetActive(false);
            }
        }
    }
}
