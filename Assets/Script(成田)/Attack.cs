using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skilltree//�X�L�����ƂɃ_���[�W��ς��������߃X�L�����̊֐������Ǘ�����B
{
    public override void SkillAction()
    {
        PlayerStatus.AttackDamage += 500;
    }
}
