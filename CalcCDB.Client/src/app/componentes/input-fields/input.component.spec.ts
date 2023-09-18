import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputFields } from './input.component';

describe('DecimalInputComponent', () => {
  let component: InputFields;
  let fixture: ComponentFixture<InputFields>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InputFields]
    });
    fixture = TestBed.createComponent(InputFields);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
