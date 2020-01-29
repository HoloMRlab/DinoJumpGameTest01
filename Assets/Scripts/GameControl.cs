using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // making the variable 'static' associated with this class 'GameControl', and allowing to be accessible from any scripts
    public static GameControl instance;

    //gameOverText라는 Game Object를 인스펙터 창에 드래그 앤 드롭하기.
    public GameObject gameOverText;

    //게임을 종료하는 건지 아닌지 확인시켜주는 boolean 데이터 gameOver
    public bool gameOver = false;

    //인스펙터창에 'T-Rex Ground'의 움직임 속도. 인스펙터창에 수정 가능, 'ScrollingOject'라는 스크립트 내에서 scrollSpeed의 데이터 값을 받아서 'T-Rex Ground'를 움직이게 함.
    public float scrollSpeed = -5.0f;

    public Text scoreText;
    public Text scoreFinalText;

    private float score;

    // Before to set up Start
    private void Awake()
    {
        score = 0;
        // If instance of the 'Game Conttrol' starts out...it's gonna look around...and another 'Game Control' around??...Nope--> OK, I'm in Charge.
        if (instance == null) //If there is no 'Game Control' found (everythig is fine),
        {
            instance = this; //this is the 'Game Control'
        }
        // If there is, however,... Ok, I'm not needed...then destroy itself...
        else if (instance != null) //However, if instance exists but not this one,
        {
            Destroy(gameObject); //Destory the 'gameObect'which this script is attached to
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //게임이 종료되고 (gameOver==true), 사용자가 Enter를 누른다면...
        if (gameOver == true && Input.GetKey(KeyCode.Return))
        {
            //다시 현재 Scene을 로드해준다.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //점수를 계산해 주는 메서드
    public void TrexScrored()
    {
        //만약 gameOver가 true라면 (게임이 종료되면)
        if (gameOver == true)
        {
            //다시 돌아간다(?)
            return;
        }
        //점수를 1만큼 증가
        score++;
        //scoreText라는 Text UI오브젝트 내의 text를 "Score: 몇점"으로 저장
        scoreText.text = "Score: " + score.ToString();
        scoreFinalText.text = "Your Score: " + score.ToString();
    }

    public void TrexDied() //public 'TrexDied' function of the 'Game Control' 'Game Control' 클래스의 퍼블릭 'TrexDied'메소드
    {
        gameOverText.SetActive(true); //gameOverText라는 Game Object를 활성화 시켜라.
        gameOver = true; //게임 종료
    }
}