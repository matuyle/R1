
public static class EventManager 
{
    public delegate void PressureButtonHandler(int buttonId);
    public static event PressureButtonHandler onPressureButtonE;
    public static void OnPressureButtonPushed(int buttonId) { if (onPressureButtonE != null) onPressureButtonE(buttonId); }

    public delegate void WheelActiveZoneHandler(bool playerInZone);
    public static event WheelActiveZoneHandler onPlayerInZoneE;
    public static void OnPlayerInZone(bool playerInZone) { if (onPlayerInZoneE != null) onPlayerInZoneE(playerInZone); }

    public delegate void CheckPointHandler(int id);
    public static event CheckPointHandler onPointTakenE;
    public static void OnPointTaken(int id) { if (onPointTakenE != null) onPointTakenE(id); }

    public delegate void GameEndHandler();
    public static event GameEndHandler onGameEndE;
    public static void OnGameEnd() { if (onGameEndE != null) onGameEndE(); }

    // Ui events
    public delegate void IsPausedHandler(bool isPaused);
    public static event IsPausedHandler onPauseE;
    public static void OnPause(bool isPaused) { if (onPauseE != null) onPauseE(isPaused); }

    public delegate void DoubleJumpImageHandler();
    public static event DoubleJumpImageHandler onShowDoubleJumpE;
    public static void OnShowDoubleJumpIcon() { if (onShowDoubleJumpE != null) onShowDoubleJumpE(); }



    //EventManager.OnPressureButtonPushed(id);
    //EventManager.onPressureButtonE += OnPressureButtonPushed;
    //EventManager.onPressureButtonE -= OnPressureButtonPushed;
}
