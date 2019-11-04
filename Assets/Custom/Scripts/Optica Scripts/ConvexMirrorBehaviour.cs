﻿using UnityEngine;


public class ConvexMirrorBehaviour : IMirrorBehaviour
{
    
    public ConvexRaysBehaviour RaysBehaviour;

    public float Radius;


    public void Start()
    {
        RaysBehaviour.Initialize(RealObject, this);
        PositionVirtualImage();
    }

    public Vector3 GetCenter()
    {
        Vector3 center = transform.position;
        center.z += Radius;
        return center;
    }

    public Vector3 GetFocalPoint()
    {
        Vector3 focal = transform.position;
        focal.z += Radius / 2;
        return focal;
    }


    private void PositionVirtualImage()
    {
        Vector3 convergingPoint = RaysBehaviour.ConvergentPoint;
        float imageHeight = convergingPoint.y - transform.position.y;

        Vector3 targetPos = convergingPoint;
        targetPos.y = 0;

        VirtualImage.transform.localScale = new Vector3(imageHeight, imageHeight, 1);
        VirtualImage.transform.localPosition = targetPos;
    }

}
