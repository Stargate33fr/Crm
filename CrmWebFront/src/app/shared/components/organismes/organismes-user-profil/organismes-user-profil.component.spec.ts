/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganismesUserProfilComponent } from './organismes-user-profil.component';
import { SharedTestingModule } from '@core/testing/shared.testing.module.spec';
import { RouterTestingModule } from '@angular/router/testing';

describe('OrganismesUserProfilComponent', () => {
  let component: OrganismesUserProfilComponent;
  let fixture: ComponentFixture<OrganismesUserProfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OrganismesUserProfilComponent],
      imports: [SharedTestingModule, RouterTestingModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganismesUserProfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
