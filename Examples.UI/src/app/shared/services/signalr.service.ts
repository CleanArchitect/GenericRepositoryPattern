import { HubConnection, HubConnectionBuilder, HttpTransportType } from "@aspnet/signalr";
import { Subject } from 'rxjs';
import { IToast } from '../../examples/models/IToast';

export class SignalRService {
    private hubConnection: HubConnection;

    public updateExamples = new Subject<any>();
    public showToast = new Subject<IToast>();

    constructor() {
        this.hubConnection = new HubConnectionBuilder()
            .withUrl('http://localhost:5000/exampleHub', {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets
            })
            .build();

        this.hubConnection
            .start()
            .catch(err => console.log('Error:' + err));

        this.hubConnection.on('SendClientExamplesUpdate', () => {
            console.log('examples update message received!');
            this.updateExamples.next();
        });

        this.hubConnection.on('SendClientToast', (toast: IToast) => {
            console.log('client toast received!');
            this.showToast.next(toast);
        })
    }

    public broadcastToast(toast: IToast) {
        this.hubConnection.invoke('BroadcastToast', toast)
            .catch(err => console.error(err));
    }
}