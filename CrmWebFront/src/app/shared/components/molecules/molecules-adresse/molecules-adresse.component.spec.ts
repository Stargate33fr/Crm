/* eslint-disable @typescript-eslint/no-unused-vars */
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedTestingModule } from '@core/testing/shared.testing.module.spec';
import { configureTestSuite } from 'ng-bullet';
import { MoleculesAdresseComponent } from './molecules-adresse.component';

describe('MoleculesAdresseComponent', () => {
  let component: MoleculesAdresseComponent;
  let fixture: ComponentFixture<MoleculesAdresseComponent>;

  configureTestSuite(() => {
    TestBed.configureTestingModule({
      declarations: [MoleculesAdresseComponent],
      imports: [SharedTestingModule, ReactiveFormsModule, FormsModule],
    });
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoleculesAdresseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
