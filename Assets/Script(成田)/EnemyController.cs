using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour//����͐l�^�Ȃ̂�gamedev 1-3-5���Q�l�ɁB
{//�_���[�W�̊֐��͕ʂɂ���̂ŁA�����ł͑�܂��ȓ����Aanimation���ǂ��g�������l���đg�ނ��ƁB
    [SerializeField]
    int enemyHp = 5000;
    [SerializeField]
    float moveSpeed = 3.0f;
    float x = 0;
    float z = 0;
    Animator anim = null;
    public int EnemyHp { get => enemyHp; set => enemyHp = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
