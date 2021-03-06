﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function uploadFiles(inputId) {
    var input = document.getElementById(inputId);
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }

    startUpdatingProgressIndicator();
    $.ajax(
        {
            url: "/uploader",
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                stopUpdatingProgressIndicator();
                alert("Files Uploaded!");
            }
        }
    );
}

var intervalId;

function startUpdatingProgressIndicator() {
    $("#progress").show();

    intervalId = setInterval(
        function () {
            // We use the POST requests here to avoid caching problems (we could use the GET requests and disable the cache instead)
            $.post(
                "/uploader/progress",
                function (progress) {
                    $("#bar").css({ width: progress + "%" });
                    $("#label").html(progress + "%");
                }
            );
        },
        10
    );
}

function stopUpdatingProgressIndicator() {
    clearInterval(intervalId);
}