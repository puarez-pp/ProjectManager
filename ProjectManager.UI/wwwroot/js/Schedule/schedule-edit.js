(function () {
    const form = document.getElementById('schedule-edit-form');
    if (!form) return;

    const stagesContainer = document.getElementById('schedule-stages-container');
    const stageTemplate = document.getElementById('stage-template');
    const taskTemplate = document.getElementById('task-template');

    let stageIndexCounter = stagesContainer.querySelectorAll('.schedule-stage-edit').length || 0;

    function nextStageIndex() {
        return stageIndexCounter++;
    }

    function nextTaskIndex(stageEl) {
        const tasks = stageEl.querySelectorAll('.schedule-task-edit');
        return tasks.length;
    }

    document.addEventListener('click', function (e) {
        if (e.target.closest('.js-add-stage')) {
            e.preventDefault();
            addStage();
        }

        if (e.target.closest('.js-remove-stage')) {
            e.preventDefault();
            const card = e.target.closest('.schedule-stage-edit');
            if (card) card.remove();
        }

        if (e.target.closest('.js-add-task')) {
            e.preventDefault();
            const btn = e.target.closest('.js-add-task');
            const stageIndex = btn.getAttribute('data-stage-index');
            const stageEl = stagesContainer.querySelector(`.schedule-stage-edit[data-stage-index="${stageIndex}"]`);
            if (stageEl) addTask(stageEl, stageIndex);
        }

        if (e.target.closest('.js-remove-task')) {
            e.preventDefault();
            const row = e.target.closest('.schedule-task-edit');
            if (row) row.remove();
        }
    });

    function addStage() {
        const index = nextStageIndex();
        const html = stageTemplate.innerHTML.replace(/__INDEX__/g, index);
        const wrapper = document.createElement('div');
        wrapper.innerHTML = html.trim();
        const stageEl = wrapper.firstElementChild;
        stageEl.setAttribute('data-stage-index', index);
        stagesContainer.appendChild(stageEl);
    }

    function addTask(stageEl, stageIndex) {
        const tIndex = nextTaskIndex(stageEl);
        const html = taskTemplate.innerHTML
            .replace(/__SINDEX__/g, stageIndex)
            .replace(/__TINDEX__/g, tIndex);
        const wrapper = document.createElement('div');
        wrapper.innerHTML = html.trim();
        const taskEl = wrapper.firstElementChild;
        stageEl.querySelector('.schedule-tasks-container').appendChild(taskEl);
    }
})();
