using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;




[System.Serializable]
public class MyTextData
{
    public int id;
    public int status;
    public int[] emotion;
    public string[] script;

}
[System.Serializable]
public class MyTextDataArray
{
    public MyTextData[] data;
}
public class DialogData : MonoBehaviour
{
    public int chapterNo;
    TextAsset npcTextData;
    Dictionary<int, Sprite> portraitData;
    MyTextDataArray npcText;
    TextAsset playerTextData;
    MyTextDataArray playerText;
    public Sprite[] portraits;
    void Start()
    {
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }
    void GenerateData()
    {
        npcTextData = Resources.Load("npcScript") as TextAsset;
        npcText = JsonUtility.FromJson<MyTextDataArray>(npcTextData.ToString());
        playerTextData = Resources.Load("playerScript") as TextAsset;
        playerText = JsonUtility.FromJson<MyTextDataArray>(playerTextData.ToString());
        portraitData.Add(0 + 0, portraits[0]);
        portraitData.Add(0+1, portraits[1]);
        portraitData.Add(1000 + 0, portraits[1]);
        portraitData.Add(1000 + 1, portraits[0]);
        portraitData.Add(1100 + 0, portraits[0]);
        portraitData.Add(1100 + 1, portraits[1]);

    }

    public string GetNpcDialog(int id, int idx)
    {
        int findIndex = Array.FindIndex(npcText.data, i => i.id == id&&i.status==chapterNo);
        if (idx >= npcText.data[findIndex].script.Length)
        {
            return null;
        }
        else
        {
            return npcText.data[findIndex].script[idx];
        }
        
    }

    public Sprite GetNpcPortrait(int id, int idx)
    {
        int findIndex = Array.FindIndex(npcText.data, i => i.id == id&& i.status == chapterNo);
        int emotionIdx = npcText.data[findIndex].emotion[idx];
      
        return portraitData[id + emotionIdx];
    }
    public string GetPlayerDialog(int id, int idx)
    {
        int findIndex = Array.FindIndex(playerText.data, i => i.id == id&& i.status == chapterNo);
        if (idx >= playerText.data[findIndex].script.Length)
        {
            return null;
        }
        else
        {
            return playerText.data[findIndex].script[idx];
        }

    }

    public Sprite GetPlayerPortrait(int id, int idx)
    {
        int findIndex = Array.FindIndex(playerText.data, i => i.id == id&& i.status == chapterNo);
        int emotionIdx = playerText.data[findIndex].emotion[idx];

      

        return portraitData[0 + emotionIdx];
    }


}

//public class DialogData : MonoBehaviour
//{
//    Dictionary<int, Sprite> portraitData;
//    Dictionary<int, string[]> dialogData;
//    public Sprite[] portraits;
//        void Start()
//    {
//        dialogData = new Dictionary<int, string[]>();
//        portraitData = new Dictionary<int, Sprite>();
//        GenerateData();
//    }
//    void GenerateData()
//    {
//        dialogData.Add(1000, new string[] { "어서오시게, 이 세 계에...:0",
//                                            "내가 누구냐고? 하하! 성미가 급한 친구구만.:1", 
//                                            "이 세계에서 여행을 하다보면 언젠간 알게 되겠지.:0"});
//        dialogData.Add(1100, new string[] { "당신인가. Q의 의지를 잇는 자가...:0",
//                                            "이 세계를 바꿔주게...신들은 인계에 직접 관여를 할 수 없기에...:1"});
//        portraitData.Add(1000 + 0, portraits[0]);
//        portraitData.Add(1000 + 1, portraits[1]);
//        portraitData.Add(1100 + 0, portraits[0]);
//        portraitData.Add(1100 + 1, portraits[1]);

//    }

//    public string GetDialog(int id,int idx)
//    {
//        if (idx >= dialogData[id].Length)
//        {
//            return null;
//        }
//        else
//        {
//            return dialogData[id][idx];
//        }
//    }
//    public Sprite GetPortrait(int id, int idx)
//    {
//        return portraitData[id+idx];
//    }


//}
