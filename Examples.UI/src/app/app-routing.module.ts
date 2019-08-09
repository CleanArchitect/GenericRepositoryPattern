import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamplesComponent } from './examples/examples.component';
import { AppComponent } from './app.component';
import { MatTableModule, MatIconModule, MatButtonModule, MatDialogModule, MatCheckboxModule, MatInputModule } from '@angular/material';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const routes: Routes = [
  {
    path: 'examples', component: ExamplesComponent
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatCheckboxModule,
    BrowserAnimationsModule,
    CommonModule
  ],
  exports: [
    RouterModule
  ],
  declarations: [
    ExamplesComponent
  ],
  bootstrap: [AppComponent]
})
export class AppRoutingModule { }
