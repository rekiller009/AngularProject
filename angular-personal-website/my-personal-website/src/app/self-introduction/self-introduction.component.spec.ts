import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelfIntroductionComponent } from './self-introduction.component';

describe('SelfIntroductionComponent', () => {
  let component: SelfIntroductionComponent;
  let fixture: ComponentFixture<SelfIntroductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelfIntroductionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelfIntroductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
