$(document).ready(function () {
    let isLoading = false; // Флаг загрузки

    function loadBooks() {
        if (isLoading) return;
        isLoading = true;
        $("#loading").show();

        $.get("/Books/LoadBooks", function (html) {
            // Добавляем частичное представление в таблицу
            $("#book-table-body").append(html);

            // Проверяем, вернулись ли данные
            if (html.trim() === "") {
                $("#loading").text("Больше данных нет");
            } else {
                $("#loading").hide();
            }

            isLoading = false;
        });
    }

    // Подгрузка при скролле
    $(window).on("scroll", function () {
        if ($(window).scrollTop() + $(window).height() >= $(document).height()) {
            loadBooks();
        }
    });
});