using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillId
{
    heal = 1,
    attack,
    buff
}
public class SkillTree1 : MonoBehaviour
{
    SkillManager skillManager = null;//skillpoint���g�����߁B

    Skilltree parent;//���B

    List<SkillTree1> childs = new List<SkillTree1>();//�������g�B����Skilltree�������Ă���X�L���B

    [SerializeField, SerializeReference, SubclassSelector]
    ISkill skill;//�ŏ����玝���Ă����B

    // Start is called before the first frame update
    void Start()
    {
        skillManager = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
    }

    public void SkillPointJudge(float skillpoint,int arraynumber)//�|�C���g������Ă��邩�Askill�̔z�񏇔�
    {
        if (skillManager.SkillPoint < skillpoint)
        {
            return;
        }
        else
        {
            skillManager.Buttons[arraynumber].Yobidasi(skill);
        }
    }

    public virtual void SkillAction() { }
}
