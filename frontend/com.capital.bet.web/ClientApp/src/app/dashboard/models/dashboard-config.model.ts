import { DashboardTemplate } from "./dashboard-template.model";

/** Dashboard Configuration */
export class DashboardConfig {
  /** Dashboard Id */ 
  public dashId: string;
  /** Dashboard Owner */
  public userId: string;
  /** Dashboard Friendly Name */
  public dashName: string;
  /** Dashboard Notes */
  public dashNote: string;
  /** Dashboard Template */
  public dashTemplate: DashboardTemplate;


  
}
