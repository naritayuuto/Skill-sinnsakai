using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController1 : MonoBehaviour
{
    [SerializeField]
    int enemyHp = 5000;
    /// <summary>Enemy�̑���</summary>
    [SerializeField]
    float moveSpeed = 3.0f;
    /// <summary>�v���C���[�������邱�Ƃ��ł��鋗��</summary>
    [SerializeField, Header("�v���C���[���������鋗��")]
    float playerSensedis = 5f;
    [SerializeField, Header("�����o���܂ł̎���")]
    float moveTime = 5f;
    [SerializeField, Header("�J�E���g�p")]
    float timer = 0f;
    /// <summary>�ړI�n���؂�ւ�鋗��</summary>
    [SerializeField, Header("�ړI�n���؂�ւ�鋗��")]
    float changeDis = 5f;
    [SerializeField, Header("�v���C���[�ɍU�����鋗��")]
    float attackDis = 1f;
    /// <summary>Enemy��X���Ƃy���̈ړ��͈�</summary>
    [SerializeField,Header("X���Ƃy���̈ړ��͈�")]
    float xz = 30f;
    /// <summary>�p���B����鎞��</summary>
    float parrylimit = 0.5f;

    float enemyPosX;
    float enemyPosZ;
    int pattern = 0;
    GameObject player = null;
    NavMeshAgent agent = null;
    /// <summary>Enemy�̐������ꂽ�����n�_</summary>
    Vector3 enemypos;
    Vector3 targetpos;
    Vector3 destination = new Vector3(0, 0, 0);
    Animator anim = null;
    /// <summary>�v���C���[�������Ă��邩�ǂ���</summary>
    bool playerFound = false;
    /// <summary>�U�������ǂ���</summary>
    bool attack = false;//�p���B�\�ȍU���̂ݎg���\��
    /// <summary>�p���B���o���邩�ǂ���</summary>
    bool parry = false;//

    public int EnemyHp { get => enemyHp; set => enemyHp = value; }
    public bool Parry { get => parry; set => parry = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemypos = transform.position;
        destination = transform.position;
        Debug.Log(Vector3.Distance(transform.position, targetpos));
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = player.transform.position;
        var distance = Vector3.Distance(transform.position, targetpos);
        if (distance >= playerSensedis)//�v���C���[���G�͈͊O
        {
            pattern = 1;
        }
        if (distance <= playerSensedis)//�v���C���[���G�͈͓�
        {
            playerFound = true;
            pattern = 2;
        }
        switch (pattern)
        {
            case 1:
                if (playerFound)//�v���C���[�������������A�������������ꂽ�ꏊ�֖߂�
                {
                    destination = enemypos;
                    agent.SetDestination(destination);
                    playerFound = false;
                }
                if (Vector3.Distance(transform.position, destination) <= changeDis)//�ړI�n���ӂɗ�����
                {
                    moveTime += Time.deltaTime;//�����~�܂鎞�Ԃ���肽������
                    if (moveTime >= timer)//���Ԃ�������
                    {
                        MovePosition(transform.position);//�����𒆐S�Ƃ������͈͂̒����烉���_���ō��W�v�Z
                        moveTime -= moveTime;
                    }
                }
                break;
            case 2:
                if (Vector3.Distance(transform.position, targetpos) > attackDis)//�����Ă��邪�U�����͂��Ȃ������̏���
                {
                    agent.SetDestination(targetpos);//�ړI�n����Ƀv���C���[�ɕύX 
                }
                break;//switch���𔲂���
        }
    }

    private void MovePosition(Vector3 enemyPos)//�ړI�n�v�Z
    {
        enemyPosX = Random.Range(enemyPos.x - xz, enemyPos.x + xz);
        enemyPosZ = Random.Range(enemyPos.z - xz, enemyPos.z + xz);
        if (enemyPosX > enemypos.x + xz ||
             enemyPosX < enemypos.x - xz &&
             enemyPosZ > enemypos.z + xz ||
             enemyPosZ < enemypos.z - xz)
        {
            MovePosition(enemyPos);//��蒼��
        }
        else
        {
            destination = new Vector3(enemyPosX, enemypos.y, enemyPosZ);
            agent.SetDestination(destination);//NavMeshAgent�̏����擾��,�V�����ړI�n�ipos�j��ݒ肷��B
        }
    }
    private void LateUpdate()
    {
        if (anim)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
            anim.SetFloat("Pos", Vector3.Distance(transform.position, targetpos));
        }
    }
}
