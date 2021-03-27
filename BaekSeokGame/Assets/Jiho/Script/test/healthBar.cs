using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//체력바 표시를 나타내는데 쓰임
//저 함수를 실행시켜서 수치를 변경하는 것은 플레이어에 들어간 combat.cs 스크립트를 통해 함
//현재는 PlayerHealthBar에만 쓰였고, 나중에 저거 프리팹화 해서 몬스터나 기타 오브젝트에도 쓰게 해야할듯


public class healthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
