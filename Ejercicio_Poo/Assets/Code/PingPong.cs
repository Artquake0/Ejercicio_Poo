using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PingPong : IAProfile
{
    int WaypointIndex = 0;
    float speed = 5f;
    bool completed = false;
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
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.Waypoints[WaypointIndex].transform.position, this.speed*Time.deltaTime);

        if (this.transform.position == this.Waypoints[WaypointIndex].transform.position)
        {
            if (WaypointIndex < 2 && completed == false)
                WaypointIndex++;
            if (WaypointIndex == 2 && this.transform.position == this.Waypoints[WaypointIndex].transform.position)
                completed = true;
            if(completed == true)
                WaypointIndex--;
            if(WaypointIndex == 0)
                completed = false;
        }

    }

}
