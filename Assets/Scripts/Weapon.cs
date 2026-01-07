using StarterAssets;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
       starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    int i = 1;


    void Update()
    {

        if (starterAssetsInputs.shoot)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity))
            {
                Debug.Log(hit.collider.name +  i);
                i++;
            }else 
            {
                Debug.Log($"Its null {i}");
            }
            starterAssetsInputs.ShootInput(false);
        }


    }
}
