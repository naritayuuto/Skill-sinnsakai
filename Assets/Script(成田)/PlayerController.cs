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
    GameObject[] weapons;
    [SerializeField]
    float skillpoint = 0.0f;
    private float getpoint = 0.5f;
    //[SerializeField]
    //Heal heal = null;
    //Skilltree[] newSkill = null;
    List<Skilltree> heal = new List<Skilltree>();
    List<Skilltree> attack = new List<Skilltree>();
    List<Skilltree> buff = new List<Skilltree>();
    Skilltree skilltree = null;
    Rigidbody _rb = default;
    Animator anim = null;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>
    Vector3 _dir;

    public float Playerhp { get => playerhp; set => playerhp = value; }
    public float Skillpoint { get => skillpoint; set => skillpoint = value; }
    public float Getpoint { get => getpoint; set => getpoint = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        skilltree = GameObject.FindGameObjectWithTag("Skilltree").GetComponent<Skilltree>();
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        //if (!heal) Debug.LogError("�X�L����Heal���Z�b�g���Ă�������");
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
            //�ړ��̏���
            Vector3 velo = dir.normalized * moveSpeed;
            velo.y = _rb.velocity.y;   
            _rb.velocity = velo;   
        }
        //if (Input.GetButtonDown("Space"))
        //{
        //    if (skilltree.SkillActive[(int)SkillId.heal])//�P
        //    {
        //        //newSkill[(int)SkillId.heal].SkillAction();
        //    }
        //}
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
    void LateUpdate()
    {
        Vector3 velocity = _rb.velocity;
        velocity.y = 0; // �㉺�����̑��x�͖�������
        //anim.SetFloat("Speed", velocity.magnitude);
    }
}
