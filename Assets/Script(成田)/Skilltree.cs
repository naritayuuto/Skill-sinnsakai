using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillTree : MonoBehaviour
{
    [SerializeField]
    SkillTree _parent = null;//���B

    List<SkillTree> _childs = new List<SkillTree>();//�������g�̉��ɕt���Ă���q������
    [SerializeField, SerializeReference, SubclassSelector]
    ISkill _skill = null;//�ŏ����玝���Ă����B
    PlayerController player = null;
    SkillManager sManager = null;
    public SkillTree Parent { get => _parent; set => _parent = value; }
    public List<SkillTree> Childs { get => _childs; set => _childs = value; }

    private void Awake()
    {
        ChildAdd(this);//�e���Z�b�g����Ă�����q���Ƃ��Đe��List�ɒǉ�����B
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sManager = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
    }

    public void SkillPointJudge(float skillpoint,int arraynumber,UnityEngine.UI.Button button)//�|�C���g������Ă��邩�Askill�̔z�񏇔�
    {
        if(sManager.SkillPoint >= skillpoint)
        {
            sManager.SkillPoint -= skillpoint;
            sManager.SkillActive[arraynumber] = true;
            SkillAdd();
            button.interactable = false;
            Debug.Log("����o���܂���");
        }
        else
        {
            Debug.Log("����o���܂���");
        }
    }

    public void SkillAdd()
    {
        player.AddSkill(_skill);
    }
    public void ChildAdd(SkillTree child)
    {
        if(_parent)
        {
            _parent.Childs.Add(child);
        }
    }

    public void AllOpen()//��������̃X�L����S�Ďg����悤�ɂ���
    {
        player.AddSkill(_skill);//�v���C���[�Ɏ��g�̃X�L����ǉ�
        if (_parent)//�e������̂́A�e���C���X�y�N�^�[��ŃZ�b�g����SkillTree�̂�
        {
            _parent.AllOpen();//�e�̊֐����Ă�
        }
    }
}
