import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[dash-item-host]',
})
export class DashItemHostDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}
