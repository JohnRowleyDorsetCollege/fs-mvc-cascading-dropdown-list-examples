

function init() {

    console.log({ fleetSalesObject })

    setupCascadingList();
}

function setupCascadingList() {

    var selectMf = document.getElementById("selectMf");
    var selectModel = document.getElementById("selectModel");
    var selectVersion = document.getElementById("selectVersion");

    for (let currentMf in fleetSalesObject) {

        selectMf.options.add(new Option(currentMf, currentMf));
    }

    selectMf.onchange = function () {

        selectModel.length = 1;

        for (let model in fleetSalesObject[this.value]) {

            selectModel.options.add(new Option(model, model));
        }

    }

    selectModel.onchange = function () {
        selectVersion.length = 1;

        let versions = fleetSalesObject[selectMf.value][this.value]

        for (let currentVersion of versions) {

            selectVersion.options.add(new Option(currentVersion, currentVersion));
        }

    }



}