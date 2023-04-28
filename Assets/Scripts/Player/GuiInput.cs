
using UnityEngine;
using UnityEngine.UI;

public class GuiInput : MonoBehaviour
{
    Vector2 axies;

    public void UpPress()    
    {
        axies.y = 1;
    }
    public void UpRelease()    
    {
        axies.y = 0;
    }
    public void DownPress()    
    {
        axies.y = -1;
    }
    public void DownRelease()    
    {
        axies.y = 0;
    }

    public void LeftPress() 
    {
        axies.x = -1;
    }
    public void LeftRelease() 
    {
        axies.x = 0;
    }
    public void RightPress() 
    {
        axies.x = 1;
    }
    public void RightRelease() 
    {
        axies.x = 0;
    }
    // Update is called once per frame

    public static GuiInput Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);

        else
            Instance = this;
    }
    public Vector2 getAxies()
    {
        return axies;
    }

}
