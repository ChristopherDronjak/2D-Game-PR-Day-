using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    private Animator animate;
    private bool on_ground;

    private void Start()
    {
        //gets references for rigidbody and animator
        _rigidbody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        //rotates player
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f && on_ground)
           Jump();
        

        //set animator parameters
        animate.SetBool("Run", movement != 0);
        animate.SetBool("on ground", on_ground);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        on_ground = false;
        AudioManager.instance.Play("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
            on_ground = true;
        else if (collision.gameObject.tag == "Trap")
            on_ground = true;
    }
}