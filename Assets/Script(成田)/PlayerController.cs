using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour//�ړ���animation�Ə����A�{�^��������Ă���bool���m�F�Atrue�̏ꍇskill���g����悤�ɂ���
{
    [SerializeField]
    float speed = 1.0f;
    Skilltree skilltree = null;
    Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        skilltree = GameObject.FindGameObjectWithTag("Skilltree").GetComponent<Skilltree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
