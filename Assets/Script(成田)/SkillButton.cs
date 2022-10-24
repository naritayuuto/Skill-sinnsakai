using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    PlayerController player = null;
    [SerializeField]
    SkillId skillId = SkillId.heal;
    /// <summary>�z��ԍ�</summary>
    [SerializeField]
    int arrayNumber = 0;
    /// <summary>���n���̉��Ԗڂ̃X�L���Ȃ̂�</summary>
    [SerializeField]
    int skillnumber = 0;
    /// <summary>������邽�߂ɕK�v�ȃ|�C���g</summary>
    [SerializeField]
    int skillpoint = 0;

    SkillManager _skillManager = null;

    SkillTree1 skilltree = null;

    Button button = null;

    /// <summary>�X�L�����������Ă��邩</summary>
    bool skillcheck = false;
    public int Skillnumber { get => skillnumber; set => skillnumber = value; }

    public int ArrayNumber { get => arrayNumber; set => arrayNumber = value; }
    public bool Skillcheck { get => skillcheck; set => skillcheck = value; }
    public SkillId SkillId { get => skillId; set => skillId = value; }
    public int Skillpoint { get => skillpoint; set => skillpoint = value; }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        skilltree = gameObject.GetComponent<SkillTree1>();//�����������Ă���X�L���c���[�������Ă���B
        _skillManager = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
        button = GetComponent<Button>();
    }

    public void OnCllik()
    {
        skilltree.SkillPointJudge(skillpoint,arrayNumber);
    }

    public void Yobidasi(ISkill skill)
    {
       if(skillcheck)
        {
            Debug.Log(skillId + "��" + skillnumber + "�ԖڌĂ΂�܂���");
            player.AddSkill(skill);
            _skillManager.SkillPoint -= skillpoint;
            _skillManager.SkillActive[arrayNumber] = true;
            button.interactable = false;
        }
       else
        {
            Debug.Log("�܂��J������Ă��܂���");
        }
    }
}
