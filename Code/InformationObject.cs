namespace Code
{
    public class InformationObject
    {
        public string TextField { get; set; }
        public int CountField { get; set; }
    }

    public class InformationObjects
    {
        public static InformationObject[] _informationObjects;

        static InformationObjects()
        {
            _informationObjects = new InformationObject[4];
        }

        public InformationObject this[int index]
        {
            get
            {
                return _informationObjects[index];
            }
            set
            {
                _informationObjects[index] = value;
            }
        }
    }
}