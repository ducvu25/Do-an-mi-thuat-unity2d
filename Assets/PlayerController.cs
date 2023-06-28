using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 index;
    public GameObject Finish;
    Vector3 jumpForce;
    float jumpTime = 0.0f;
    float delay_jump = 0.2f;
    Animator animator;
    Rigidbody2D myBody;
    bool facing_rigth = true;
    bool isJumping = true;
    bool jump = true;
    bool gt2 = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = index;
        jumpForce = new Vector3(8, 0, 3);
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Finish.activeSelf)
            return;
        delay_jump -= Time.deltaTime;
        if (transform.position.x >= -14 && !gt2)
        {
            gt2 = true;
            Finish.SetActive(true);
            UIControlerr ui = Finish.GetComponent<UIControlerr>();
            ui.GioiThieu(5);
        }
        Jump();
        Run();
        if (transform.position.y < -15)
            transform.position = index;
    }
    void Run()
    {
        float x = 0f;//= Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            x = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            x = 1;
        if (x == 0 && !isJumping)
        {
            animator.SetBool("Run", false);
            //animator.CrossFade("PlayerIdle", 0.2f);
            return;
        }
        transform.position = transform.position + new Vector3(x * speed * Time.deltaTime, 0, 0);
        if ((facing_rigth && x == -1) || (!facing_rigth && x == 1))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
            facing_rigth = !facing_rigth;
        }
        if (!isJumping)
        {
            animator.SetBool("Run", true);
            //animator.CrossFade("PlayerIdle", 0.5f);
        }
        else
        {
            animator.SetBool("Fly", true);
            animator.CrossFade("PlayerIdle", 0.55f);
        }
    }
    void Jump()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jump && delay_jump <= 0)
        {
            if (!isJumping)
            {
                isJumping = true;
                jumpForce.y = jumpForce.z;
            }
            else
            {
                jumpTime += Time.deltaTime;
                jumpForce.y = 8 * (jumpTime / 0.3f);
                if (jumpForce.y >= jumpForce.x)
                    jumpForce.y = jumpForce.x;
            }
        }
        if (((Input.GetAxis("Vertical") == 0 && jump && isJumping) || jumpTime >= 0.3f) && delay_jump <= 0)
        {
            myBody.AddForce(new Vector2(0f, jumpForce.y), ForceMode2D.Impulse);
            animator.SetBool("Jump", jump);
            animator.CrossFade("PlayerIdle", 0.35f);
            jump = !jump;
            isJumping = false;
            jumpTime = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && jump == false)
        {
            animator.SetBool("Jump", jump);
            if (animator.GetBool("Fly"))
                animator.SetBool("Fly", false);
            jump = !jump;
            delay_jump = 0.2f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Clover"))
        {
            ManagerController manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ManagerController>();
            manager.SetStar();
            Destroy(col.gameObject);
        }
    }
    // void OnAnimation(int i)
    // {
    //     switch (i)
    //     {
    //         case 0:
    //             {
    //                 animator.SetBool("Run", true);
    //                 StartCoroutine(ExitAfterDelay(0.3f, 0));
    //                 break;
    //             }
    //         case 1:
    //             {
    //                 animator.SetBool("Jump", true);
    //                 StartCoroutine(ExitAfterDelay(0.5f, 1));
    //                 break;
    //             }
    //         case 2:
    //             {
    //                 animator.SetBool("Fly", true);
    //                 StartCoroutine(ExitAfterDelay(1.1f, 2));
    //                 break;
    //             }
    //     }
    // }

    // void OffAnimation(int i)
    // {
    //     switch (i)
    //     {
    //         case 0:
    //             {
    //                 animator.SetBool("Run", false);
    //                 break;
    //             }
    //         case 1:
    //             {
    //                 animator.SetBool("Jump", false);
    //                 break;
    //             }
    //         case 2:
    //             {
    //                 animator.SetBool("Fly", false);
    //                 break;
    //             }
    //     }
    // }
    // IEnumerator ExitAfterDelay(float delayTime, int i)
    // {
    //     yield return new WaitForSeconds(delayTime);
    //     OffAnimation(i);
    // }
}
