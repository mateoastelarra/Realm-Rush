using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] Slider HealthUI;

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
        UpdateHealthUI();
    }

    private void Update()
    {
        HealthUI.transform.rotation = Quaternion.Euler(180, 0 , 0);   
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
            UpdateHealthUI();
            if (currentHP <= 0)
            {
                enemy.RewardGold();
                maxHP += difficultyRamp;
                gameObject.SetActive(false);
            }
        }
    }

    void UpdateHealthUI()
    {
        HealthUI.value = (currentHP * 1.0f) / maxHP ;
    }
}
