using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackjudge : MonoBehaviour
{
    [SerializeField]
    PlayerController player = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))//�U�����������X�^�[�̃^�O���o���Ă����āA���߂čU�������ꍇ�̂�0.5���Z�ɂ���
        {
            player.GetSkillPoint(player.Getpoint);
            //Enemy�Ƀ_���[�W��^���鏈���͊֐��ɂ���animation�C�x���g�ōs���B
        }
    }
}
