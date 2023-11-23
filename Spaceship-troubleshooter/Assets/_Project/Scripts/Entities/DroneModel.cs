namespace Assets._Project.Scripts.Entities
{
    public class DroneModel
    {
        public bool IsAvailable;
        public float FixingTroubleTime => _fixingTroubleTime;

        private float _fixingTroubleTime;

        public DroneModel(float fixingTroubleTime)
        {
            _fixingTroubleTime = fixingTroubleTime;

            IsAvailable = false;
        }

        public void Upgrade()
        {
            if(_fixingTroubleTime > 5f)
            {
                _fixingTroubleTime -= 1f;
            }
        }
    }
}
