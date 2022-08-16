using UnityEngine;
using System.Collections;


public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 500;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public int EnemyDamage;
    private string currentAnimation;

    public bool _moveRight = true;
    Animator animator;

    Health playerHealth;
    

    // Use this for initialization
    public void Awake()
    {
        playerHealth = GameObject.FindObjectOfType<Health>();
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > -1;
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;
        animator.Play(newState);
    }

    //Animationstates

    const string BigRat = "Big rat";



    // Update is called once per frame
    public void Update()
    {

        if (_moveRight)
        {
            enemyRigidBody2D.transform.Translate(Vector2.right * EnemySpeed * Time.deltaTime);
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.transform.Translate(-Vector2.right * EnemySpeed * Time.deltaTime);
            if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;


    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }



   
}