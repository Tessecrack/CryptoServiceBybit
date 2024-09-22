let currentSymbol;
let currentTimeframe;
let currentCategory;


let cachedSymbols = {};

const timeframesSelectElement = document.getElementById("timeframesSelect");
const categoriesSelectElement = document.getElementById("categoriesSelect");
const symbolsSelectElement = document.getElementById("symbolsSelect");


categoriesSelectElement.addEventListener("change", async () => {
    const selectedCategory = categoriesSelectElement.options[categoriesSelectElement.selectedIndex];
    currentCategory = selectedCategory.value;
    await getSymbols(currentCategory);
});

timeframesSelectElement.addEventListener("change", () => {
    const selectedTimeframe = timeframesSelectElement.options[timeframesSelectElement.selectedIndex];
    currentTimeframe = selectedTimeframe.value;
});

function addOptionToSelectElement(selectElement, option) {
    const optionElement = document.createElement("option");
    optionElement.value = option;
    optionElement.append(option);
    selectElement.append(optionElement);
}

async function init() {
    await getSymbols();
}

async function getSymbols(category = "spot") {
    if (cachedSymbols[category]) {
        const list = cachedSymbols[category];
        symbolsSelectElement.innerHTML = "";
        list.forEach(e => addOptionToSelectElement(symbolsSelectElement, e.symbol));
    } else {
        const response = await fetch(`/api/tickers/${category}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const responseJson = await response.json();
            const list = responseJson.result.list;
            cachedSymbols[category] = list;
            symbolsSelectElement.innerHTML = "";
            list.forEach(e => addOptionToSelectElement(symbolsSelectElement, e.symbol));
        }
    }
}

init();