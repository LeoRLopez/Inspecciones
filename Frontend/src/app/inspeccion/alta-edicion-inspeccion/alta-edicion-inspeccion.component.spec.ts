import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AltaEdicionInspeccionComponent } from './alta-edicion-inspeccion.component';

describe('AltaEdicionInspeccionComponent', () => {
  let component: AltaEdicionInspeccionComponent;
  let fixture: ComponentFixture<AltaEdicionInspeccionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AltaEdicionInspeccionComponent]
    });
    fixture = TestBed.createComponent(AltaEdicionInspeccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
