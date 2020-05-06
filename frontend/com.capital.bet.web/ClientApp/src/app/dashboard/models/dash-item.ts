import { DashboardItem } from "./dashboard-item.model";
import { EventEmitter } from "@angular/core";


export interface DashItem {
  config: DashboardItem;
  configurationChanged: EventEmitter<DashboardItem>;
  itemRemovedEvent: EventEmitter<DashboardItem>;
  moveItemEvent: EventEmitter<DashboardItem>;
}
