using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skilltree : MonoBehaviour
{
    ///<summary>skillnumber�Ɛ�������</summary>
    [SerializeField] SkillButton[] skillButton;
    PlayerController player = null;
    int count = 0;
    /// <summary>���Ԗڂ̃X�L�����������Ă���̂����Ǘ����Ă���</summary>
    bool[] skillActive;
    /// <summary>�X�L����������邽�߂�point�A�ʏ�U���œG���U�������ꍇ���߂�</summary>
    private float skillpoint = 0f;
    public SkillButton[] SkillButton { get => skillButton; set => skillButton = value; }
    public bool[] SkillActive { get => skillActive; set => skillActive = value; }
    public float Skillpoint { get => skillpoint; set => skillpoint = value; }
    public PlayerController Player { get => player;}

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        skillActive = new bool[skillButton.Length];
        for (int i = 0; i < skillButton.Length; i++)
        {
            skillButton[i].Skillnumber = i+1;
            skillButton[i].SkillId = (SkillId)i+1;
            skillActive[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SkillJudge(int num)
    {
        if(2 < num)//skillButton[3]�ȏゾ������
        {
            for(int i = 0; i < num; i++)
            {
                if (skillButton[i].Skillcheck)
                {
                    count++;
                }
            }
            if(2 <= count)
            {//�������Ă��邩�m�F
                skillButton[num].Skillcheck = true;
                skillActive[num] = true;
            }
        }
        else
        {//�������Ă��邩�m�F
            skillButton[num].Skillcheck = true;
            skillActive[num] = true;
        }
        skillButton[num].Yobidasi();
    }
    public virtual void SkillAction(){}
}
