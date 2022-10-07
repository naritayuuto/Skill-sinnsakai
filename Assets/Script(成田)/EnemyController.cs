using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour//����͐l�^�Ȃ̂�gamedev 1-3-5���Q�l�ɁB
{//�_���[�W�̊֐��͕ʂɂ���̂ŁA�����ł͑�܂��ȓ����Aanimation���ǂ��g�������l���đg�ނ��ƁB
    /// <summary>Enemy�̗̑�</summary>
    [SerializeField]
    int enemyHp = 5000;
    /// <summary>Enemy�̑���</summary>
    [SerializeField]
    float moveSpeed = 3.0f;
    /// <summary>Enemy��X���Ƃy���̈ړ�����</summary>
    [SerializeField]
    float xz = 0f;
    /// <summary>Enemy�̓����o���Ԋu</summary>
    [SerializeField]
    int moveInterval = 10;
    ///// <summary>Enemy��X���̈ړ��͈�</summary>
    //float enemyMoveRangeX = 0f;
    ///// <summary>Enemy��Z���̈ړ��͈�</summary>
    //float enemyMoveRangeZ = 0f;
    /// <summary>parry��true�ɂȂ���������J�E���g���鎞��</summary>
    float parrytimer = 0.0f;
    /// <summary>�����Ă���ԃJ�E���g���鎞��</summary>
    float movetimer = 0.0f;
    /// <summary>�p���B����鎞��</summary>
    float parrylimit = 0.5f;

    float enemyPosX;
    float enemyPosZ;
    /// <summary>Enemy�̏����ʒu</summary>
    Vector3 enemyInitialPosition;
    bool attack = false;
    bool parry = false;
    /// <summary>player�����������ǂ���</summary>
    bool playerSense = false;
    public int EnemyHp { get => enemyHp; set => enemyHp = value; }
    public bool Parry { get => parry;}//�U����animation����0.5�b�Ԃ���true�ɂ���B
    Animator anim = null;
    Rigidbody rb = null;
    PlayerController player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        enemyInitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movetimer += Time.deltaTime;
        if(!playerSense)
        {
            if (movetimer > moveInterval)
            {
                MovePosition(transform.position);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position, moveSpeed);
        }
        if(parry)
        {
            parrytimer += Time.deltaTime;
            if(parrytimer > parrylimit)
            {
                parry = false;
            }
        }
    }
    private void ParryActive()//�U���panimation�p�֐��A
    {
        parry = true;
    }
    //transform.position = Vector3.MoveTowards(�����̈ʒu, �ړI�n, speed);

    private void MovePosition(Vector3 enemyPos)
    {//enemyPosx��0�Axz��50�������ꍇ�A-50�`+50�܂ŁB
        enemyPosX = Random.Range(enemyPos.x - xz, enemyPos.x + xz);
        enemyPosZ = Random.Range(enemyPos.z - xz, enemyPos.z + xz);
        if ( enemyPosX > enemyInitialPosition.x + xz || 
             enemyPosX < enemyInitialPosition.x - xz &&
             enemyPosZ > enemyInitialPosition.z + xz ||
             enemyPosZ < enemyInitialPosition.z - xz)
        {
            MovePosition(enemyPos);
        }
        else
        {
            transform.position = Vector3.MoveTowards(enemyPos, new Vector3(enemyPosX, enemyPos.y, enemyPosZ), moveSpeed);
        }
    }

    private void PlayerSenseAttack()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerSense = false;
        }
    }
}
