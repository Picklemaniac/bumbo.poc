var startItem, endItem, rowUsing, calendarSchedule, date, beginTime, isPositive;

function init() {
    date = new Date();
    calendarSchedule = [];
    beginTime = date.setHours(8, 0, 0)

    var cells = document.querySelectorAll(".draw");

    cells.forEach(cell => {
        var rows = cell.querySelectorAll("[data-row]");

        cell.addEventListener("mousedown", e => {
            if (e.target.classList.contains("booked")) return;
            startItem = e.target.dataset.row;
            endItem = e.target.dataset.row;
            rowUsing = cell;
            updateSelected();
        });

        window.addEventListener("mouseup", e => {
            if (!rowUsing) return;
            createItem();
        });

        cell.addEventListener("mousemove", e => {
            if (!rowUsing) return;
            if (e.target.classList.contains("booked")) return;
            var row = parseInt(e.target.dataset.row);
            var start = parseInt(startItem);
            var end = parseInt(endItem);

            if (row < start)
                endItem = start;
            else
                endItem = row;

            updateSelected();
        });
    })
}

function updateSelected() {
    var rows = rowUsing.querySelectorAll("[data-row]");
    rows.forEach(row => {
        row.classList.remove("selected")
    });

    var selectedRows = Array.from(rows).filter(row => parseInt(row.dataset.row) >= parseInt(startItem) && parseInt(row.dataset.row) <= parseInt(endItem));
    selectedRows.forEach(row => {
        row.classList.add("selected")
    });
}

function createItem() {
    calendarSchedule.push({
        startTime: calculateTime(startItem - 1),
        endTime: calculateTime(endItem),
        userId: rowUsing.dataset.userId
    })
    rowUsing = null;

    renderScheduler();
    // alert(calculateTime(startItem - 1) + " - " + calculateTime(endItem));
}

function renderScheduler() {
    var rows = document.querySelectorAll("[data-row]");
    rows.forEach(row => {
        row.classList.remove("selected");
        row.classList.remove("booked");
    });

    var cells = document.querySelectorAll(".draw");
    cells.forEach(cell => {
        var userCalendar = calendarSchedule.filter(item => item.userId == cell.dataset.userId);

        userCalendar.forEach(item => {
            var start = calculateRow(item.startTime);
            var end = calculateRow(item.endTime);
            console.log(start + " - " + end)
            var selectedRows = Array.from(cell.querySelectorAll("[data-row]")).filter(row => parseInt(row.dataset.row) > parseInt(start) && parseInt(row.dataset.row) <= parseInt(end));

            selectedRows.forEach(row => {
                row.classList.add("booked")
            })
        })
    })


}

function calculateTime(row) {
    var hours = 8;
    var minutes = 0;
    var time = new Date();

    for (var i = 0; i < row; i++) {
        minutes += 10;

        if (minutes == 60) {
            minutes = 0;
            hours++;
        }
    }

    time.setHours(hours, minutes, 0)
    return time;
}

function calculateRow(time) {
    var calcTime = new Date(time);
    var beginTime = new Date();
    beginTime.setHours(8, 0, 0);
    var diff = Math.abs(calcTime - beginTime);
    var minutes = Math.floor((diff / 1000) / 60);
    var calcMinutes = Math.ceil((minutes) / 10) * 10;;
    console.log(calcMinutes);
    return calcMinutes / 10;
}

init();