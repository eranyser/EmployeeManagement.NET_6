# Controllers

#### What is a Controller

- A controller gather together, in a simple class, all c# methods that implement a set of logically connected web  APIs. We put together things that logically belong together in a single class and we call this class a controller.
- The controller in a Web API **inherits from ControllerBase.** This marks this class to be ASP.NET Core Controller. ControllerBase is the base class for all API Controllers.
- Additionally, in order to tell ASP.NET Core that we really want to write Web API, we need to specify the attribute **[ApiController]**
  ```c#
  [ApiController]
  public class EmployeeController : ControllerBase
  {

  }
  ```
#### What are attributes

- Attributes are passive addition to the class, they don't implement code. Can influence how code executed. This attribute can be interpreted by  somebody. (for example by reflection)
- Example of attribute is the one mentioned above **[ApiController]** - attribute that tells the interpreter to treat this class differently, i.e. as a controller.
- Another common attributes in the controller class are **Route Attributes** which specify where the controller should be available in terms of HTTP path. For example:
  - For the whole *Controller*, we can use:
    - **[Route("[controller]")]** - Token attribute.  When we say controller in the path we mean to use the name of the class, for example, the Class *EmployeeController*, without the suffix controller. I.e, we can navigate to **http://localhost:5000/employee**
    - **[Route("api/employee")]** - We can specify our own route to the whole controller. I.e we can navigate to **http://localhost:5000/api/employee**  
  - For Action, we can also add routes:
    - **[Route("item")]** - we need a route also to the action. 
    - **[Rout("[action]")]**  - Same we can specify the action keyword for the methods. 
    - **[Route("[controller]/[action]")]** - or we can combine theme togeter
 
52:08 second video.

**Bibliography:**


[![Watch the video](https://i.ytimg.com/vi/-O0UYM0ZIIc/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG&rs=AOn4CLDbNRYNMEmt4sGKqGGZJGzFsrrmNQ)](https://www.youtube.com/watch?v=-O0UYM0ZIIc&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=20&pp=iAQB)

[![Watch the video](https://i.ytimg.com/vi/SpXNoqPJDwU/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG&rs=AOn4CLAnVeJkF4Vor0M6vFNAKMGSiPBG6Q)](https://www.youtube.com/watch?v=SpXNoqPJDwU&list=PLhGL9p3BWHwtV_hn6H_uZ4vrFE3F7mY8a&index=2&t=2725s&pp=iAQB)
