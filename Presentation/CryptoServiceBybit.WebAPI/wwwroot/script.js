let currentSymbol;
let currentTimeframe;
let currentCategory;

let cachedSymbols = {};

const timeframesSelectElement = document.getElementById("timeframesSelect");
const categoriesSelectElement = document.getElementById("categoriesSelect");
const symbolsSelectElement = document.getElementById("symbolsSelect");
const tableBodyElement = document.getElementById("quotes-table-body");

categoriesSelectElement.addEventListener("change", async () => {
    const selectedCategory = categoriesSelectElement.options[categoriesSelectElement.selectedIndex];
    currentCategory = selectedCategory.value;
    await getSymbols(currentCategory);
});

timeframesSelectElement.addEventListener("change", () => {
    const selectedTimeframe = timeframesSelectElement.options[timeframesSelectElement.selectedIndex];
    currentTimeframe = selectedTimeframe.value;
});

async function getSymbols(category) {
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

function addOptionToSelectElement(selectElement, option) {
    const optionElement = document.createElement("option");
    optionElement.value = option;
    optionElement.append(option);
    selectElement.append(optionElement);
}

function updateQuotesTable() {
    const symbolsInfos = cachedSymbols[currentCategory];
    if (symbolsInfos.length > 0) {
        tableBodyElement.innerHTML = "";
        for (let i = 0; i < symbolsInfos.length; ++i) {
            const trElement = document.createElement("tr");
            const symbolNameTdElement = document.createElement("td");
            const lastPriceTdElement = document.createElement("td");

            const symbolInfo = symbolsInfos[i];

            symbolNameTdElement.append(symbolInfo.symbol);
            lastPriceTdElement.append(symbolInfo.lastPrice);

            trElement.appendChild(symbolNameTdElement);
            trElement.appendChild(lastPriceTdElement);

            tableBodyElement.appendChild(trElement);
        }
    }
}

async function init() {
    currentCategory = "spot";
    await getSymbols(currentCategory);
    updateQuotesTable()
}

init();