$ErrorActionPreference = "Stop"

$ProjectName = "CleanArchitectureCRUD"
$BaseDir = "c:\Users\mahbub.arju\OneDrive - BRAC IT Services Limited\Dotnet Journey\$ProjectName"

if (-not (Test-Path -Path $BaseDir)) {
    New-Item -ItemType Directory -Path $BaseDir | Out-Null
}

Set-Location -Path $BaseDir

dotnet new sln -n $ProjectName

# Create layers
dotnet new classlib -n "$ProjectName.Domain"
dotnet new classlib -n "$ProjectName.Application"
dotnet new classlib -n "$ProjectName.Infrastructure"
dotnet new webapi -n "$ProjectName.API"

# Add projects to solution
dotnet sln add "$ProjectName.Domain\$ProjectName.Domain.csproj"
dotnet sln add "$ProjectName.Application\$ProjectName.Application.csproj"
dotnet sln add "$ProjectName.Infrastructure\$ProjectName.Infrastructure.csproj"
dotnet sln add "$ProjectName.API\$ProjectName.API.csproj"

# Add project references
dotnet add "$ProjectName.Application\$ProjectName.Application.csproj" reference "$ProjectName.Domain\$ProjectName.Domain.csproj"

dotnet add "$ProjectName.Infrastructure\$ProjectName.Infrastructure.csproj" reference "$ProjectName.Application\$ProjectName.Application.csproj"
dotnet add "$ProjectName.Infrastructure\$ProjectName.Infrastructure.csproj" reference "$ProjectName.Domain\$ProjectName.Domain.csproj"

dotnet add "$ProjectName.API\$ProjectName.API.csproj" reference "$ProjectName.Application\$ProjectName.Application.csproj"
dotnet add "$ProjectName.API\$ProjectName.API.csproj" reference "$ProjectName.Infrastructure\$ProjectName.Infrastructure.csproj"

Write-Host "Clean Architecture Solution Setup Completed!"
