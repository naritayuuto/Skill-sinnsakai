using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float turnSpeed = 3f;
    [SerializeField]
    float jumpPower = 3f;
    [SerializeField]
    private float playerhp = 5000f;
    [SerializeField]
    int attackDamage = 500;//�֐��ŕύX����B
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    GameObject attackCollider = null;
    [SerializeField]
    GameObject guardCollider = null;
    private float getpoint = 0.5f;
    private float timer = 0.0f;
    private float attackJudgeTime = 0.5f;

    public int AttackDamage { get => attackDamage; set => attackDamage = value; }

    //Heal heal = null;
    //Skilltree[] newSkill = null;
    List<Skilltree> heal = new List<Skilltree>();
    List<Skilltree> attack = new List<Skilltree>();
    List<Skilltree> buff = new List<Skilltree>();
    Skilltree skilltree = null;
    Rigidbody _rb = default;
    Animator anim = default;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>

    bool isGrounded = true;

    bool normalAttack = false;

    bool guard = false;

    bool parrysuccess = false;
    public float Playerhp { get => playerhp; set => playerhp = value; }
    public float Getpoint { get => getpoint; set => getpoint = value; }

    public bool Guard { get => guard; set => guard = value; }
    void Start()
    {
        if(!attackCollider)
        {
            Debug.LogError("�U������p�̃R���C�_�[���Z�b�g����Ă��܂���");
        }
        else if(!guardCollider)
        {
            Debug.LogError("�K�[�h����p�̃R���C�_�[���Z�b�g����Ă��܂���");
        }
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
        if(Input.GetButtonDown("Jump"))
        {
            anim.Play("NormalAttack");
        }
    }
    void LateUpdate()
    {
        // �A�j���[�V�����̏���
        if (anim)
        {
            anim.SetBool("IsGrounded", isGrounded);//�ڒn����p
            anim.SetBool("Guard",guard);//�K�[�h�p
            anim.SetBool("Parrysuccess", parrysuccess);//�p���B������true
            Vector3 walkSpeed = _rb.velocity;
            walkSpeed.y = 0;
            anim.SetFloat("Speed", walkSpeed.magnitude);
        }
    }
    private void AttackColliderActive()//animation�C�x���g�p
    {
        attackCollider.SetActive(true);
    }
    
    private void GuardColliderActive()//animation�C�x���g�p
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
    //public void AddSkill(int skillId, int skillnumber)//SkillButton�������ꂽ��Ăяo���A�����܂ł��g����X�L����List������Ă��镔��
    //{
    //    {
    //        switch ((SkillId)skillId)
    //        {
    //            case SkillId.heal://List�ō�蒼����Add�Œǉ��Aenum�͂����܂ł���ޕ����Ȃ̂ŉ񕜗͂��ႤHeal���o�Ă����ꍇ����
    //                //newSkill[skillId] = new Heal();
    //                heal.Add();
    //                break;
    //            case SkillId.attack:
    //                attack.Add();
    //                break;
    //            case SkillId.buff:
    //                buff.Add();
    //                break;
    //                //�X�L���̍쐬���I��莟�悱���ɒǉ�
    //        }
    //    }
    //}

}
