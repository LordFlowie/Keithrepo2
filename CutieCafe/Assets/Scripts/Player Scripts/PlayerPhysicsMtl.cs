using UnityEngine;

public class PlayerPhysicsMtl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhysicsMaterial rubber = new PhysicsMaterial("Rubber");
        // Set bounciness to 1 (max)
        rubber.bounciness = 1.0f;
        // Set friction when static
        rubber.staticFriction = 10.6f;
        // Set friction when moving
        rubber.dynamicFriction = 10.6f;
        // Update the Spheres Collider
        GetComponent<CapsuleCollider>().material = rubber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
