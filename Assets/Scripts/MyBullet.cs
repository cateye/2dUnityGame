using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;

    public float livingTime = 3f;


    //change the bullet color over time
    public Color initialColor = Color.white;
    public Color finalColor = Color.red;
    private SpriteRenderer _renderer;
    private float _startingTime;
    // Start is called before the first frame update

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _startingTime = Time.time;
        Destroy(this.gameObject,livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        //transform.position = new Vector2(transform.position.x + movement.x,transform.position.y + movement.y);
        transform.Translate(movement);

        //changeColor of the bullet oover time
        float _timeSinceStarted = Time.time - _startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;
        if(_percentageCompleted > 0.50) { _renderer.color = Color.red; }
        //_renderer.color = Color.LerpUnclamped(initialColor, finalColor, _percentageCompleted);
    }


}
