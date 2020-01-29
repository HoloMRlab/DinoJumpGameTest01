using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    //속도 부분을 인스펙터에서 조절.
    public float jumpSpeed = 1.0f;

    //isDead==공룡이 죽을 때와 아닐 때 나눠서 처리
    private bool isDead = false;

    // 게임오브젝트(==공룡)에 대한 물리 처리를 위해 Rigidbody 데이터 선언
    private Rigidbody2D rb;

    // 게임 오브젝트(==공룡)에 대한 애니메이션 처리를 위해 Animator 데이터 선언
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        //이 스크립에 걸려 있는 오브젝트의 Rigidbody를 rb로 저장
        rb = GetComponent<Rigidbody2D>();
        //이 스크립에 걸려 있는 오브젝트의 Animator를 anim으로 저장
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // isDead가 활성화 되면 (공룡이 죽는다면),
        if (isDead == false)
        {
            //애니메이터  anim을 "Run"으로 활성화
            anim.SetTrigger("Run");
            //Space Bar를 누른다면 (==1이라면),
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(0.0f, jumpSpeed * 25.0f); //Rigidbody: Mass=1; Gravity=10;
            }
        }
    }

    //충돌처리 메서드
    private void OnCollisionEnter2D(Collision2D other)
    {
        //"Cactus"로 태그 되어 있는 것(==선인장)과 충돌한다면,
        if (other.gameObject.CompareTag("Cactus"))
        {
            //공룡의 속도는 멈추고,
            rb.velocity = Vector2.zero;
            //isDead 활성화 (공룡은 죽는다).
            isDead = true;
            //애니메이터 anim을 "Die'로 활성화
            anim.SetTrigger("Die");
            //'GameControl'스크립의 인스턴스가 생성하는 TrexDied의 메서드 실행
            GameControl.instance.TrexDied(); //Becomes to access to variable or to call a function of the 'Game Control' from other class.
        }
    }
}