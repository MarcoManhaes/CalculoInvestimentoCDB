import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CabecalhoComponent } from './componentes/cabecalho/cabecalho.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputFields } from './componentes/input-fields/input.component';
import { DecimalValidatorDirective } from './format/DecimalValidatorFotmat';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CabecalhoComponent,
    InputFields,
    DecimalValidatorDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
