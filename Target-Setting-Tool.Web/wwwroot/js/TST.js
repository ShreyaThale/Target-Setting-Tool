
    function DeleteOnClick(id){
        $('#confirmDelete').prop('href', `/Role/DeleteRole/${id}`);
    $('#ShowModal').modal('show');
}

    $(document).ready(function () {
        setTimeout(function () {
            let AlertBox = document.getElementById("alertBox");
            $(AlertBox).slideUp();
        }, 3000);
});


