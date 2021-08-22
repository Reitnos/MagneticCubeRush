using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontal;

    public float Horizontal
    {
        get { return horizontal; }
        protected set { horizontal = value; }
    }

    private float vertical;

    public float Vertical
    {
        get { return vertical; }
        protected set { vertical = value; }
    }

}
