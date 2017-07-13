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
            $('tbody').html(data).fadeIn(1000);
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
        url: 'api/Nodes/' + id,
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
            $('form').html(data);
            $('.modal').modal("show");
        },
        error: function () {
            $('.modal').modal("hide");
            message("Node not found!");
            getNodeList();
        }
    });
}

function formToJson() {
    var object = {
        Id: $('form #Id').val(),
        Name: $('form #Name').val()
    };

    return JSON.stringify(object);
}

function message(text) {
    $('.alert').hide();
    $('#message').html(text);
    $('.alert').fadeIn(500);
}