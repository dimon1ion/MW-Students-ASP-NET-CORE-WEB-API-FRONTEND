const url = "https://localhost:44398";

let ul = document.getElementById("students");

async function GetStudents() {
  let responce = await fetch(`${url}/api/students`);
  if (responce.status == 200) {
    return responce.json();
  } else {
    return null;
  }
}

function FillList() {
  // let students = await GetStudents();

  // if (students != null) {
  //     ul.innerHTML = "";
  //     students.forEach(student => {
  //         let li = document.createElement("li");

  //         li.innerText = student.name + " " + student.lastName;

  //         ul.appendChild(li);
  //     });
  // }

  fetch(`${url}/api/students`)
    .then((responce) => {
      return responce.json();
    })
    .then((students) => {
      ul.innerHTML = "";
      students.forEach((student) => {
        let li = document.createElement("li");

        li.innerText =
          student.id +
          " " +
          new Date(student.birthday).toLocaleDateString(
            {},
            { dateStyle: "medium" }
          ) +
          " " +
          student.name +
          " " +
          student.lastName +
          " " +
          student.group;

        ul.appendChild(li);
      });
    });
}

function AddStudent(e) {
  let student = {
    name: document.getElementById("name").value,
    lastName: document.getElementById("lastName").value,
    birthday: document.getElementById("birthday").value,
    group: document.getElementById("group").value,
  };

  // let request = await fetch("http://localhost:43761/api/students", {
  //     method: "POST",
  //     body: JSON.stringify(student),
  //     headers: {'Content-Type': 'application/json'},});

  // let result = request.json();

  // result.then(data => {
  //     document.getElementById('result').innerText = "Added " + data;
  // })

  fetch(`${url}/api/students`, {
    method: "POST",
    body: JSON.stringify(student),
    headers: { "Content-Type": "application/json" },
  })
    .then((responce) => {
      return responce.json();
    })
    .then((data) => {
      document.getElementById("result").innerText = "Added " + data;
      console.log(data);
    });

  e.preventDefault();
  clearResult();
}

function editStudent(e) {
  // console.log(document.forms[1].children.namedItem("Name").value);
  // editForm

  let inputsEdit = editForm.children;

  let studentEdit = {
    id: inputsEdit.namedItem("Id").value,
    name: inputsEdit.namedItem("Name").value,
    lastName: inputsEdit.namedItem("LastName").value,
    birthday: inputsEdit.namedItem("Birthday").value,
    group: inputsEdit.namedItem("Group").value,
  };

  fetch(`${url}/api/students`, {
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(studentEdit),
    method: "PUT",
  })
    .then((responce) => {
      if (responce.status >= 400 && responce.status <= 500) {
        alert("Error Bad Request");
      }
      return responce.json();
    })
    .then((data) => {
      result.innerText = `${data === true ? "Edited" : "Error Edit"}`;
    });

  e.preventDefault();
  clearResult();
}

function deleteStudent(e) {
  let inputsDelete = deleteForm.children;

  let studentId = inputsDelete.namedItem("Id").value;

  fetch(`${url}/api/students/${studentId}`, {
    headers: { "Content-type": "application/json" },
    method: "DELETE",
  })
    .then((responce) => {
      if (responce.status >= 400 && responce.status <= 500) {
        alert("Error Bad Request");
      }
      return responce.json();
    })
    .then((data) => {
      result.innerText = `${data === true ? "Deleted" : "Error Delete"}`;
    });

  e.preventDefault();
  clearResult();
}

function clearResult() {
  ul.innerText = "";
}
