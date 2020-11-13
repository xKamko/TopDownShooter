using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerAim : MonoBehaviour
{
    
    public event EventHandler<onShootEventArgs> onShoot;
    public class onShootEventArgs : EventArgs
    {
        public Vector3 wandEndPoint;
        public Vector3 shootPosition;

    }
    

    public Transform aimTransform;
    public Transform aimWandEndPointTransform; 

    private void Update()
    {
        handleAiming();
    }

    private void handleAiming()
    {
        Vector3 mousePosition = GetMaouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, (angle));
        Debug.Log(angle);
    }

    


    // GetMaousePosition
    public static Vector3 GetMaouseWorldPosition()
    {
        Vector3 vec = GetMaouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMaouseWorldPositionWithZ()
    {
        return GetMaouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMaouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMaouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMaouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private void handleShooting()
    {
        Vector3 mousePosition = GetMaouseWorldPosition();

        if (Input.GetMouseButtonDown(0))
        {
            onShoot?.Invoke(this, new onShootEventArgs
            {
                wandEndPoint = aimWandEndPointTransform.position,
                shootPosition = mousePosition
            });
        }
    }

}
