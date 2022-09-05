using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillButton : MonoBehaviour
{
    int skillnumber = 0;
    bool skillcheck = false;
    public int Skillnumber { get => skillnumber; set => skillnumber = value; }
    public bool Skillcheck { get => skillcheck; set => skillcheck = value; }
    Skilltree skilltree = null;
    Button button = null;
    // Start is called before the first frame update
    void Start()
    {
        skilltree = GameObject.FindGameObjectWithTag("Skilltree").GetComponent<Skilltree>();
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCllik()
    {
        skilltree.SkillJudge(skillnumber);
    }

    public void Yobidasi()
    {
       if(skillcheck)
        {
            Debug.Log(skillnumber + "�ԖڌĂ΂�܂���");
            //player��skill�ǉ��̏���������
            button.interactable = false;
        }
       else
        {
            Debug.Log("�܂��J������Ă��܂���");
        }
    }
}
