using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack1 : ISkill//�X�L�����ƂɃ_���[�W��ς��������߃X�L�����̊֐������Ǘ�����B
{
    string name = "Attack1";
    string ISkill.Name => name;
    int damage = 800;
    public void Action(PlayerController player)
    {
        player.AttackDamageKeep(damage);
        player.Anim.Play(name);
        Debug.Log("Attack");
    }
}
