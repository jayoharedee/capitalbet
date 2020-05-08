import { Injectable } from '@angular/core';
import { MDBModalService, MDBModalRef } from 'ng-uikit-pro-standard';
import { ErrorDialogConfig } from '../models/error-dialog-config.model';
import { ErrorDialogComponent } from '../shared/error-dialog/error-dialog.component';
import { Subject, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorDialogService {

  isOpen: boolean = false;
  errorDialog: MDBModalRef;

  okButtonClicked: Subject<void> = new Subject();
  cancelButtonClicked: Subject<void> = new Subject();

  okSub: Subscription;
  cancelSub: Subscription;

  constructor(private modalSrv: MDBModalService) { }

  /**
   *  show Error Dialog
   * @param config Dialog Config
   */
  public showError(config: ErrorDialogConfig) {
    this.errorDialog = this.modalSrv.show(ErrorDialogComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: '',
      containerClass: '',
      animated: true,
      data: {
        errorTitle: config.title,
        errorMessage: config.body,
        okButtonText: config.okButtonText,
        closeButtonText: config.closeButtonText
      }
    });


    this.okSub = this.errorDialog.content.OkButtonClicked.subscribe(() => {
      console.log("Ok 2");
      this.okButtonClicked.next();
    });

    this.cancelSub = this.errorDialog.content.CloseButtonClick.subscribe(() => {
      this.cancelButtonClicked.next();
    });

  }

  /** Hide Error Dialog */
  public hide() {
    if (this.errorDialog != null) {
      this.okSub.unsubscribe();
      this.cancelSub.unsubscribe();
      this.errorDialog.hide();
    }
  }

}
