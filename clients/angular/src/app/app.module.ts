import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CanActivateAutenticacaoGuard } from './utils/canActivates/canActivateAutenticacao.service';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { CanActivateAgenciaGuard } from './utils/canActivates/canActivateAgencia.service';
import { CanActivateClienteGuard } from './utils/canActivates/canActivateCliente.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { CustomFormsModule } from 'ngx-custom-validators';

registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CustomFormsModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt' },
    CanActivateAutenticacaoGuard,
    CanActivateAgenciaGuard,
    CanActivateClienteGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
