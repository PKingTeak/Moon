using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogSystem :MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers;
    [SerializeField]
    private DialogData[] dialogs;
    [SerializeField]
    private bool isAutoStart =true;
    private bool isFirst = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;

     private void Awake() 
     {
        Setup();
        
     }

     private void Setup()
     {
        for(int i = 0; i < speakers.Length; ++ i)
        {
        SetActiveObjects(speakers[i], false);
       
        }
     }


    [System.Serializable]
    public struct Speaker // 대화 관련 UI

    {
        public Image imgaeDialog;
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textDialogue;
        public GameObject objectArrow;
    }

    [System.Serializable]
    public struct DialogData
    {
        public int SpeakerIndex;
        public string name;
        [TextArea(3,5)]
        public string dialogue;
    }

    public bool UpdateDialog()
    {
        // 대사 분기 1회만 호출
        if(isFirst == true)
        {
            Setup();
            if(isAutoStart) 
            SetNextDialog();

            isFirst = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dialogs.Length > currentDialogIndex +1)
            {
                SetNextDialog();
            }
            else
            {
                for ( int i =0; i<speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    
                }

                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        //이전 대화 관련 오브젝트 비활성
        SetActiveObjects(speakers[currentSpeakerIndex], false);
//다음대사 
        currentDialogIndex ++;
//현재 화자 순번 설정
        currentSpeakerIndex = dialogs[currentDialogIndex].SpeakerIndex;
//현재 화자의 대화 관련 오브젝트 활성
        SetActiveObjects(speakers[currentSpeakerIndex],true);
//텍스트 활성
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
//대사 텍스트 설정
        speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;


    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

    }

    


   
}
