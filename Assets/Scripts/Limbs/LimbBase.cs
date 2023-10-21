using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LimbBase : MonoBehaviour
{
    public LimbEnum limbType;
    [SerializeField] Sprite limbSprite;
    [SerializeField] float launchForce;

    /// <summary>
    /// Launches the player character in the direction towards the mouse cursor with a force of launchForce
    /// </summary>
    public virtual void LaunchPlayer()
    {
        Rigidbody2D playerRigid = transform.parent.parent.GetComponent<Rigidbody2D>();
        Vector2 forceDir = (playerRigid.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        //Debug.Log(forceDir);
        playerRigid.AddForce(forceDir * launchForce, ForceMode2D.Impulse);
    }
}
