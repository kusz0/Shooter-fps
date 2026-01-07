using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void Update()
    {
    
    }
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Die();
    }
    public void Die()
    {
        if(currentHealth <= 0 )
        {
            Destroy(gameObject); 
        }
    }

}
