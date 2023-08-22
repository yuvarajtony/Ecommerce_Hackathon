import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewOrderDetailsDialogComponent } from './view-order-details-dialog.component';

describe('ViewOrderDetailsDialogComponent', () => {
  let component: ViewOrderDetailsDialogComponent;
  let fixture: ComponentFixture<ViewOrderDetailsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewOrderDetailsDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewOrderDetailsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
