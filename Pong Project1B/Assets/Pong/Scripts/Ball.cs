using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {
    public float startSpeed;
    public float step;
    public bool useDebugVisualization;
    public PowerUp newPower;
    private AudioSource audioSource;
    public AudioClip leftPaddleCollision;
    public AudioClip rightPaddleCollision;
    public AudioClip wallCollision;
    public AudioClip powerUpCollision;

    private float speed;
    private Rigidbody rb;

    //-----------------------------------------------------------------------------
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        speed = startSpeed;
    }

    //-----------------------------------------------------------------------------
    // Update is called once per frame
    public void Restart()
    {
        speed = startSpeed;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * speed; // change to send to losing side
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            if(collision.gameObject.name == "PaddleLeft")
            {
                audioSource.PlayOneShot(leftPaddleCollision);
            } 
            else if (collision.gameObject.name == "PaddleRight")
            {
                audioSource.PlayOneShot(rightPaddleCollision);
            }
            

            speed += step;
            float heightAboveOrBelow = transform.position.z - collision.transform.position.z;
            float maxHeight = collision.collider.bounds.extents.z;
            float percentOfMax = heightAboveOrBelow / maxHeight;


            if (useDebugVisualization) {
                DebugDraw.DrawSphere(transform.position, 0.5f, Color.green);
                DebugDraw.DrawSphere(collision.transform.position, 0.5f, Color.red);
                Debug.Break();
                Debug.Log($"percent height = {percentOfMax}");
            }

            bool hitLeftPaddle = collision.gameObject.name == "PaddleLeft";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed: -speed;
            Debug.Log(newHorizontalSpeed);

            Vector3 newVelocity = new Vector3(newHorizontalSpeed, 0f, percentOfMax * 4f).normalized * speed;
            rb.velocity = newVelocity;
        }

        if(collision.gameObject.name == "UpperWall" || collision.gameObject.name == "LowerWall"){
            audioSource.PlayOneShot(wallCollision);
        }

        if(collision.gameObject.name == "PowerUpSpeed")
        {
            audioSource.PlayOneShot(powerUpCollision);
            newPower.private void OnTriggerEnter(Collider other) {
                
            }

        }
    }
}
