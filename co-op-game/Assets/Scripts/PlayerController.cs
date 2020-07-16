using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float playerSpeed = 1;
    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        if (!isLocalPlayer) {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        playerRigidbody.velocity = (movement * playerSpeed);
    }
}
