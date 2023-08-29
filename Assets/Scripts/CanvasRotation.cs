using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    void LateUpdate()
    {
        // Recursively find the topmost parent in the hierarchy
        Transform topParent = transform.parent;
        while (topParent.parent != null)
        {
            topParent = topParent.parent;
        }

        // Get the current rotation of the topmost parent
        Quaternion topParentRotation = topParent.rotation;

        // Convert the current rotation to Euler angles
        Vector3 topParentEulerAngle = topParentRotation.eulerAngles;

        // Negate the Z angle
        float z = -topParentEulerAngle.z;

        // Get the current rotation of the child object
        Quaternion childRotation = transform.localRotation;

        // Convert the rotation to Euler angles
        Vector3 childEulerAngle = childRotation.eulerAngles;

        // Apply the negated Z angle
        childEulerAngle.z = z;

        // Convert the modified Euler angles back to a rotation
        Quaternion modifiedRotation = Quaternion.Euler(childEulerAngle);

        // Apply the modified rotation to the child object
        transform.localRotation = modifiedRotation;
    }
}
