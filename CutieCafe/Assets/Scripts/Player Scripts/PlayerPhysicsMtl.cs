using UnityEngine;

public class PlayerPhysicsMtl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhysicsMaterial rubber = new PhysicsMaterial("Rubber");
        rubber.bounciness = 1.0f;
        rubber.staticFriction = 10.6f;
        rubber.dynamicFriction = 10.6f;
        GetComponent<CapsuleCollider>().material = rubber;
    }
}
