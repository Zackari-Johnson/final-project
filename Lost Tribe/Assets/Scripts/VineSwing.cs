using UnityEngine;

public class VineSwing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;

    private int collisions;
    private Collider2D collideObj;

    private float horizontalInput;
    public float pushForce = 10f;

    public bool attached = false;
    public Transform attachedTo;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }

    
    void Update()
    {
        CheckKeyboardInputs();
    }

    void CheckKeyboardInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (attached)
        {
            rb.AddRelativeForce(new Vector3(horizontalInput, 0, 0) * pushForce);
        }

        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonUp("Jump") && attached)
            {
                Detach();
            }

            if(SettingsMenu.difficulty % 2 == 0)
            {
                if (Input.GetButton("Jump"))
                {
                    if (collisions > 0)
                    {
                        if (!attached)
                        {
                            if (attachedTo != collideObj.gameObject.transform.parent)
                            {
                                Attach(collideObj.gameObject.GetComponent<Rigidbody2D>());
                            }
                        }
                    }
                }
            }

            else if (SettingsMenu.difficulty % 2 == 1)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (collisions > 0)
                    {
                        if (!attached)
                        {
                            if (attachedTo != collideObj.gameObject.transform.parent)
                            {
                                Attach(collideObj.gameObject.GetComponent<Rigidbody2D>());
                            }
                        }
                    }
                }
            }


        }

    }
    
    public void Attach(Rigidbody2D vineBone)
    {
        vineBone.gameObject.GetComponent<VineSegment>().isPlayerAttached = true;
        hj.connectedBody = vineBone;
        hj.enabled = true;
        attached = true;
        attachedTo = vineBone.gameObject.transform.parent;
        rb.velocity = new Vector2(rb.velocity.x * 4, rb.velocity.y);
    }

    void Detach()
    {
        hj.connectedBody.gameObject.GetComponent<VineSegment>().isPlayerAttached = false;
        attached = false;
        attachedTo = null;
        hj.enabled = false;
        hj.connectedBody = null;

        rb.velocity = new Vector2(rb.velocity.x * 2f, 1.5f * Mathf.Abs(rb.velocity.x) + 3f * rb.velocity.y);
        rb.AddForce(new Vector2(rb.velocity.x, 0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Vine")
        {
            collisions++;
            collideObj = col;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Vine")
        {
            collisions--;
            collideObj = null;
        }
    }
}
