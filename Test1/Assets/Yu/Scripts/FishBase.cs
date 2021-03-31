using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
public enum AnimatorSwitching
{
    Idle=0,
    Run=1,
}

public class FishBase : MonoBehaviour
{
    
    protected Animator animation;
    [Header("默认速度")]
    public float IdleSpeed=2;
    [Header("逃跑速度")]
    public float RunSpeed=4;
    [Header("当前速度")]
    float Speed=2;
    [Header("转向速度")]
    float RotateSpeed=3;
    [Header("移动位置")]
    protected Quaternion TargetRota;
  
    [Range(4,9)]
    [Header("延迟时间")]
    public float delayTime = 7;
    [Range(4, 9)]
    [Header("周期时间")]
    public float CycleTime = 8;
    private void Start()
    {
        animation = GetComponent<Animator>();
        InvokeRepeating("Idle", delayTime, CycleTime);
    }
    //奔跑
    public virtual void Going(Vector3 v2)
    {
        Debug.Log("Go");    
        //计算     自身指向  目标 的  目标向量；
        Vector3 target = new Vector3(v2.x, transform.position.y, v2.z);
        Vector3 diction = (  transform.position- target).normalized;
        //自身前方  指向 目标向量  的四元数
        TargetRota = Quaternion.FromToRotation(transform.forward, diction);

        animation.SetInteger("Run", 1);
        Speed = RunSpeed;
        Invoke("ChangeRun", 1.5f);
    }
    //停止奔跑
    private void ChangeRun()
    {
        Speed = IdleSpeed;
        animation.SetInteger("Run", 0);       
    }

    public Transform Rotate1;
    private void Update()
    {
        
        if (Mathf.Abs(transform.position.x) > 13 || transform.position.z > 2 || transform.position.z < -21)
        {
            //计算     自身指向  目标 的  目标向量；
            Rotate1.position = new Vector3(Rotate1.position.x, transform.position.y, Rotate1.position.z);
            Vector3 diction = ( Rotate1.position - transform.position).normalized;
            //Debug.DrawLine(Rotate1.position, transform.position,Color.red);
            //自身前方  指向 目标向量  的四元数
            Quaternion q = Quaternion.FromToRotation(transform.forward,diction);
            TargetRota = Quaternion.identity;
            transform.rotation *=q;
        }
        if(TargetRota!=Quaternion.identity)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRota, RotateSpeed * Time.deltaTime);
        }
        //鱼儿向前 游动
        transform.position += transform.forward*Speed* Time.deltaTime;
          
    }
    private void Idle()
    {       
        int x = Random.Range(-179, 179);    
        TargetRota = Quaternion.Euler(0, x,0);
        //transform.rotation *= TargetRota;
    }
}
