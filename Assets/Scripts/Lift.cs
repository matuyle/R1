using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private float startingPosY;
    public bool isMoving = false;
    private float speed = 0.5f;
    // Start is called before the first frame update
    void Start() {
        startingPosY = transform.position.y;
        //StartCoroutine(StartLifting());
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (transform.position.y < 13 && isMoving) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (isMoving) {
            isMoving = false;
            StartCoroutine(WaitAndReset());
            // wait for seconds and move back to normal position
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(StartLifting());
        }
    }

    IEnumerator StartLifting() {
        if (!isMoving) {
            yield return new WaitForSeconds(2f);
            isMoving = true;
        }
    }

    IEnumerator WaitAndReset() {
        yield return new WaitForSeconds(2f);
        transform.position = (new Vector3(transform.position.x, startingPosY, transform.position.z));
    }
}
