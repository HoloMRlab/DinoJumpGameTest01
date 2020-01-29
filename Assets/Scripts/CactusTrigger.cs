using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //다른 Collider2D오브젝트가 이 오브젝트의 Collider로 들어갈 때의 Trigger기능을 해주는 메서드(발동시킨다)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //만약 다른 오브젝트가 MoveControl이라는 스크립을 가지고 있다면
        if (other.GetComponent<MoveControl>())
        {
            //GameControl 스크립의 인스턴스에서 생성하는 TrexScored 메서드를 실행한다.
            GameControl.instance.TrexScrored();
        }
    }
}