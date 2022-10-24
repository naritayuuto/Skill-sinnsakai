using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    /// <summary>player�̑���</summary>
    [SerializeField]
    float moveSpeed = 3f;
    /// <summary>player�̉�]���x</summary>
    [SerializeField]
    float turnSpeed = 3f;
    /// <summary>player�̃W�����v��</summary>
    [SerializeField]
    float jumpPower = 3f;
    /// <summary>player�̊�{�U����</summary>
    [SerializeField]
    int attackDamage = 500;//�֐��ŕύX����B
    /// <summary>player�̕���z��</summary>
    [SerializeField]
    GameObject[] weapons;
    /// <summary>�U������p�R���C�_�[</summary>
    [SerializeField]
    GameObject attackCollider = null;
    /// <summary>�K�[�h����p�R���C�_�[</summary>
    [SerializeField]
    GameObject guardCollider = null;
    /// <summary>����</summary>
    private float timer = 0.0f;
    /// <summary>�U������p�R���C�_�[�̃A�N�e�B�u�^�C��</summary>
    private float attackJudgeTime = 0.5f;
    /// <summary>�K�[�h����p�R���C�_�[�̃A�N�e�B�u�^�C��</summary>
    private float guardJudgeTime = 0.5f;
    /// <summary>�ڒn����</summary>
    bool isGrounded = true;
    /// <summary>�ʏ�U������p,�R���C�_�[Active�p</summary>
    bool normalAttack = false;
    /// <summary>�h�䔻��p,�R���C�_�[Active�p</summary>
    bool guard = false;

    bool parrysuccess = false;
    public bool Guard { get => guard; set => guard = value; }
    public int AttackDamage { get => attackDamage; set => attackDamage = value; }

    List<ISkill> skills = new List<ISkill>();
    Rigidbody _rb = default;
    Animator anim = default;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>

    void Start()
    {
        //if(!attackCollider)
        //{
        //    Debug.LogError("�U������p�̃R���C�_�[���Z�b�g����Ă��܂���");
        //}
        //else if(!guardCollider)
        //{
        //    Debug.LogError("�K�[�h����p�̃R���C�_�[���Z�b�g����Ă��܂���");
        //}
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //skilltree = GameObject.FindGameObjectWithTag("Skilltree").GetComponent<Skilltree>();
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        //if (!heal) Debug.LogError("�X�L����Heal���Z�b�g���Ă�������");
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        timer += Time.deltaTime;
        //if(playerDamagehp <= 0)
        //{
        //    //GameOver
        //}
        if (normalAttack)
        {
            timer -= timer;
            AttackColliderActive();
            normalAttack = false;
        }
        if(timer > attackJudgeTime)
        {
            attackCollider.SetActive(false);   
        }
        if(guard)
        {
            timer -= timer;
            GuardColliderActive();
            guard = false;
        }
        if(timer > guardJudgeTime)
        {
            guardCollider.SetActive(false);
        }
        // ���͕����̃x�N�g���v�Z
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // �����̓��͂��Ȃ����́Ay �������̑��x��ێ�
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            // �J��������ɂ���
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;
            //�ړ��̏���
            Vector3 velo = dir.normalized * moveSpeed;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        //}
        if(Input.GetButtonDown("Fire1"))
        {
            anim.Play("NormalAttack");
        }
    }
    void LateUpdate()
    {
        // �A�j���[�V�����̏���
        if (anim)
        {
            Vector3 walkSpeed = _rb.velocity;
            walkSpeed.y = 0;
            anim.SetFloat("Speed", walkSpeed.magnitude);
            anim.SetBool("IsGrounded", isGrounded);//�ڒn����p
            anim.SetBool("Guard",guard);//�K�[�h�p
            anim.SetBool("Parrysuccess", parrysuccess);//�p���B������true
        }
    }
    private void AttackColliderActive()
    {
        attackCollider.SetActive(true);
    }
    
    private void GuardColliderActive()
    {
        guardCollider.SetActive(true);
    }
    private void NormalAttackPlay()//animation�C�x���g�p
    {
        normalAttack = true;
    }

    public void NormalAttack()//animation�C�x���g�p
    {
        attackDamage = Random.Range(400, 600);
    }

    public void ParryJudge(bool judge)
    {
        if(!judge)
        {
            return;
        }
        else
        {
            parrysuccess = true;//parry�p��animation�𗬂�
        }
    }
    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    public void AddSkill(ISkill skill)
    {
        skills.Add(skill);
    }
}
