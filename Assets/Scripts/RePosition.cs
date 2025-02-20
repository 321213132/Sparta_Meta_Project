using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {    
        //태그가 Area아니면 반환
        if (!collision.CompareTag("Area"))
            return;
        
        //트리거가 끝날때 옆으로 60칸옮겨 연결해줌
        transform.Translate(Vector2.right * 60);
    }
}
