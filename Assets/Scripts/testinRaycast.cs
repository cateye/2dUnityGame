using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinRaycast : MonoBehaviour
{

    private Animator _animator;
    private Weapon _weapon;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("IsMoving", false);
            _animator.SetTrigger("Shoot");
          
        }
    }

    void CanShoot()
    {
        if(_weapon != null)
        {
            //Shoot
            StartCoroutine(_weapon.ShootWithRaycast());
        }
    }
}
