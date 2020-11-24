using UnityEngine;
using UnityEngine.UI;

namespace Quartzified
{
    /// <summary>
    /// Different Input Functions using the Old Input System
    /// </summary>
    public class Inputs
    {
        public class Mobile
        {
            /// <summary>
            /// Returns the Pinch amount
            /// </summary>
            /// <returns></returns>
            public static float GetPinch()
            {
                if (Input.touchCount == 2)
                {
                    Touch firstTouch = Input.GetTouch(0);
                    Touch secondTouch = Input.GetTouch(1);

                    Vector2 firstTouchOldPos = firstTouch.position - firstTouch.deltaPosition;
                    Vector2 secondTouchOldPos = secondTouch.position - secondTouch.deltaPosition;

                    float prevTouchDeltaMag = (firstTouchOldPos - secondTouchOldPos).magnitude;
                    float touchDeltaMag = (firstTouch.position - secondTouch.position).magnitude;

                    return touchDeltaMag - prevTouchDeltaMag;
                }
                return 0;
            }
        }

    }
}
