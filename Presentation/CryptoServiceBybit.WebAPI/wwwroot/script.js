let currentSymbol;
let currentTimeframe;
let currentCategory;

let cachedSymbols = {};

const timeframesSelectElement = document.getElementById("timeframesSelect");
const categoriesSelectElement = document.getElementById("categoriesSelect");
const symbolsSelectElement = document.getElementById("symbolsSelect");
const quotesTableElement = document.getElementById("quotes-table");

categoriesSelectElement.addEventListener("change", async () => {
    const selectedCategory = categoriesSelectElement.options[categoriesSelectElement.selectedIndex];
    currentCategory = selectedCategory.value;
    await getSymbols(currentCategory);
    updateQuotesTable();
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
            list.sort(function (firstItem, secondItem) {
                const firstNumber = Number(firstItem.lastPrice);
                const secondNumber = Number(secondItem.lastPrice);
                if (firstNumber > secondNumber) {
                    return -1;
                } else if (firstNumber < secondNumber) {
                    return 1;
                }
                return 0;
            });
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
    if (quotesTableElement) {
        quotesTableElement.innerHTML = "";
    }
    if (symbolsInfos.length > 0) {
        for (let i = 0; i < symbolsInfos.length; ++i) {
            const row = document.createElement("div");
            row.id = "quotes-table-row";

            const symbolInfo = symbolsInfos[i];

            const symbolCell = document.createElement("div");
            symbolCell.id = "quotes-table-cell-symbol";
            symbolCell.className = "text";
            symbolCell.append(symbolInfo.symbol);

            const priceCell = document.createElement("div");
            priceCell.id = "quotes-table-cell-price";
            priceCell.className = "text";
            priceCell.append(symbolInfo.lastPrice);

            row.appendChild(symbolCell);
            row.appendChild(priceCell);
            quotesTableElement.appendChild(row);
        }
    }
}

async function init() {
    currentCategory = "spot";
    await getSymbols(currentCategory);
    updateQuotesTable()
}

init();