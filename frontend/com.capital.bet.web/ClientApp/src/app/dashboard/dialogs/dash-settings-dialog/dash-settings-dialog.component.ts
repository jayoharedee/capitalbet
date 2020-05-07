import { Component, OnInit, Input } from '@angular/core';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { DashboardConfig } from '../../models/dashboard-config.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Subject } from 'rxjs';
import { TwoColomnRowBottomComponent } from '../../templates/two-colomn-row-bottom/two-colomn-row-bottom.component';
import { DashboardTemplate } from '../../models/dashboard-template.model';
import { TwoColumnTemplateComponent } from '../../templates/two-column-template/two-column-template.component';
import { DashboardItem } from '../../models/dashboard-item.model';

@Component({
  selector: 'app-dash-settings-dialog',
  templateUrl: './dash-settings-dialog.component.html',
  styleUrls: ['./dash-settings-dialog.component.scss']
})
export class DashSettingsDialogComponent implements OnInit {

  @Input() config: DashboardConfig;

  configUpdated: Subject<DashboardConfig> = new Subject();


  settingsGroup: FormGroup;

  get DashName() { return this.settingsGroup.get('title'); }
  get DashNotes() { return this.settingsGroup.get('desc'); }
  get DashTemplate() { return this.settingsGroup.get('template'); }


  constructor(public modalRef: MDBModalRef,
    private fb: FormBuilder) {
    this.settingsGroup = this.fb.group({
      title: [''],
      desc: [''],
      template:['']
    });
  }

  ngOnInit(): void {
    if (this.config != null) {
      this.DashName.setValue(this.config.dashName);
      this.DashNotes.setValue(this.config.dashNote);
      this.DashTemplate.setValue(this.config.dashTemplate.title);
    }

  }

  onUpdateSettingsAction() {

    this.config.dashName = this.DashName.value;
    this.config.dashNote = this.DashNotes.value;

    // On do if changed
    if (this.config.dashTemplate.title != this.DashTemplate.value) {
      // Which template to use
      switch (this.DashTemplate.value) {
        case 'TwoColomnRowBottomComponent':
          this.config.dashTemplate = this.switchZones({
            template: TwoColomnRowBottomComponent,
            title: 'TwoColomnRowBottomComponent',
            zoneItems: [],
            zonesCount: 3
          });
          break;
        case 'TwoColumnTemplateComponent':
          this.config.dashTemplate = this.switchZones({
            template: TwoColumnTemplateComponent,
            title: 'TwoColumnTemplateComponent',
            zoneItems: [],
            zonesCount: 2
          });
          break;
      }
    }
    this.configUpdated.next(this.config);
  }

  /**
   *  Swap Zones 
   * @param newConfig new Config
   */
  switchZones(newConfig: DashboardTemplate): DashboardTemplate{
    for (let i = 0; i < this.config.dashTemplate.zonesCount; i++) {
      let itms = this.config.dashTemplate.zoneItems[i];
      if (newConfig.zonesCount > i)
        newConfig.zoneItems.push(itms);
      else {
        for (let it of itms) {
          newConfig.zoneItems[0].push(it);
        }
      }
    }

    if (this.config.dashTemplate.zonesCount < newConfig.zonesCount) {
      for (let i = 0; i < newConfig.zonesCount; i++) {
        if (newConfig.zoneItems[i] == null)
          newConfig.zoneItems.push([]);
      }
    }

    return newConfig;
  }


}
