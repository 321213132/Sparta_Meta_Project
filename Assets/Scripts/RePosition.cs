using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {    
        //�±װ� Area�ƴϸ� ��ȯ
        if (!collision.CompareTag("Area"))
            return;
        
        //Ʈ���Ű� ������ ������ 60ĭ�Ű� ��������
        transform.Translate(Vector2.right * 60);
    }
}
