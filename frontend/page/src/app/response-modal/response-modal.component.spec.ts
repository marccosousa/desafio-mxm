import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponseModalComponent } from './response-modal.component';

describe('ResponseModalComponent', () => {
  let component: ResponseModalComponent;
  let fixture: ComponentFixture<ResponseModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ResponseModalComponent]
    });
    fixture = TestBed.createComponent(ResponseModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
