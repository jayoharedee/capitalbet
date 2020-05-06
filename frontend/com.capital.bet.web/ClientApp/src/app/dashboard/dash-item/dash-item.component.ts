import { Component, OnInit, Input, EventEmitter, Output, OnDestroy, ViewChild, ComponentFactoryResolver } from '@angular/core';
import { DashboardItem } from '../models/dashboard-item.model';
import { DashItem } from '../models/dash-item';
import { MDBModalRef, MDBModalService } from 'ng-uikit-pro-standard';
import { DashTitleEditorComponent } from '../dash-title-editor/dash-title-editor.component';
import { Subscription } from 'rxjs';
import { DashHostDirective } from '../directives/dash-host.directive';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dash-item',
  templateUrl: './dash-item.component.html',
  styleUrls: ['./dash-item.component.scss']
})
export class DashItemComponent implements OnInit, OnDestroy, DashItem {

  @ViewChild(DashHostDirective, { static: true }) templateHost: DashHostDirective;

  settingsDialog: MDBModalRef;

  @Input() config: DashboardItem;


  @Output() configurationChanged: EventEmitter<DashboardItem> = new EventEmitter();
  @Output() itemRemovedEvent: EventEmitter<DashboardItem> = new EventEmitter();
  @Output() moveItemEvent: EventEmitter<DashboardItem> = new EventEmitter();

  subs: Subscription[] = [];

  constructor(private modalSrv: MDBModalService,
    private dash: DashboardService,
    private componentFactoryResolver: ComponentFactoryResolver) { }


  ngOnInit(): void {
    this.subs = [];
    if (this.config != null && this.config.component != null) {
      const z1Ref = this.templateHost.viewContainerRef;
      z1Ref.clear();
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.config.component);
      const componentRef = z1Ref.createComponent(componentFactory);
      (<DashItem>componentRef.instance).config = this.config.config;
    }
  }

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }


  showSettings() {
    if (this.config.settingsDialog == null) {
      this.settingsDialog = this.modalSrv.show(DashTitleEditorComponent, {
        backdrop: true,
        keyboard: true,
        focus: true,
        show: false,
        ignoreBackdropClick: true,
        class: '',
        containerClass: '',
        animated: true,
        data: {
          config: this.config
        }
      });

      this.subs.push(
        this.settingsDialog.content.dataUpdated.subscribe((itm: DashboardItem) => {
          this.config = itm;
          this.dash.updateDashboardItem(itm);
          this.settingsDialog.hide();
        })
      );

    } else {
      this.settingsDialog = this.modalSrv.show(this.config.settingsDialog, {
        backdrop: true,
        keyboard: true,
        focus: true,
        show: false,
        ignoreBackdropClick: true,
        class: '',
        containerClass: '',
        animated: true,
        data: {
          config: this.config
        }
      });

      this.subs.push(
        this.settingsDialog.content.dataUpdated.subscribe((itm: DashboardItem) => {
          this.config = itm;
          this.dash.updateDashboardItem(itm);
          this.settingsDialog.hide();
        })
      );
    }
  }


  moveItem() {
    this.moveItemEvent.emit(this.config);
  }

  removeItem() {
    this.itemRemovedEvent.emit(this.config);
  }

}
