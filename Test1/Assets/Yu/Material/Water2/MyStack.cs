/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/X/X
*作用：    未知
*描述：    未知
*
***********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStack : MonoBehaviour
{
    public static MyStack Instance;
    public RipperPostEffect[] r=new RipperPostEffect[6];
    private void Awake()
    {
        Instance = this;
        for(int j=0;j<6;j++)
        {
           // Debug.Log{ r[i]}
            r[j]= gameObject.AddComponent<RipperPostEffect>();
        }
    }
    public void Destroy(RipperPostEffect obj)
    {
        foreach(var item in r)
        {
            if(item==obj)
            {
                Destroy(item);
            }
        }  
    }
    int i = -1;
    public RipperPostEffect GetObject(Transform father)
    {      
        i = ++i > 5 ? 0 : i;
        if (r[i] !=null)
            r[i].Del();
        r[i] = gameObject.AddComponent<RipperPostEffect>();
        r[i].enabled = true;
        r[i].time = 0;
       // r[i].distanceFactor = 60;
       
        return r[i];
    }
}
