# Creating an HTML Form

- In order to submit data to the *AddEmployee* method we need to create a Form that submits the data to our controller.
- the defautl static file foledr is **wwwroot** under the root folder. 
- The simplest html form:
  ```html
  <!DOCTYPE html>
  <html>
  <head>
      <meta charset="utf-8" />
      <title>Add Employee</title>
  </head>
  <body>
  	<h2>Add Employee</h2>
  
  	<form action="https://localhost:7156/employee" method="post" id="addEmployeeForm">
  		<label for="Name">Employee name:</label><br />
  		<input type="text" id="employee_name" name="Name"><br /><br />
  		<label for="Email">Email:</label><br />
  		<input type="text" id="email" name="Email"><br /><br />
  		<label for="Department">Department:</label><br />S
  		<input type="text" id="department" name="Department"><br /><br />
  		<input type="submit" value="Submit">
  	</form>
  
  </body>
  </html>
  ```
- By default, when we submit a form in HTML, the data is sent to the server in the format **application/x-www-form-urlencoded**. This means that the form data is encoded into a string in the format key1=value1&key2=value2.
- In the **Controller** we add the **[FromForm]** attribute to each propery that is sent from the form
  ```c#
  [HttpPost]
  [Route("submit")]
  public IActionResult AddEmployee([FromForm] string Name, [FromForm] string Email, [FromForm] string Department)
  {
        Employee newEmployee = new Employee() { Name = Name, Email = Email, Department = Department };
        Employee addedEmployee = _employeeRepository.AddEmployee(newEmployee);
        return CreatedAtRoute("GetSpecificEmployee", new { Id = addedEmployee.Id }, addedEmployee);
  }
  ```
 - We can also use the DTO *Employee* Object with the attribute *[FromForm]*, and .NET model binding will enter the right properties, according their names to the Object:
   ```c#
   [HttpPost]
   [Route("submit")]
   public IActionResult AddEmployeeSubmit([FromForm] Employee newEmployee)
   {
       Employee addedEmployee = _employeeRepository.AddEmployee(newEmployee);
       return CreatedAtRoute("GetSpecificEmployee", new { Id = addedEmployee.Id }, addedEmployee);
   }
   ```
 - In order to send Json format we need javascript code. We can do it with original old **XMLHttpRequest (XHR)**, or modern **fetch** method.
 - We will add two more buttons in our html:
   - First button will activate fetch command
     ```javascript
     function useFetch() {
	     let form = document.getElementById("addEmployeeForm");
	     var data = {
	     	EmployeeName: form.elements["employee_name"].value,
	     	Email: form.elements["email"].value,
	     	Department: form.elements["department"].value
	     };
 
	     fetch('https://localhost:7156/employee', {
	     			method: 'POST',
	     			headers: {
	     				'Content-Type': 'application/json'
	     			},
	     			body: JSON.stringify(data)
	     })
	     .then(response => response.json())
	     .then(data => console.log(data));
     }     
     ```
   - Second button will activate send using XHR 
     ```javascript
     function useXHR() {
     	var form = document.getElementById("addEmployeeForm");
     	var formData = {
     		EmployeeName: form.elements["employee_name"].value,
     		Email: form.elements["email"].value,
     		Department: form.elements["department"].value
     	};
     
     	var xhr = new XMLHttpRequest();
     	xhr.open("POST", "https://localhost:7156/employee", true);
     	xhr.setRequestHeader("Content-Type", "application/json");
     	xhr.onreadystatechange = function () {
     		if (xhr.readyState === 4 && xhr.status === 200) {
     			// Handle response from the server if needed
     			console.log(xhr.responseText);
     		}
     	};
     	xhr.send(JSON.stringify(formData));
     }     
     ```




[Back to Table of Content](../README.md#02-webapi-basic-conceptes)   
