using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    private bool right = false;
    private bool left = false;

    void Update(){
        if (Input.GetKey("d")){
            right = true;
        }else{
            right= false;
        }
        if (Input.GetKey("a")){
            left = true;
        }else{
            left= false;
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (right){
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (left){
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
