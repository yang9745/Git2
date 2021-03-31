/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/X/X
*作用：    未知
*描述：    未知
*
***********************************/
//点击鼠标产生波纹
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRipper : MonoBehaviour
{
    public Camera mainCamera;
    public Shader shader;
    public RipperPostEffect components;
    float t = 0;
    Vector2 v2=Vector2.zero;
    Vector2 v3 = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //主摄像机添加屏幕后处理脚本
        //    mainCamera.gameObject.AddComponent<RipperPostEffect>();
        //    RipperPostEffect[] components = mainCamera.gameObject.GetComponents<RipperPostEffect>();
        //    //指定shader
        //    components[components.Length - 1].shader = shader;
        //    //设置鼠标位置在（0，1）区间
        //    components[components.Length - 1].startPos = new Vector4(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0, 0);
        //}
        t += Time.deltaTime;
        if (t < 0.13f)
            return;
        t = 0;
        if (Input.GetMouseButton(0))
        {
            v3 =  (Vector2)Input.mousePosition-v2;
            v2 = Input.mousePosition;
           RipperPostEffect r= MyStack.Instance.GetObject( transform);
           
            r.shader = shader;
            r.vector4 = new Vector4( v3.x,v3.y,0,0);
           // Debug.Log(v3);
            r.startPos = new Vector4(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0, 0);
            //主摄像机添加屏幕后处理脚本
            //mainCamera.gameObject.AddComponent<RipperPostEffect>();
            // components = mainCamera.gameObject.GetComponents<RipperPostEffect>();
            //指定shader
          //  components[id].shader = shader;
           
            //设置鼠标位置在（0，1）区间
          //  components[id].startPos = new Vector4(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0, 0);
        }
    }
  
}
