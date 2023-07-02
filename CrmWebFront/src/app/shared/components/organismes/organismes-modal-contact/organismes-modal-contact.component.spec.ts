/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, async } from '@angular/core/testing';

import { OrganismesModalContactComponent } from './organismes-modal-contact.component';

describe('OrganismesModalContactComponent', () => {
  let component: OrganismesModalContactComponent;
  let fixture: ComponentFixture<OrganismesModalContactComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OrganismesModalContactComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganismesModalContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
