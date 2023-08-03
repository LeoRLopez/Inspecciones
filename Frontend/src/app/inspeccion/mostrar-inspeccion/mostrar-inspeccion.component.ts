import { Component, OnInit } from '@angular/core';
import { Message } from 'primeng/api';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/shared/services/inspection-api.service';

@Component({
  selector: 'app-mostrar-inspeccion',
  templateUrl: './mostrar-inspeccion.component.html',
  styleUrls: ['./mostrar-inspeccion.component.css']
})
export class MostrarInspeccionComponent implements OnInit{
  messages: Message[] = [];
  messages1: Message[] = [];
  messages2: Message[] = [];
  inspectionList$!: Observable<any[]>;
  inspectionTypeList$!: Observable<any[]>;
  estadosList$!: Observable<any[]>;
  inspectionTypeList: any = [];
  estadosList: any = [];
  inspectionTypesMap: Map<number, string> = new Map();
  estadosMap: Map<number, string> = new Map();

  modalTitle: string = '';
  activarAltaEdicionInspectionComponent: boolean = false;
  inspection: any;

  constructor(private service: InspectionApiService){}


  ngOnInit(): void {
    this.messages = [{ severity: 'success', summary: 'Success ', detail: 'Inspeccion agregada correctamente!' }];
    this.messages1 = [{ severity: 'info', summary: 'Info ', detail: 'Inspeccion editada correctamente!' }];
    this.messages2 = [{severity: 'success', summary: 'Deleted ', detail: 'Inspeccion Eliminada correctamente!' }];

    this.inspectionList$ = this.service.getInspectionList();
    this.inspectionTypeList$ = this.service.getInspectionTypeList();
    this.estadosList$ = this.service.getEstadosList();
    this.actualizarInspectionTypesMap();
    this.actualizarEstadosMap();
  }

  actualizarInspectionTypesMap() {
    this.service.getInspectionTypeList().subscribe(data => {
      this.inspectionTypeList = data;
      for(let i = 0; i < data.length; i++){
        this.inspectionTypesMap.set(this.inspectionTypeList[i].id, this.inspectionTypeList[i].inspectionName);
      }
    });
  }

  actualizarEstadosMap() {
    this.service.getEstadosList().subscribe(e => {
      this.estadosList = e;
      for(let i = 0; i < e.length; i++) {
        this.estadosMap.set(this.estadosList[i].id, this.estadosList[i].estadoNombre);
        console.log(this.estadosMap)
      }
    });
  }

  modalAdd(){
    this.inspection = {
      id: 0,
      statusId: null,
      description:null,
      inspectionTypeId:null
    }

    this.modalTitle = "Agregar Inspeccion";
    this.activarAltaEdicionInspectionComponent = true;
  }

  modalEdit(item:any){
    this.inspection = item;
    this.modalTitle = "Editar Inspeccion";
    this.activarAltaEdicionInspectionComponent = true;

  }

  modalDelete(item:any){
    if(confirm(`Esta seguro de querer eliminar la inspeccion?`)){
      this.service.deleteInspeccion(item.id).subscribe(res => {
        var closeModalbtn = document.getElementById('add-edit-modal-close');
      if(closeModalbtn){
        closeModalbtn.click();
      }

      var showDeleteSuccess = document.getElementById('delete-success-alert');
      if(showDeleteSuccess) {
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showDeleteSuccess) {
          showDeleteSuccess.style.display = "none";
        }
      }, 4000);
      this.inspectionList$ = this.service.getInspectionList();
      })
    }
  }

  modalClose(){
    this.activarAltaEdicionInspectionComponent = false;
    this.inspectionList$ = this.service.getInspectionList();
  }
}
