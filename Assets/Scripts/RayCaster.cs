using UnityEngine;

public class RayCaster : MonoBehaviour {
    public bool onGround = true;
    public bool moveRightEnabled = true;
    public bool moveLeftEnabled = true;
    public float rayLengthSides;
    public float rayLengthUp;
    public float rayLengthDown;
    public GameObject player;

    private void Start() {
        rayLengthSides = 0.3f;
        rayLengthDown = 0.4f;
        rayLengthUp = 0.4f;
    }
    void Update() {
        moveLeftEnabled = true;
        moveRightEnabled = true;
        onGround = false;

        Ray rayRight = new Ray(transform.position, transform.right);
        Ray rayLeft = new Ray(transform.position, -transform.right);
        Ray rayUp = new Ray(transform.position, transform.up);
        Ray rayDown = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(rayRight, out hit, rayLengthSides)) {
            Debug.Log("hit right");
            if (hit.transform.gameObject.tag != "Rigid")
                moveRightEnabled = false;
            if (hit.transform.gameObject.tag == "Gravity Wall Sides")
                onGround = true;
        }
        if (Physics.Raycast(rayLeft, out hit, rayLengthSides)) {
            Debug.Log("hit left");
            if (hit.transform.gameObject.tag != "Rigid")
                moveLeftEnabled = false;
            if (hit.transform.gameObject.tag == "Gravity Wall Sides")
                onGround = true;
        }
        if (Physics.Raycast(rayDown, out hit, rayLengthDown)) {
            Debug.Log("hit down");
            onGround = true;
        }
        if (Physics.Raycast(rayUp, out hit, rayLengthUp)) {
            Debug.Log("hit up");
            onGround = false;
            if (hit.transform.gameObject.tag == "Gravity Wall") {
                onGround = true;
                rayLengthUp = 1.5f;
            } else {
                rayLengthUp = 0.4f;
            }
        }

        gameObject.transform.position = player.transform.position;
        
    }

}