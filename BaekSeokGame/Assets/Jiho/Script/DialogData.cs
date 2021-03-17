using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData : MonoBehaviour
{

    Dictionary<int, string[]> dialogData;
        void Start()
    {
        dialogData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        dialogData.Add(1000, new string[] { "어서오시게, 이 세계에...",
                                            "내가 누구냐고? 하하! 성미가 급한 친구구만.", 
                                            "이 세계에서 여행을 하다보면 언젠간 알게 되겠지."});
        dialogData.Add(1100, new string[] {  "당신인가. Q의 의지를 잇는 자가...",
                                            "이 세계를 바꿔주게...신들은 인계에 직접 관여를 할 수 없기에..."});
    }

    public string GetDialog(int id,int idx)
    {
        if (idx >= dialogData[id].Length)
        {
            return null;
        }
        else
        {
            return dialogData[id][idx];
        }
    }

    
}
