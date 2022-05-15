public class StaticValues
{
    public static bool soundEnabled = true;
    public static float xSensivity = 50;
    public static float ySensivity = 50;

    public bool GetSound() {
        return soundEnabled;
    }
    public void InvSound() {
        soundEnabled = !soundEnabled;
    }
    public float GetXSens() {
        return xSensivity;
    }
    public void SetXSens(float xSens) {
        xSensivity = xSens;
    }
    public float GetYSens() {
        return ySensivity;
    }
    public void SetYSens(float ySens) {
        ySensivity = ySens;
    }
}
