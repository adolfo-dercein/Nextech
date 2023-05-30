import { Component, TemplateRef } from '@angular/core';
import { ToastService } from 'src/shared/services/toast-service';

@Component({
  selector: 'app-toast-container',
  templateUrl: './toast-container.component.html',
  host: { class: 'toast-container position-fixed top-0 end-0 p-3', style: 'z-index: 1200' },
  styleUrls: ['./toast-container.component.scss']
})
export class ToastContainerComponent 
{
  constructor(public toastService: ToastService) {}

  isTemplate(toast: any) 
  {
		return toast.textOrTpl instanceof TemplateRef;
	}
}
