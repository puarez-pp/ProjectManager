(function () {
    const container = document.querySelector('.schedule-stage-list');
    if (!container) return;

    container.addEventListener('click', async function (e) {
        const btn = e.target.closest('.js-task-status-toggle');
        if (!btn) return;

        const taskId = btn.getAttribute('data-task-id');
        if (!taskId) return;

        // TODO: wywołanie endpointu UpdateTaskStatus, teraz zmiana klasy / badge
        const row = btn.closest('.schedule-task-row');
        if (!row) return;

        row.classList.toggle('schedule-task-completed');
    });
})();
