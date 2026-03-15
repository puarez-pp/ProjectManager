
(function () {

    // ------------------------------------------------------------
    // 1. Pobieranie template'ów (Stage + Task)
    // ------------------------------------------------------------

    function getStageTemplate() {
        return document.getElementById("stage-template").innerHTML.trim();
    }

    function getTaskTemplate() {
        return document.getElementById("task-template").innerHTML.trim();
    }

    // ------------------------------------------------------------
    // 2. Reindeksowanie etapów i zadań
    // ------------------------------------------------------------

    function reindexStages() {
        const stages = document.querySelectorAll(".stage-item");

        stages.forEach((stage, i) => {
            stage.dataset.stageIndex = i;

            stage.querySelectorAll("[name]").forEach(el => {
                el.name = el.name.replace(/Stages
                    \[\d+\]
                    /, `Stages[${i}]`);
            });

            // reindeksowanie zadań w tym etapie
            reindexTasks(stage, i);
        });
    }

    function reindexTasks(stageElement, stageIndex) {
        const tasks = stageElement.querySelectorAll(".task-item");

        tasks.forEach((task, j) => {
            task.dataset.taskIndex = j;

            task.querySelectorAll("[name]").forEach(el => {
                el.name = el.name
                    .replace(/Stages

                        \[\d+\]

                        \.Tasks

                        \[\d+\]

                        /, `Stages[${stageIndex}].Tasks[${j}]`);
            });
        });
    }

    // ------------------------------------------------------------
    // 3. Dodawanie nowego etapu
    // ------------------------------------------------------------

    function addStage() {
        const container = document.getElementById("stages-container");
        const template = getStageTemplate();

        // tymczasowy index (i tak będzie reindeksowane)
        const newIndex = container.children.length;

        const html = template.replace(/__stageIndex__/g, newIndex);
        container.insertAdjacentHTML("beforeend", html);

        reindexStages();
    }

    // ------------------------------------------------------------
    // 4. Dodawanie zadania do konkretnego etapu
    // ------------------------------------------------------------

    function addTask(stageIndex) {
        const stage = document.querySelector(`.stage-item[data-stage-index="${stageIndex}"]`);
        const container = stage.querySelector(".tasks-container");
        const template = getTaskTemplate();

        const newTaskIndex = container.children.length;

        const html = template
            .replace(/__stageIndex__/g, stageIndex)
            .replace(/__taskIndex__/g, newTaskIndex);

        container.insertAdjacentHTML("beforeend", html);

        reindexStages();
    }

    // ------------------------------------------------------------
    // 5. Usuwanie etapu
    // ------------------------------------------------------------

    function removeStage(button) {
        const stage = button.closest(".stage-item");
        stage.remove();
        reindexStages();
    }

    // ------------------------------------------------------------
    // 6. Usuwanie zadania
    // ------------------------------------------------------------

    function removeTask(button) {
        const task = button.closest(".task-item");
        task.remove();

        const stage = button.closest(".stage-item");
        const stageIndex = stage.dataset.stageIndex;

        reindexTasks(stage, stageIndex);
    }

    // ------------------------------------------------------------
    // 7. Delegacja zdarzeń
    // ------------------------------------------------------------

    document.addEventListener("click", function (e) {

        // Dodawanie etapu
        if (e.target.matches("#add-stage-btn")) {
            addStage();
        }

        // Usuwanie etapu
        if (e.target.matches(".remove-stage-btn")) {
            removeStage(e.target);
        }

        // Dodawanie zadania
        if (e.target.matches(".add-task-btn")) {
            const stageIndex = e.target.dataset.stageIndex;
            addTask(stageIndex);
        }

        // Usuwanie zadania
        if (e.target.matches(".remove-task-btn")) {
            removeTask(e.target);
        }
    });

})();
