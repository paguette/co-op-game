using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerController
{
    // Start is called before the first frame update
    public override void Attack(float attackHorizontal, float attackVertical) {
        Debug.Log("Woosh fireballz" + attackHorizontal + " " + attackVertical);
    }
}
