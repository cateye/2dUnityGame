using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{

    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private Animator _animator;
    private Weapon _weapon;
 

    private GameObject _target;

    private Vector2 direction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void UpdateTarget()
    {
        if(_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1,1,1);

            return;
        }

        if(_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1,1,1);
        }
        else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator PatrolToTarget()
    {
        // Coroutine to move the enemy
        _animator.SetBool("IsMoving", true);
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            // let's move to the target
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            // IMPORTANT
            yield return null;
        }
        _animator.SetBool("IsMoving", false);
        // At this point, i've reached the target, let's set our position to the target's one
        Debug.Log("Target reached");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        UpdateTarget();
        _animator.SetTrigger("Shoot");

        // And let's wait for a moment
        Debug.Log("Waiting for " + waitingTime + " seconds");
        yield return new WaitForSeconds(waitingTime); // IMPORTANT
        
        // once waited, let's restore the patrol behaviour
        Debug.Log("Waited enough, let's update the target and move again");
        StartCoroutine("PatrolToTarget");
    }

    private void EnemyShoot()
    {
        if (_weapon != null) {
            _weapon.Shoot();
        }
    }

}
