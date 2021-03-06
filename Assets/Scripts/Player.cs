using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;

    Vector2 velocity;
    Animator animator;
    bool isVertical;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // 대각선 움직임 제한 && 캐릭터 움직임 애니메이션 트리거
        if (Input.GetButtonDown("Vertical") || Input.GetButtonUp("Horizontal")) {
            isVertical = true;
            animator.SetTrigger("Change");
        }
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Vertical")) {
            isVertical = false;
            animator.SetTrigger("Change");
        }

        // 캐릭터 속도 지정 && 캐릭터 움직임 애니메이션 방향 지정
        if (isVertical) {
            velocity = new Vector2(0, Input.GetAxisRaw("Vertical") * speed);
            animator.SetInteger("vAxisRaw", (int)Input.GetAxisRaw("Vertical"));
            animator.SetInteger("hAxisRaw", 0);
        }
        else { 
            velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
            animator.SetInteger("vAxisRaw", 0);
            animator.SetInteger("hAxisRaw", (int)Input.GetAxisRaw("Horizontal"));
        }

        // 캐릭터 움직이기
        rigid.velocity = velocity;
    }
}
