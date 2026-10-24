# metricutils
MetricUtils is a lightweight, high-performance C# class library designed for calculating evaluation metrics for classification models. It is optimized for imbalanced datasets using the Confusion Matrix and Matthews Correlation Coefficient (MCC).

## Features
- **Matthews Correlation Coefficient (MCC):** Provides a balanced evaluation of binary classification models, accurately handling class imbalance (unlike Accuracy or F1-Score).
- **Confusion Matrix:** Fast, single-pass (`O(n)`) computation of True Positives, True Negatives, False Positives, and False Negatives.
- **Zero Dependencies:** Written in pure C# (compatible with .NET 8.0+ / .NET Standard).
- **Robust:** Includes built-in vector dimension validation and safe handling of division-by-zero scenarios.

## Installation & Setup
### Option 1: Direct DLL Reference
1. Build the project in Release mode (`dotnet build -c Release`).
2. Copy the `MetricUtils.dll` file from the `bin/Release/net8.0/` directory.
3. In your target project, add a reference to this DLL.

### Option 2: Project Reference (Within the same Solution)
Add the library project to your target application via the .NET CLI:
```bash
dotnet add reference path/to/MetricUtils.csproj
```

## Usage Example
To calculate metrics, import the `MetricUtils` namespace and pass two arrays of identical length:

```csharp
using System;
using MetricUtils;

class Program
{
    static void Main()
    {
        // Ground truth (correct labels)
        int[] yTrue = { 1, 0, 1, 1, 0, 1, 0, 0, 1, 0 };
        
        // Model predictions
        int[] yPred = { 1, 0, 1, 0, 0, 1, 0, 1, 1, 0 };

        try
        {
            // Calculate Matthews Correlation Coefficient
            double mcc = Metrics.CalculateMcc(yTrue, yPred);
            
            Console.WriteLine(\$"Matthews Correlation Coefficient (MCC): {mcc:F4}");
            // Output value will range from -1.0 to +1.0
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(\$"Validation Error: {ex.Message}");
        }
    }
}
```

## How it works
The library builds a confusion matrix under the hood and evaluates model performance using the standard Matthews formula:

$$MCC = \frac{TP \times TN - FP \times FN}{\sqrt{(TP + FP)(TP + FN)(TN + FP)(TN + FN)}}$$

- **+1.0** — Perfect prediction.
- **0.0** — Average random prediction (coin flip).
- **-1.0** — Total disagreement between prediction and observation.

## License 
This project is licensed under the [MIT](LICENSE) License. You are free to use, modify, and distribute this software for personal or commercial projects.

