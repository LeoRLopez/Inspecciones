import { HttpClientModule } from'@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { InputTextModule } from 'primeng/inputtext';

import { AppComponent } from './app.component';
import { AltaEdicionInspeccionComponent } from './inspeccion/alta-edicion-inspeccion/alta-edicion-inspeccion.component';
import { StoreModule } from '@ngrx/store';
import { MostrarInspeccionComponent } from './inspeccion/mostrar-inspeccion/mostrar-inspeccion.component';
import { InspeccionComponent } from './inspeccion/inspeccion.component';
import { InspectionApiService } from './shared/services/inspection-api.service';
import { MessagesModule } from 'primeng/messages';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { inspectionReducer } from './reducer';

@NgModule({
  declarations: [
    AppComponent,
    AltaEdicionInspeccionComponent,
    MostrarInspeccionComponent,
    InspeccionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    TableModule,
    ButtonModule,
    InputTextModule,
    MessagesModule,
    ReactiveFormsModule,
    StoreModule.forRoot({inspecciones: inspectionReducer})
  ],
  providers: [InspectionApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
