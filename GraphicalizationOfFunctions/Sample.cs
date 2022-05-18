namespace GraphicalizationOfFunctions
{
    class Sample
    {
        public static void Start()
        {
            if(1 == 1)
            {
                return;
            }
        }

        public static void StaticFunction()
        {
            var a = 0;
            switch (a)
            {
                case 1:
                    return;
                case 2:
                    return;
                case 3:
                    return;
            }
        }

        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
