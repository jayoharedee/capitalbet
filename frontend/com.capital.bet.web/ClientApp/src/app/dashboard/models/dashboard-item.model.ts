import { Type } from "@angular/core";

/** Represents a dashboard item */
export class DashboardItem {
  /** Unique Key for Item */
  public id: string;
  /** Component Type to load */
  public component: Type<any>;
  /** Component Title */
  public title: string;
  /** Component Order */
  public order: number;
  /** Component Settings Dialog Type */
  public settingsDialog: Type<any>;
  /** Config Data */
  public config: any;

}
