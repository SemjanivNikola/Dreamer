using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public static PlayerCombat instance;
    public bool isAttacking = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NormalAttack") && !isAttacking)
        {
            Attack();
        }
        
    }

    void Attack()
    {
        isAttacking = true;
    }
}
