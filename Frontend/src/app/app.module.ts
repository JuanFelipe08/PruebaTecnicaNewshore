import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FormComponent } from './components/form/form.component';
import {FormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { ViewJourneyDetailComponent } from './components/view-journey-detail/view-journey-detail.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { SnackBarComponent } from './components/snack-bar/snack-bar.component';
import {InterceptorServiceAddToken} from './services/interceptors/interceptor-service-add-token.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FormComponent,
    ViewJourneyDetailComponent,
    SnackBarComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      MatSnackBarModule,
      MatDialogModule
    ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorServiceAddToken,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
