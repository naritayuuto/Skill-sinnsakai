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
    float skillpoint = 0.0f;
    [SerializeField]
    private float playerhp = 5000f;
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    GameObject attackCollider = null;
    private float getpoint = 0.5f;
    private float timer = 0.0f;
    private float attackJudgeTime = 0.5f;

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
    public float Playerhp { get => playerhp; set => playerhp = value; }
    public float Skillpoint { get => skillpoint; set => skillpoint = value; }
    public float Getpoint { get => getpoint; set => getpoint = value; }

    void Start()
    {
        if(!attackCollider)
        {
            Debug.LogError("�U������p�̃R���C�_�[���Z�b�g����Ă��܂���");
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
        if(normalAttack)
        {
            timer += Time.deltaTime;
            AttackColliderActive();
        }
        if(timer > attackJudgeTime)
        {
            attackCollider.SetActive(false);
            normalAttack = false;
            timer -= timer;
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
            anim.SetBool("IsGrounded", isGrounded);
            Vector3 walkSpeed = _rb.velocity;
            walkSpeed.y = 0;
            anim.SetFloat("Speed", walkSpeed.magnitude);
        }
    }
    private void AttackColliderActive()
    {
        attackCollider.SetActive(true);
    }
    private void NormalAttack()
    {
        normalAttack = true;
    }
    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
    public void GetSkillPoint(float point)
    {
        skillpoint += point;
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
