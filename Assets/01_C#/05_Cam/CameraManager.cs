using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void FollowObj(GameObject obj)
    {
        Vector3 followPossition = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);

        transform.position = followPossition;
    }
}
