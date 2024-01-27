# Dependency Injection

- EmployeeController is dependent on IEmployeeRepository for retrieving Employee data.
- Instead of the EmployeeController creating a new instance of an implementation of IEmployeeRepository, we are injecting IEmployeeRepository instance into the EmployeeController using the constructor.
    ```c#
  	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
        
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public Employee GetEmployeeById(int id) 
        {
            return _employeeRepository.GetEmployeeById(id);
        }
    }
    ```
 - This is called **constructor injection**, as we are using the constructor to inject the dependency.
 - Notice, we are assigning the injected dependency to a read-only field. This is a good practice as it prevents accidentally assigning another value to it inside a method.
 - Currently we gets an error since the ASP.NET dependency injection container does not know which object instance to provide if someone requests an object that implements IEmployeeRepository
 - EmployeeRepository may have several implementations. At the moment in our project we only have one implementation and that is MockEmployeeRepository
 - As the name implies, MockEmployeeRepository works with the in-memory employee mock data.
 - Later we will provide another implementation for IEmployeeRepository which retrieves employee data from a database.
 - To fix the *InvalidOperationException* error, we need to register MockEmployeeRepository class with the dependency injection container in ASP.NET core.

#### Registering Services with the ASP.NET Core Dependency Injection Container

 - ASP.NET core provides the following 3 methods to register services with the dependency injection container. The method that we use determines the lifetime of the registered service. 
   - **AddSingleton()** - As the name implies, AddSingleton() method creates a Singleton service. A Singleton service is created when it is first requested. This same instance is then used by all the subsequent requests. So in general, a Singleton service is created only one time per application and that single instance is used throughout the application life time.
   - **AddTransient()** - This method creates a Transient service. A new instance of a Transient service is created each time it is requested.
   - **AddScoped()** - This method creates a Scoped service. A new instance of a Scoped service is created once per request within the scope. For example, in a web application it creates 1 instance per each http request but uses the same instance in the other calls within that same web request.
 - For now, to fix the InvalidOperationException error, let's register MockEmployeeRepository class with the ASP.NET Core Dependency Injection container using AddSingleton() method as shown below. So, with this code in-place, if someone asks for IEmployeeRepository, an instance of MockEmployeeRepository will be provided.
   ```c#
   builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
   ```
 - The benefit of using dependency injection instead of creating an instance of MockEmployeeRepository In the EmployeeController using the new keyword is to prevent coupling between the EmployeeController and the MockEmployeeRepository. Although it looks like a single place, in a real application when there are lot of controllers, we might need to do changes in lot of places, specifically if we want to change the implementation. 
 - Unit testing also becomes much easier, as we can easily swap out dependencies with dependency injection

**Bibliography:** 

[![Watch the video](https://i.ytimg.com/vi/BPGtVpu81ek/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG&rs=AOn4CLAfs6pWsQONYsQEbT6-NuQmynaq8A)](https://www.youtube.com/watch?v=BPGtVpu81ek&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=20)

