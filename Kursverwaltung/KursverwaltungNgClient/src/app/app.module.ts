import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { KursverwaltungService } from './kursverwaltung.service';
import {HttpClientModule} from '@angular/common/http';
import { KurseComponent } from './kurse/kurse.component';

@NgModule({
  declarations: [
    AppComponent,
    KurseComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [KursverwaltungService],
  bootstrap: [AppComponent]
})
export class AppModule { }
