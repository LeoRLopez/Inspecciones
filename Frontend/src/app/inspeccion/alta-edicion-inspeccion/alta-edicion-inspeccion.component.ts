import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/shared/services/inspection-api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

interface AppState {inspecciones: any}

@Component({
  selector: 'app-alta-edicion-inspeccion',
  templateUrl: './alta-edicion-inspeccion.component.html',
  styleUrls: ['./alta-edicion-inspeccion.component.css']
})
export class AltaEdicionInspeccionComponent implements OnInit{
  inspectionList$!: Observable<any[]>;
  estadosList$!: Observable<any[]>;
  inspectionTypeList$!: Observable<any[]>;
  inspectionTypeList: any = [];
  inspectionTypesMap: Map<number, string> = new Map();
  
  inspectionFormGroup = new FormGroup({
    tipoInspeccion: new FormControl('', [Validators.required]),
    estado: new FormControl('', [Validators.required]),
    descripcion: new FormControl('',[Validators.required])
  })

  constructor(private service: InspectionApiService, private store: Store<AppState>){
    this.store.subscribe(state => {console.log(state)});
  }

  @Input() inspection:any;
  id: number = 0 ;
  statusId: string = "";
  description: string = "";
  inspectionTypeId!: number;


  ngOnInit(): void {
    this.id = this.inspection.id;
    this.statusId = this.inspection.statusId;
    this.description = this.inspection.description;
    this.inspectionTypeId = this.inspection.inspectionTypeId;

    this.estadosList$ = this.service.getEstadosList();
    this.inspectionList$ = this.service.getInspectionList();
    this.inspectionTypeList$ = this.service.getInspectionTypeList();
    this.actualizarInspectionTypesMap();
  }

  addInspection(){
    var inspection = {
      statusId: this.statusId,
      description: this.description,
      inspectionTypeId: this.inspectionTypeId
    }

    this.service.postInspections(inspection).subscribe(res => {
      var closeModalbtn = document.getElementById('add-edit-modal-close');
      if(closeModalbtn){
        closeModalbtn.click();
      }

      var showSuccess = document.getElementById('add-success-alert');
      if(showSuccess) {
        showSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showSuccess) {
          showSuccess.style.display = "none";
        }
      }, 4000);
    });
  }

  editInspection(){
    var inspection = {
      id: this.id,
      statusId: this.statusId,
      description: this.description,
      inspectionTypeId: this.inspectionTypeId
    }
    var id: number = this.id;

    this.service.editInspection(id, inspection).subscribe(res => {
      var closeModalbtn = document.getElementById('add-edit-modal-close');
      if(closeModalbtn){
        closeModalbtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showUpdateSuccess) {
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    });
  }

  actualizarInspectionTypesMap() {
    this.service.getInspectionTypeList().subscribe(data => {
      this.inspectionTypeList = data;
      for(let i = 0; i < data.length; i++){
        this.inspectionTypesMap.set(this.inspectionTypeList[i].id, this.inspectionTypeList[i].inspectionName);
      }
    });
  }
}
