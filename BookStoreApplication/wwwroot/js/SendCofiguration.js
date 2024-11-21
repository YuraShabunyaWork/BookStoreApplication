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
        .then(response => response.json())
        .then(data => {
            console.log('Ответ сервера:', data);
            if (data.success) {
                // Заполнение таблицы полученными данными
                document.getElementById("book-table-body").innerHTML = "";
                const tableBody = document.getElementById("book-table-body");
                data.books.forEach((book) => {
                    const row = `
                        <tr>
                            <th scope="row">${book.id}</th>
                            <td>${book.isbn}</td>
                            <td>${book.title}</td>
                            <td>${book.author}</td>
                            <td>${book.publisher}</td>
                        </tr>`;
                    tableBody.insertAdjacentHTML('beforeend', row);
                });
            } else {
                alert("Ошибка загрузки данных");
            }
        })
        .catch(error => console.error('Ошибка:', error));
}