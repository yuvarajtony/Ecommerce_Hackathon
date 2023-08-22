import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookOrderDialogboxComponent } from './book-order-dialogbox.component';

describe('BookOrderDialogboxComponent', () => {
  let component: BookOrderDialogboxComponent;
  let fixture: ComponentFixture<BookOrderDialogboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookOrderDialogboxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookOrderDialogboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
