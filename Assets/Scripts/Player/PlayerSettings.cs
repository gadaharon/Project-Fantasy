using System.Collections;
using UnityEngine;

public class PlayerSettings : Singleton<PlayerSettings>
{
    public Transform PlayerBody => playerBody;

    [SerializeField] Transform playerBody;

    public void SetPlayerLocation(Transform location)
    {
        playerBody.gameObject.GetComponent<CharacterController>().enabled = false;
        playerBody.position = location.position;
        playerBody.rotation = location.rotation;
        playerBody.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
