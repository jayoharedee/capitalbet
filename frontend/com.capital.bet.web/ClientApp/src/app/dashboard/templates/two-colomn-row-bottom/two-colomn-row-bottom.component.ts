import { Component, OnInit, ViewChild, ComponentFactoryResolver, Input, OnDestroy } from '@angular/core';
import { DashItemHostDirective } from '../../directives/dash-item-host.directive';
import { DashboardConfig } from '../../models/dashboard-config.model';
import { Subscription } from 'rxjs';
import { DashboardService } from '../../services/dashboard.service';
import { DashItem } from '../../models/dash-item';
import { DashItemComponent } from '../../dash-item/dash-item.component';
import { DashboardItem } from '../../models/dashboard-item.model';
import { DashboardTemplate } from '../../models/dash-template';

@Component({
  selector: 'app-two-colomn-row-bottom',
  templateUrl: './two-colomn-row-bottom.component.html',
  styleUrls: ['./two-colomn-row-bottom.component.scss']
})
export class TwoColomnRowBottomComponent implements OnInit, OnDestroy, DashboardTemplate {

  @ViewChild('zoneOne', { static: true, read: DashItemHostDirective }) zoneOne: DashItemHostDirective;
  @ViewChild('zoneTwo', { static: true, read: DashItemHostDirective }) zoneTwo: DashItemHostDirective;
  @ViewChild('zoneThree', { static: true, read: DashItemHostDirective }) zoneThree: DashItemHostDirective;


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

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }


  public loadTemplate() {
    var z1 = this.config.dashTemplate.zoneItems[0];
    var z2 = this.config.dashTemplate.zoneItems[1];
    var z3 = this.config.dashTemplate.zoneItems[2];
    const z1Ref = this.zoneOne.viewContainerRef;
    z1Ref.clear();
    const z2Ref = this.zoneTwo.viewContainerRef;
    z2Ref.clear();
    const z3Ref = this.zoneThree.viewContainerRef;
    z3Ref.clear();


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

    for (let itm of z3) {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(DashItemComponent);
      const componentRef = z3Ref.createComponent(componentFactory);
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

}
