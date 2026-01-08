using StarterAssets;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] int damageAmount = 1;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shooting";

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
        animator.Play(SHOOT_STRING,0,0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity))
        {
           VfXEffectHandle(hit);
           EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
           enemyHealth?.TakeDamage(damageAmount);    
        
        }
    }
    private void VfXEffectHandle(RaycastHit hit)
    {
        Vector3 vector3 = hit.point;

        Instantiate(hitVFXPrefab, vector3,quaternion.identity);
    }


}
