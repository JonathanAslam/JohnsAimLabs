using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public void Hit() {
        transform.position = TargetContainerScript.Instance.GetRandomSpawnPos();
    }
}
