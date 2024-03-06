// See https://aka.ms/new-console-template for more information
/// <summary>
///  Top-level statements 
///  Код програми (оператори)  вищого рівня
/// </summary>
///
/*
AnyFunc();

/// <summary>
/// 
///  Top-level statements must precede namespace and type declarations.
/// At the top-level methods/functions can be defined and used
/// На верхньому рівні можна визначати та використовувати методи/функції
/// </summary>
void AnyFunc()
{
    Console.WriteLine(" Some function in top-level");
}
Console.WriteLine("Problems 1 ");
AnyFunc();
//  приклад класів
UserClass cl = new UserClass();
cl.Name = " UserClass top-level ";
Lab4CSharp.UserClass cl2 = new Lab4CSharp.UserClass();
cl2.Name = " UserClass namespace Lab4CSharp ";
Console.WriteLine(cl + "   " + cl2 + "   ");*/
using Lab4CSharp;
Console.WriteLine("Lab4 C# ");

static void Task1()
{
    //==================================
    // Creating a rectangle
    Rectangle rectangle = new Rectangle(3, 4, 3);

    // Printing sides
    rectangle.PrintSides();

    // Calculating perimeter and area
    Console.WriteLine("Perimeter: {0}", rectangle.CalculatePerimeter());
    Console.WriteLine("Area: {0}", rectangle.CalculateArea());

    // Checking if it's a square
    Console.WriteLine("Is Square: {0}", (bool)rectangle);

    // Incrementing sides
    rectangle++;
    Console.WriteLine("After incrementing:");
    rectangle.PrintSides();

    // Multiplying sides by a scalar
    Rectangle scaledRectangle = rectangle * 2;
    Console.WriteLine("Scaled Rectangle:");
    scaledRectangle.PrintSides();

    // Converting to string and back
    string rectangleString = (string)rectangle;
    Console.WriteLine("Converted to string: {0}", rectangleString);
    Rectangle newRectangle = (Rectangle)rectangleString;
    Console.WriteLine("Converted back to Rectangle:");
    newRectangle.PrintSides();

    // Decrementing sides
    newRectangle--;
    Console.WriteLine("After decrementing:");
    newRectangle.PrintSides();

    // Accessing sides using index
    Console.WriteLine("Side at index 0: {0}", newRectangle[0]);
    Console.WriteLine("Side at index 1: {0}", newRectangle[1]);
    Console.WriteLine("Color at index 2: {0}", newRectangle[2]);
}

static void Task2()
{
    // Creating vectors
    VectorShort v1 = new VectorShort(3, 5);
    VectorShort v2 = new VectorShort(3, 10);

    // Printing vectors
    Console.WriteLine("Vector v1:");
    v1.Print();

    Console.WriteLine("Vector v2:");
    v2.Print();

    // Performing operations
    VectorShort sum = v1 + v2;
    Console.WriteLine("Sum of vectors v1 and v2:");
    sum.Print();

    VectorShort scalarProduct = v1 * 2;
    Console.WriteLine("Scalar product of vector v1 and 2:");
    scalarProduct.Print();

    // Checking vector length
    Console.WriteLine($"Length of vector v1: {v1.Lenth}");

    // Checking code error
    Console.WriteLine($"Code error of vector v1: {v1.CodeError}");

    // Incrementing vector v1
    ++v1;
    Console.WriteLine("After incrementing vector v1:");
    v1.Print();

    // Decrementing vector v2
    --v2;
    Console.WriteLine("After decrementing vector v2:");
    v2.Print();

    // Checking if vectors are empty
    Console.WriteLine($"Is vector v1 empty? {(bool)v1}");
    Console.WriteLine($"Is vector v2 empty? {(bool)v2}");

    // Performing bitwise NOT operation
    VectorShort bitwiseNot = ~v1;
    Console.WriteLine("Bitwise NOT of vector v1:");
    bitwiseNot.Print();

    // Performing bitwise OR operation
    VectorShort bitwiseOr = v1 | v2;
    Console.WriteLine("Bitwise OR of vectors v1 and v2:");
    bitwiseOr.Print();

    // Performing bitwise XOR operation
    VectorShort bitwiseXor = v1 ^ v2;
    Console.WriteLine("Bitwise XOR of vectors v1 and v2:");
    bitwiseXor.Print();

    // Performing bitwise AND operation
    VectorShort bitwiseAnd = v1 & v2;
    Console.WriteLine("Bitwise AND of vectors v1 and v2:");
    bitwiseAnd.Print();
}

static void Task3()
{
    // Create matrices
    MatrixShort mat1 = new MatrixShort(2, 2, 1);
    MatrixShort mat2 = new MatrixShort(2, 2, 2);

    // Print matrices
    Console.WriteLine("Matrix 1:");
    mat1.Print();
    Console.WriteLine("Matrix 2:");
    mat2.Print();

    // Add matrices
    MatrixShort matSum = mat1 + mat2;
    Console.WriteLine("Sum of matrices:");
    matSum.Print();

    // Multiply matrices
    MatrixShort matProd = mat1 * mat2;
    Console.WriteLine("Product of matrices:");
    matProd.Print();

    // Check equality
    Console.WriteLine($"Matrices are equal: {mat1 == mat2}");

    // Check inequality
    Console.WriteLine($"Matrices are not equal: {mat1 != mat2}");

    // Check if one matrix is less than another
    Console.WriteLine($"Matrix 1 is less than matrix 2: {mat1 < mat2}");

    // Check if one matrix is greater than another
    Console.WriteLine($"Matrix 1 is greater than matrix 2: {mat1 > mat2}");

    // Check if one matrix is less than or equal to another
    Console.WriteLine($"Matrix 1 is less than or equal to matrix 2: {mat1 <= mat2}");

    // Check if one matrix is greater than or equal to another
    Console.WriteLine($"Matrix 1 is greater than or equal to matrix 2: {mat1 >= mat2}");

}

static void ShowMenu()
{
    string[] menuStrings =
    {
                "1. Task 1!",
                "2. Task 2!",
                "3. Task 3!"
            };
    int currentOprtion = 0;
    ConsoleKeyInfo keyInfo;
    int choice = 0;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Lab 4 CSharp");
        PrintMenu(menuStrings, currentOprtion);


        keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
        {
            currentOprtion = currentOprtion + 1 <= menuStrings.Length - 1 ? currentOprtion + 1 : 0;
        }
        else if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
        {
            currentOprtion = currentOprtion - 1 >= 0 ? currentOprtion - 1 : menuStrings.Length - 1;
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            choice = currentOprtion;
            break;
        }
    }
    switch (choice)
    {
        case 0:
            Task1();
            break;
        case 1:
            Task2();
            break;
        case 2:
            Task3();
            break;
        default:
            break;
    }
}
static void PrintMenu(string[] menuString, int choosenString)
{
    for (int i = 0; i < menuString.Length; i++)
    {
        if (i == choosenString)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        Console.WriteLine(menuString[i]);
        if (i == choosenString)
        {
            Console.ResetColor();
        }
    }
}

while (true)
{
    Console.Clear();
    try
    {
        ShowMenu();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

/// <summary>
/// 
/// Top-level statements must precede namespace and type declarations.
/// Оператори верхнього рівня мають передувати оголошенням простору імен і типу.
/// Створення класу(ів) або оголошенням простору імен є закіченням  іструкцій верхнього рівня
/// 
/// </summary>

/*class UserClass
{
    public string Name { get; set; }
};
*/