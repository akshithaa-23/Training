import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Arraydisplay } from './arraydisplay';

describe('Arraydisplay', () => {
  let component: Arraydisplay;
  let fixture: ComponentFixture<Arraydisplay>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Arraydisplay]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Arraydisplay);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
