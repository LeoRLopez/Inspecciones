import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  constructor(private httpClient: HttpClient) { 
  }

  //inspections
  getInspectionList(): Observable<any[]> {
    return this.httpClient.get<any>(environment.URLs.OBTENER_INSPECCIONES)
  }

  postInspections(data: any) {
    return this.httpClient.post(environment.URLs.AGREGAR_INSPECCION, data)
  }

  editInspection(id: number, data: any) {
    return this.httpClient.put(environment.URLs.EDITAR_INSPECCION + `/${id}`, data)
  }

  deleteInspeccion(id: number) {
    return this.httpClient.delete(environment.URLs.ELIMINAR_INSPECCION + `/${id}`)
  }

  //inspectionTypes
  getInspectionTypeList(): Observable<any[]> {
    return this.httpClient.get<any>(environment.URLs.OBTENER_INSPECCION_TYPES)
  }

  postInspectionType(data: any) {
    return this.httpClient.post(environment.URLs.AGREGAR_INSPECCION_TYPE, data)
  }

  editInspectionType(id: number, data: any) {
    return this.httpClient.put(environment.URLs.EDITAR_INSPECCION_TYPE + `/${id}`, data)
  }

  deleteInspeccionType(id: number) {
    return this.httpClient.delete(environment.URLs.ELIMINAR_INSPECCION_TYPE + `/${id}`)
  }

  //estados
  getEstadosList(): Observable<any[]> {
    return this.httpClient.get<any>(environment.URLs.OBTENER_ESTADOS)
  }

  postEstado(data: any) {
    return this.httpClient.post(environment.URLs.AGREGAR_ESTADO, data)
  }

  editEstado(id: number, data: any) {
    return this.httpClient.put(environment.URLs.EDITAR_ESTADO + `/${id}`, data)
  }

  deleteEstado(id: number) {
    return this.httpClient.delete(environment.URLs.ELIMINAR_ESTADO + `/${id}`)
  }
}
