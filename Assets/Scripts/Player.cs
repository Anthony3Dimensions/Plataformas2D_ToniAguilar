using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad del personaje")]
    [SerializeField]private float _playerSpeed = 4;
    [Tooltip("Controla la fuerza de salto del personaje")]

    [SerializeField]private float _jumpForce = 4;
    private float _playerInput;
    //private float _playerInput2;

    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _director;

    private 

    void Start()
    {
       _rBody2D = GetComponent<Rigidbody2D>();
       //_sensor = GetComponentInChildren<GroundSensor>(); 
       Debug.Log(GameManager.instance.vidas);
      
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();

       if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
       {
           Jump();
       }

       if(Input.GetButtonDown("Fire2"))
       {
         _director.Play();
       }

       _animator.SetBool("IsJumping", !GroundSensor._isGrounded);

       
        /*if(GroundSensor._isGrounded == true)
        {
            _animator.SetBool("IsJumping", false);
        }

        else
        {
            _animator.SetBool("IsJumping", true);
        }*/

      

        
    }

    void FixedUpdate()
    {
        //_rBody2D.AddForce(new Vector2(_playerInput * _playerSpeed, 0), ForceMode2D.Impulse);

        _rBody2D.velocity = new Vector2(_playerInput * _playerSpeed, _rBody2D.velocity.y);
 

    }

    void PlayerMovement()
    {
        _playerInput = Input.GetAxis("Horizontal");

        if(_playerInput != 0)
        {
            _animator.SetBool("IsRunning", true);

        }

        if(_playerInput == 0)
        {
            _animator.SetBool("IsRunning", false);
        }


        if(_playerInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);

        }
        if(_playerInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);

        }
                if(_playerInput == 0)
        {
            _animator.SetBool("IsRunning", true);

        }

        /*_playerInput2 =Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInput, _playerInput2) * _playerSpeed * Time.deltaTime);*/ 
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse); 

        SoundManager.instance.PlayerJump();

    }


    public void SignalTest()
    {
        Debug.Log("Señal recibida");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 7)
        {
            GameManager.instance.GameOver();
            SoundManager.instance.DeadZone();
        }
    }



}
