var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    string? operand;
    string? firstNumber;
    string? secondNumber;
    string[] allowedOperations = { "add", "subtract", "multiply", "divide", "modulo" };

    operand = context.Request.Query["operation"];
    firstNumber = context.Request.Query["firstNumber"];
    secondNumber = context.Request.Query["secondNumber"];

    double firstNumberAsDouble;
    double secondNumberAsDouble;

    context.Response.StatusCode = 400;
    if (operand is null)
    {
        await context.Response.WriteAsync("Supply operation");
    }
    else if (firstNumber is null)
    {
        await context.Response.WriteAsync("Supply first number");
    }
    else if (secondNumber is null)
    {
        await context.Response.WriteAsync("Supply second number");
    }
    else if (!double.TryParse(firstNumber, out firstNumberAsDouble))
    {
        await context.Response.WriteAsync("First number must be number");
    }
    else if (!double.TryParse(secondNumber, out secondNumberAsDouble))
    {
        await context.Response.WriteAsync("Second number must be number");
    }
    else if (secondNumberAsDouble == 0)
    {
        await context.Response.WriteAsync("Second number can't be 0");
    }
    else if (!allowedOperations.Contains(operand))
    {
        await context.Response.WriteAsync("Incorrect operation");
    }
    else
    {
        context.Response.StatusCode = 200;
        if (operand == allowedOperations[0])
        {
            await context.Response.WriteAsync($"{firstNumberAsDouble + secondNumberAsDouble}");
        }
        else if (operand == allowedOperations[1])
        {
            await context.Response.WriteAsync($"{firstNumberAsDouble - secondNumberAsDouble}");
        }
        else if (operand == allowedOperations[2])
        {
            await context.Response.WriteAsync($"{firstNumberAsDouble * secondNumberAsDouble}");
        }
        else if (operand == allowedOperations[3])
        {
            await context.Response.WriteAsync($"{firstNumberAsDouble / secondNumberAsDouble}");
        }
        else if (operand == allowedOperations[4])
        {
            await context.Response.WriteAsync($"{firstNumberAsDouble % secondNumberAsDouble}");
        }
    }

});


app.Run();