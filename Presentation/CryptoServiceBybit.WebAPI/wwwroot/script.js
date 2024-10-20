import { Worker } from "./workers/worker.js";

const categories = ["spot", "inverse", "linear"];

let currentSymbol;
let currentTimeframe;
let currentCategory;

let cachedSymbols = new Map(); // key is categories; values is symbols Map

const timeframesSelectElement = document.getElementById("timeframesSelect");
const categoriesSelectElement = document.getElementById("categoriesSelect");
const symbolsSelectElement = document.getElementById("symbolsSelect");
const quotesTableElement = document.getElementById("quotes-table");


const symbolPriceUpdater = new Worker(callbackSymbolUpdatePrice);


categoriesSelectElement.addEventListener("change", async () => {
    const selectedCategory = categoriesSelectElement.options[categoriesSelectElement.selectedIndex];
    currentCategory = selectedCategory.value;
    await getSymbols(currentCategory);
    updateQuotesTable();
    updateSymbolsSelectElement();
});

timeframesSelectElement.addEventListener("change", () => {
    const selectedTimeframe = timeframesSelectElement.options[timeframesSelectElement.selectedIndex];
    currentTimeframe = selectedTimeframe.value;
});

async function callbackSymbolUpdatePrice(msg) {
    await getSymbolsInfo();
    updateQuotesTable();
}

async function getSymbols() {
    const symbolsByCategory = cachedSymbols.get(currentCategory);
    if (symbolsByCategory) {
        return;
    } else {
        await getSymbolsInfo(currentCategory);
    }
}

async function getSymbolsInfo() {
    const response = await fetch(`/api/tickers/${currentCategory}`, {
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
        const mapSymbols = new Map();
        list.forEach((e) => {
            if (e.symbol) {
                const symInfo = {
                    lastPrice: e.lastPrice,
                    symbol: e.symbol
                };
                mapSymbols.set(e.symbol, symInfo);
            }
        });
        cachedSymbols.set(currentCategory, mapSymbols);
    }
}

async function getLastPrice(category, symbol) {
    const response = await fetch(`/api/market/kline/${category}/${symbol}?timeframe=1&limit=1`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const responseJson = await response.json();
        console.log(responseJson);
    }
}

function addOptionToSelectElement(selectElement, option) {
    const optionElement = document.createElement("option");
    optionElement.value = option;
    optionElement.append(option);
    selectElement.append(optionElement);
}

function updateSymbolsSelectElement() {
    const symbolsByCategory = cachedSymbols.get(currentCategory);
    if (symbolsByCategory) {
        const mapSymbols = symbolsByCategory;
        symbolsSelectElement.innerHTML = "";
        for (const [key, value] of mapSymbols) {
            addOptionToSelectElement(symbolsSelectElement, value.symbol);
        }
    }
}

function updateQuotesTable() {
    const symbolsByCategory = cachedSymbols.get(currentCategory);
    quotesTableElement.innerHTML = "";

    for (const [key, value] of symbolsByCategory) {
        const row = document.createElement("div");
        row.id = "quotes-table-row";

        const symbolInfo = value;

        const symbolCell = document.createElement("div");
        symbolCell.className = "quotes-table-cell-symbol";
        symbolCell.id = symbolInfo.symbol;
        symbolCell.append(symbolInfo.symbol);

        const priceCell = document.createElement("div");
        priceCell.className = "quotes-table-cell-price";
        priceCell.id = symbolInfo.lastPrice;
        priceCell.append(symbolInfo.lastPrice);

        row.appendChild(symbolCell);
        row.appendChild(priceCell);
        quotesTableElement.appendChild(row);
    }
}

async function init() {
    currentCategory = "spot";
    await getSymbols(currentCategory);
    updateQuotesTable();
    updateSymbolsSelectElement();
    symbolPriceUpdater.runWorker();
}

init();