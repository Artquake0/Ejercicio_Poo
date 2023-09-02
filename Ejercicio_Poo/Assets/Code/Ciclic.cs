using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciclic : IAProfile
{
    int WaypointIndex = 0;
    float speed = 5f;
    [SerializeField] GameObject[] Waypoints;


    void Update()
    {
        this.detectTime -= Time.deltaTime;
        if (this.detectTime < 0)
        {
            detectPlayer();
            this.detectTime = 2;
        }


        ExecuteProfile();
    }

    protected override void ExecuteProfile()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.Waypoints[WaypointIndex].transform.position, this.speed * Time.deltaTime);

        if (this.transform.position == this.Waypoints[WaypointIndex].transform.position)
        {
            if(WaypointIndex == 3)
            {
                WaypointIndex = 0;
                return;
            }
            WaypointIndex++;
        }

    }
}
