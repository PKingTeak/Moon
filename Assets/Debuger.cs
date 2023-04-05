using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Debuger : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem01;
    [SerializeField]
    private TextMeshProUGUI textCountdown;

    [SerializeField]
    private DialogSystem dialogSystem02;
   
   private IEnumerator Start()
   {
    
    textCountdown.gameObject.SetActive(true);
    // 첫번째 대사 분기 시작
    yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());


//대사 분기 사이에 원하는 행동을 추가할수 있음
// 캐릭터를 움직이거나 아이템을 획득하는 등의 행동을 추가할수 있음.
    textCountdown.gameObject.SetActive(true);
    int count =5;
    while (count >0)
    {
        textCountdown.text= count.ToString();
        count --;
        yield return new WaitForSeconds(1);

    }
    textCountdown.gameObject.SetActive(false);
    //1분기 대화 종료


// 2분기 대화 시작
    yield return new WaitUntil(()=>dialogSystem02.UpdateDialog());
    textCountdown.gameObject.SetActive(true);
    textCountdown.text = "The End";

    yield return new WaitForSeconds(2);
    UnityEditor.EditorApplication.ExitPlaymode();
   }
}
