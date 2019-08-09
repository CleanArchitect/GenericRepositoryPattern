import { Component } from '@angular/core';
import { SignalRService } from './shared/services/signalr.service';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent {
	title = 'examples-ui';

	constructor(
		private signalRService: SignalRService,
		private toastr: ToastrService
	) {
		this.signalRService.showToast.subscribe((message) => {
            this.toastr.info(message.message, message.title);
        });
	}
}
