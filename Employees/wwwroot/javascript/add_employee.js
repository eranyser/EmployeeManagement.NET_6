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

