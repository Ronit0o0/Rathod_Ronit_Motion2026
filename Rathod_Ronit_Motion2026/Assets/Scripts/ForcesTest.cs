using UnityEngine;
using UnityEngine.InputSystem;
public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum projectileType
    {
        arrow, cannonball, dogquestionmark, angry_bird
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * 1f, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.z = 0f;

            Vector3 directionToApplyForce = worldMousePosition - transform.position;


            rb.AddForce(directionToApplyForce.normalized * forceStrength);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger Stay");
    }


}
