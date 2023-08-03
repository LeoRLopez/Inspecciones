const BASE_URL = 'https://localhost:7160/'
export const environment = {
    URLs:{
        OBTENER_ESTADOS: BASE_URL + 'api/Estados',
        AGREGAR_ESTADO: BASE_URL + 'api/Estados',
        EDITAR_ESTADO: BASE_URL + 'api/Estados',
        ELIMINAR_ESTADO: BASE_URL + 'api/Estados',
        OBTENER_INSPECCIONES: BASE_URL + 'api/Inspection',
        AGREGAR_INSPECCION: BASE_URL + 'api/Inspection',
        EDITAR_INSPECCION:BASE_URL + 'api/Inspection',
        ELIMINAR_INSPECCION: BASE_URL + 'api/Inspection',
        OBTENER_INSPECCION_TYPES: BASE_URL + 'api/InspectionType',
        AGREGAR_INSPECCION_TYPE: BASE_URL + 'api/InspectionType',
        EDITAR_INSPECCION_TYPE: BASE_URL + 'api/InspectionType',
        ELIMINAR_INSPECCION_TYPE: BASE_URL+ 'api/InspectionType'
    }
}