import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchResultsComponent } from './search-results.component';
import { ActivatedRoute } from '@angular/router';
import { ItemService } from 'src/api/service/item-service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { LoadingComponent } from 'src/app/components/loading/loading.component';
import { ItemDTO } from 'src/api/model/item-dto';
import { eTypeItem } from 'src/api/model/enum/eType-Item';


describe('SearchResultsComponent', () => {
  let component: SearchResultsComponent;
  let fixture: ComponentFixture<SearchResultsComponent>;

  const news: ItemDTO[] = [{
    id: 123456,  
    deleted: false,     
    type: eTypeItem.Story,  
    by: 'Author',  
    date: 123123123, 
    text: 'Lorem Ipsum', 
    dead : false,    
    parent: 'Parent News', 
    poll: 'string',  
    kids: [123,123,123],
    url: 'string',  
    score: 123,
    title: 'Title',  
    parts: [123,123], 
    descendants: 'string'
  }]


  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchResultsComponent, LoadingComponent],
      providers: [ ItemService, HttpClient, HttpHandler, 
        {
          provide: ActivatedRoute,
          useValue: {
              snapshot: {
                  queryParamMap: {
                      get(): string {
                          return '123';
                      },
                  },
              },
          },
      },
      ]
    });
    fixture = TestBed.createComponent(SearchResultsComponent);
    component = fixture.componentInstance;
    component.news = news;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
