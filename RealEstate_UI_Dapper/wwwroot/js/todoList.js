
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7221/signalRHub").build();

connection.start().then(() => {
    setInterval(() => {
        connection.invoke("GetTodoList");
    }, 700);

}).catch((err) => { console.log(err) });

connection.on("receiveTodoList", (value) => {
    let todoTable = value.map(item => {
        return `<div class="d-flex align-items-center border-bottom py-2">
                    <input class="form-check-input m-0" onclick="changeTodoStatus(${item.id},${item.status})" type="checkbox" ${item.status ? "" : "checked"}>
                    <div class="w-100 ms-3">
                        <div class="d-flex w-100 align-items-center justify-content-between">
                                 ${item.status ? `<span>${item.description}</span><a href="#" class="btn btn-sm"><i class="fa fa-times"></i></a>` : `<span><del>${item.description}</del></span><a href="#" class="btn btn-sm text-primary"><i class="fa fa-times"></i></a>`}
                        </div>
                    </div>
                </div>`;
    }).join(""); // Diziyi birleştirerek tek bir dizeye dönüştür

    $("#todoList").html(todoTable);
});

function changeTodoStatus(id, status) {
    var todo = { id: id };
    $.ajax({
        type: 'get',
        data: JSON.stringify(todo),
        url: status ? 'https://localhost:7221/api/ToDoLists/ToDoStatusChangeToFalse?id=' + id : 'https://localhost:7221/api/ToDoLists/ToDoStatusChangeToTrue?id=' + id,
        contentType: 'application/json',
    });
}