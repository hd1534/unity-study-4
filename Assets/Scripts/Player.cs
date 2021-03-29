using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;

    Vector2 velocity;
    bool isVertical;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 대각선 움직임 제한
        if (Input.GetButtonDown("Vertical") || Input.GetButtonUp("Horizontal"))
            isVertical = true;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Vertical"))
            isVertical = false;
            

        if (isVertical) 
            velocity = new Vector2(0, Input.GetAxisRaw("Vertical")* speed);
        else 
            velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);

        rigid.velocity = velocity;
    }
}
