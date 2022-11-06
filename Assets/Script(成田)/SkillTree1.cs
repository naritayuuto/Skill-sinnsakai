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

    List<SkillTree1> _childs = new List<SkillTree1>();//�������g�̉��ɕt���Ă���q������
    [SerializeField, SerializeReference, SubclassSelector]
    ISkill _skill = null;//�ŏ����玝���Ă����B
    PlayerController player = null;
    bool kaihou = false;

    public SkillTree1 Parent { get => _parent; set => _parent = value; }
    public List<SkillTree1> Childs { get => _childs; set => _childs = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ChildAdd(this);//�e���Z�b�g����Ă�����q���Ƃ��Đe��List�ɒǉ�����B
    }

    public void SkillPointJudge(float skillpoint,int arraynumber)//�|�C���g������Ă��邩�Askill�̔z�񏇔�
    {
    }

    public void SkillAdd()
    {
        player.AddSkill(_skill);
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
}
