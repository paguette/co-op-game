using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float speed = 1;
    public float damage = 1;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Attack(float attackHorizontal, float attackVertical) {

    }

    void FixedUpdate() {
        if (!isLocalPlayer) {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        playerRigidbody.velocity = (movement * speed);

        float attackHorizontal = Input.GetAxis("FireHorizontal");
        float attackVertical = Input.GetAxis("FireVertical");

        Attack(attackHorizontal, attackVertical);
    }
}
