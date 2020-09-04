using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float angleSpeed;
    public float jumpForce;

    public Animator animator;

    private Rigidbody rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float j = Input.GetAxisRaw("Jump");
        Debug.Log(+h+" "+v+" "+j);
        if (v>0)
        {
            gameObject.transform.Translate(new Vector3(0,0, 0.2f*speed),Space.Self);
        }
        if (h<0)
        {       
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - angleSpeed, 0);
        }
        if (h>0)
        {
            Debug.Log("돌아가는중");
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + angleSpeed, 0);
        }
        if (j > 0)
        {
            rigidbody.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            //isPlayerJump = true;
        }
        animationUpdate(h, v, j);
    }
    public void animationUpdate(float h, float v, float j)
    {
        if(h!=0 || v!=0)
            animator.SetBool("iswalk", true) ;
        else
            animator.SetBool("iswalk", false);

        if (j!=0)
            animator.SetBool("isjump", true);
        else
            animator.SetBool("isjump", false);
    }
   
}
