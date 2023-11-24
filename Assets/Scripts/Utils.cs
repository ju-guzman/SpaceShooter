using UnityEngine;

public static class Utils
{
    public static float GetCameraYSize()
    {
        return 2f * Camera.main.orthographicSize;
    }

    public static float GetCameraYSizeInWorldCoordinates()
    {
        return Camera.main.orthographicSize;
    }

    public static float GetCameraXSize() {

        return GetCameraYSize() * Camera.main.aspect;
    }
}
