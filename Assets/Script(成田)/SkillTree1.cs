using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillId
{
    None,
    heal,
    attack,
    buff
}
public class SkillTree1 : MonoBehaviour
{
    [SerializeField]
    SkillTree1 _parent = null;//���B

    List<SkillTree1> childs = new List<SkillTree1>();//�������g�̉��ɕt���Ă���q������
    [SerializeField, SerializeReference, SubclassSelector]
    ISkill skill = null;//�ŏ����玝���Ă����B
    bool kaihou = false;

    public SkillTree1 Parent { get => _parent; set => _parent = value; }
    public List<SkillTree1> Childs { get => childs; set => childs = value; }

    // Start is called before the first frame update
    void Start()
    {
        ChildAdd(this);//�e���Z�b�g����Ă�����q���Ƃ��Đe��List�ɒǉ�����B
    }

    public void SkillPointJudge(float skillpoint,int arraynumber)//�|�C���g������Ă��邩�Askill�̔z�񏇔�
    {
    }

    public void ChildAdd(SkillTree1 child)
    {
        if(_parent)
        {
            _parent.Childs.Add(child);
        }
    }

    public void AllOpen()//��������̃X�L����S�Ďg����悤�ɂ���
    {
        kaihou = true;
        if(_parent)
        {
            _parent.AllOpen();
        }
    }
    public virtual void Action() { }
}
