"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var uuid = require("uuid");
/** Dashboard Local Storage Helper */
var DashboardLocalStorage = /** @class */ (function () {
    function DashboardLocalStorage(key) {
        this._dashboardKeyName = '';
        this._dashboardKeyName = key;
        var itm = localStorage.getItem(this._dashboardKeyName);
        if (itm == null) {
            var dash = [];
            localStorage.setItem(this._dashboardKeyName, JSON.stringify(dash));
        }
    }
    Object.defineProperty(DashboardLocalStorage.prototype, "dashboardKeyName", {
        /** Get Storage Key Name */
        get: function () { return this._dashboardKeyName; },
        /** Set Storage Key Name */
        set: function (value) { this._dashboardKeyName = value; },
        enumerable: true,
        configurable: true
    });
    /**
     *  Save or Update Config File
     * @param config Config File
     */
    DashboardLocalStorage.prototype.saveConfigFile = function (config) {
        var data = localStorage.getItem(this._dashboardKeyName);
        var dash = JSON.parse(data);
        if (this.loadConfigFile(config.dashId) != null && config.dashId != null) { // update item
            var ds = this.loadAllConfigs();
            for (var _i = 0, ds_1 = ds; _i < ds_1.length; _i++) {
                var i = ds_1[_i];
                if (i.dashId == config.dashId) {
                    i.dashName = config.dashName;
                    i.dashNote = config.dashNote;
                    i.dashTemplate = config.dashTemplate;
                    i.userId = config.userId;
                    break;
                }
            }
            localStorage.setItem(this._dashboardKeyName, JSON.stringify(ds));
        }
        else {
            if (config.dashId == null || config.dashId.length < 3)
                config.dashId = uuid.v4();
            dash.push(config);
            localStorage.setItem(this._dashboardKeyName, JSON.stringify(dash));
        }
    };
    /** Load Default Config File */
    DashboardLocalStorage.prototype.loadDefaultConfig = function () {
        var key = localStorage.getItem(this._dashboardKeyName + "DEFAULT");
        var ds = this.loadAllConfigs();
        if (ds.length == 0)
            return null;
        if (key == null) {
            localStorage.setItem(this._dashboardKeyName + "DEFAULT", ds[0].dashId);
            return ds[0];
        }
        else {
            var itm = this.loadConfigFile(key);
            if (itm == null) {
                localStorage.setItem(this._dashboardKeyName + "DEFAULT", ds[0].dashId);
                return ds[0];
            }
            else {
                return itm;
            }
        }
    };
    /**
     *  Load Config By Id
     * @param id CDashboard Id
     */
    DashboardLocalStorage.prototype.loadConfigFile = function (id) {
        for (var _i = 0, _a = this.loadAllConfigs(); _i < _a.length; _i++) {
            var i = _a[_i];
            if (i.dashId == id)
                return i;
        }
        return null;
    };
    /** Load All Config Files */
    DashboardLocalStorage.prototype.loadAllConfigs = function () {
        var data = localStorage.getItem(this._dashboardKeyName);
        var dash = JSON.parse(data);
        return dash;
    };
    return DashboardLocalStorage;
}());
exports.DashboardLocalStorage = DashboardLocalStorage;
//# sourceMappingURL=dashboard-local-storage.js.map