import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[dash-host]',
})
export class DashHostDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}
