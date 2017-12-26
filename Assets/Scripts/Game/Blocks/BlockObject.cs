using UnityEngine;

public class BlockObject : MonoBehaviour
{
    [SerializeField] private Material[] materials = null;
    [SerializeField] private MeshRenderer blockRenderer = null;

    public void SetPlayerID(int playerID)
    {
        this.blockRenderer.material = this.materials[playerID];
    }
}