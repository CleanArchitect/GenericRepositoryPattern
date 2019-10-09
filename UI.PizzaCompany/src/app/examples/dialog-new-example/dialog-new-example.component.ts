import { MatDialogRef } from '@angular/material';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ExamplesService } from '../services/examples.service';
import { INewExample } from './models/INewExample';

@Component({
    selector: 'dialog-new-example',
    templateUrl: './dialog-new-example.component.html',
    styleUrls: ['./dialog-new-example.component.scss']
})
export class DialogNewExampleComponent {
    public newExampleForm: FormGroup;

    constructor(
        private exampleService: ExamplesService,
        private dialogRef: MatDialogRef<DialogNewExampleComponent>,
        private fb: FormBuilder
    ) {
        this.newExampleForm = this.fb.group({
            exampleString: [null, Validators.required],
            exampleBoolean: [null, Validators.required],
            exampleInt: [null, Validators.required]
        });
    }

    onCancel(): void {
        this.dialogRef.close();
    }

    onSave(): void {
        const formValues = this.newExampleForm.value;
        
        const newExample: INewExample = {
            exampleString: formValues.exampleString,
            exampleBoolean: formValues.exampleBoolean,
            exampleInt: formValues.exampleInt
        };

        this.exampleService.addExample(newExample).subscribe(() => {
            this.dialogRef.close();
        });
    }
}