import { DashboardItem } from "./dashboard-item.model";
import { Type } from "@angular/core";

export class DashboardTemplate {
  public title: string;
  public template: Type<any>;
  public zonesCount: number;
  public zoneItems: Array<DashboardItem[]>;
}
