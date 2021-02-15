using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Ball ball;
    public PowerUp power;


    //-----------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        if(power.name == "PowerUpSpeed"){
            ball.increaseSpeed();
            Debug.Log("speed working");
        }

        if(power.name == "PowerUpPaddle"){
            ball.increasePaddle();
            Debug.Log("Paddle working");
        }
    }
}
