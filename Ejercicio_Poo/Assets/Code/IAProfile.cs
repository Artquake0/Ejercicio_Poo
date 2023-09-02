using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAProfile : MonoBehaviour
{
    protected float lookDir;
    [SerializeField] protected float detectTime;
    protected Vector2 detectionField;
    [SerializeField] protected GameObject Player;
    [Range(0f, 360f)]
    [SerializeField] protected float visionAngle = 30f;
    [SerializeField] protected float viewDistance = 10f;
    

    protected void OnDrawGizmos()
    {
        if (visionAngle > 0) return;
        float halfvision = visionAngle / 2;

        Vector2 p1, p2;

        p1 = pointForAngle(halfvision, viewDistance);
        p2 = pointForAngle(-halfvision, viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, (Vector2)this.transform.position + p1);
        Gizmos.DrawLine(this.transform.position, (Vector2)this.transform.position + p2);

        Gizmos.DrawRay(this.transform.position, this.transform.right * 4f);
    }

    protected Vector3 pointForAngle(float angle, float distance)
    {
        return this.transform.TransformDirection(new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad))*distance);
    }

    protected abstract void ExecuteProfile();

    protected void onPlayerDetected()
    {
        Debug.Log("Player Detected!");
    }

    protected void detectPlayer()
    {
        Vector2 playerVector = this.Player.transform.position - this.transform.position;
        if(Vector3.Angle(playerVector.normalized, this.transform.right) < visionAngle)
        {
            if(playerVector.magnitude < viewDistance) 
            {
                onPlayerDetected();
            }
        }
    }
}
