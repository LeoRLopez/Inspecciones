import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostrarInspeccionComponent } from './mostrar-inspeccion.component';

describe('MostrarInspeccionComponent', () => {
  let component: MostrarInspeccionComponent;
  let fixture: ComponentFixture<MostrarInspeccionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MostrarInspeccionComponent]
    });
    fixture = TestBed.createComponent(MostrarInspeccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
