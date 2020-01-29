using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //rbObs라는 Rigidbody2D를 선언
    private Rigidbody2D rbObs;

    //cactusCollider라는 BoxCollider2D를 선언
    private BoxCollider2D cactusCollider;

    // Start is called before the first frame update
    private void Start()
    {
        //이 스크립트에 걸려 있는 오브젝트의 Rigidbody2D를 rbObs로 저장
        rbObs = GetComponent<Rigidbody2D>();
        //rbObs의 속성에서 velocity에 x방향 속도는 'GameControl'스크립의 인스터스에서 생성하는 scrollSpeed로, y방향 속도는 0으로
        rbObs.velocity = new Vector2(GameControl.instance.scrollSpeed, 0.0f);
        //이 스크립트에 걸려 있는 오브젝트의 BoxCollider2D를 cactusCollider로 저장
        cactusCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //만약 'GameControl' 스크립의 인스턴스에서 생성하는 gameOver가 true라면 (Game Over임을 인식하면)
        if (GameControl.instance.gameOver == true)
        {
            //rbObs 속성에서 velocity에 0,0d의 속도로 저장
            rbObs.velocity = Vector2.zero;
        }
    }
}