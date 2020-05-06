import { Injectable } from '@angular/core';
import { DashboardConfig } from '../models/dashboard-config.model';
import { Subject, Observable } from 'rxjs';
import { DashboardTemplate } from '../models/dashboard-template.model';
import { DashboardItem } from '../models/dashboard-item.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private _avaComponents: DashboardItem[] = [];
  private _configFile: DashboardConfig = null;
  private _currentConfig: Subject<DashboardConfig> = new Subject();

  /** monitor changes to the dashboard configuration */
  public get currentConfig(): Observable<DashboardConfig> {
    return this._currentConfig.asObservable();
  }

  /** Get the available components list */ 
  public get availableComponents(): DashboardItem[] {
    return this._avaComponents;
  }

/** Set the available components list */
  public set availableComponents(comps: DashboardItem[]) {
    this._avaComponents = comps;
  }


  constructor() { }

  /**
   * Load Configuration File 
   * @param config Configuration Data
   */
  public loadConfig(config: DashboardConfig) {
    this._configFile = config;
    this._currentConfig.next(config);
  }

  /**
   * Update the Template
   * @param tempate Template Data
   */
  public updateTemplate(tempate: DashboardTemplate) {
    if (this._configFile == null)
      throw Error("Configuration File Not Set");

    let itms = this._configFile.dashTemplate.zoneItems;
    let title = this._configFile.dashTemplate.title;
    this._configFile.dashTemplate = tempate;
    this._configFile.dashTemplate.zoneItems = itms;
    this._configFile.dashTemplate.title = title;
    this._currentConfig.next(this._configFile);
  }

  /**
   * Update the dashboard item
   * @param item item
   */
  public updateDashboardItem(item: DashboardItem) {

    if (this._configFile == null)
      throw Error("The Configuration file was not set");

    for (let itm of this._configFile.dashTemplate.zoneItems) {
      for (let dash of itm) {
        if (dash.id == item.id) {
          dash.component = item.component;
          dash.config = item.config;
          dash.order = item.order;
          dash.settingsDialog = item.settingsDialog;
          dash.title = item.title;
          this._currentConfig.next(this._configFile);
          break;
        }
      }
    }
  }

  /**
   * Add Item to Dashboard Zone
   * @param item Dashboard Item
   * @param zone Zone
   */
  public addDashboardItem(item: DashboardItem, zone: number) {
    if (this._configFile == null)
      throw Error('Configuration failed not set ...');

    this._configFile.dashTemplate.zoneItems[zone].push(item);
    this._currentConfig.next(this._configFile);

  }

  /**
   *  Remove a dashboard item
   * @param item dashboard item
   */
  public removeDashboardItem(item: DashboardItem) {
    if (this._configFile == null)
      throw Error("The Configuration file was not set");

    for (let i = 0; i < this._configFile.dashTemplate.zoneItems.length;i++) {
      let itm = this._configFile.dashTemplate.zoneItems[i];
      for (let y = 0; y < itm.length; y++) {
        let dash = itm[y];
        if (dash.id == item.id) {
          this._configFile.dashTemplate.zoneItems[i].splice(y, 1);
          this._currentConfig.next(this._configFile);
          break;
        }
      }
    }

  }


}
