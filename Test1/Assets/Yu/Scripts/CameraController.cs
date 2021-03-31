/*****************************
 * 
 * 鱼基类
 * 
 * ****************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    public void GetRay(Vector2 v2)
    {
        // Camera.main.
       
        Ray ray = Camera.main.ScreenPointToRay(v2);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 20);        
        RaycastHit[] info;
        LayerMask mask = 1 << LayerMask.NameToLayer("Player");
        if ((info=Physics.RaycastAll(ray,50,mask))!=null)
        {
            foreach(var item in info)
               item.transform.gameObject.GetComponent<FishBase>().Going(item.point);
        }
    }
}
