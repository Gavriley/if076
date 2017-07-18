$(document).ready(function () {
    $('.alert').hide();
    getNodeList();

    $('form').submit(function (event) {
        event.preventDefault();
    });
});

function getNodeList() {
    $('tbody').hide();
    $('#progress').show();

    $.ajax({
        url: 'api/Nodes',
        type: 'GET',
        success: function (data) {
            $('#progress').hide();
            $('tbody').html(printNodeList(data)).fadeIn(1000);
        }
    });
}

function createNode() {
    $.ajax({
        url: 'api/Nodes',
        type: 'POST',
        data: formToJson(),
        contentType: 'application/json;charset=utf-8',
        success: function () {
            $('.modal').modal("hide");
            message("Your node successfully created!");
            getNodeList();
        },
        error: function () {
            $('.modal').modal("hide");
            message("Sorry, something wrong :(");
            getNodeList();
        }
    });
}

function updateNode(id) {
    $.ajax({
        url: 'api/Nodes',
        type: 'PUT',
        data: formToJson(),
        contentType: 'application/json;charset=utf-8',
        success: function () {
            $('.modal').modal("hide");
            message("Your node successfully updated!");
            getNodeList();
        },
        error: function () {
            $('.modal').modal("hide");
            message("Node not found!");
            getNodeList();
        }
    });
}

function dropNode(id) {
    $.ajax({
        url: 'api/Nodes/' + id,
        type: 'DELETE',
        success: function () {
            $('.modal').modal("hide");
            message("Your node successfully deleted!");
            getNodeList();
        },
        error: function () {
            $('.modal').modal("hide");
            message("Node not found!");
            getNodeList();
        }
    });
}

function formNode(id) {
    $.ajax({
        url: 'api/Nodes/' + id,
        type: 'GET',
        success: function (data) {
            $('form').html(printNodeForm(data));
            $('.modal').modal("show");
        },
        error: function () {
            $('.modal').modal("hide");
            message("Node not found!");
            getNodeList();
        }
    });
}

function newNodeForm() {
    $('form').html(printNodeForm());
    $('.modal').modal("show");
}

function formToJson() {
    var object = {
        Id: $('form input[name=Id]').val(),
        Name: $('form input[name=Name]').val()
    };

    return JSON.stringify(object);
}

function message(text) {
    $('.alert').hide();
    $('#message').html(text);
    $('.alert').fadeIn(500);
}

function printNodeList(list) {
    var blocks = '';

    list.forEach(function (item) {
        blocks += '<tr><td>' + item.name + '</td><td>';
        blocks += '<button type="button" class="btn btn-success" onclick="formNode(' + item.id + ')">Edit</button>';
        blocks += ' <button type="button" class="btn btn-danger" onclick="dropNode(' + item.id + ')">Delete</button>';
        blocks += '</td></tr>';
    });

    return blocks;
}

function printNodeForm(node = undefined) {

    var id, name, title, method; 

    if (node !== undefined) {
        id = node.id;
        name = node.name;
        title = "Edit Node";
        method = 'updateNode(' + id + ')';

    } else {
        name = '';
        title = "Add Node";
        method = "createNode()";

    }

    form = '<div class="modal-header">';
    form += '<button type="button" class="close" data-dismiss="modal">&times;</button>';
    form += '<h4 class="modal-title">' + title + '</h4></div><div class="modal-body">';
    if (id !== undefined)
        form += '<input type="hidden" name="Id" value="' + id + '" />';
    form += '<div class="form-group">';
    form += '<input type="text" name="Name" class="form-control" value="' + name + '" placeholder="Type node name" /></div>';
    form += '<div class="modal-footer"><input class="btn btn-primary pull-left" type="submit" onclick="' + method + '" value="Save" />';
    form += '<button type="button" class="btn btn-default" data-dismiss="modal">Close</button></div></div>';

    return form;
}