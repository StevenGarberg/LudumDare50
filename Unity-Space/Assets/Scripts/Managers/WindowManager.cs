namespace LudumDare50.Unity.Managers
{
    public class WindowManager
    {
        public static WindowManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}