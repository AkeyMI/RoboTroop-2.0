using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] Room room = default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            room.ActivateRoom();
        }
    }
}
