using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    [Header("随机移动位置")]
    [SerializeField]
    Transform[] tran;
    public  Vector3 getPoint()
    {
        int i = Random.Range(0, 14);
        return tran[i].position;
    }
}
