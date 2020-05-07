import { Component, OnInit, Input } from '@angular/core';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { DashboardItem } from '../../models/dashboard-item.model';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-add-widget-dialog',
  templateUrl: './add-widget-dialog.component.html',
  styleUrls: ['./add-widget-dialog.component.scss']
})
export class AddWidgetDialogComponent implements OnInit {
  @Input() availableItems: DashboardItem[] = [];
  @Input() zoneCount: number = 3;


  itemAddedRequest: Subject<DashboardItem> = new Subject();

  addWidgetGroup: FormGroup;


  get Title() { return this.addWidgetGroup.get('title'); }
  get Widget() { return this.addWidgetGroup.get('widgetId'); }
  get Zone() { return this.addWidgetGroup.get('zoneSelected'); }


  constructor(public modalRef: MDBModalRef,
    private fb: FormBuilder)
  {
    this.addWidgetGroup = this.fb.group({
      title: ['', [Validators.required]],
      widgetId: ['', [Validators.required]],
      zoneSelected: ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  get ArrayCount() {
    return Array(this.zoneCount).fill(() => map((x, i) => i));
  }

  /** On Item Added Click  */
  onAddComponentAction() {
    if (this.addWidgetGroup.valid) {
      var db = this.availableItems.filter((x) => {
        return (x.id == this.Widget.value) ? true : false;
      });
      if (db.length > 0) {
        let ret: DashboardItem = {
          component: db[0].component,
          settingsDialog: db[0].settingsDialog,
          config: db[0].config,
          id: db[0].id,
          order: (+this.Zone.value),
          title: this.Title.value
        };
        this.itemAddedRequest.next(ret);
      } else {
        // TODO : Handle Component Not Found
      }
    } else {
      //TODO : Handle Form Errors
    }
  }

}
