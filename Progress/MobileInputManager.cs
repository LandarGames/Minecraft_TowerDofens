using UnityEngine;

public class MobileInputManager : MonoBehaviour
{
    public bool testInIspector = false;
    private bool activeContainer;
    private bool activeFireContainer = false;
    private bool mobile = false;
    private int firstCheckMobile = 0;

    public void ActiveMobileContainer()
    {
        activeContainer = !activeContainer;
        if (IsMobileDevice())
        {
            Progress.IsAndroid = true;
        }
    }


    private void Start()
    {
        // Вызывает JavaScript для проверки сенсорности устройства
        Application.ExternalEval("checkForTouchDevice()");
        ActiveMobileContainer();
    }

#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobile();

#endif
    public bool IsMobileDevice()
    {
        if (firstCheckMobile == 1)
            return mobile;
        firstCheckMobile = 1;


        var isMobile = false;

#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif


        if (isMobile)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mobile = true;
            return true;
        }
        else
        {
            if (testInIspector)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            mobile = testInIspector;
            return testInIspector;
        }
    }
}