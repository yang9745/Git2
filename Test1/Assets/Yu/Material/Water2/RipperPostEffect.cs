/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/X/X
*作用：    未知
*描述：    未知
*
***********************************/
//水波纹屏幕后处理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipperPostEffect : PostEffectBase
{  
    /// <summary>
    /// uv到中心点向量的距离系数
    /// </summary>
    public float distanceFactor = 80.0f;
    /// <summary>
    /// 时间系数
    /// </summary>
    public float timeFactor = 1.0f;
    /// <summary>
    /// 波纹幅度系数
    /// </summary>
    public float totalFactor = 100.0f;
    /// <summary>
    /// 波纹半径限制
    /// </summary>
    public float waveWidth = 0.03f;
    /// <summary>
    /// 波纹扩散的速度
    /// </summary>
    public float waveSpeed = 0.2f;
    /// <summary>
    /// 波纹开始时间
    /// </summary>
    public float waveStartTime;
    /// <summary>
    /// 鼠标点击屏幕的位置
    /// </summary>
    public Vector4 startPos = new Vector4(0, 0, 0, 0);
    // Use this for initialization
    public float time;
    public float MaxTime=2;
    public Vector4 vector4;
    //public Color color = new Color(1, 1, 1,1);
    public Color color=new Color(0.32f,0.69f,0.69f,0.0002f);
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //计算波纹移动的距离（时间*速度）
        float curWaveDistance = (Time.time - waveStartTime) * waveSpeed;
        //设置一系列参数
        _Material.SetFloat("_distanceFactor", distanceFactor);
        _Material.SetFloat("_timeFactor", timeFactor);
        _Material.SetFloat("_totalFactor", totalFactor);
        _Material.SetFloat("_waveWidth", waveWidth);
        _Material.SetFloat("_curWaveDis", curWaveDistance);
        _Material.SetVector("_startPos", startPos);
        _Material.SetColor("_Color", color);
        vector4.x = vector4.x > 5 ? 1 : vector4.x;
        vector4.x = vector4.x < -5 ? -1 : vector4.x;
        vector4.y = vector4.y > 5 ? 1 : vector4.y;
        vector4.y = vector4.y < -5 ? -1 : vector4.y;
        _Material.SetColor("_Vect", vector4);
        //Debug.Log(vector4);
        Graphics.Blit(source, destination, _Material);

    }
    private void Awake()
    {
          //记录开始时间
        waveStartTime = Time.time;
    }
    private void Start()
    {
      
    }
    private void Update()
    {
        //自动销毁此组件
        time += Time.deltaTime;
        if (time >= MaxTime)
        {
            Destroy(this);        
        }
    }
   public void Del()
    {
        Destroy(this);
    }
}
