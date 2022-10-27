using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�����ł�skillbutton�ɂ��ꂼ�ꉽ�̃X�L�������̂�����U�肷��B
//skilltree�Ƃ���͕ʕ��B
public class SkillManager : MonoBehaviour//skill���Ǘ�����B�ڎ��̂悤�Ȃ��̂ŉ����������Ă���̂��̏��������Ă���B
{
    [SerializeField]
    SkillButton[] buttons;//SkillButton������skillnumber���L�^���邽�߂Ɏg�p����B_skillActive�̗v�f�ԍ��Ɍ��т��B

    bool[] _skillActive;//���ړI�ɂ����邱�Ƃ͂Ȃ�

    List<SkillTree1> skillTree = new List<SkillTree1>();

    float skillPoint = 0f;

    ///<summary>heal�X�L���̐�</summary>
    private int healcount = 1;
    ///<summary>attack�X�L���̐�</summary>
    private int attackcount = 2;
    ///<summary>buff�X�L���̐�</summary>
    private int buffcount = 3;
    public float SkillPoint { get => skillPoint; set => skillPoint = value; }
    public bool[] SkillActive { get => _skillActive; set => _skillActive = value; }
    public SkillButton[] Buttons { get => buttons;}

    private void Start()
    {
        _skillActive = new bool[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < healcount)//heal�̃X�L��
            {
                buttons[i].Skillnumber = i + 1;
                buttons[i].SkillId = SkillId.heal;
            }
            else if (i < attackcount + healcount)//attack�̃X�L��
            {
                buttons[i].Skillnumber = i - healcount + 1;
                buttons[i].SkillId = SkillId.attack;
            }
            else//buff�̃X�L��
            {
                buttons[i].Skillnumber = i - attackcount;
                buttons[i].SkillId = SkillId.buff;
            }
            buttons[i].ArrayNumber = i;
            buttons[i].Skillpoint += 2 * buttons[i].Skillnumber;
        }
    }
}
