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
    [SerializeField]
    float playerSensedis = 5f;
    [SerializeField]
    float moveTimer = 5f;
    [SerializeField]
    float time = 5f;
    /// <summary>�ړI�n���؂�ւ�鋗��</summary>
    [SerializeField]
    float changepos = 5f;
    /// <summary>Enemy��X���Ƃy���̈ړ��͈�</summary>
    [SerializeField]
    float xz = 30f;
    float enemyPosX;
    float enemyPosZ;
    GameObject player = null;
    NavMeshAgent agent = null;
    /// <summary>Enemy�̐������ꂽ�����n�_</summary>
    Vector3 enemypos;
    Vector3 targetpos;
    Vector3 destination = new Vector3(0, 0, 0);
    Animator anim = null;
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
        if (distance >= playerSensedis)//�͈͊O
        {
            if (Vector3.Distance(transform.position,destination) <= changepos)//�ړI�n���ӂɗ�����
            {
                moveTimer += Time.deltaTime;
                if (moveTimer >= time)//���Ԃ�������
                {
                    MovePosition(transform.position);//�V�����ړI�n���Z�b�g
                    moveTimer -= moveTimer;
                }
            }
        }
        else if (distance <= playerSensedis)//�͈͓�
        {
            agent.SetDestination(targetpos);
            if (Vector3.Distance(transform.position, targetpos) <= 1f)
            {
                //animation�𗬂��B
            }
        }
    }
    private void MovePosition(Vector3 enemyPos)
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
