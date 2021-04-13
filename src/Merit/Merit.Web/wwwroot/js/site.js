// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConfirmQ(istrue) {
    if (istrue) {
        $(x).show();
        $(y).hide();
        $(a).hide();
        $(b).show();
    }
    else {
        $(x).hide();
        $(y).show();
    }
}

function ConfirmX(istrue) {
    if (istrue) {
        $(a).show();
        $(b).hide();
        $(x).hide();
        $(y).show();
    }
    else {
        $(a).hide();
        $(b).show();
    }
}