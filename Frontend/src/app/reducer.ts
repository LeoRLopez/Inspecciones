import { Action } from "@ngrx/store";
import { InspectionApiService } from "src/app/shared/services/inspection-api.service";

export function inspectionReducer( state: any, action: Action ) {
    var service: InspectionApiService
    switch ( action.type ) {
        case 'OBTENER_LISTA_INSPECCIONES': 
            return state;
        case 'ELIMINAR_INSPECCION':
            return state;
        case 'EDITAR_INSPECCION':
            return state;
        case 'NUEVA_INSPECCION':
            return state;
        default: 
            return state;
    }
    
}