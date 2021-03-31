/*****************************
 * 
 * 鱼基类
 * 
 * ****************************/
using System.Collections;
using System.Collections.Generic;
using TouchScript.Behaviors.Cursors;
using UnityEngine;
namespace TouchScript
{
    public class CameraController : MonoBehaviour
    {
        public CursorManager cursor;
        public Material material;
        bool b = false;
        bool b2 = false;
        private void Awake()
        {
            
        }
        private void Update()
        {
            if(Input.anyKeyDown&&!Input.GetMouseButtonDown(0))
            {
                b = !b;
                if (b)
                {
                    cursor.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                   
                }
                else
                {
                    cursor.gameObject.transform.GetChild(0).gameObject.SetActive(false);                 
                    cursor.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
               
            }
            if(Input.GetMouseButtonDown(1))
            {
                if (b)              
                    material.color = new Color(0, 0, 0, 1);
              else
                    material.color = new Color(1, 1, 1, 0);
            }
        }
        public void GetRay(Vector2 v2)
        {
            // Camera.main.

            Ray ray = Camera.main.ScreenPointToRay(v2);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 20);
            RaycastHit[] info;
            LayerMask mask = 1 << LayerMask.NameToLayer("Player");
            if ((info = Physics.RaycastAll(ray, 50, mask)) != null)
            {
                foreach (var item in info)
                    item.transform.gameObject.GetComponent<FishBase>().Going(item.point);
            }
        }
    }
}
