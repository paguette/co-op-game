using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    public string localPlayerClass;

    public GameManager gameManager;

    void Start() {
        gameManager = GetComponent<GameManager>();
    }
    
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        GameObject chosenClass = null;
        // Find fitting class
        foreach(GameObject availableClass in gameManager.availableClasses) {
            if (availableClass.name == localPlayerClass) {
                // Found the class
                chosenClass = availableClass;
                break;
            }
        }

        if (chosenClass == null) {
            Debug.LogError("Could not find valid class for " + localPlayerClass);
            return;
        }

        var player = (GameObject)GameObject.Instantiate(chosenClass, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        Debug.Log("Client has requested to get his player added to the game");
    }
}
