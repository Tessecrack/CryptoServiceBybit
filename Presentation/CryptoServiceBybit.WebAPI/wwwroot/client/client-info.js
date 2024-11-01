export class ClientInfo {
    constructor() {
        this._selectedSymbol = "BTCUSDT";
        this._selectedTimeframe = "1";
        this._selectedCategory = "spot";
    }

    selectSymbol(symbolName) {
        this._selectedSymbol = symbolName;
    }

    selectTimeframe(timeframe) {
        this._selectedTimeframe = timeframe;
    }

    selectCategory(category) {
        this._selectedCategory = category;
    }

    getSelectedSymbol() {
        return this._selectedSymbol;
    }

    getSelectedTimeframe() {
        return this._selectedTimeframe;
    }

    getSelectedCategory() {
        return this._selectedCategory;
    }
}