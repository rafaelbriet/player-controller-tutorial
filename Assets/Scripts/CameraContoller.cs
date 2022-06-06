using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector2 targetOffset;

    private void LateUpdate()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mouseScreenPosition.x = (mouseScreenPosition.x - 0.5f) * 2f;
        mouseScreenPosition.y = (mouseScreenPosition.y - 0.5f) * 2f;

        mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, -1f, 1f);
        mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, -1f, 1f);

        float offsetX = targetOffset.x * mouseScreenPosition.x;
        float offsetY = targetOffset.y * mouseScreenPosition.y;

        Vector3 cameraPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);

        transform.position = cameraPosition;
    }
}
