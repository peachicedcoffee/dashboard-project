function renderTodos(items, onDelete, onToggle){
    const ul = document.getElementById("todoList");
    ul.innerHTML="";

    items.forEach((item, index) => {
        const li = document.createElement("li");        
        li.innerText=item.text;
        
        //완료여부에 따라 스타일 적용
        if(item.done){
            li.style.textDecoration = "line-through";
            li.style.color ="gray";
        }

        //클릭 시 완료 상태 토글
        li.addEventListener("click", () => onToggle(index));

        const delBtn = document.createElement("button");
        delBtn.innerText="X";
        delBtn.style.marginLeft= "10px";
        delBtn.addEventListener("click", (e) => {
            e.stopPropagation(); //삭제버튼 눌러도 완료 토글되지 않게 막기
            onDelete(index);
        });

        li.appendChild(delBtn);
        ul.appendChild(li);
    });
}

