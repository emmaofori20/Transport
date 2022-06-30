// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    console.log("ready!");
  hideLoader();
});

$(".nav-item").click(function () {
   showLoader();
});

$(".dropdown-item").click(function () {
    showLoader();
})

///////////////////////LOADER QUERY////////////////////////////////
function showLoader() {
    document.getElementById("myloader").style.display = "block";
}

function hideLoader() {
    document.getElementById("myloader").style.display = "none";

}
///////////////////////LOADER QUERY////////////////////////////////
