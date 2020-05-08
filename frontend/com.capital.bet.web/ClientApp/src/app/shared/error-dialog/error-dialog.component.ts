import { Component, OnInit, Output, Input } from '@angular/core';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.scss']
})
export class ErrorDialogComponent implements OnInit {

  @Input() errorTitle: string = 'Application Error';
  @Input() errorMessage: string = 'An error has occurred in the application.';
  @Input() okButtonText: string = 'Ok';
  @Input() closeButtonText: string = 'Close';

  @Output() OkButtonClicked: Subject<void> = new Subject();
  @Output() CloseButtonClick: Subject<void> = new Subject();


  constructor(public modalRef: MDBModalRef) { }

  ngOnInit(): void {
  }

  okClicked() {
    console.log("Ok 1");
    this.OkButtonClicked.next();
  }

  closeClicked() {
    this.CloseButtonClick.next();
  }

}
