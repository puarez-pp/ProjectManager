(function () {
    const table = document.getElementById('schedule-list-table');
    if (!table) return;

    table.addEventListener('click', function (e) {
        const row = e.target.closest('.schedule-list-row');
        if (!row) return;

        // przykład: klik w wiersz otwiera harmonogram (poza przyciskami)
        if (e.target.closest('a,button')) return;

        const id = row.getAttribute('data-schedule-id');
        if (!id) return;

        const url = `/Schedule/Schedule/${id}`;
        window.location.href = url;
    });
})();
