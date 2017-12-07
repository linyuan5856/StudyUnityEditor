using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosEditor : MonoBehaviour
{

    public Texture mTexture;
    public Transform target;
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        if (mTexture == null)
            return;
        Gizmos.DrawGUITexture(new Rect(20, 20, 20f, 20f), mTexture);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(this.transform.position, new Vector3(2f, 2f, 2f));
        
        Gizmos.DrawIcon(this.transform.position + new Vector3(2, 2, 0), "node3", true);
    }

    /// <summary>
	/// Callback to draw gizmos only if the object is selected.
	/// </summary>
	void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
        }
	}
}
