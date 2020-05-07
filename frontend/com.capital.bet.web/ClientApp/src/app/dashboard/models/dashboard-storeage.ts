import { DashboardConfig } from "./dashboard-config.model";


/** Provides the interface user for dashboard storage */
export interface DashboardStorage {
  dashboardKeyName: string;
  saveConfigFile(config: DashboardConfig);
  loadDefaultConfig(): DashboardConfig;
  loadConfigFile(id: string): DashboardConfig;
  loadAllConfigs(): DashboardConfig[];
}
