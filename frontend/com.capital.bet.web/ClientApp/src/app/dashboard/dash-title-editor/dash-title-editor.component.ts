import { Component, OnInit } from '@angular/core';
import { DashboardItem } from '../models/dashboard-item.model';
import { Subject } from 'rxjs';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dash-title-editor',
  templateUrl: './dash-title-editor.component.html',
  styleUrls: ['./dash-title-editor.component.scss']
})
export class DashTitleEditorComponent implements OnInit {

  config: DashboardItem;
  dataUpdated: Subject<DashboardItem> = new Subject();

  updateGroup: FormGroup;

  get Title() { return this.updateGroup.get('title'); }

  constructor(public modalRef: MDBModalRef,
    private fb: FormBuilder)
  {
    this.updateGroup = this.fb.group({
      title: ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
    this.Title.setValue(this.config.title);
  }

  updateTitle() {
    if (this.updateGroup.valid) {
      this.config.title = this.Title.value;
      this.dataUpdated.next(this.config);
    }
  }

}
