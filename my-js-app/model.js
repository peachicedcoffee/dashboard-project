const todos=[];

function addTodo(text){
    todos.push({text, done:false});
}

function toggleTodo(index){
    todos[index].done = !todos[index].done;
}

function removeTodo(index){
    todos.splice(index,1);
}

function getTodos(){
    return [...todos];
}