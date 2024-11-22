function selectLanguage(language) {
    document.getElementById('selectedLanguage').textContent = language;
    sendDataToServer();
}

function sendDataToServer() {
    const language = document.getElementById('selectedLanguage').textContent;
    const seed = document.getElementById('IntegerInput').value;
    const likes = document.getElementById('likes').value;
    const review = document.getElementById('floatingInput').value;

    const url = new URL('/Books/UpdateConfig', window.location.origin);
    url.searchParams.append('language', language);
    url.searchParams.append('seed', seed);
    url.searchParams.append('likes', likes);
    url.searchParams.append('review', review);

    console.log('Отправка данных:', url.toString());
    fetch(url, { method: 'GET' })
        .then(response => response.text())  // Получаем HTML-контент
        .then(html => {
            // Вставляем полученный HTML в элемент
            document.getElementById("book-table-body").innerHTML = "";
            document.getElementById("book-table-body").innerHTML = html;
        })
        .catch(error => console.error('Ошибка:', error));
}