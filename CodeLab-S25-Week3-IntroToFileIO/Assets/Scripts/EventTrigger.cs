using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Rigidbody rg; 

   
    void Update()
    {
        if (rg == null)
        {
            Debug.LogError("Rigidbody is not assigned!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rg.linearVelocity = new Vector3(5, rg.linearVelocity.y, rg.linearVelocity.z); // Move right
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rg.linearVelocity = new Vector3(-5, rg.linearVelocity.y, rg.linearVelocity.z); // Move left
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            rg.linearVelocity = rg.linearVelocity * 0.0001f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name);
            EventManager.instance.TriggerEvent(EventManager.GameEvent.ENTER_PATH,other.name);
            EventManager.instance.TriggerEvent(EventManager.GameEvent.CHANGE_CAMERA,CameraStateMachineEvents.CameraTypes.Scene02_Start);
        }
    }
}