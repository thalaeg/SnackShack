namespace SnackShack
{
    public class OrderTimer
    {
        private int numberOfSandwhiches;

        public OrderTimer(int numberOfSandwhiches)
        {
            this.numberOfSandwhiches = numberOfSandwhiches;
        }

        public string GetIntroText()
            => $"{numberOfSandwhiches} sandwhich order(s) placed, start making sandwich 1";

        public string MakeSchedule()
        {
            var timer = "0:00";
            if (numberOfSandwhiches == 0)
                return timer;

            timer += " " + GetIntroText() + "\n1:00 serve sandwich 1";
            var timeCount = 60;
            BuildTimer(ref timer, ref timeCount);
            return timer;

            void BuildTimer(ref string timer, ref int timeCount)
            {
                for (int i = 2; i < numberOfSandwhiches + 1; i++)
                {
                    BuildMakeSandwhich(ref timer, ref timeCount, i);
                    BuildServeSandwhich(ref timer, ref timeCount, i);
                }

                static void BuildMakeSandwhich(ref string timer, ref int timeCount, int i)
                {
                    timeCount += 30;
                    timer += $"\n{timeCount / 60}:{GetSeconds(timeCount)} make sandwich {i}";
                }

                static void BuildServeSandwhich(ref string timer, ref int timeCount, int i)
                {
                    timeCount += 60;
                    timer += $"\n{timeCount / 60}:{GetSeconds(timeCount)} serve sandwich {i}";
                }
            }

            static string GetSeconds(int timeCount)
            {
                var secondsString = (timeCount % 60).ToString();
                if (secondsString == "0")
                    secondsString = "00";
                return secondsString;
            }            
        }

        public string GetCustomerView()
        {
            if (numberOfSandwhiches * 90 >= 300)
                return $"Sandwhich {numberOfSandwhiches} can not be completed in time.";
            else
                return "";
        }
    }
}
