using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Guard : IAProfile
{ 
    [SerializeField] float waitForTurn;
    private void Update()
    {
        this.detectTime -= Time.deltaTime;
        if (this.detectTime < 0)
        {
            detectPlayer();
            this.detectTime = 2;
        }

        waitForTurn -= Time.deltaTime;
        if (waitForTurn < 0)
        {
            ExecuteProfile();
            waitForTurn = 5;
        }
      
    }

    protected override void ExecuteProfile()
    {
        this.lookDir = Random.value;
        if (lookDir < 0.25f)
            this.transform.Rotate(new Vector3(0, 0, 0));
        else if (lookDir > 0.25f && lookDir < 0.50f)
            this.transform.Rotate(new Vector3(0, 0, 90));
        else if (lookDir > 0.50f && lookDir < 0.75f)
            this.transform.Rotate(new Vector3(0, 0, 180));
        else
            this.transform.Rotate(new Vector3(0, 0, 270));
    }
}
