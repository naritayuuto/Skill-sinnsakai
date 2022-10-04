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
    float time = 0.0f;
    float parrylimit = 0.5f;
    Animator anim = null;
    bool attack = false;
    bool parry = false;
    public int EnemyHp { get => enemyHp; set => enemyHp = value; }
    public bool Parry { get => parry;}//�U����animation����0.5�b�Ԃ���true�ɂ���B

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(parry)
        {
            time += Time.deltaTime;
            if(time > parrylimit)
            {
                parry = false;
            }
        }
    }
    private void ParryActive()
    {
        parry = true;
    }
}
