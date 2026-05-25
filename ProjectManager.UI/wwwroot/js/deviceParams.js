document.addEventListener("DOMContentLoaded", () => {

    const applyBtn = document.getElementById("applyFilters");

    applyBtn.addEventListener("click", () => {
        const from = document.getElementById("filterFrom").value;
        const to = document.getElementById("filterTo").value;

        const rows = [...document.querySelectorAll("tbody tr")];

        rows.forEach(row => {
            const tsCell = row.querySelector("td");
            if (!tsCell) return;

            const ts = tsCell.innerText.trim();

            let visible = true;

            if (from && ts < from) visible = false;
            if (to && ts > to) visible = false;

            row.style.display = visible ? "" : "none";
        });
    });

});
