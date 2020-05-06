import { Component, OnInit, ViewChild, Input, ComponentFactoryResolver, TemplateRef, OnDestroy } from '@angular/core';
import { DashItemHostDirective } from '../../directives/dash-item-host.directive';
import { DashboardConfig } from '../../models/dashboard-config.model';
import { DashboardTemplate } from '../../models/dash-template';
import { DashItemComponent } from '../../dash-item/dash-item.component';
import { DashItem } from '../../models/dash-item';
import { Subscription } from 'rxjs';
import { DashboardItem } from '../../models/dashboard-item.model';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-two-column-template',
  templateUrl: './two-column-template.component.html',
  styleUrls: ['./two-column-template.component.scss']
})
export class TwoColumnTemplateComponent implements OnInit, OnDestroy, DashboardTemplate {

  @ViewChild('zoneOne', { static: true, read: DashItemHostDirective }) zoneOne: DashItemHostDirective;
  @ViewChild('zoneTwo', { static: true, read: DashItemHostDirective }) zoneTwo: DashItemHostDirective;

  @Input() config: DashboardConfig;

  subs: Subscription[] = [];

  constructor(private componentFactoryResolver: ComponentFactoryResolver,
    private dashSrv: DashboardService) { }


  ngOnInit(): void {
    this.subs.push(
      this.dashSrv.currentConfig.subscribe((cfg: DashboardConfig) => {
        console.log(cfg);
        this.config = cfg;
        this.loadTemplate();
      })
    );
    this.loadTemplate();
  }


  public loadTemplate() {
    var z1 = this.config.dashTemplate.zoneItems[0];
    var z2 = this.config.dashTemplate.zoneItems[1];
    const z1Ref = this.zoneOne.viewContainerRef;
    z1Ref.clear();
    const z2Ref = this.zoneTwo.viewContainerRef;
    z2Ref.clear();

    for (let itm of z1) {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(DashItemComponent);
      const componentRef = z1Ref.createComponent(componentFactory);
      (<DashItem>componentRef.instance).config = itm;
      this.subs.push(
        (<DashItem>componentRef.instance).configurationChanged.subscribe((itm: DashboardItem) => {
          // Dashboard Item Updated
          this.dashSrv.updateDashboardItem(itm);
        })
      );
      this.subs.push(
        (<DashItem>componentRef.instance).itemRemovedEvent.subscribe((itm: DashboardItem) => {
          console.log('Remove Requested =>', itm);
          // request to remove dashboard Item
          this.dashSrv.removeDashboardItem(itm);
        })
      );
      this.subs.push(
        (<DashItem>componentRef.instance).moveItemEvent.subscribe((itm: DashboardItem) => {
          // request to move dashboard Item
        })
      );
    }

    for (let itm of z2) {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(DashItemComponent);
      const componentRef = z2Ref.createComponent(componentFactory);
      (<DashItem>componentRef.instance).config = itm;
      this.subs.push(
        (<DashItem>componentRef.instance).configurationChanged.subscribe((itm: DashboardItem) => {
          // Dashboard Item Updated
          this.dashSrv.updateDashboardItem(itm);
        })
      );
      this.subs.push(
        (<DashItem>componentRef.instance).itemRemovedEvent.subscribe((itm: DashboardItem) => {
          console.log('Remove Requested =>', itm);
          // request to remove dashboard Item
          this.dashSrv.removeDashboardItem(itm);
        })
      );
      this.subs.push(
        (<DashItem>componentRef.instance).moveItemEvent.subscribe((itm: DashboardItem) => {
          // request to move dashboard Item
        })
      );
    }
  }


  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

}
