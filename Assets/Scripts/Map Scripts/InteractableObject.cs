using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
  protected override void OnCollided(GameObject collidedObject)
  {
    if(Input.GetKeyDown("e"))
    {
        Debug.Log("e was pressed");
        OnInteract();
        
   }
  }

  protected virtual void OnInteract()
  {
        if (!z_Interacted)
        {
           z_Interacted = true; 
           Debug.Log("INTERACT WITH" + name);
        }

        
  }
}
