using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject parent;
    RayCaster rayCaster;
    Rigidbody rb;
    AudioSource audioData;

    public float spinnSpeed;
    public float moveSpeed;
    public float jumpForce;
    public float boostJumpForce;
    public float rotationLimit;
    public float rotationMul;
    private double oldPosition = 0;
    public bool doubleJumpEnabled = false;
    public bool hasDoubleJump = false;
    public bool onGround = true;
    public int jumpCount = 0;
    public float lastJump;
    public bool inJumpZone;
    public bool boostNextJump;
    Vector3 velocity;

    bool jumped = false;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.onPlayerInZoneE += OnPlayerInZone;
        EventManager.onGameEndE += OnGameEnd;

        spinnSpeed = 3f;
        moveSpeed = 2f;
        jumpForce = 5f;
        boostJumpForce = 400f;
        rotationLimit = 4f;
        rotationMul = 0.5f;
        rb = GetComponent<Rigidbody>();
        rayCaster = parent.GetComponent<RayCaster>();
        audioData = GetComponent<AudioSource>();
    }

    private void OnDestroy() {
        EventManager.onPlayerInZoneE -= OnPlayerInZone;
        EventManager.onGameEndE -= OnGameEnd;
    }
    private void Update() {
        if (inJumpZone) boostNextJump = true;
        if ((!jumped && Input.GetKeyDown(KeyCode.W) && onGround) || (!jumped && Input.GetKeyDown(KeyCode.Space) && onGround)
           || (!jumped && Input.GetKeyDown(KeyCode.W) && !onGround && doubleJumpEnabled)
           || (!jumped && Input.GetKeyDown(KeyCode.Space) && !onGround && doubleJumpEnabled)) {

            jumped = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        Debug.Log("speedx: " + rb.velocity);
        onGround = rayCaster.onGround;
        if (onGround) {
            if (Time.time - lastJump > 1) {
                jumpCount = 0;
            }
        }
        if (onGround && hasDoubleJump) {
            doubleJumpEnabled = true;
        }
        // Jump
        if (jumped) {
            audioData.Play(0);
            jumped = false;
            lastJump = Time.time;
            if (jumpCount == 0) {
                jumpCount = 1;
                onGround = false;
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                rb.AddForce(!boostNextJump ? Vector3.up * jumpForce : Vector3.up * boostJumpForce);
            } else if (jumpCount > 0) {
                //rb.velocity = new Vector3(0, rb.velocity.y -2.5f, 0);

                float max = jumpForce;
                float add = max - rb.velocity.y;
                if (boostNextJump) add = 10f;
                
                //float nextjump = jumpforce;
                //if (rb.velocity.y < 0.5f) { 
                //    rb.velocity = new vector3(0, 0, 0);
                //}
                //if (rb.velocity.y > 2) nextjump /= 2f;
                rb.AddForce(0, add, 0, ForceMode.Impulse);
                jumpCount = 0;
                if (doubleJumpEnabled) doubleJumpEnabled = false;
            }
            if (jumpCount != 0) {
                boostNextJump = false;
            }
        } 
        if (Input.GetKey(KeyCode.D) && rayCaster.moveRightEnabled) {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            //rb.AddForce(Vector3.right * moveSpeed);
            var velocity = rb.velocity;
            velocity.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            rb.velocity = velocity;
        }
        if (Input.GetKey(KeyCode.A) && rayCaster.moveLeftEnabled) {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            //rb.AddForce(Vector3.left * moveSpeed);
            var velocity = rb.velocity;
            velocity.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            rb.velocity = velocity;
        }
        Debug.Log("Spinning speed: " + rb.angularVelocity.z);
        if (onGround) {
            rb.angularVelocity = new Vector3(0,0,0);
        }
        if (Math.Round(transform.position.x, 2) > oldPosition && !onGround) // he's looking right
        {
            if(rb.angularVelocity.z > -rotationLimit)
                rb.AddRelativeTorque(new Vector3(0, 0, rotationMul * -Time.deltaTime), ForceMode.Impulse);
        }

        if (Math.Round(transform.position.x, 2) < oldPosition && !onGround) // he's looking left
        {
            if (rb.angularVelocity.z < rotationLimit)
                rb.AddRelativeTorque(new Vector3(0, 0,  rotationMul * Time.deltaTime), ForceMode.Impulse);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        oldPosition = Math.Round(transform.position.x, 2);
        StateManager.playerPosition = transform.position;

    }

    void OnPlayerInZone(bool inZone) {
        inJumpZone = inZone;
    }
   
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Col_Jump") {
            hasDoubleJump = true;
            EventManager.OnShowDoubleJumpIcon();
        }
    }

    void OnGameEnd() {
        hasDoubleJump = false;
        doubleJumpEnabled = false;
        lastJump = 0;
        jumpCount = 0;
    }
}
