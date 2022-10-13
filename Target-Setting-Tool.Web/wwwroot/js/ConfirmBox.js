function deleteBtnClick(id) {
    $('#confirmDelete').prop('href', `/Right/DeleteRight/${id}`);
    $('#deleteConfirm').modal('show');
}
$(document).ready(function () {
    setTimeout(function () {
        let AlertBox = document.getElementById("alertBox");
        $(AlertBox).slideUp();

        
        //YOUR CODE

    }, 3000);
});

//function DeleteAlertBox() {
//    let AlertBox = document.getElementById("alertBox");
//    //console.log("Hello World")
//    AlertBox.remove();
//}
