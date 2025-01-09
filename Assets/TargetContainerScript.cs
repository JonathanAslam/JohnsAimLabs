using UnityEngine;

public class TargetContainerScript : MonoBehaviour
{
    public static TargetContainerScript Instance;

    void Awake() {
        Instance = this;
    }

    [SerializeField] BoxCollider boxCollider;

    public Vector3 GetRandomSpawnPos() {
        // add boxCollider.center and transform.position together since the transform of the component and boxCollider position are not the same values, so we need to account for both and add together
        Vector3 center = boxCollider.center + transform.position;
        // get total length of the box collider with boxCollider.size.x and divide by 2 to get length of half. from center. the minimum value would be (center x-value) - (length/2)
        // if we had a box, to get the minimum position from a coordinate plane, you would find the center of the length, divide length by 2, and subtract center - 1/2(length)
        // to get the max posotion, you would do the same but add instead: center + 1/2(length)
        float minimumX = center.x - boxCollider.size.x / 2f;
        float maximumX = center.x + boxCollider.size.x / 2f;
        // same concept for height
        float minimumY = center.y - boxCollider.size.y / 2f;
        float maximumY = center.y + boxCollider.size.y / 2f;
        // same concept for z. this is a 3d game so there is depth
        float minimumZ = center.z - boxCollider.size.z / 2f;
        float maximumZ = center.z + boxCollider.size.z / 2f;

        // generate random values within the range for x, y, z. these randomly generated each time we need to generate a new target.
        float randomX = Random.Range(minimumX,maximumX);
        float randomY = Random.Range(minimumY,maximumY);
        float randomZ = Random.Range(minimumZ,maximumZ);

        //generate random position
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }
}
