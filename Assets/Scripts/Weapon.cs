using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
        int i = 1;


    void Update()
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
    
    }
}
