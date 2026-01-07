using StarterAssets;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] int damageAmount = 1;

    StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
       starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }


    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {

        if (!starterAssetsInputs.shoot)
        {
            return;
        }
        shootEffect.Play();

        RaycastHit hit;
        
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity))
        {
           EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);    
        
        }
            starterAssetsInputs.ShootInput(false);
        
    }
    

}
