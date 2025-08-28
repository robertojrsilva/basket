# basket
Sample for Technical Assessment

🚀 Getting Started

0. Prerequisites<br>
Visual Studio 2022 or later<br>
.NET 6.0 SDK or later

1. Clone the repository<br>
git clone [https://github.com/robertojrsilva/basket.git](https://github.com/robertojrsilva/basket.git)<br>

2. Running the BasketBackend<br>
Open BasketBackend solution in Visual Studio.<br>
Set it as the startup project.<br>
Run the project (Ctrl + F5).<br>
The Backend should be available at: <br>
	<tab>https://localhost:7034/ or <br>
	<tab>http://localhost:5281/ <br>
Swagger UI is available at: <br>
	<tab>https://localhost:7034/swagger/<br>
	
4. Running the BasketFrontend
Open BasketFrontend solution in Visual Studio.<br>
Set it as the startup project.<br>
Update Backend base URL in program.cs (if necessary):<br>
	builder.Services.AddScoped(sp =>
		new HttpClient { BaseAddress = new Uri("https://localhost:7034/") }
	);<br>
Run the project (Ctrl + F5).<br>
The Frontend will be available at:<br>
	https://localhost:7264/ or <br>
	http://localhost:5189/ <br>

🧪 Testing
In BasketBackend solution, open BasketBackendTests project <br>
Run the tests (Ctrl + R and then T) or run the command: <br>
dotnet test BasketBackend.Tests <br>
