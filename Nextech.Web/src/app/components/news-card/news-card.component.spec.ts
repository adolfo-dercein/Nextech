import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsCardComponent } from './news-card.component';
import { eTypeItem } from 'src/api/model/enum/eType-Item';

describe('NewsCardComponent', () => {
  let component: NewsCardComponent;
  let fixture: ComponentFixture<NewsCardComponent>;

  const ItemDTO = {
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
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ NewsCardComponent ]
    });
    fixture = TestBed.createComponent(NewsCardComponent);
    component = fixture.componentInstance;
    component.item = ItemDTO,
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
