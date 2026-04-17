document.getElementById("addBtn").addEventListener("click", () =>{
    const input = document.getElementById("todoInput");
    const text = input.value.trim();
    if(text==="") return;

    addTodo(text);
    input.value="";    
    renderTodos(getTodos(), handleDelete, handleToggle);    
});

function handleDelete(index){
    removeTodo(index);
    renderTodos(getTodos(), handleDelete, handleToggle);
}

function handleToggle(index){
    toggleTodo(index);
    renderTodos(getTodos(), handleDelete, handleToggle);
}

//앱 초기 렌더링
renderTodos(getTodos(), handleDelete, handleToggle);