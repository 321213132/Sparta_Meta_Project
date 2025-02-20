using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    public Sprite[] Monsters;
    int num = 1;
    int dir = 0;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dir = Random.Range(40, 50);
        num = Random.Range(0, Monsters.Length+1);
        _spriteRenderer.sprite = Monsters[num];

        //태그 확인
        if (collision.CompareTag("Obstacle"))
            return;

        
        transform.Translate(Vector2.right * dir);
        Debug.Log("chagne");
    }
}
