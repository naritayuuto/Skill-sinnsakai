using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skilltree : MonoBehaviour
{
    ///<summary>skillnumber�Ɛ�������</summary>
    [SerializeField] SkillButton[] skillButton;//��XInstantiate���āA�������ꍇ�Ɏg�����\�b�h�����߂�B�z�u�Ȃǂ͂܂�����B
    GameObject player = null;
    PlayerController playerStatus = null;
    Playerhp playerhp = null;
    [SerializeField]
    Image[] skillLine;
    List<Skilltree> childs = new List<Skilltree>();//�������g�B����Skilltree�������Ă���X�L���B
    [SerializeField, SerializeReference, SubclassSelector]
    ISkill skill;//�ŏ����玝���Ă����B

    Skilltree parent;//���B
    ///<summary>heal�X�L���̐�</summary>
    private int healcount = 1;
    ///<summary>attack�X�L���̐�</summary>
    private int attackcount = 2;
    ///<summary>buff�X�L���̐�</summary>
    private int buffcount = 3;
    //int count = 0;
    /// <summary>�ǂ̃X�L�����������Ă���̂����Ǘ����Ă���</summary>
    bool[] skillActive;
    /// <summary>�X�L����������邽�߂�point�A�ʏ�U���œG���U�������ꍇ���߂�</summary>
    private float skillpoint = 0f;
    public SkillButton[] SkillButton { get => skillButton; set => skillButton = value; }
    public bool[] SkillActive { get => skillActive; set => skillActive = value; }
    public float Skillpoint { get => skillpoint; set => skillpoint = value; }
    public PlayerController PlayerStatus { get => playerStatus; set => playerStatus = value; }
    public Playerhp Playerhp { get => playerhp; set => playerhp = value; }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerController>();
        playerhp = player.GetComponent<Playerhp>();
        skillActive = new bool[skillButton.Length];
        for (int i = 0; i < skillButton.Length; i++)
        {
            //if (i < healcount)//heal�̃X�L��
            //{
            //    skillButton[i].Skillnumber = i + 1;
            //    skillButton[i].SkillId = SkillId.heal;
            //}
            //else if(i < attackcount + healcount)//attack�̃X�L��
            //{
            //    skillButton[i].Skillnumber = i - healcount + 1;
            //    skillButton[i].SkillId = SkillId.attack;
            //}
            //else//buff�̃X�L��
            //{
            //    skillButton[i].Skillnumber = i - attackcount;
            //    skillButton[i].SkillId = SkillId.buff;
            //}
            //skillButton[i].Skillpoint += 2 * skillButton[i].Skillnumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SkillPointJudge(float skillpoint, int skillnumber, int skillid)
    {
        if (Skillpoint < skillpoint)
        {
            return;
        }
        else
        {
            SkillOnOffJudge(skillnumber, skillid);
        }
    }
    public void SkillOnOffJudge(int skillnumber, int skillid)
    {
        //if ((SkillId)skillid == SkillId.heal)
        //{
        //    if (skillnumber == 1)
        //    {
        //        skillButton[skillnumber - 1].Skillcheck = true;
        //        skillActive[skillnumber - 1] = true;
        //    }
        //    else if (skillButton[skillnumber - 2].Skillcheck)
        //    {
        //        skillButton[skillnumber - 1].Skillcheck = true;
        //        skillActive[skillnumber - 1] = true;
        //    }
        //    skillButton[skillnumber - 1].Yobidasi();
        //}
        //else if ((SkillId)skillid == SkillId.attack)
        //{
        //    if (skillnumber == 1)
        //    {
        //        skillButton[skillnumber + healcount -1].Skillcheck = true;
        //        skillActive[skillnumber + healcount -1] = true;
        //    }
        //    else if(skillButton[skillnumber + healcount - 2].Skillcheck)
        //    {
        //        skillButton[skillnumber + healcount -1].Skillcheck = true;
        //        skillActive[skillnumber + healcount -1] = true;
        //    }
        //    skillButton[skillnumber + healcount -1].Yobidasi();
        //}
        //else if ((SkillId)skillid == SkillId.buff)
        //{
        //    if (skillnumber == 1)
        //    {
        //        skillButton[skillnumber + attackcount + healcount -1].Skillcheck = true;
        //        skillActive[skillnumber + attackcount + healcount - 1] = true;
        //    }
        //    else if (skillButton[skillnumber + attackcount + healcount - 2].Skillcheck)
        //    {
        //        skillButton[skillnumber + attackcount + healcount - 1].Skillcheck = true;
        //        skillActive[skillnumber + attackcount + healcount - 1] = true;
        //    }
        //    skillButton[skillnumber + attackcount].Yobidasi();
        //}
        //if(2 < num)//skillButton[3]�ȏゾ������
        //{
        //    for(int i = 0; i < num; i++)
        //    {
        //        if (skillButton[i].Skillcheck)
        //        {
        //            count++;
        //        }
        //    }
        //    if(2 <= count)
        //    {//�������Ă��邩�m�F
        //        skillButton[num].Skillcheck = true;
        //        skillActive[num] = true;
        //    }
        //}
        //else
        //{//�������Ă��邩�m�F
        //    skillButton[num].Skillcheck = true;
        //    skillActive[num] = true;
        //}
        //skillButton[num].Yobidasi();
    }
    public virtual void SkillAction(){}//�㏑���p���\�b�h
}
