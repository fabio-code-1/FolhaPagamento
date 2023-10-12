$(document).ready(function () {
    $('#addTask').click(function () {
        var taskText = $('#taskInput').val().trim();
        if (taskText !== '') {
            var taskHTML = `
              <div class="d-flex align-items-center border-bottom py-2 task-item">
                  <input class="form-check-input m-0" type="checkbox" />
                  <div class="w-100 ms-3">
                      <div class="d-flex w-100 align-items-center justify-content-between">
                          <span>${taskText}</span>
                          <button class="btn btn-sm delete-task">
                              <i class="fa fa-times"></i>
                          </button>
                      </div>
                  </div>
              </div>`;
            $('.tasks').append(taskHTML);
            $('#taskInput').val('');
        }
    });

    $(document).on('click', '.delete-task', function () {
        $(this).closest('.task-item').remove();
    });

    $(document).on('change', '.form-check-input', function () {
        var taskText = $(this).siblings('.w-100').find('span');
        if (this.checked) {
            taskText.wrap("<del>");
        } else {
            taskText.unwrap();
        }
    });
});