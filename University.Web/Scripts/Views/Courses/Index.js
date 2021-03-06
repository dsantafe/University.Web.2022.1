$(document).ready(function () {
    getCourses();
    getCoursesList();
});

$("#create").click(function () {
    $("#modalCourses .modal-body", this).empty();
    $("#modalCourses .modal-body").load(urlBase + "/Courses/Create");
    $("#modalCourses").modal("show");
});

function getCourses() {
    var $row = $('#rowCourses');
    $('#divCourses').remove();
    var $div = $('<div></div>');
    $div.addClass('table-responsive mb-5');
    $div.attr({ id: 'divCourses' });
    $div.addClass('divCourses mb-5');
    var $table = $("<table></table>");
    $table.addClass('table table-bordered display text-center');
    $table.attr({ id: 'tableCourses', width: '100%' });
    $div.append($table);
    $row.append($div);

    $.get(urlBase + '/Courses/IndexJson').done(function (data) {
        $.notify("Load data", "info");
        console.table(data);

        table = $('#tableCourses').DataTable({
            data: data,
            "iDisplayLength": 10,
            "order": [[0, "desc"]],
            columns: [
                { title: 'ID', data: 'CourseID', className: 'd-none' },
                { title: 'Title', data: 'Title' },
                { title: 'Credits', data: 'Credits' },
                { title: 'Options', data: null }
            ],
            columnDefs: [
                {
                    targets: 3,
                    render: function (data, type, row) {
                        return '<a href="javascript:void" class="btn btn-warning edit fas fa-edit"></a>' +
                            '<a href="javascript:void" class="btn btn-danger delete fas fa-trash"></a>';
                    }
                }
            ]
        });

        $('#tableCourses').on('click', 'tbody a.edit', function (e) {
            let id = $(this).parent().siblings('td')[0].innerText;

            $('#modalCourses .modal-body', this).empty();
            $('#modalCourses .modal-body').load(urlBase + '/Courses/Edit/' + id);
            $("#modalCourses").modal("show");
        });

        $('#tableCourses').on('click', 'tbody a.delete', function (data) {
            let id = $(this).parent().siblings('td')[0].innerText;
            deleteCourse(id);
        });

    }).fail(function (data) {
        console.table(data);
    });
}

function deleteCourse(id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this register!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel plx!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {

                $.get(urlBase + "/Courses/Delete/" + id).done(function (data) {
                    if (data.IsSuccess) {
                        getCourses();
                        swal("Deleted!", "Your register has been deleted.", "success");
                    } else {
                        swal("Notification", data.Message, "error");
                    }
                }).fail(function (data) {
                    swal("Notification", data.Message, "error");
                })

            } else {
                swal("Cancelled", "Your register is safe :)", "error");
            }
        });
}

function getCoursesList() {
    $.get(urlBase + '/Courses/GetCourses', function (data) {
        $("#CourseSelect").empty();
        $("#CourseSelect").select2({
            placeholder: "Seleccione",
            data: JSON.parse(data)
        });
        $("#CourseSelect").val("").trigger("change");
    });
}