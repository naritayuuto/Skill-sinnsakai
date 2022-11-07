using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    /// <summary>�z��ԍ�</summary>
    [SerializeField]
    int arrayNumber = 0;
    ///// <summary>���n���̉��Ԗڂ̃X�L���Ȃ̂�</summary>
    //[SerializeField]
    //int skillnumber = 0;
    /// <summary>������邽�߂ɕK�v�ȃ|�C���g</summary>
    [SerializeField]
    int skillpoint = 0;

    SkillTree skilltree = null;

    Button button = null;

    /// <summary>�X�L�����������Ă��邩</summary>
    bool skillcheck = false;
    //public int Skillnumber { get => skillnumber; set => skillnumber = value; }
    public int ArrayNumber { get => arrayNumber; set => arrayNumber = value; }
    public int Skillpoint { get => skillpoint; set => skillpoint = value; }
    // Start is called before the first frame update
    void Start()
    {
        skilltree = GetComponent<SkillTree>();//�����������Ă���X�L���c���[�������Ă���B
        button = GetComponent<Button>();
    }

    public void OnCllik()
    {
        skilltree.SkillPointJudge(skillpoint,arrayNumber,button);
    }

    //public void SkillRelease()
    //{
    //   if(skillcheck)
    //    {
    //        Debug.Log(arrayNumber + "�ԖڌĂ΂�܂���");

    //        button.interactable = false;
    //    }
    //   else
    //    {
    //        Debug.Log("�܂��J������Ă��܂���");
    //    }
    //}
}
