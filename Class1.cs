namespace MetricUtils
{
    public static class Metrics
    {
        public static double CalculateMcc(int[] yTrue, int[] yPred)
        {
            if (yTrue.Length != yPred.Length)
                throw new ArgumentException("Vectors must be of the same length!");

            int tp = 0, tn = 0, fp = 0, fn = 0;

            for (int i = 0; i < yTrue.Length; i++)
            {
                if (yTrue[i] == 1 && yPred[i] == 1) tp++;
                else if (yTrue[i] == 0 && yPred[i] == 0) tn++;
                else if (yTrue[i] == 0 && yPred[i] == 1) fp++;
                else if (yTrue[i] == 1 && yPred[i] == 0) fn++;
            }

            double numerator = ((double)tp * tn) - ((double)fp * fn);
            double denominator = Math.Sqrt((double)(tp + fp) * (tp + fn) * (tn + fp) * (tn + fn));

            return denominator != 0 ? numerator / denominator : 0.0;
        }
    }

}
