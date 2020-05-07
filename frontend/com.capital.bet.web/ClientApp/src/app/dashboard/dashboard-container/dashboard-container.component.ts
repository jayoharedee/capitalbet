import { Component, OnInit, Input, ViewChild, ComponentFactoryResolver, OnDestroy } from '@angular/core';
import { DashboardConfig } from '../models/dashboard-config.model';
import { DashHostDirective } from '../directives/dash-host.directive';
import { TwoColumnTemplateComponent } from '../templates/two-column-template/two-column-template.component';
import { DashboardTemplate } from '../models/dash-template';
import { DashItemComponent } from '../dash-item/dash-item.component';
import { DashboardItem } from '../models/dashboard-item.model';
import { MDBModalRef, MDBModalService } from 'ng-uikit-pro-standard';
import { AddWidgetDialogComponent } from '../dialogs/add-widget-dialog/add-widget-dialog.component';
import { OpenDashboardDialogComponent } from '../dialogs/open-dashboard-dialog/open-dashboard-dialog.component';
import { SaveDashDialogComponent } from '../dialogs/save-dash-dialog/save-dash-dialog.component';
import { DashSettingsDialogComponent } from '../dialogs/dash-settings-dialog/dash-settings-dialog.component';
import { DashboardService } from '../services/dashboard.service';
import { Subscription } from 'rxjs';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  // ...
} from '@angular/animations';


@Component({
  selector: 'dashboard-container',
  templateUrl: './dashboard-container.component.html',
  styleUrls: ['./dashboard-container.component.scss'],
  animations: [
    trigger('openClose', [
      state('open', style({
        opacity: 1,
      })),
      state('closed', style({
        height: '0px',
        opacity: 0,
      })),
      transition('open => closed', [
        animate('1s')
      ]),
      transition('closed => open', [
        animate('0.5s')
      ]),
    ]),
  ]
})
export class DashboardContainerComponent implements OnInit, OnDestroy {
  @ViewChild(DashHostDirective, { static: true }) templateHost: DashHostDirective;

  // Modal References
  addWidgetDialog: MDBModalRef;
  openDashDialog: MDBModalRef;
  saveDashDialog: MDBModalRef;
  dashSettingsDialog: MDBModalRef;
  dashboardToolsOpen: boolean = true;


  /** Available Dashboard Items */
  @Input() availableItem: DashboardItem[] = [];
  /** Dashboard Configuration Data */
  @Input() config: DashboardConfig = null;


  subs: Subscription[] = [];

  constructor(private componentFactoryResolver: ComponentFactoryResolver,
    private dashSrv: DashboardService,
    private modalSrv: MDBModalService) { }

  ngOnInit(): void {
    if (this.config != null) {
      this.layoutDashboard();
    } else {
      this.config = {
        dashId: '',
        dashName: 'Default Dashboard',
        dashNote: 'Default Dashboard',
        dashTemplate: {
          template: TwoColumnTemplateComponent,
          title: 'My Dashboard',
          zoneItems: [],
          zonesCount:2
        },
        userId:''
      };
      this.layoutDashboard();
      this.showError('No Configuration was supplied ...');
    }

    this.dashSrv.availableComponents = this.availableItem;
    this.dashSrv.loadConfig(this.config);
    this.subs.push(
      this.dashSrv.currentConfig.subscribe((cfg: DashboardConfig) => {
        this.config = cfg;
        this.layoutDashboard();
      })
    );
  }

  ngOnDestroy() {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }


  toggelTools() {
    this.dashboardToolsOpen = !this.dashboardToolsOpen;
  }

  /** layout the dashboard */
  private layoutDashboard() {
    this.templateHost.viewContainerRef.clear();
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.config.dashTemplate.template);
    const templateRef = this.templateHost.viewContainerRef.createComponent(componentFactory);
    (<DashboardTemplate>templateRef.instance).config = this.config;
  }

  /**
   *  Show Error Messages
   * @param msg Message
   */
  private showError(msg: string) {
    console.error("Dashboard Error => ", msg);
  }

  /** Open Add Widgets Dialog */
  addWidgets() {
    this.addWidgetDialog = this.modalSrv.show(AddWidgetDialogComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true,
      data: {
        availableItems: this.availableItem,
        zoneCount: this.config.dashTemplate.zonesCount
      }
    });
    // handle new added items
    this.subs.push(
      this.addWidgetDialog.content.itemAddedRequest.subscribe((item: DashboardItem) => {
        this.addWidgetDialog.hide();
        if (this.config.dashTemplate.zonesCount > item.order) { // make sure it can fit in requested zone
          this.config.dashTemplate.zoneItems[item.order].push({
            id: item.id + this.config.dashTemplate.zoneItems[item.order].length,
            component: item.component,
            config: item.config,
            order: this.config.dashTemplate.zoneItems[item.order].length,
            settingsDialog: item.settingsDialog,
            title: item.title
          });
          this.dashSrv.loadConfig(this.config);
        } else { // every template has at least one zone 
          this.config.dashTemplate.zoneItems[0].push({
            id: item.id + this.config.dashTemplate.zoneItems[item.order].length,
            component: item.component,
            config: item.config,
            order: this.config.dashTemplate.zoneItems[item.order].length,
            settingsDialog: item.settingsDialog,
            title: item.title
          });
          this.dashSrv.loadConfig(this.config);
        }
      })
    );
  }

  /** Open a saved dashboard dialog */
  openDashboards() {
    this.openDashDialog = this.modalSrv.show(OpenDashboardDialogComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true
    });
  }

  /** open dashboard setting dialog */
  dashboardSettings() {
    this.dashSettingsDialog = this.modalSrv.show(DashSettingsDialogComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true,
      data: {
        config:this.config
      }
    });

    this.subs.push(
      this.dashSettingsDialog.content.configUpdated.subscribe((cfg: DashboardConfig) => {
        console.log(cfg);
        this.dashSettingsDialog.hide();
        this.config = cfg;
        this.dashSrv.loadConfig(cfg);
      })
    );
  }

  /** open save dashboard dialog */
  saveCurrentDashboard() {
    this.saveDashDialog = this.modalSrv.show(SaveDashDialogComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true
    });
  }


}
