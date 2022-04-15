using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed, jumpForce; // variable untuk jalan dan loncat, jika jalan harus ada speednya 
    public bool isFacingRight; // rotasi, jika ingin lihat kanan kiri, gabisa ke kanan kiri. Dimainkan di animasinya => animation - animation
    Rigidbody2D rb; // Rigidbofy(tipe data) behavior untuk pemain, 

    public float radius; // Untuk loncat 
    public Transform groundChecker; // transform = tipe data
    public LayerMask whatIsGround; //LayerMask = tipe data 

    Animator anim; // untuk animasinya aja bisa diam bisa jalan
    string walk_parameter = "Walk"; // Jadi String walk_parameter itu untuk nge referensi ke bagian animatornya
    string idle_parameter = "Idle"; //

    private void Awake() // dipanggil pertama kali sebelum start 
    {
        rb = GetComponent<Rigidbody2D>(); // get componet untuk mengubah
         // merefrense rigif dan animator
        anim = GetComponent<Animator>(); // anim = variable 
    }

    // Start is called before the first frame update = dipanggil sebelum frame pertama update
    void Start()
    {
        
    }

    // Update is called once per frame
    // dia dipanggil 1 kali setiap 1 frame 
    // looping
    void Update()
    {
        Jump();
    }

    private void FixedUpdate() // hirarki mirip awake yang dipanggil duluan sebelum update
    // dipisah karena ingin 
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y); // kita mebuat vector 2 / arah 
        
        // kondisi
        if(move != 0) // untuk animasi, jika move ga 0 maka jadi walk arameter
        {
            anim.SetTrigger(walk_parameter);
        }
        else // kalau diem yaudah diem
        {
            anim.SetTrigger(idle_parameter);
        }

        if(move > 0 && isFacingRight == false) // Untuk animasi kanan kri, jika move > 0 
        {
            transform.eulerAngles = Vector2.zero; //eulerAngles rotasi 
            isFacingRight = true;
        }
        else if(move < 0 && isFacingRight) // menghadap kanan 
        {
            transform.eulerAngles = Vector2.up * 180; // dia akan ke kiri 180 
            isFacingRight = false; // tidak melihat ke kanan 
        }
    }

    void Jump() // untuk fungsion jump
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() ) // Input.GetKeyDown bawaan unity , KeyCode.Space untuk ngerefrsh , IsGrounded = sebuah fungsion 
        {
            rb.velocity = Vector2.up * jumpForce; // untuk loncat 
        }
    }

    bool IsGrounded() // tipe data bool/ boolean 
    {
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
        // agar ketika loncat bisa balik lagi, ketika ditanah bisa loncat lagi
        // kalau ditekan spasi bolak balik dia terbang diawan karena gravitisinya kalah
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, radius);
        // 
    }
}
