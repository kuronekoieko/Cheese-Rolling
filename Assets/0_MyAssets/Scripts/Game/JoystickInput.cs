using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JoystickInput
{
    static Vector3 downPos;
    static float radius = 1;

    /// <summary>
    /// 指定の半径を上限として、ドラッグした量を-1~1にまるめて返す
    /// </summary>
    /// <value></value>
    public static Vector2 MouseDragVecNormalized
    {
        get
        {
            var drag = MouseDragVecInch;
            if (drag.sqrMagnitude > radius * radius)
            {
                drag = drag.normalized;
            }
            drag /= radius;
            return drag;
        }
    }

    /// <summary>
    /// 端末の解像度に関係なく、物理的に指をドラッグした距離(インチ)を返す
    /// </summary>
    /// <value></value>
    public static Vector2 MouseDragVecInch
    {
        get
        {
            var drag = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                downPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                drag = Input.mousePosition - downPos;
                // https://indie-du.com/entry/2016/08/15/142051
                drag /= Screen.dpi;
            }
            return drag;
        }
    }
}
