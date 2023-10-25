using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHP = 5;
    [SerializeField] Slider HealthUI;

    [Header("Death Animation")]
    [SerializeField] GameObject enemyMesh;
    [SerializeField] GameObject flame;
    [SerializeField] GameObject smoke;
    [SerializeField] float deathDelay = 1f;
    [SerializeField] float healthPercentageForFire = 0.3f;

    [Header("Difficulty")]
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
        HealthUI.gameObject.SetActive(true);
        enemyMesh.SetActive(true);
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
                StartCoroutine(nameof(EnemyDeath));
            }
            else if ((currentHP * 1.0f) / maxHP <= healthPercentageForFire)
            {
                flame.SetActive(true);
                smoke.SetActive(true);
            }
        }
    }

    void UpdateHealthUI()
    {
        HealthUI.value = (currentHP * 1.0f) / maxHP ;
    }

    IEnumerator EnemyDeath()
    {
        HealthUI.gameObject.SetActive(false);
        enemyMesh.SetActive(false);
        flame.SetActive(false);

        yield return new WaitForSeconds(deathDelay);

        smoke.SetActive(false);
        gameObject.SetActive(false);
    }
}
