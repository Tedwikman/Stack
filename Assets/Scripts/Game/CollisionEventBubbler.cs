using UnityEngine;

public class CollisionEventBubbler : MonoBehaviour
{
    public event System.Action<Collision> OnEnteredCollision;
    public event System.Action<Collision> OnContinuesCollision;
    public event System.Action<Collision> OnExitCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(OnEnteredCollision != null)
        { OnEnteredCollision(collision); }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(OnContinuesCollision != null)
        { OnContinuesCollision(collision); }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(OnExitCollision != null)
        { OnExitCollision(collision); }
    }
}