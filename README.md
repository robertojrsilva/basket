# basket
Sample for Technical Assessment

🚀 Getting Started

0. Prerequisites
Visual Studio 2022 or later
.NET 6.0 SDK or later

1. Clone the repository
git clone https://github.com/your-username/your-repo.git

2. Running the BasketBackend
Open BasketBackend solution in Visual Studio.
Set it as the startup project.
Run the project (Ctrl + F5).
The Backend should be available at: 
	https://localhost:7034/ or
	http://localhost:5281/
Swagger UI is available at:
	https://localhost:7034/swagger/
	
3. Running the BasketFrontend
Open BasketFrontend solution in Visual Studio.
Set it as the startup project.
Update Backend base URL in program.cs (if necessary):
	builder.Services.AddScoped(sp =>
		new HttpClient { BaseAddress = new Uri("https://localhost:7034/") }
	);
Run the project (Ctrl + F5).
The Frontend will be available at:
	https://localhost:7264/ or
	http://localhost:5189/

🧪 Testing
In BasketBackend solution, open 

Run the tests (Ctrl + R and then T) or run the command:
dotnet test BasketBackend.Tests
