import { Component } from '@angular/core';
import { MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { IExample } from './models/IExample';
import { ExamplesService } from './services/examples.service';
import { SignalRService } from '../shared/services/signalr.service';
import { IToast } from "./models/IToast";
import { DialogNewExampleComponent } from './dialog-new-example/dialog-new-example.component';

@Component({
    templateUrl: './examples.component.html',
    styleUrls: ['./examples.component.scss']
})
export class ExamplesComponent {
    displayedColumns = ['id', 'dateCreated', 'dateLastModified', 'exampleBoolean', 'exampleString', 'exampleInt'];
    exampleData: MatTableDataSource<IExample>;

    constructor(
        private examplesService: ExamplesService,
        private signalRService: SignalRService,
        private dialog: MatDialog
    ) {
        this.getExamples();

        this.signalRService.updateExamples.subscribe(() => {
            this.getExamples();
        });
    }

    getExamples(): void {
        this.examplesService.getExamples().subscribe((response) => {
            this.exampleData = new MatTableDataSource(response.examples);
        });
    }

    openDialog(): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.width = "450px";

        this.dialog.open(DialogNewExampleComponent, dialogConfig);
    }

    sendToast(): void {
        const toast = <IToast>{
            message: 'Hello from the other side',
            title: 'Hello'
        };

        this.signalRService.broadcastToast(toast);
    }
}