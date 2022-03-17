using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPoint(List<Transform> points, float a) {
        List<Vector3> result = new List<Vector3>();
        result = ConvertPoints(points);
        int saveNum = 150;
        while(saveNum >= 0) {
           saveNum--;
           result = Rec(result, a);
           if(result.Count == 1)
                break;
        }
        return result[0];
    }

    public static List<Vector3> ConvertPoints(List<Transform> pointsTransform)
    {
        List<Vector3> dataPos = new List<Vector3>();
        for(int i = 0; i < pointsTransform.Count; i++)
            dataPos.Add(new Vector3(pointsTransform[i].position.x, pointsTransform[i].position.y, pointsTransform[i].position.z));
        return dataPos;
    }

    public static List<Vector3> Rec(List<Vector3> pointsRec, float b)
    {
        List<Vector3> dataRec = new List<Vector3>();
        for(int i = 0; i < pointsRec.Count - 1; i++) {
            if(i != pointsRec.Count)
            {
                Vector3 p = Vector3.Lerp(pointsRec[i], pointsRec[i + 1], b);
                dataRec.Add(p);
            }
        }
        return dataRec;
    }

    public static Vector3 GetFirstDerivative(List<Transform> points, float a) {
        a = Mathf.Clamp01(a);
        float oneMinusT = 1f - a;
        return new Vector3(0, 0, 0);
    }
}
