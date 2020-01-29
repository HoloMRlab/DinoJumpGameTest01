using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    //rb2D라는 Rigidbody2D를 선언
    private Rigidbody2D rb2D;

    //배경을 충돌처리(이벤트처리?)하도록 BoxCollider2D로 데이터 선언
    private BoxCollider2D groundCollider;

    //배경의 길이 선언
    private float groundLength;

    // Start is called before the first frame update
    //첫 업데이트 시,
    private void Start()
    {
        //이 스크립트에 걸려 있는 오브젝트의 Rigidbody2D를 rb2D로 저장
        rb2D = GetComponent<Rigidbody2D>();
        //rb2D의 velocity속성 (속도 값)을 지정함. 그 속도 값은 x축으로 GameControl스크립트에서 만들어 내는 instance(객체)의 scrollSpeed값으로 움직이고, y축으로는 움직이지 않음.
        rb2D.velocity = new Vector2(GameControl.instance.scrollSpeed, 0.0f);
        // 이 스크립트에 걸려 있는 오브젝트의 BoxCollider2D는 groundCollider로 저장
        groundCollider = GetComponent<BoxCollider2D>();
        //이 스크립에 걸려 있는 BoxCollider형태로 정의된 오브젝트의 x축선상의 크기는 groundLength로 저장
        groundLength = groundCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        //만약 GameControl 스크립트에서 만들어내는 instance(객체)의 gameOver boolean변수가 true이면 (GameControl 스크립내에서 게임이 종료되는 것을 알게 되면)
        if (GameControl.instance.gameOver == true)
        {
            //rb2D의 velocity 속성 (속도 값)을 0으로 만들어 버린다.
            rb2D.velocity = Vector2.zero;
        }

        //만약 현재 x축 위치가 오른쪽으로 groundLength만큼 이동해 있다면,
        if (transform.position.x < -groundLength)
        {
            //RepostionGround에서 정의한 대로 배경을 다시 위치시킬 것
            RepositionGround();
        }
    }

    //배경을 다시 위치 시키는 메서드
    private void RepositionGround()
    {
        //groundOffset의 크기값 (==groundLength의 두배==배경 너비의 두배)
        Vector2 groundOffset = new Vector2(groundLength * 2.0f, 0);
        //위치 이동은 현 위치에서 gorundOffest을 더한 값(?)
        transform.position = (Vector2)transform.position + groundOffset;
    }
}