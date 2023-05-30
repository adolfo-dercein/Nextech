import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopNewsComponent } from './top-news.component';
import { ItemService } from 'src/api/service/item-service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { LoadingComponent } from 'src/app/components/loading/loading.component';

describe('TopNewsComponent', () => {
  let component: TopNewsComponent;
  let fixture: ComponentFixture<TopNewsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TopNewsComponent, LoadingComponent ],
      providers: [ ItemService, HttpClient, HttpHandler ]
    });
    fixture = TestBed.createComponent(TopNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  
});
