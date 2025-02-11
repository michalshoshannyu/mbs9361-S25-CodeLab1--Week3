using UnityEngine;

public class CameraStateMachineEvents : MonoBehaviour
{
    Animator _animator;

    //camera names
    public enum CameraTypes
    {
        NO_CHANGE = 0,
        GameStart = 1,
        Scene01_Start = 2,
        Scene02_Start = 3,
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        EventManager.instance.StartListening(EventManager.GameEvent.CHANGE_CAMERA, (object payload)
            =>
        {
            Debug.Log("Event Received: " + payload);
            ChangeCamera((CameraTypes)payload);
        });
    }


    public void ChangeCamera(int argument)
    {
        Debug.Log("imhere");
        ChangeCamera((CameraTypes)argument);
        
    }

    //camera triggers
    private void ChangeCamera(CameraTypes type)
    {
        switch (type)
        {
            case CameraTypes.GameStart:
                _animator.SetTrigger("GameStart");
                Debug.Log("Triggering GameStart camera transition");

                break;
            case CameraTypes.Scene01_Start:
                _animator.SetTrigger("Scene01_Start");
                Debug.Log("Triggering Scene01_Start camera transition");
                break;
            case CameraTypes.Scene02_Start:
                Debug.Log("Triggering Scene02_Start camera transition");
                Debug.Log("im also hereee");
                _animator.SetTrigger("Scene02_Start");
                break;
            case CameraTypes.NO_CHANGE:
                break;
            default:
                Debug.LogError("Unimplemented Camera-type - dude, concentrate");
                break;
        }
  
    }
}