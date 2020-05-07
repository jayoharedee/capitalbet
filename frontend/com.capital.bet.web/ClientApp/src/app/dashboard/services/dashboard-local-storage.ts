import { DashboardStorage } from "../models/dashboard-storeage";
import { DashboardConfig } from "../models/dashboard-config.model";
import * as uuid from 'uuid';

/** Dashboard Local Storage Helper */
export class DashboardLocalStorage implements DashboardStorage {

  private _dashboardKeyName: string = '';

  /** Get Storage Key Name */ 
  public get dashboardKeyName(): string { return this._dashboardKeyName; }
  /** Set Storage Key Name */ 
  public set dashboardKeyName(value: string) { this._dashboardKeyName = value; }


  constructor(key: string) {
    this._dashboardKeyName = key;
    let itm = localStorage.getItem(this._dashboardKeyName);
    if (itm == null) {
      let dash: DashboardConfig[] = [];
      localStorage.setItem(this._dashboardKeyName, JSON.stringify(dash));
    }
  }

  /**
   *  Save or Update Config File
   * @param config Config File
   */
  saveConfigFile(config: DashboardConfig) {
    let data = localStorage.getItem(this._dashboardKeyName);
    let dash: DashboardConfig[] = JSON.parse(data);
    if (this.loadConfigFile(config.dashId) != null && config.dashId != null) { // update item
      let ds: DashboardConfig[] = this.loadAllConfigs();
      for (let i of ds) {
        if (i.dashId == config.dashId) {
          i.dashName = config.dashName;
          i.dashNote = config.dashNote;
          i.dashTemplate = config.dashTemplate;
          i.userId = config.userId;
          break;
        }
      }
      localStorage.setItem(this._dashboardKeyName, JSON.stringify(ds));
    } else {
      if (config.dashId == null || config.dashId.length < 3)
        config.dashId = uuid.v4();

      dash.push(config);
      localStorage.setItem(this._dashboardKeyName, JSON.stringify(dash));
    }
  }


  /** Load Default Config File */
  loadDefaultConfig(): DashboardConfig {
    let key = localStorage.getItem(this._dashboardKeyName + "DEFAULT");
    let ds: DashboardConfig[] = this.loadAllConfigs();
    if (ds.length == 0)
      return null;
    if (key == null) {
      localStorage.setItem(this._dashboardKeyName + "DEFAULT", ds[0].dashId);
      return ds[0];
    } else {
      let itm = this.loadConfigFile(key);
      if (itm == null) {
        localStorage.setItem(this._dashboardKeyName + "DEFAULT", ds[0].dashId);
        return ds[0];
      } else {
        return itm;
      }
    }
  }

  /**
   *  Load Config By Id
   * @param id CDashboard Id
   */
  loadConfigFile(id: string): DashboardConfig {
    for (let i of this.loadAllConfigs()) {
      if (i.dashId == id)
        return i;
    }
    return null;
  }

  /** Load All Config Files */
  loadAllConfigs(): DashboardConfig[] {
    let data = localStorage.getItem(this._dashboardKeyName);
    let dash: DashboardConfig[] = JSON.parse(data);
    return dash;
  }

}
