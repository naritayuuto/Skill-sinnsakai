using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3;
    [SerializeField]
    float turnSpeed = 3f;
    [SerializeField]
    private float playerhp = 5000f;
    [SerializeField]
    Heal heal = null;
    Skilltree[] newSkill = null;
    Skilltree skilltree = null;
    Rigidbody _rb = default;
    Animator anim = null;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>
    Vector3 _dir;

    public float Playerhp { get => playerhp; set => playerhp = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        skilltree = GameObject.FindGameObjectWithTag("Skilltree").GetComponent<Skilltree>();
        if (!heal) Debug.LogError("�X�L����Heal���Z�b�g���Ă�������");
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

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

            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);

            Vector3 velo = dir.normalized * moveSpeed; // ���͂��������Ɉړ�����
            velo.y = _rb.velocity.y;   // �W�����v�������� y �������̑��x��ێ�����
            _rb.velocity = velo;   // �v�Z�������x�x�N�g�����Z�b�g����
        }
        if (Input.GetButtonDown("Space"))
        {
            if (skilltree.SkillActive[(int)SkillId.heal])//�P
            {
                newSkill[(int)SkillId.heal].SkillAction();
            }
        }
    }
    public void AddSkill(int skillId)
    {
        {
            switch ((SkillId)skillId)
            {
                case SkillId.heal:
                    newSkill[skillId] = new Heal();
                    break;
                //case SkillId.attack1:
                //    newSkill = new AreaAttack();
                //    break;
            }
        }
    }

    void LateUpdate()
    {
        Vector3 velocity = _rb.velocity;
        velocity.y = 0; // �㉺�����̑��x�͖�������
        anim.SetFloat("Speed", velocity.magnitude);
    }
}
