# EmployeeManagement.NET_6

## 01 Creating Empty Project

- Creating a new Web API Project via VS2022.
	- Didn't use Top Level Statement. (Use main method)
	- didn't use minimal API (Use Controllers)
	- Didn't choose Authentication method like Microsoft Identity Server.
	- Leave, for now, the default WeatherForcast Controller.
	  ![Configure WebAPI](./tutorial_images/CreateWebAPI1.png)
	  ![More Info WebAPI](./tutorial_images/CreateWebAPI2.png)
	- As we set *Enable OpenAPI Support* it includes the *Swashbuckle.AspNetCore* Nuget package. [Nuget Package location](https://stackoverflow.com/questions/40902578/wheres-the-nuget-package-location-in-asp-net-core)
- Solution & Project changes
	- The format and content of the **.csproj** has changed significantly (from .NET Framework) 
		- Ability to edit the project file without unloading it from solution explorer
		- The project file does not contain any folder or file reference.
		- The File System determines what files and folders belong to the project.
			- All files and folders that are present in the project root folder are part of the project and will be displayed in the solution explorer.
- Content of the Project File
	- TFM, (Target Framework Moniker): specify the target framework for your application
	
		| Name         | Abbreviation | TFM  |
		|--------------|--------------|------| 
		|.NET Framework|net           |net472|
		|              |              |net48 |
		|.NetCore      |netcoreapp    |netcoreapp2.2|
		|              |              |netcoreapp3.1|
		|              |net           |net5.0|
		|              |              |net6.0|
