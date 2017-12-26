using UnityEngine;

public class PredictionBlock : MonoBehaviour
{
    private float scaleFactor
    { get { return this.transform.localScale.x; } }

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
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Ray cameraRay = GetCameraRay();
        RaycastHit hit;
        if(!Physics.Raycast(cameraRay, out hit))
        { return; }

        Vector3 newPos = hit.point + (Vector3.up * 0.5f * scaleFactor);
        this.transform.position = newPos;
    }

    private Ray GetCameraRay()
    {
        Vector3 cameraPos = this.cameraTransform.position;
        Vector3 cameraForward = this.cameraTransform.forward;

        return new Ray(cameraPos, cameraForward);
    }
}