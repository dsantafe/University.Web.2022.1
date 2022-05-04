$("#create-save").click(function () {
    createCourse();
})

function createCourse() {
    //var courseID = document.getElementById("CourseID");
    //var courseID = $("#CourseID").val();

    var formData = $("#formCreateCourse").serialize();

    $.post(urlBase + "/Courses/Create", formData).done(function (data) {
        console.table(data);

        if (data.IsSuccess) {
            swal("Notification", "The process is successful", "success");
            $("#modalCourses").modal("hide");
            getCourses();
        } else {
            swal("Notification", data.Message, "error");
        }

    }).fail(function (data) {
        console.table(data);
        swal("Notification", "The process is failed", "error");
    })
}