using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform cameraTransform = null;

    private void Start()
    {
        StoreCamera();
    }

    private void StoreCamera()
    {
        this.cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if(AssertIsMobile())
        { MobileInput(); }
        else
        { ComputerInput(); }
    }

    private bool AssertIsMobile()
    {
        return Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer;
    }

    private void MobileInput()
    {
        if(Input.touchCount < 1)
        { return; }

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Ray cameraRay = GetCameraRay();
                RaycastHit hit;
                if(!Physics.Raycast(cameraRay, out hit))
                { return; }

                MainMessenger.Instance.PlayerTapped(hit);
                break;
            }
        }
    }

    private void ComputerInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = GetCameraRay();
            RaycastHit hit;
            if(!Physics.Raycast(cameraRay, out hit))
            { return; }

            MainMessenger.Instance.PlayerTapped(hit);
        }
    }

    private Ray GetCameraRay()
    {
        Vector3 cameraPos = this.cameraTransform.position;
        Vector3 cameraForward = this.cameraTransform.forward;

        return new Ray(cameraPos, cameraForward);
    }
}