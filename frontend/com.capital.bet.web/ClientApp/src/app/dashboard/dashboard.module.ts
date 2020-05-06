import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardContainerComponent } from './dashboard-container/dashboard-container.component';
import { MDBBootstrapModule } from 'ng-uikit-pro-standard';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashItemComponent } from './dash-item/dash-item.component';
import { DashboardService } from './services/dashboard.service';
import { SharedModule } from '../shared.module';
import { DashHostDirective } from './directives/dash-host.directive';
import { TwoColumnTemplateComponent } from './templates/two-column-template/two-column-template.component';
import { DashItemHostDirective } from './directives/dash-item-host.directive';
import { DashTitleEditorComponent } from './dash-title-editor/dash-title-editor.component';
import { RouterModule } from '@angular/router';
import { AddWidgetDialogComponent } from './dialogs/add-widget-dialog/add-widget-dialog.component';
import { OpenDashboardDialogComponent } from './dialogs/open-dashboard-dialog/open-dashboard-dialog.component';
import { DashSettingsDialogComponent } from './dialogs/dash-settings-dialog/dash-settings-dialog.component';
import { SaveDashDialogComponent } from './dialogs/save-dash-dialog/save-dash-dialog.component';




@NgModule({
  declarations: [
    DashboardContainerComponent,
    DashItemComponent,
    DashHostDirective,
    DashItemHostDirective,
    TwoColumnTemplateComponent,
    DashTitleEditorComponent,
    AddWidgetDialogComponent,
    OpenDashboardDialogComponent,
    DashSettingsDialogComponent,
    SaveDashDialogComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    SharedModule,
    MDBBootstrapModule,
  ],
  exports: [
    DashboardContainerComponent,
    DashHostDirective,
    DashItemHostDirective
  ],
  providers: [
    DashboardService
  ],
  entryComponents: [
    DashItemComponent,
    TwoColumnTemplateComponent,
    DashTitleEditorComponent,
    AddWidgetDialogComponent,
    OpenDashboardDialogComponent,
    DashSettingsDialogComponent,
    SaveDashDialogComponent
  ]
})
export class DashboardModule { }
