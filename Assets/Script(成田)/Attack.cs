using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack : ISkill//�X�L�����ƂɃ_���[�W��ς��������߃X�L�����̊֐������Ǘ�����B
{
    string name = "Attack";
    string ISkill.Name => name;
    public void Action(PlayerController player)
    {
        Debug.Log("Attack");
    }
}
