let currentSymbol;
let currentCategory;
let currentTimeframe;
let currentLastPrice;

const listSymbolsElement = document.getElementById("listSymbolsSelect");
const tablePrices = document.getElementById("tablePricesBody");

const symbolsListElement = document.getElementById("listSymbolsSelect");
const categoriesListElement = document.getElementById("listCategoriesSelect");
const timeframesListElement = document.getElementById("listTimeframesSelect");

const updatePriceBtnElement = document.getElementById("updatePriceBtn");

const selectedSymbolLbl = document.getElementById("selectedSymbolLbl");
const lastPriceSymbolLbl = document.getElementById("lastPriceSymbolLbl");

async function init() {
    await getTickers("spot", true);
    changeCurrentSymbol();
    changeCurrentCategory();
    changeCurrentTimeframe();

    await updatePriceByCurrentSymbol(currentSymbol, currentCategory, currentTimeframe);
    await getLastPrice(currentSymbol, currentCategory);
}

async function getLastPrice(currentSymbol, currentCategory) {
    const response = await fetch(`/api/tickers/${currentCategory}/${currentSymbol}?timeframe=1&limit=1`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const responseJson = await response.json();
        const lastPrice = responseJson.result.list[0].lastPrice;

        currentLastPrice = lastPrice;
        changeCurrentLastPrice();
    }
}

async function getTickers(categoryStr) {
    const response = await fetch(`/api/tickers/${categoryStr}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const responseJson = await response.json();
        const listTickers = responseJson.result.list;
        removeOptions(listSymbolsElement);
        for (let i = 0; i < listTickers.length; ++i) {
            const optionElement = document.createElement("option");
            const symbol = listTickers[i].symbol;
            optionElement.value = symbol;
            optionElement.text = symbol;
            listSymbolsElement.append(optionElement);
        }
    }
}

async function updatePriceByCurrentSymbol(symbol, category, timeframe) {
    const response = await fetch(`/api/market/kline/${category}/${symbol}?timeframe=${timeframe}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const responseJson = await response.json();
        const priceList = responseJson.result.list;

        tablePrices.innerHTML = "";
        priceList.forEach(e => tablePrices.append(this.row(e)));
    }
}

function removeOptions(selectElement) {
    const length = selectElement.options.length;
    if (length == 0) {
        return;
    }
    for (i = length - 1; i >= 0; i--) {
        selectElement.remove(i);
    }
}

function changeCurrentSymbol() {
    const selectedSymbolInList = symbolsListElement.options[symbolsListElement.selectedIndex];
    
    selectedSymbolLbl.value = selectedSymbolInList.value;
    selectedSymbolLbl.textContent = selectedSymbolInList.value;
    currentSymbol = selectedSymbolInList.value;
}

function changeCurrentCategory() {
    const selectedCategory = categoriesListElement.options[categoriesListElement.selectedIndex];
    currentCategory = selectedCategory.value;
}

function changeCurrentTimeframe() {
    const selectedTimeframe = timeframesListElement.options[timeframesListElement.selectedIndex];
    currentTimeframe = selectedTimeframe.value;
}

function changeCurrentLastPrice() {
    lastPriceSymbolLbl.value = currentLastPrice;
    lastPriceSymbolLbl.textContent = currentLastPrice;
}

function row(priceInfo) {
    const date = priceInfo[0];
    const open = priceInfo[1];
    const high = priceInfo[2];
    const low = priceInfo[3];
    const close = priceInfo[4];

    const trElement = document.createElement("tr");

    const humanReadableDate = new Date(Number(date));

    const dateTd = document.createElement("td");
    dateTd.append(humanReadableDate.toLocaleString());
    trElement.append(dateTd);

    const openTd = document.createElement("td");
    openTd.append(open);
    trElement.append(openTd);

    const highTd = document.createElement("td");
    highTd.append(high);
    trElement.append(highTd);

    const lowTd = document.createElement("td");
    lowTd.append(low);
    trElement.append(lowTd);

    const closeTd = document.createElement("td");
    closeTd.append(close);
    trElement.append(closeTd);

    return trElement;
}

symbolsListElement.addEventListener("change", async () => {
    changeCurrentSymbol();
    await updatePriceByCurrentSymbol(currentSymbol, currentCategory, currentTimeframe);
    await getLastPrice(currentSymbol, currentCategory);
});

categoriesListElement.addEventListener("change", async () => {
    const selectedCategory = categoriesListElement.options[categoriesListElement.selectedIndex];
    currentCategory = selectedCategory.value;
    await getTickers(selectedCategory.value);
    changeCurrentSymbol();

    await updatePriceByCurrentSymbol(currentSymbol, currentCategory, currentTimeframe);
});

timeframesListElement.addEventListener("change", async () => {
    changeCurrentTimeframe();

    await updatePriceByCurrentSymbol(currentSymbol, currentCategory, currentTimeframe);
});

updatePriceBtnElement.addEventListener("click", async () => {
    await updatePriceByCurrentSymbol(currentSymbol, currentCategory, currentTimeframe);
});

init();